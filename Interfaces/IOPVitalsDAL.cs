using System;
using System.Collections.Generic;
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

        void SaveComments(string[] comments);

        void SaveAll(EmployeeDTO employeeDto, OperationDTO operationDto, PatientDTO patientDto);
    }
}
