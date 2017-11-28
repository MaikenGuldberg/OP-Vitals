using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace OP_VitalsBL
{
    public class CtrlOPVitalsBL:iOPVitalsBL
    {
        private iOPVitalsDAL currentDal;
        private Calibration calibration;
        private DAQSettingsDTO _daqSettings;
        private MeanFilter meanfilter_;
        private DeQueue _deQueue;
        private Thread _chartThread;
        private Thread _DeQueueThread;
        private Thread _CalcSysThread;
        private Thread _CalcDiaThread;
        private Thread _CalcMeanBloodPressureThread;
        private Thread _CalcPulsThread;
        public  EmployeeDTO employee { get; set; }
        private RsquaredCalculator rsquaredCalculator;
        private ConcurrentQueue<RawDataQueue> _RawDataQueue;
        private AutoResetEvent _dataReadyEventMeanFilter;
        private AutoResetEvent _dataReadyEventCalcSys;
        private AutoResetEvent _dataReadyEventCalcDia;
        private AutoResetEvent _dataReadyEventCalcMeanBloodPressure;
        private AutoResetEvent _dataReadyEventCalcPuls;
        private CalcSys _calcSys;
        private CalcDia _calcDia;
        private CalcMeanBloodPressure _calcMeanBloodPressure;
        private CalcPuls _calcPuls;

        private bool _stopThreads;

        public CtrlOPVitalsBL(iOPVitalsDAL currentDal, ref ConcurrentQueue<RawDataQueue> RawDataQueue,DAQSettingsDTO daqSettingsDto)
        {
            _dataReadyEventMeanFilter = new AutoResetEvent(false);
            _dataReadyEventCalcSys = new AutoResetEvent(false);
            _dataReadyEventCalcDia = new AutoResetEvent(false);
            _dataReadyEventCalcMeanBloodPressure = new AutoResetEvent(false);
            _dataReadyEventCalcPuls = new AutoResetEvent(false);
            _RawDataQueue = RawDataQueue;
            this.currentDal = currentDal;
            rsquaredCalculator = new RsquaredCalculator();
            calibration = new Calibration(rsquaredCalculator);
            _daqSettings = daqSettingsDto;
            employee = new EmployeeDTO();
            _deQueue = new DeQueue(_RawDataQueue);
            meanfilter_ = new MeanFilter(_dataReadyEventMeanFilter, _deQueue);
            _calcSys = new CalcSys(_daqSettings,_dataReadyEventCalcSys,_deQueue);
            _calcDia = new CalcDia(_daqSettings, _dataReadyEventCalcDia, _deQueue);
            _calcMeanBloodPressure = new CalcMeanBloodPressure(_daqSettings,_dataReadyEventCalcMeanBloodPressure,_deQueue);
            _calcPuls = new CalcPuls(_daqSettings,_dataReadyEventCalcPuls,_deQueue);
        }

        public void AddToCalibrationlist(double pressure)
        {
            calibration.AddMeasurePoint(currentDal.GetZeroPoint(),pressure);
        }

        public void LinearRegression(List<CalibrationPointDTO> list)
        {
            calibration.LinearRegression(list);
            _daqSettings.ConversionConstant_ = calibration.Slope_;
        }

        public List<CalibrationPointDTO> GetCalibrationList()
        {
            return calibration.calibrationlist_;
        }

        public double GetYintercept_()
        {
            return calibration.Yintercept_;
        }

        public double GetRsquared_()
        {
            return calibration.Rsquared_;
        }

        public double GetSlope_()
        {
            return calibration.Slope_;
        }

        public void SaveCalibration()
        {
            currentDal.SaveCalibration(calibration.Slope_,employee.EmployeeID_);
        }

        

        public bool ValidateLogin(EmployeeDTO Employee)
        {
            return currentDal.ValidateLogin(Employee);
        }

        public void InitiateDaqFromBL()
        {
            currentDal.StartDaq();
        }

        public double GetZeroPointFromBL()
        {
            return currentDal.GetZeroPoint();
        }

        public void AttachToMeanFilter(IMeanFilterObserver observer)
        {
            meanfilter_.Attach(observer);
        }

        public void AttachToCalcSys(ICalcSysObserver observer)
        {
            _calcSys.Attach(observer);
        }

        public void AttachToCalcDia(ICalcDiaObserver observer)
        {
            _calcDia.Attach(observer);
        }

        public void AttachToMeanBloodPressure(ICalcMeanBloodPressureObserver observer)
        {
            _calcMeanBloodPressure.Attach(observer);
        }

        public void AttachToCalcPuls(ICalcPulsObserver observer)
        {
            _calcPuls.Attach(observer);
        }
        public List<double> GetDisplayList()
        {
            return meanfilter_.GetDisplayList();
        }

        public double GetSys()
        {
            return _calcSys.GetSys();
        }

        public double GetDia()
        {
            return _calcDia.GetDia();
        }

        public double GetMeanBloodPressure()
        {
            return _calcMeanBloodPressure.GetMeanBloodPressure();
        }

        public double GetPuls()
        {
            return _calcPuls.GetPuls();
        }
        public void StartChartThread()
        {
            currentDal.StartDaq();
            currentDal.StartSaveThread();
            _chartThread = new Thread(meanfilter_.RunMeanFilter);
            _CalcSysThread = new Thread(_calcSys.RunCalcSys);
            _DeQueueThread = new Thread(_deQueue.GetDataFromQue);
            _CalcDiaThread = new Thread(_calcDia.RunCalcDia);
            _CalcMeanBloodPressureThread = new Thread(_calcMeanBloodPressure.RunCalcMeanBloodPressure);
            _CalcPulsThread = new Thread(_calcPuls.RunCalcPuls);
            

            _chartThread.IsBackground = true;
            _CalcSysThread.IsBackground = true;
            _DeQueueThread.IsBackground = true;
            _CalcDiaThread.IsBackground = true;
            _CalcMeanBloodPressureThread.IsBackground = true;
            _CalcPulsThread.IsBackground = true;

            _DeQueueThread.Start();
            _chartThread.Start();
            _CalcSysThread.Start();
            _CalcDiaThread.Start();
            _CalcMeanBloodPressureThread.Start();
            _CalcPulsThread.Start();
        }

        public void StopThreads(bool result)
        {
            meanfilter_.stopThread(result);
            _deQueue.stopThread(result);
            _calcSys.stopThread(result);
            _calcDia.stopThread(result);
            _calcMeanBloodPressure.StopThread(result);
            _calcPuls.stopThread(result);
            currentDal.StopMeasurement();
            currentDal.StopSaveDataThread(result);
        }
    }
}
