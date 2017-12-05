using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.Design;
using Interfaces;

namespace OP_VitalsPL
{
    public partial class UICPR : Form
    {
        private iOPVitalsBL currentBl;
        private UILogin login;
        private UIForkertCPR _wrongCPR;
        private UIKontrolform _controlform;
        public UICPR(iOPVitalsBL mybl,UILogin UILogin)
        {
            InitializeComponent();
            currentBl = mybl;
            login = UILogin;
        }

        

        private void UICPROKButton_Click(object sender, EventArgs e)
        {
            currentBl.GetAlarmDTO().NormalSys = Convert.ToInt16(SysNormal.Text); //gemmer normalværdierne for sys og dia i alarm dto'en
            currentBl.GetAlarmDTO().NormalDia = Convert.ToInt16(DiaNormal.Text);

            if (CPRFindesIkkeCheckBox.Checked == false) //tjekker om tjekboksen cpr findes ikke er tjekket af, hvis den ikke er det tjekkes der om cpr-nummeret findes
            {
                bool iscpr = currentBl.CheckCPR(CPRTextBox.Text);
                if (iscpr == true)
                {
                    this.Hide();
                    currentBl.GetPatientDto().PatientCPR = CPRTextBox.Text;
                    _controlform = new UIKontrolform(currentBl, login);
                    _controlform.Show();
                }
                else if (iscpr == false)
                {
                    _wrongCPR = new UIForkertCPR();
                    var result = _wrongCPR.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.Hide();
                        currentBl.GetPatientDto().PatientCPR = CPRTextBox.Text;
                        _controlform = new UIKontrolform(currentBl,login);
                        _controlform.Show();
                    }
                    else if (result == DialogResult.Retry)
                    {
                        
                    }
                }
            }
            else if (CPRFindesIkkeCheckBox.Checked == true)
            {
                this.Hide();
                currentBl.GetPatientDto().PatientCPR = "Not known";
                _controlform = new UIKontrolform(currentBl, login);
                _controlform.Show();
            }
        }
    }
}
