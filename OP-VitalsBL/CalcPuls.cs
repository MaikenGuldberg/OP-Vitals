using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MathNet.Filtering;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Threading;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcPuls : CalcPulsSubject, IDeQueueObserver
    {
        private List<double> analyselist;
        private double _puls;
        private DAQSettingsDTO _daqDTO;
        private readonly AutoResetEvent _dataReadyEvent;
        private bool _stopThread;

        private DeQueue _deQueue;

        public CalcPuls(DAQSettingsDTO daqDTO, AutoResetEvent dataReadyEvent, DeQueue deQueue)
        {
            _daqDTO = daqDTO;
            analyselist = new List<double>();
            _puls = 0;
            _dataReadyEvent = dataReadyEvent;
            _deQueue = deQueue;
            _deQueue.Attach(this);
        }

        private void CalculatePuls(List<double> dataList)
        {
            foreach (var value in dataList)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 6 * _daqDTO.SampleRate) //Tjekker om listen er på 6000 punkter (altså om der er målinger for 6 sekunder)
            {
                Complex[] ComplexValuesWithoutWindow = new Complex[6 * _daqDTO.SampleRate]; //Opretter et array med 6000 pladser af typen complex. Hvilket vil sige at værdierne i arrayet er komplexe dvs. består af en realdel og en imaginer del.
                for (int i = 0; i < analyselist.Count; i++)//Læser værdierne fra analyselisten til det komplexe array. Imaginerværdien er lig nul idet vi har realle tal i vores analyseliste
                {
                    ComplexValuesWithoutWindow[i] = new Complex(analyselist[i], 0);
                }
                Complex[] complexValuesWithWindow = new Complex[6 * _daqDTO.SampleRate];
                double[] hannDoubles = MathNet.Numerics.Window.Hamming(complexValuesWithWindow.Length); //Laver et hamming vindue som benyttes til at undgå lekage når vi fouretransformerer

                for (int i = 0; i < ComplexValuesWithoutWindow.Length; i++) //Ganger hamming vinduet på vores rå signal 
                {
                    complexValuesWithWindow[i] = hannDoubles[i] * ComplexValuesWithoutWindow[i];
                }

                Fourier.Forward(complexValuesWithWindow, FourierOptions.NoScaling); //fourietransformerer vores signal der er påført et vindue

              
                double[] magnitudes = new double[complexValuesWithWindow.Length / 2]; //Laver et array der skal indeholde vores magnitudes. Vi kigger kun på det halve frekvensspektrum idet signalet spejler sig omkring den halve samplingsfrekvens

                for (int i = 2; i < complexValuesWithWindow.Length / 2; i++) //Finder magnitudes af de forskellige frekvens bins og tilføjer arrayet
                {
                    magnitudes[i] = complexValuesWithWindow[i].Magnitude;
                }

                //Finder idexet for den største magnitude og returnerer denne værdi
                int MaxIndex = 0;
                for (int i = 0; i < magnitudes.Length; i++)
                {
                    if (magnitudes[i] == magnitudes.Max())
                        MaxIndex = i;
                }

                //Finder frekvens for den største magnityde 
                double frequenceForMaxMagnitude = MaxIndex * 1000.0 / complexValuesWithWindow.Length;



                //Finder blodtrykket
                double bpm = 60 * frequenceForMaxMagnitude;

                _puls = bpm;
                Notify();
                analyselist.Clear(); //Sletter listens punkter
            }
        }

        //private void CalculatePuls(List<double> dataList, DAQSettingsDTO Daq)
        //{
        //    for (int i = 0; i < dataList.Count; i++)
        //    {
        //        if (analyselist.Count < 8 * Daq.SampleRate)
        //        {
        //            analyselist.Add(i);
        //        }
        //        if (analyselist.Count == 8 * Daq.SampleRate)
        //        {
        //            Complex[] calcArray = MakeComplexArray(analyselist.ToArray());
        //            Fourier.Forward(calcArray, FourierOptions.NoScaling);
        //            for (int j = 1; j < calcArray.Length / 2; j++)
        //            {
        //                double mag = (2.0 / analyselist.Count) *
        //                             (Math.Abs(Math.Sqrt(Math.Pow(calcArray[j].Real, 2) +
        //                                                 Math.Pow(calcArray[j].Imaginary, 2))));
        //                //double mag = calcArray[j].Magnitude;
        //                if (mag > _lastMagnitude)
        //                {
        //                    _lastMagnitude = mag;
        //                    _puls = j * (Daq.SampleRate * 60.0 / analyselist.Count);
        //                }
        //            }
        //            _lastMagnitude = 0;
        //            analyselist.RemoveAt(0);
        //        }
        //    }
        //}

        

        public void RunCalcPuls()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculatePuls(list);
            }
        }

        public double GetPuls()
        {
            return Math.Round(_puls);
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }


    }
}
