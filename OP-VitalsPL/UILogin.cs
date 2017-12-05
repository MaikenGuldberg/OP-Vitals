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
        private UINulpunktsjustering nulpunktsjustering;
        private UI_NulpunktsjusteringsFejl nulpunktsjusteringsFejl;
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
            currentBl.employee.EmployeeID_ = EmployeeIDTextBox.Text; //Gemmer id i employee dto'en
            currentBl.employee.Password_ = PasswordTextBox.Text; //Gemmer password i employee dto'en
            if (currentBl.ValidateLogin(currentBl.employee) == true) 
            {
                if (Profession(currentBl.employee.Profession_)==1) // Hvis medarbejderen er en operationssygeplejerske åbnes nulpunktsjusterings formen
                {
                    this.Hide();
                    
                    nulpunktsjustering = new UINulpunktsjustering(currentBl,this);
                    nulpunktsjustering.Show();
                    EmployeeIDTextBox.Clear();
                    PasswordTextBox.Clear();
                   
                }
                if(Profession(currentBl.employee.Profession_)==2) // Hvis medarbejeren er en tekniker åbnes kalibreringsformen
                {
                    kalibrering = new UIKalibrering(currentBl,this);
                    kalibrering.Show();
                    this.Hide();
                    EmployeeIDTextBox.Clear();
                    PasswordTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Forkert medarbejder id eller kodeord. Prøv igen."); //viser besked hvis der er noget galt med log in.
            }
        }

        private int Profession(string profession) //Metode der tjekker hvilken profession vedkommende der logger ind har.
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
