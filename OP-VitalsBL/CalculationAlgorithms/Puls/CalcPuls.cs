using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using MathNet.Filtering;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcPuls: CalcPulsSubject, IDeQueueObserver
    {
        private List<double> analysisList;
        private double _puls;
        private DAQSettingsDTO _daqDTO;
        private readonly AutoResetEvent _dataReadyEvent;
        private bool _stopThread;
        private DeQueue _deQueue;

        public CalcPuls(DAQSettingsDTO daqDTO,AutoResetEvent dataReadyEvent,DeQueue deQueue)
        {
            _daqDTO = daqDTO;
            analysisList = new List<double>();
            _puls = 0;
            _dataReadyEvent = dataReadyEvent;
            _deQueue = deQueue;
            _deQueue.Attach(this);
        }

        public void CalculatePuls(List<double> dataList)
        {
            foreach (var value in dataList)
            {
                analysisList.Add(value);
            }

            if (analysisList.Count == 6 * _daqDTO.SampleRate)
            {
                Complex[] complexAnalysisListWithoutWindow = new Complex[6 * _daqDTO.SampleRate];
                for (int i = 0; i < analysisList.Count; i++)
                {
                    complexAnalysisListWithoutWindow[i] = new Complex(analysisList[i],0);
                }

                Complex[] complexAnalysisListWithWindow = new Complex[6 * _daqDTO.SampleRate];
                double[] hammingWindow = MathNet.Numerics.Window.Hamming(complexAnalysisListWithWindow.Length);

                for (int i = 0; i < complexAnalysisListWithoutWindow.Length; i++)
                {
                    complexAnalysisListWithWindow[i] = hammingWindow[i] * complexAnalysisListWithoutWindow[i];
                }
                Fourier.Forward(complexAnalysisListWithWindow,FourierOptions.NoScaling);

                double[] magnitudes = new double[complexAnalysisListWithWindow.Length/2];

                for (int i = 2; i < complexAnalysisListWithWindow.Length/2; i++)
                {
                    magnitudes[i] = complexAnalysisListWithWindow[i].Magnitude;
                }

                int maxIndex = 0;

                for (int i = 0; i < magnitudes.Length; i++)
                {
                    if (magnitudes[i] == magnitudes.Max())
                        maxIndex = i;
                }

                double frequenceForMaxMagnitude = maxIndex * 1000.0 / complexAnalysisListWithWindow.Length;
                double bpm = 60 * frequenceForMaxMagnitude;

                _puls = bpm;
                Notify();
                analysisList.Clear();
            }
        }

        public void RunCalcPuls()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculatePuls(list);
            }
        }

        public double GetPuls()
        {
            return Math.Round(_puls);
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void StopThread(bool result)
        {
            _stopThread = result;
        }


        //private void CalculatePuls(List<double> dataList,DAQSettingsDTO DAQ)
        //{
        //    Fourier.Forward(dataList);
        //    for (int i = 0; i < dataList.Count; i++)
        //    {
        //        if (analysisList.Count < 3 * DAQ.SampleRate)
        //        {
        //            analysisList.Add(dataList[i]);
        //        }
        //        if (analysisList.Count == 3 * DAQ.SampleRate)
        //        {
        //            _dia = Math.Round(analysisList.Min());
        //            analysisList.RemoveAt(0);
        //        }
        //    }
        //    //threashold = bloodpreasure.Systole * 0.80;
        //    foreach (var data in dataList)
        //    {
        //        if (analysisList.Count < 9 * DAQ.SampleRate)
        //        {
        //            analysisList.Add(data);
        //            if (data > threashold)
        //            {
        //                pulsList.Add(data);

        //            }
        //            else
        //            {
        //                if (pulsList.Count > 0)
        //                {
        //                    Counthighs++;
        //                    pulsList.Clear();
        //                }
        //            }

        //        }
        //        if (analysisList.Count == 9 * DAQ.SampleRate)
        //        {
        //            _puls = Counthighs * (9 / 60);
        //            analysisList.RemoveAt(0);
        //            Counthighs = 0;
        //        }
        //    }

        //}

        //public double GetPuls()
        //{
        //    return _puls;
        //}
    }
}
