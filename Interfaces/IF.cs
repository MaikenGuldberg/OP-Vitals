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

        void StartDaq();
        double GetZeroPoint();

        bool ValidateLogin(EmployeeDTO Employee);
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
        void InitiateDaqFromBL();

        double GetZeroPointFromBL();

        bool ValidateLogin(EmployeeDTO Employee);
        EmployeeDTO employee { get; set; }
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
        void CalculateSys(double value, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ);
    }

    public interface ICalcDia
    {
        void CalculateDia(double value, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ);
    }
}
