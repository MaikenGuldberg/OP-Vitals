using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.IO;
using Interfaces;

namespace OP_VitalsDAL
{
    public class ParameterBuilder : iParameterBuilder
    {
        public void AddEmployee(SqlCommand cmd, EmployeeDTO employee)
        {
            cmd.Parameters.AddWithValue("@OPNurseFirstName", employee.FirstName_);
            cmd.Parameters.AddWithValue("@OPNurseLastName", employee.LastName_);
            cmd.Parameters.AddWithValue("@OPNurseIDNumber", employee.EmployeeID_);
        }

        public void AddPatient(SqlCommand cmd, PatientDTO patient)
        {
            cmd.Parameters.AddWithValue("@PatientCPR", patient.PatientCPR);
        }

        public void AddOperation(SqlCommand cmd, OperationDTO operation)
        {
            cmd.Parameters.AddWithValue("@NumberOFAlarms", operation.NumberOfAlarms_);
            cmd.Parameters.AddWithValue("@DurationOperation_hour", operation.DurationOperation_hour_);
            cmd.Parameters.AddWithValue("@DurationOperation_min", operation.DurationOperation_min_);
            cmd.Parameters.AddWithValue("@DurationOperation_sec", operation.DurationOperation_sec_);
            cmd.Parameters.AddWithValue("@Complikations", operation.Complikations_);
        }

        public void AddComments(SqlCommand cmd, string zipfolderpathComment)
        {
            byte[] Comment = File.ReadAllBytes(zipfolderpathComment);
            cmd.Parameters.AddWithValue("@Comments", Comment);
        }

        public void AddRawData(SqlCommand cmd, string zipfolderpathdata)
        {
            byte[] Raw_Data = File.ReadAllBytes(zipfolderpathdata);
            cmd.Parameters.AddWithValue("@Raw_Data", Raw_Data);
        }

        

        public void AddDAQ(SqlCommand cmd, DAQSettingsDTO DAQ)
        {
            cmd.Parameters.AddWithValue("@Samplerate_hz", DAQ.SampleRate);
            cmd.Parameters.AddWithValue("@Interval_sec", DAQ.Interval_ms);
            cmd.Parameters.AddWithValue("@Data_Format", DAQ.Data_Format_);
            cmd.Parameters.AddWithValue("@Bin_or_Text", DAQ.Bin_or_text_);
            cmd.Parameters.AddWithValue("@Measurement_Format_Type", DAQ.Data_Format_);
            cmd.Parameters.AddWithValue("@ConversionConstant_mmhgprmV", DAQ.ConversionConstant_);
            cmd.Parameters.AddWithValue("@ZeroPoint_mmHg", DAQ.ZeroPoint_);
        }

        public void AddTransdusor(SqlCommand cmd, TransdusorDTO transdusor)
        {
            cmd.Parameters.AddWithValue("@Transdusor_Identification", transdusor.Transdusor_Identification_);
        }

        public void AddDataSequence(SqlCommand cmd, BPDataSequenceDTO dataSequence)
        {
            cmd.Parameters.AddWithValue("@NumberOfSequences", dataSequence.NumberOfSequences_);
            cmd.Parameters.AddWithValue("@SequenceDuration_sec", dataSequence.SequenceDuration_sec_);
        }

    }
}
