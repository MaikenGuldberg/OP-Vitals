using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using OP_VitalsDAL;

namespace OP_VitalsBL
{
    class SaveDataInFile
    {
        private DAQSettingsDTO _daqDTO;
        private bool _stopThread;
        private List<double> savelist;
        private ConcurrentQueue<RawDataQueue> _saveDataQueue;
        private FileManager _fileManager;
        private int _sequenceNumber;
        public SaveDataInFile(DAQSettingsDTO daqDTO,ConcurrentQueue<RawDataQueue> saveDataQueue,FileManager fileManager)
        {
            savelist = new List<double>();
            _daqDTO = daqDTO;
            _saveDataQueue = saveDataQueue;
            _fileManager = fileManager;
            _stopThread = false;
            _sequenceNumber = 1;
        }
        
        private void SaveToFile()
        {
            if (savelist.Count < _daqDTO.SampleRate * _daqDTO.SaveInterval_)
            {
                RawDataQueue dataQueue;
                while (!_saveDataQueue.TryDequeue(out dataQueue))
                {
                    Thread.Sleep(0);
                }
                foreach (var point in dataQueue.GetRawData100())
                {
                    savelist.Add(point);
                }
            }
            if (savelist.Count >= _daqDTO.SampleRate * _daqDTO.SaveInterval_)
            {
                _fileManager.SaveMeasurementsInFile(savelist,_fileManager.GetOperationFolder(),_sequenceNumber);
                savelist.Clear();
                _sequenceNumber++;
            }
        }

        public void RunSaveToFile()
        {
            while (!_stopThread)
            {
                SaveToFile();
            }
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
            if (savelist.Count > 0)
            {
                _fileManager.SaveMeasurementsInFile(savelist, _fileManager.GetOperationFolder(), _sequenceNumber);
            }
            savelist.Clear();
            _sequenceNumber = 1;
        }

    }
}
