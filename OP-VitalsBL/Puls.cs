using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    class Puls
    {
        private List<double> analyselist;
        private List<double> pulsList;
        private int Counthighs;
        private double threashold;

        public Puls()
        {
            analyselist = new List<double>();

            Counthighs = 0;
        }

        public void CalculatePuls(List<double> dataList, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            threashold = bloodpreasure.Systole * 0.80;
            foreach (var data in dataList)
            {
                if (analyselist.Count < 9 * DAQ.SampleRate)
                {
                    analyselist.Add(data);
                    if (data > threashold)
                    {
                        pulsList.Add(data);
                        
                    }
                    else
                    {
                        if (pulsList.Count > 0)
                        {
                            Counthighs++;
                            pulsList.Clear();
                        }
                    }

                }
                if (analyselist.Count == 9 * DAQ.SampleRate)
                {
                    bloodpreasure.Puls = Counthighs * (9 / 60);
                    analyselist.RemoveAt(0);
                    Counthighs = 0;
                }
            }
           
            //if (analyselist.Count < 9*DAQ.SampleRate)
            //{
            //    if (value > threashold)
            //    {
            //        pulsList.Add(value);
            //        analyselist.Add(value);
            //    }
            //    else
            //    {
            //        analyselist.Add(value);
            //        if (pulsList.Count > 0)
            //        {
            //            Counthighs++;
            //            pulsList.Clear();
            //        }
            //    }
                
            //}
            //if (analyselist.Count == 9*DAQ.SampleRate)
            //{
            //    bloodpreasure.Puls = (Counthighs-1) * (9/60);
            //    analyselist.Clear();
            //    Counthighs = 0;
            //}
        }
    }
}
