using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP_VitalsPL;
using OP_VitalsBL;
using OP_VitalsDAL;

namespace OP_VitalsMain
{
    public class Program
    {
        private CtrlOPVitalsPL1 currentOpVitalsPl;
        private CtrlOPVitalsBL currentOpVitalsBl;
        private CtrlOPVitalsDAL currentOpVitalsDal;

        static void Main(string[] args)
        {
            Program currentProgram = new OP_VitalsMain.Program();
        }

        public Program()
        {
            currentOpVitalsDal = new CtrlOPVitalsDAL();
            currentOpVitalsBl = new CtrlOPVitalsBL(currentOpVitalsDal);
            currentOpVitalsPl = new CtrlOPVitalsPL1(currentOpVitalsBl);
            currentOpVitalsPl.StartGUI();
        }
    }
}
