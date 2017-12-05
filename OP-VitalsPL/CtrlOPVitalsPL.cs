using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using DTO;

namespace OP_VitalsPL
{
    public class CtrlOPVitalsPL:iOPVitalsPL
    {
        private iOPVitalsBL currentBl;

        public CtrlOPVitalsPL(iOPVitalsBL currentBl)
        {
            this.currentBl = currentBl;
        }

        public void StartGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();
            Application.Run(new UILogin(currentBl));
        }
    }
}
