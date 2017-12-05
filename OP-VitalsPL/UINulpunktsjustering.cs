using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace OP_VitalsPL
{
    public partial class UINulpunktsjustering : Form
    {
        private iOPVitalsBL currentBl;
        private UILogin login;
        private UI_NulpunktsjusteringsFejl nulpunktsjusteringsFejl;
        private UICPR CPR;
        public UINulpunktsjustering(iOPVitalsBL mybl,UILogin UILogin)
        {
            InitializeComponent();
            currentBl = mybl;
            login = UILogin;
            currentBl.LoadCalibrationConstant(); //henter den seneste kalibreringsfil og indlæser omregningskonstanten
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nulpunktsjustering påbegyndes"); //viser at nulpunktsjusteringen er ved at begynde
            var zeroPointAdjust = currentBl.ZeroPointAdjust(); //der foretages en nulpunktsjustering
            if (zeroPointAdjust == false) //hvis nulpunktsjusteringsværdien ikke er indefor det forventede åbnes UINulpunktsjusteringsFejl formen
            {
                this.Hide();
                nulpunktsjusteringsFejl = new UI_NulpunktsjusteringsFejl(currentBl,login);
                nulpunktsjusteringsFejl.Show();
            }
            else if (zeroPointAdjust == true) //Hvis nulpunktsjusteringsværdien er indenfor det forventede åbnes UICPR formen
            {
                this.Hide();
                CPR = new UICPR(currentBl,login);
                CPR.Show();
            }
        }
    }
}
