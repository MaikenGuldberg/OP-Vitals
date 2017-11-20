using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    class Bloodpressure
    {
        private CalcSys calcSys_;
        private CalcDia calcDia_;
        private CalcMeanBloodPressure _calcCalcMeanPressure;

        public Bloodpressure()
        {
            calcSys_ = new CalcSys();
            calcDia_ = new CalcDia();
            _calcCalcMeanPressure = new CalcMeanBloodPressure();
        }

        public void CalcBloodpressureValues(List<double> list,BloodpreasureDTO bloodpreasureDto,DAQSettingsDTO DaqDTO)
        {
            calcSys_.CalculateSys(list,bloodpreasureDto,DaqDTO);
            calcDia_.CalculateDia(list,bloodpreasureDto,DaqDTO);
            _calcCalcMeanPressure.CalculateMean(list,bloodpreasureDto,DaqDTO);
        }
    }
}
