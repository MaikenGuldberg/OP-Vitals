using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using Interfaces;
using OP_VitalsBL;


namespace OP_VitalsDAL
{
    public class CtrlOPVitalsDAL:iOPVitalsDAL
    {
        private FileManager fileManager;
        private string path;
        private AsyncDaq DaqAsync;
        private EmployeeDatabase employee;
        private SaveDataInFile _saveDataInFile;
        private ConcurrentQueue<RawDataQueue> _RawDataQueue;
        private ConcurrentQueue<RawDataQueue> _saveDataQueue;
        private DAQSettingsDTO _daqSettings;
        private Thread _saveMeasuremenThread;

        public CtrlOPVitalsDAL(ref ConcurrentQueue<RawDataQueue> RawDataQueue,ref ConcurrentQueue<RawDataQueue> saveDataQueue,DAQSettingsDTO daqSettings)
        {
            _RawDataQueue = RawDataQueue;
            _saveDataQueue = saveDataQueue;
            _daqSettings = daqSettings;
            fileManager = new FileManager();
            employee = new EmployeeDatabase();
            DaqAsync = new AsyncDaq(_RawDataQueue,_saveDataQueue);
            _saveDataInFile = new SaveDataInFile(_daqSettings,_saveDataQueue,fileManager);

        }

        

        public void SaveCalibration(double value, string technicianID)
        {
            fileManager.CreateCalibrationFile(value,technicianID, out path);
        }

        public void StartDaq(bool QueueMode)
        {
            DaqAsync.InitiateAsyncDaq(QueueMode);
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

        public void StartSaveThread()
        {
            fileManager.CreateAFolderToOperationFiles(DateTime.Now);
            _saveMeasuremenThread = new Thread(_saveDataInFile.RunSaveToFile);

            _saveMeasuremenThread.IsBackground = true;

            _saveMeasuremenThread.Start();
        }

        public void StopSaveDataThread(bool result)
        {
            _saveDataInFile.stopThread(result);
        }

        public void LoadCalibrationConstant()
        {
            _daqSettings.ConversionConstant_ = fileManager.ReadCalibrationFile();
        }
    }

}
