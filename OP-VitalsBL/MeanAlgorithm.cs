﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    public class MeanAlgorithm
    {

        private List<double> analyselist;

        public MeanAlgorithm()
        {
                analyselist = new List<double>();
        }
        private void CalculateMean(double value,BloodpreasureDTO bloodpreasure)
        {
    
            if (analyselist.Count < 3000)
            {
                analyselist.Add(value);
               
            }
            if (analyselist.Count== 3000)
            {
                bloodpreasure.Meanpressure = analyselist.Average();
            }
            else
            {
                analyselist.Clear();
            }
         
        }

    }
}
