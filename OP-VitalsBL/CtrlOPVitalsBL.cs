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
        private OperationDTO _operationDTO;
        private AlarmDTO _alarmDTO;
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
        private Alarm _alarm;
        private IAlarmPlayer _alarmPlayer;
        private FilterFactory _filterFactory;
        private PatientDTO _patientDto;
        private FilterSettingsDTO _filterSettingsDTO;

        private bool _stopThreads;

        public CtrlOPVitalsBL(iOPVitalsDAL currentDal, ref ConcurrentQueue<RawDataQueue> RawDataQueue,DAQSettingsDTO daqSettingsDto,PatientDTO patientDto)
        {
            
            _RawDataQueue = RawDataQueue;
            this.currentDal = currentDal;
            InitializeDataReadyEvents();
            InitializeCalibrationClasses();
            _daqSettings = daqSettingsDto;
            _patientDto = patientDto;
            _operationDTO = new OperationDTO();
            employee = new EmployeeDTO();
            _deQueue = new DeQueue(_RawDataQueue,_daqSettings);
            _filterSettingsDTO = new FilterSettingsDTO();
            _filterFactory = new FilterFactory(_daqSettings,_filterSettingsDTO);
            meanfilter_ = new MeanFilter(_dataReadyEventMeanFilter, _deQueue,_filterFactory);
            InitializeAlarmClasses();
            InitializeCalculationClasses();


        }

        private void InitializeDataReadyEvents()
        {
            _dataReadyEventMeanFilter = new AutoResetEvent(false);
            _dataReadyEventCalcSys = new AutoResetEvent(false);
            _dataReadyEventCalcDia = new AutoResetEvent(false);
            _dataReadyEventCalcMeanBloodPressure = new AutoResetEvent(false);
            _dataReadyEventCalcPuls = new AutoResetEvent(false);
        }

        private void InitializeCalibrationClasses()
        {
            rsquaredCalculator = new RsquaredCalculator();
            calibration = new Calibration(rsquaredCalculator);
        }

        private void InitializeCalculationClasses()
        {
            _calcSys = new CalcSys(_daqSettings, _dataReadyEventCalcSys, _deQueue, _alarm);
            _calcDia = new CalcDia(_daqSettings, _dataReadyEventCalcDia, _deQueue, _alarm);
            _calcMeanBloodPressure = new CalcMeanBloodPressure(_daqSettings, _dataReadyEventCalcMeanBloodPressure, _deQueue);
            _calcPuls = new CalcPuls(_daqSettings, _dataReadyEventCalcPuls, _deQueue);
        }

        private void InitializeAlarmClasses()
        {
            _alarmDTO = new AlarmDTO();
            _alarmPlayer = new AlarmPlayer();
            _alarm = new Alarm(_alarmDTO, _alarmPlayer,_operationDTO);

        }
        public void AddToCalibrationlist(double pressure) //denne metode tilføjer et kalibreringspunkt til kalibreringslisten
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

        public bool ZeroPointAdjust() //måler det atmosfæriske tryk og tjekker om det er en valid værdi
        {
            currentDal.StartDaq(false); //Starter Daqen unden brug af ConcurrentQueue
            double atmospherePressure = currentDal.GetZeroPoint() * _daqSettings.ConversionConstant_; //finder spændingen og laver denne om til tryk
            if (atmospherePressure > 750) //Tjekker om det atmosfæriske tryk er som forventet og hvis det er bliver zeropoint attributten sat til denne værdi i daqSettingsDTO'en
            {
                return false;
            }
            else
            {
                return true;
                _daqSettings.ZeroPoint_ = atmospherePressure;
            }
            currentDal.StopMeasurement(); //Stopper tråden der optager målinger fra daqen.
        }
        public void InitiateDaqFromBL(bool QueueMode)
        {
            currentDal.StartDaq(QueueMode);
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
        public void StartChartThread()
        {
            currentDal.StartDaq(true);
            currentDal.StartSaveThread();
            _alarm.ResetAlarm(); // ved ikke om den virker
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
            _calcPuls.StopThread(result);
            currentDal.StopMeasurement();
            currentDal.StopSaveDataThread(result);
            _alarmPlayer.StopAlarm("SubAkut");
        }

        public double GetPuls()
        {
            return _calcPuls.GetPuls();
        }

        public void AttachToCalcPuls(ICalcPulsObserver observer)
        {
            _calcPuls.Attach(observer);
        }

        public bool CheckCPR(string CPRnr)
        {
            return OP_VitalsBL.CheckCPR.cprOK(CPRnr);
        }

        public PatientDTO GetPatientDto()
        {
            return _patientDto;
        }

        public void LoadCalibrationConstant()
        {
            currentDal.LoadCalibrationConstant();
        }

        public AlarmDTO GetAlarmDTO()
        {
            return _alarmDTO;
        }

        

        public void SaveComments(string[] comments,int OPHoure,int OPMinut,int OPSec,int Complikation)
        {
            _operationDTO.DurationOperation_hour_ = OPHoure;
            _operationDTO.DurationOperation_min_ = OPMinut;
            _operationDTO.DurationOperation_sec_ = OPSec;
            _operationDTO.Complikations_ = Complikation;
            currentDal.SaveComments(comments);
        }

        public void SetFilter(string filtertype)
        {
            _filterSettingsDTO.filtersetting = filtertype;
        }

        public void SaveInDatabase()
        {
            currentDal.SaveAll(employee,_operationDTO,_patientDto);
        }
    }
}
