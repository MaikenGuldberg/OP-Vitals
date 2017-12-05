using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;



namespace Interfaces
{
    public interface iOPVitalsDAL
    {
        void SaveCalibration(double value, string technicianID);

        void StartDaq(bool QueueMode);
        double GetZeroPoint();

        bool ValidateLogin(EmployeeDTO Employee);

        void StopMeasurement();
        void StartSaveThread();
        void StopSaveDataThread(bool result);
        void LoadCalibrationConstant();
    }

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

        void AttachToMeanFilter(IMeanFilterObserver observer);

        List<double> GetDisplayList();
        void StartChartThread();

        void StopThreads(bool result);

        double GetSys();

        void AttachToCalcSys(ICalcSysObserver observer);
        double GetDia();
        void AttachToCalcDia(ICalcDiaObserver observer);

        double GetMeanBloodPressure();

        void AttachToMeanBloodPressure(ICalcMeanBloodPressureObserver observer);

        double GetPuls();
        void AttachToCalcPuls(ICalcPulsObserver observer);

        bool ZeroPointAdjust();

        bool CheckCPR(string CPRnr);

        PatientDTO GetPatientDto();

        void LoadCalibrationConstant();

        AlarmDTO GetAlarmDTO();

    }

    public interface iOPVitalsPL
    {
        void StartGUI();
    }

    public interface iParameterBuilder
    {
        void AddEmployee(SqlCommand cmd, EmployeeDTO employee);
        void AddPatient(SqlCommand cmd, PatientDTO patient);
        void AddOperation(SqlCommand cmd, OperationDTO operation);
        void AddComments(SqlCommand cmd, string zipfolderpathComment);
        void AddRawData(SqlCommand cmd, string zipfolderpathdata);
        void AddDAQ(SqlCommand cmd, DAQSettingsDTO DAQ);
        void AddTransdusor(SqlCommand cmd, TransdusorDTO transdusor);
        void AddDataSequence(SqlCommand cmd, BPDataSequenceDTO dataSequence);

    }

    public interface iRsquaredCalculator
    {
        void LinearRegressionCalc(double[] xVals, double[] yVals,
            int inclusiveStart, int exclusiveEnd,
            out double rsquared, out double yintercept,
            out double slope);
    }

    public interface ICalcSys
    {
        
    }

    public interface ICalcDia
    {
        
    }

    public interface IMeanFilterObserver
    {
        void UpdateMeanFilterGUI();
    }

    public interface IDeQueueObserver
    {
        void UpdateRawData();
    }

    public interface ICalcSysObserver
    {
        void UpdateSysGUI();
    }

    public interface ICalcDiaObserver
    {
        void UpdateDiaGUI();
    }

    public interface ICalcMeanBloodPressureObserver
    {
        void UpdateMeanBloodPressureGUI();
    }

    public interface ICalcPulsObserver
    {
        void UpdatePulsGUI();
    }

    public interface IAlarmPlayer
    {
        void PlayAlarm(string type);
        void StopAlarm(string type);
    }
}
