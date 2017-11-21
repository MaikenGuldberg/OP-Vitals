﻿using System;
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
        private DAQSettingsDTO daqSettings;
        private MeanFilter meanfilter_;
        private DeQueue _deQueue;
        private Thread _chartThread;
        private Thread _DeQueueThread;
        private Thread _CalcSysThread;
        public  EmployeeDTO employee { get; set; }
        private RsquaredCalculator rsquaredCalculator;
        private ConcurrentQueue<RawDataQueue> _RawDataQueue;
        private AutoResetEvent _dataReadyEventMeanFilter;
        private AutoResetEvent _dataReadyEventCalcSys;
        private CalcSys _calcSys;

        private bool _stopThreads;

        public CtrlOPVitalsBL(iOPVitalsDAL currentDal, ref ConcurrentQueue<RawDataQueue> RawDataQueue)
        {
            _dataReadyEventMeanFilter = new AutoResetEvent(false);
            _dataReadyEventCalcSys = new AutoResetEvent(false);
            _RawDataQueue = RawDataQueue;
            this.currentDal = currentDal;
            rsquaredCalculator = new RsquaredCalculator();
            calibration = new Calibration(rsquaredCalculator);
            daqSettings = new DAQSettingsDTO();
            employee = new EmployeeDTO();
            _deQueue = new DeQueue(_RawDataQueue);
            meanfilter_ = new MeanFilter(_dataReadyEventMeanFilter, _deQueue);
            _calcSys = new CalcSys(daqSettings,_dataReadyEventCalcSys,_deQueue);
        }

        public void AddToCalibrationlist(double pressure)
        {
            calibration.AddMeasurePoint(currentDal.GetZeroPoint(),pressure);
        }

        public void LinearRegression(List<CalibrationPointDTO> list)
        {
            calibration.LinearRegression(list);
            daqSettings.ConversionConstant_ = calibration.Slope_;
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

        public List<double> GetDisplayList()
        {
            return meanfilter_.GetDisplayList();
        }

        public double GetSys()
        {
            return _calcSys.GetSys();
        }

        public void StartChartThread()
        {
            currentDal.StartDaq();
            _chartThread = new Thread(meanfilter_.RunMeanFilter);
            _CalcSysThread = new Thread(_calcSys.RunCalcSys);
            _DeQueueThread = new Thread(_deQueue.GetDataFromQue);


            _chartThread.IsBackground = true;
            _CalcSysThread.IsBackground = true;
            _DeQueueThread.IsBackground = true;

            _DeQueueThread.Start();
            _chartThread.Start();
            _CalcSysThread.Start();
        }

        public void StopThreads(bool result)
        {
            meanfilter_.stopThread(result);
            _deQueue.stopThread(result);
            _calcSys.stopThread(result);
            currentDal.StopMeasurement();
        }
    }
}
