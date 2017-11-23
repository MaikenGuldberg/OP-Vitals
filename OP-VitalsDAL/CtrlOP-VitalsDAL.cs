using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;


namespace OP_VitalsDAL
{
    public class CtrlOPVitalsDAL:iOPVitalsDAL
    {
        private FileManager fileManager;
        private string path;
        private AsyncDaq DaqAsync;
        private EmployeeDatabase employee;
        private ConcurrentQueue<RawDataQueue> _RawDataQueue;

        public CtrlOPVitalsDAL(ref ConcurrentQueue<RawDataQueue> RawDataQueue)
        {
            _RawDataQueue = RawDataQueue;
            fileManager = new FileManager();
            employee = new EmployeeDatabase();
            DaqAsync = new AsyncDaq(_RawDataQueue);
        }

        

        public void SaveCalibration(double value, string technicianID)
        {
            fileManager.CreateCalibrationFile(value,technicianID, out path);
        }

        public void StartDaq()
        {
            DaqAsync.InitiateAsyncDaq();
        }

        public double GetZeroPoint()
        {
            return DaqAsync.GetDataPointZero();
        }
        public bool ValidateLogin(EmployeeDTO Employee)
        {
            return employee.ValidateLogin(Employee);
        }

        public AsyncDaq GetAsyncDaq()
        {
            return DaqAsync;
        }

        public void StopMeasurement()
        {
            DaqAsync.StopMeasurement();
        }
    }

}
