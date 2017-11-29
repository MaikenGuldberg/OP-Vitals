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

        private DAQSettingsDTO _daqSettingsDTO;
        private OperationDTO _operationDTO;
        private PatientDTO _patientDTO;
        private EmployeeDTO _employeeDTO;
        private TransdusorDTO _transdusorDTO;
        private BPDataSequenceDTO _bpDataSequenceDTO;


        private Thread _saveMeasuremenThread;
        private ParameterBuilder _parameterBuilder;
        private ClinicalDatabase _clinicalDatabase;

        public CtrlOPVitalsDAL(ref ConcurrentQueue<RawDataQueue> RawDataQueue,ref ConcurrentQueue<RawDataQueue> saveDataQueue,DAQSettingsDTO daqSettingsDTO,OperationDTO operation,EmployeeDTO employeeDTO,TransdusorDTO transdusorDTO,BPDataSequenceDTO bpDataSequenceDTO,PatientDTO patientDTO)
        {
            _RawDataQueue = RawDataQueue;
            _saveDataQueue = saveDataQueue;
            _daqSettingsDTO = daqSettingsDTO;
            _operationDTO = operation;
            _employeeDTO = employeeDTO;
            _transdusorDTO = transdusorDTO;
            _bpDataSequenceDTO = bpDataSequenceDTO;
            _patientDTO = patientDTO;

            fileManager = new FileManager();
            employee = new EmployeeDatabase();
            DaqAsync = new AsyncDaq(_RawDataQueue,_saveDataQueue);
            _saveDataInFile = new SaveDataInFile(_daqSettingsDTO,_saveDataQueue,fileManager);
            _parameterBuilder = new ParameterBuilder();
            _clinicalDatabase = new ClinicalDatabase(_parameterBuilder);

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

        public void StartSaveThread()
        {
            fileManager.CreateAFolderToOperationFiles(DateTime.Now);
            _operationDTO.PathOperationFolder_ = fileManager.GetOperationFolder();
            _saveMeasuremenThread = new Thread(_saveDataInFile.RunSaveToFile);

            _saveMeasuremenThread.IsBackground = true;

            _saveMeasuremenThread.Start();
        }

        public void StopSaveDataThread(bool result)
        {
            _saveDataInFile.stopThread(result);
        }

        public void SaveToDatabase()
        {
            _clinicalDatabase.SaveMeasurement(_employeeDTO, _operationDTO, _patientDTO, _daqSettingsDTO,
                _bpDataSequenceDTO, _transdusorDTO);
        }

        //public void SaveComment(string comment)
        //{
        //    fileManager.SaveComments();
        //}
    }

}
