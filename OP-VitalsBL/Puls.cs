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

        public void CalculatePuls(double value, BloodpreasureDTO bloodpreasure)
        {
            if (analyselist.Count == 0)
            {
                threashold = bloodpreasure.Systole * 0.80;
            }
            if (analyselist.Count < 9000)
            {
                if (value > threashold)
                {
                    pulsList.Add(value);
                    analyselist.Add(value);
                }
                else
                {
                    analyselist.Add(value);
                    if (pulsList.Count > 0)
                    {
                        Counthighs++;
                        pulsList.Clear();
                    }
                }
                
            }
            if (analyselist.Count == 9000)
            {
                bloodpreasure.Puls = (Counthighs-1) * (9/60);
                analyselist.Clear();
                Counthighs = 0;
            }
        }
    }
}
