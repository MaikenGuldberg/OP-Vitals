using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface iOPVitalsBL
    {
        void AddToCalibrationlist(double pressure);
        void LinearRegression(List<CalibrationPointDTO> list);
        List<CalibrationPointDTO> GetCalibrationList();
        double GetYintercept_();
        double GetRsquared_();
        double GetSlope_();
        void SaveCalibration();
        void InitiateDaqFromBL(bool QueueMode);

        double GetZeroPointFromBL();

        bool ValidateLogin(EmployeeDTO Employee);
        EmployeeDTO employee { get; set; }

        void AttachToMeanFilter(MeanFilterObserver observer);

        List<double> GetDisplayList();
        void StartChartThread();

        void StopThreads(bool result);

        double GetSys();

        void AttachToCalcSys(CalcSysObserver observer);
        double GetDia();
        void AttachToCalcDia(CalcDiaObserver observer);

        double GetMeanBloodPressure();

        void AttachToMeanBloodPressure(CalcMeanBloodPressureObserver observer);

        double GetPuls();
        void AttachToCalcPuls(CalcPulsObserver observer);

        bool ZeroPointAdjust();

        bool CheckCPR(string CPRnr);

        PatientDTO GetPatientDto();

        void LoadCalibrationConstant();

        AlarmDTO GetAlarmDTO();
        void SaveComments(string[] comments, int OPHoure, int OPMinut, int OPSec, int Complikation);

        void SetFilter(string filtertype);
        void SaveInDatabase();

    }
}
