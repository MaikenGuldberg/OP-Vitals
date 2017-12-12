using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Interfaces;

namespace OP_VitalsPL
{
    public partial class UI_NulpunktsjusteringsFejl : Form
    {
        private iOPVitalsBL currentBl;
        private UILogin login;
        private UICPR CPR;
        public UI_NulpunktsjusteringsFejl(iOPVitalsBL mybl,UILogin UILogin)
        {
            InitializeComponent();
            currentBl = mybl;
            login = UILogin;

        }

        private void CheckButton_Click(object sender, EventArgs e) //hvis man trykker på tjekket laves der en ny nulpunktsjustering 
        {
            this.Hide();
            MessageBox.Show("Nulpunktsjustering påbegyndes");
            var zeroPointAdjust = currentBl.ZeroPointAdjust();
            if (zeroPointAdjust == false)
            {
                this.Show();
            }
            else if (zeroPointAdjust == true)
            {
                this.Hide();
                CPR = new UICPR(currentBl, login);
                CPR.Show();
            }
        }
    }
}
