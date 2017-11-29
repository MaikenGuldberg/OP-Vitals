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
using DTO;
using Interfaces;

namespace OP_VitalsPL
{
    public partial class UILogin : Form
    {
        private iOPVitalsBL currentBl;
        private UIKalibrering kalibrering;
        private UIKontrolform kontrolform;
        private UIMonitor monitor;
        private UINulpunktsjustering nulpunktsjustering;
        public UILogin(iOPVitalsBL myBl)
        {
            InitializeComponent();
            this.currentBl = myBl;
        }

        private void UILogin_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            currentBl.GetEmployeeDTO().EmployeeID_ = EmployeeIDTextBox.Text;
            currentBl.GetEmployeeDTO().Password_ = PasswordTextBox.Text;
            if (currentBl.ValidateLogin(currentBl.GetEmployeeDTO()) == true)
            {
                if (Profession(currentBl.GetEmployeeDTO().Profession_)==1)
                {
                    this.Hide();
                    kontrolform = new UIKontrolform(currentBl);
                    monitor = new UIMonitor(currentBl);
                    kontrolform.Show();
                    monitor.Show();
                    nulpunktsjustering = new UINulpunktsjustering();
                    var result = nulpunktsjustering.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Nulpunktsjustering påbegyndes");
                    }


                }
                if(Profession(currentBl.GetEmployeeDTO().Profession_)==2)
                {
                    kalibrering = new UIKalibrering(currentBl);
                    kalibrering.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Forkert medarbejder id eller kodeord. Prøv igen.");
            }
        }

        private int Profession(string profession)
        {
            if (string.Equals(profession, "OpSygeplejerske")) //Det er vigtigt at professionerne står præcies sådan i databasen
            {
                return 1;
            }

            if (string.Equals(profession, "Tekniker")) //Det er vigtigt at professionerne står præcies sådan i databasen
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
