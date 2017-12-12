using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using NationalInstruments;
using NationalInstruments.DAQmx;
using DTO;

namespace OP_VitalsDAL
{
    public class AsyncDaq
    {
        private AnalogMultiChannelReader analogInReader;
        private NationalInstruments.DAQmx.Task myTask;
        private NationalInstruments.DAQmx.Task runningTask;
        private AsyncCallback analogCallback;
        private AnalogWaveform<double>[] data;
        private List<double> zeroPoint;
        private double zeroDouble;
        private readonly ConcurrentQueue<RawData> _rawDataQueue;
        private readonly ConcurrentQueue<RawData> _saveDataQueue;
        private bool _queueMode;

        public AsyncDaq(ConcurrentQueue<RawData> rawDataQueue,ConcurrentQueue<RawData> saveDataQueue)
        {
            _rawDataQueue = rawDataQueue;
            _saveDataQueue = saveDataQueue;
            _queueMode = false;
        }
        public void InitiateAsyncDaq(bool QueueMode)
        {
            _queueMode = QueueMode;
            if (runningTask == null)
            {
                try
                {
                    // Create a new task
                    myTask = new NationalInstruments.DAQmx.Task();

                    // Create a virtual channel
                    myTask.AIChannels.CreateVoltageChannel("Dev2/ai0", "",
                        (AITerminalConfiguration)(-1), -5, 5, AIVoltageUnits.Volts);

                    // Configure the timing parameters
                    myTask.Timing.ConfigureSampleClock("", 1000, // 1000 = frekvensen der læses med i hz
                        SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 100); // 100 = antal samples per læsning

                    // Verify the Task
                    myTask.Control(TaskAction.Verify);

                    runningTask = myTask;
                    analogInReader = new AnalogMultiChannelReader(myTask.Stream);
                    analogCallback = new AsyncCallback(AnalogInCallback);

                    // Use SynchronizeCallbacks to specify that the object 
                    // marshals callbacks across threads appropriately.
                    analogInReader.SynchronizeCallbacks = true;
                    analogInReader.BeginReadWaveform(100,
                        analogCallback, myTask);
                }
                catch (DaqException exception)
                {
                    // Display Errors
                    runningTask = null;
                    myTask.Dispose();
                }
            }
        }

        public void StopMeasurement()
        {
            if (runningTask != null)
            {
                // Dispose of the task
                runningTask = null;
                myTask.Dispose();
            }
        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    // Read the available data from the channels
                    data = analogInReader.EndReadWaveform(ar);
                    if (_queueMode == true) //Sikres at der ikke bliver lagt målinger i kø når der laves kalibrering
                    {
                        RawData reading = new RawData();
                        reading.SetRawDataSample(data);
                        _rawDataQueue.Enqueue(reading); //Consumer producer patteren

                        RawData reading2 = new RawData();
                        reading2.SetRawDataSample(data);
                        _saveDataQueue.Enqueue(reading2);
                    }
                    analogInReader.BeginMemoryOptimizedReadWaveform(100,
                        analogCallback, myTask, data);
                }
            }
            catch (DaqException exception)
            {
                // Display Errors
                runningTask = null;
                myTask.Dispose();
            }
        }

        public double GetDataPointZero()
        {
            zeroPoint = new List<double>();
            foreach (var d in analogInReader.ReadMultiSample(1000))
            {
                zeroPoint.Add(d*1000);
            }
            zeroDouble = (zeroPoint.Average()); //ændre enheden fra Volt til mV
            return zeroDouble;
        }
    }
}


