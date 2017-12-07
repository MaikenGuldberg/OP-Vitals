using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
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
}
