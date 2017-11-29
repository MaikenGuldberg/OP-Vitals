using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using OP_VitalsPL;
using OP_VitalsBL;
using OP_VitalsDAL;

namespace OP_VitalsMain
{
    public class Program
    {
        private CtrlOPVitalsPL currentOpVitalsPl;
        private CtrlOPVitalsBL currentOpVitalsBl;
        private CtrlOPVitalsDAL currentOpVitalsDal;
        private ConcurrentQueue<RawDataQueue> RawDataQueue;
        private ConcurrentQueue<RawDataQueue> SaveQueue;
        private DAQSettingsDTO daqSettings;
        private EmployeeDTO employee;
        private PatientDTO patient;
        private OperationDTO operation;
        private TransdusorDTO transdusor;
        private BPDataSequenceDTO bpDataSequence;

        static void Main(string[] args)
        {
            Program currentProgram = new OP_VitalsMain.Program();
        }

        public Program()
        {
            RawDataQueue = new ConcurrentQueue<RawDataQueue>();
            SaveQueue = new ConcurrentQueue<RawDataQueue>();
            daqSettings = new DAQSettingsDTO();
            employee = new EmployeeDTO();
            patient = new PatientDTO();
            operation = new OperationDTO();
            transdusor = new TransdusorDTO();
            bpDataSequence = new BPDataSequenceDTO();

            currentOpVitalsDal = new CtrlOPVitalsDAL(ref RawDataQueue,ref SaveQueue,daqSettings,operation,employee,transdusor,bpDataSequence,patient);
            currentOpVitalsBl = new CtrlOPVitalsBL(currentOpVitalsDal,ref RawDataQueue,daqSettings,operation,employee);
            currentOpVitalsPl = new CtrlOPVitalsPL(currentOpVitalsBl);
            currentOpVitalsPl.StartGUI();
        }
    }
}
