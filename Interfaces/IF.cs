using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;



namespace Interfaces
{
    //public interface iOPVitalsDAL
    //{
    //    void SaveCalibration(double value, string technicianID);

    //    void StartDaq(bool QueueMode);
    //    double GetCalibrationPoint();

    //    bool ValidateLogin(EmployeeDTO Employee);

    //    void StopMeasurement();
    //    void StartSaveThread();
    //    void StopSaveDataThread(bool result);
    //    void LoadCalibrationConstant();

    //    void SaveComments(string[] comments);

    //    void SaveAll(EmployeeDTO employeeDto, OperationDTO operationDto, PatientDTO patientDto);
    //}

    //public interface iOPVitalsBL
    //{
    //    void AddToCalibrationlist(double pressure);
    //    void LinearRegression(List<CalibrationPointDTO> list);
    //    List<CalibrationPointDTO> GetCalibrationList();
    //    double GetYintercept_();
    //    double GetRsquared_();
    //    double GetSlope_();
    //    void SaveCalibration();
    //    void InitiateDaqFromBL(bool QueueMode);

    //    double GetZeroPointFromBL();

    //    bool ValidateLogin(EmployeeDTO Employee);
    //    EmployeeDTO employee { get; set; }

    //    void AttachToMeanFilter(MeanFilterObserver observer);

    //    List<double> GetDisplayList();
    //    void StartChartThread();

    //    void StopThreads(bool result);

    //    double GetSys();

    //    void AttachToCalcSys(CalcSysObserver observer);
    //    double GetDia();
    //    void AttachToCalcDia(CalcDiaObserver observer);

    //    double GetMeanBloodPressure();

    //    void AttachToMeanBloodPressure(CalcMeanBloodPressureObserver observer);

    //    double GetPuls();
    //    void AttachToCalcPuls(CalcPulsObserver observer);

    //    bool ZeroPointAdjust();

    //    bool CheckCPR(string CPRnr);

    //    PatientDTO GetPatientDto();

    //    void LoadCalibrationConstant();

    //    AlarmDTO GetAlarmDTO();
    //    void SaveComments(string[] comments, int OPHoure, int OPMinut, int OPSec, int Complikation);

    //    void SetFilter(string filtertype);
    //    void SaveInDatabase();

    //}

    //public interface iOPVitalsPL
    //{
    //    void StartGUI();
    //}

    //public interface iParameterBuilder
    //{
    //    void AddEmployee(SqlCommand cmd, EmployeeDTO employee);
    //    void AddPatient(SqlCommand cmd, PatientDTO patient);
    //    void AddOperation(SqlCommand cmd, OperationDTO operation);
    //    void AddComments(SqlCommand cmd, string zipfolderpathComment);
    //    void AddRawData(SqlCommand cmd, string zipfolderpathdata);
    //    void AddDAQ(SqlCommand cmd, DAQSettingsDTO DAQ);
    //    void AddTransdusor(SqlCommand cmd, TransdusorDTO transdusor);
    //    void AddDataSequence(SqlCommand cmd, BPDataSequenceDTO dataSequence);

    //}

    //public interface iRsquaredCalculator
    //{
    //    void LinearRegressionCalc(double[] xVals, double[] yVals,
    //        int inclusiveStart, int exclusiveEnd,
    //        out double rsquared, out double yintercept,
    //        out double slope);
    //}

    public interface ICalcSys
    {
        
    }

    public interface ICalcDia
    {
        
    }

    //public interface MeanFilterObserver
    //{
    //    void UpdateMeanFilterGUI();
    //}

    //public interface DeQueueObserver
    //{
    //    void UpdateRawData();
    //}

    //public interface CalcSysObserver
    //{
    //    void UpdateSysGUI();
    //}

    //public interface CalcDiaObserver
    //{
    //    void UpdateDiaGUI();
    //}

    //public interface CalcMeanBloodPressureObserver
    //{
    //    void UpdateMeanBloodPressureGUI();
    //}

    //public interface CalcPulsObserver
    //{
    //    void UpdatePulsGUI();
    //}

    //public interface IAlarmPlayer
    //{
    //    void PlayAlarm(string type);
    //    void StopAlarm(string type);
    //}

    //public interface IFilter
    //{
    //    List<double> FilterData(double[] data);
    //}
}
