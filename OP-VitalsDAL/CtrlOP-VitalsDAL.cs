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
        private ConcurrentQueue<RawData> _RawDataQueue;
        private ConcurrentQueue<RawData> _saveDataQueue;
        private DAQSettingsDTO _daqSettings;
        private Thread _saveMeasuremenThread;
        private ClinicalDatabase _clinicalDatabase;
        private TransdusorDTO _transdusorDTO;
        private BPDataSequenceDTO _bpDataSequenceDTO;
        private string pathoperation;
        private string pathcomment;

        public CtrlOPVitalsDAL(ref ConcurrentQueue<RawData> RawDataQueue,ref ConcurrentQueue<RawData> saveDataQueue,ref DAQSettingsDTO daqSettings)
        {
            _RawDataQueue = RawDataQueue;
            _saveDataQueue = saveDataQueue;
            _daqSettings = daqSettings;
            fileManager = new FileManager();
            employee = new EmployeeDatabase();
            DaqAsync = new AsyncDaq(_RawDataQueue,_saveDataQueue,_daqSettings);
            _bpDataSequenceDTO = new BPDataSequenceDTO();
            _saveDataInFile = new SaveDataInFile(_daqSettings,_saveDataQueue,fileManager,_bpDataSequenceDTO);
            _clinicalDatabase = new ClinicalDatabase(new ParameterBuilder());
            _transdusorDTO = new TransdusorDTO();
            pathcomment = "";
            pathoperation = "";
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
            pathoperation = fileManager.CreateAFolderToOperationFiles(DateTime.Now);
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

        public void SaveComments(string[] comments)
        {
            pathcomment = fileManager.SaveComments(comments);
        }

        public void SaveAll(EmployeeDTO employeeDto, OperationDTO operationDto, PatientDTO patientDto)
        {
            _clinicalDatabase.SaveMeasurement(employeeDto, operationDto, patientDto, _daqSettings, _bpDataSequenceDTO,
                _transdusorDTO,pathcomment,pathoperation);
        }
    }

}
