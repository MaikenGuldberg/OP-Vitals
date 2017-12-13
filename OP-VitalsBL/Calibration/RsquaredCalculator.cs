using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class RsquaredCalculator: iRsquaredCalculator
    {
        
        //Metode til at udregne a og b værdien for en lineær regression på baggrung af beregninger på nogle punkter.
        //xVals er alle x-værdierne på punkterne
        //yVals er alle punkternes y-værdier
        //inclusiveStart er index-værdien for det punkt der skal være med i regressionen (hvis man har en liste med tre punkter skal der stå 0 idet indexeringen starter ved 0)
        //exclusiveEnd er index-værdien for det punkt der ikke skal være med i regressionen (hvis man har en liste med tre punkter skal der stå 3 idet indexeringen starter ved 0)
        public void LinearRegressionCalc(double[] xVals, double[] yVals,
                                            int inclusiveStart, int exclusiveEnd,
                                            out double rsquared, out double yintercept,
                                            out double slope)
        {
            Debug.Assert(xVals.Length == yVals.Length); //sikre at arraysne har samme længde
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            double ssY = 0;
            double sumCodeviates = 0;
            double sCo = 0;
            double count = exclusiveEnd - inclusiveStart; //antal punkter

            for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
            {
                double x = xVals[ctr];
                double y = yVals[ctr];
                sumCodeviates += x * y;
                sumOfX += x; //summen af alle x-værdier
                sumOfY += y; //summen af alle y-værdier
                sumOfXSq += x * x; //summen af x-værdiernes kvadratroder
                sumOfYSq += y * y; //summen af y-værdiernes kvadratroder
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count); //beregning af nævneren i brøken til at finde hældningen på den lineære regression
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            double meanX = sumOfX / count; //udregning af middelværdierne af x. Benyttes til udregning af yintercept
            double meanY = sumOfY / count; //udregning af middelværdierne af y. Benyttes til udregning af yintercept
            double dblR = RNumerator / Math.Sqrt(RDenom); //udregning af r
            rsquared = dblR * dblR; // r i anden værdien
            yintercept = meanY - ((sCo / ssX) * meanX); //linjens skæring med y-aksen
            slope = sCo / ssX; // hældningen på linjen
        }
        // En tak til https://gist.github.com/tansey/1375526 for at ligge koden op til offentligt brug


    }
}
