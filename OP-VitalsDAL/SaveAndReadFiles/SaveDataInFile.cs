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
        private ConcurrentQueue<RawData> _saveDataQueue;
        private FileManager _fileManager;
        private int _sequenceNumber;
        private BPDataSequenceDTO _bpDataSequenceDTO;
        public SaveDataInFile(DAQSettingsDTO daqDTO,ConcurrentQueue<RawData> saveDataQueue,FileManager fileManager,BPDataSequenceDTO bpDataSequenceDTO)
        {
            savelist = new List<double>();
            _daqDTO = daqDTO;
            _saveDataQueue = saveDataQueue;
            _fileManager = fileManager;
            _stopThread = false;
            _sequenceNumber = 1;
            _bpDataSequenceDTO = bpDataSequenceDTO;
        }
        
        private void SaveToFile()
        {
            if (savelist.Count < _daqDTO.SampleRate * _daqDTO.SaveInterval_)
            {
                RawData data;
                while (!_saveDataQueue.TryDequeue(out data))
                {
                    Thread.Sleep(0);
                }
                foreach (var point in data.GetRawData100())
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
                _daqDTO.Interval_s = savelist.Count / _daqDTO.SampleRate;
                _fileManager.SaveMeasurementsInFile(savelist, _fileManager.GetOperationFolder(), _sequenceNumber);
            }
            _bpDataSequenceDTO.NumberOfSequences_ = _sequenceNumber;
            savelist.Clear();
            _sequenceNumber = 1;
        }

    }
}
