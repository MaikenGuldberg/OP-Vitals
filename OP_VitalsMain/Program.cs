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

        //Datakøer
        private ConcurrentQueue<RawDataQueue> RawDataQueue;
        private ConcurrentQueue<RawDataQueue> SaveQueue;

        //DTO'er
        private DAQSettingsDTO daqSettings;
        private PatientDTO patientDTO;

        static void Main(string[] args)
        {
            Program currentProgram = new OP_VitalsMain.Program();
        }

        public Program()
        {
            //Datakøer
            RawDataQueue = new ConcurrentQueue<RawDataQueue>();
            SaveQueue = new ConcurrentQueue<RawDataQueue>();

            //DTO'er
            daqSettings = new DAQSettingsDTO();
            patientDTO = new PatientDTO();


            currentOpVitalsDal = new CtrlOPVitalsDAL(ref RawDataQueue,ref SaveQueue,daqSettings);
            currentOpVitalsBl = new CtrlOPVitalsBL(currentOpVitalsDal,ref RawDataQueue,daqSettings,patientDTO);
            currentOpVitalsPl = new CtrlOPVitalsPL(currentOpVitalsBl);
            currentOpVitalsPl.StartGUI();
        }
    }
}
