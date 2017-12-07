using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    public class ButterworthFilter:IFilter
    {
        private DAQSettingsDTO _daqDTO;
        private double _CutOff;

        public ButterworthFilter(DAQSettingsDTO daqDTO)
        {
            _daqDTO = daqDTO;
            _CutOff = 20;
        }


        public double[] Butterworth(double[] indata, double Samplingrate, double CutOff)
        {
            if (indata == null) return null;
            if (CutOff == 0) return indata;

            long dF2 = indata.Length - 1;        // The data range is set with dF2
            double[] Dat2 = new double[dF2 + 4]; // Array with 4 extra points front and back
            double[] data = indata; // Ptr., changes passed data

            // Copy indata to Dat2
            for (long r = 0; r < dF2; r++)
            {
                Dat2[2 + r] = indata[r];
            }
            Dat2[1] = Dat2[0] = indata[0];
            Dat2[dF2 + 3] = Dat2[dF2 + 2] = indata[dF2];

            // Udregningen er baseret på, at dette er et 4. ordens lavpasfilter
            // Udregning af Butterworth filter koefficenter. Koefficenterne er a, b, c, d, e
            const double pi = 3.14159265358979;
            double wc = Math.Tan(CutOff * pi / Samplingrate);
            double k1 = 1.414213562 * wc; // Sqrt(2) * wc
            double k2 = wc * wc;
            double a = k2 / (1 + k1 + k2);
            double b = 2 * a;
            double c = a;
            double k3 = b / k2;
            double d = -2 * a + k3;
            double e = 1 - (2 * a) - k3;

            // RECURSIVE TRIGGERS - ENABLE filter is performed (first, last points constant)
            // Filterer forrige punkter. Start ved index 2 og filtrerer nuværende punkter og de 2 forrige
            double[] DatYt = new double[dF2 + 4];
            DatYt[1] = DatYt[0] = indata[0];
            for (long s = 2; s < dF2 + 2; s++)
            {
                DatYt[s] = a * Dat2[s] + b * Dat2[s - 1] + c * Dat2[s - 2]
                           + d * DatYt[s - 1] + e * DatYt[s - 2];
            }
            DatYt[dF2 + 3] = DatYt[dF2 + 2] = DatYt[dF2 + 1];

            // FORWARD filter
            // Benytter tidligere filtrerede punkter fra DatYt. Filtrerer punkterne foran ved hjælp af filterkoefficenterne
            double[] DatZt = new double[dF2 + 2];
            DatZt[dF2] = DatYt[dF2 + 2];
            DatZt[dF2 + 1] = DatYt[dF2 + 3];
            for (long t = -dF2 + 1; t <= 0; t++)
            {
                DatZt[-t] = a * DatYt[-t + 2] + b * DatYt[-t + 3] + c * DatYt[-t + 4]
                            + d * DatZt[-t + 1] + e * DatZt[-t + 2];
            }

            // Calculated points copied for return
            // Skriver de filtrerede punkter til data arrayet der bliver returneret.
            for (long p = 0; p < dF2; p++)
            {
                data[p] = DatZt[p];
            }

            return data;
        }

        public List<double> FilterData(double[] data)
        {
            return Butterworth(data, _daqDTO.SampleRate, _CutOff).ToList();
        }
    }
}
