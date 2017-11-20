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

        static void Main(string[] args)
        {
            Program currentProgram = new OP_VitalsMain.Program();
        }

        public Program()
        {
            RawDataQueue = new ConcurrentQueue<RawDataQueue>();

            currentOpVitalsDal = new CtrlOPVitalsDAL(ref RawDataQueue);
            currentOpVitalsBl = new CtrlOPVitalsBL(currentOpVitalsDal,ref RawDataQueue);
            currentOpVitalsPl = new CtrlOPVitalsPL(currentOpVitalsBl);
            currentOpVitalsPl.StartGUI();
        }
    }
}
