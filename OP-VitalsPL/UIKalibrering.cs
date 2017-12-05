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
using System.Drawing.Text;
using System.Windows.Forms.Design;
using Interfaces;
using DTO;


namespace OP_VitalsPL
{
    public partial class UIKalibrering : Form
    {
        private iOPVitalsBL currentBl;
        private UIGodkendKalibrering godkendKalibrering; //Godkend kalibrerings
        private bool PointDeletet; //Bool værdi der benyttes til at finde ud af og der er slettet et punkt fra listen af punkter der er indtastet. Denne benyttes til at finde ud af hvornår listen af punkter skal sorteres
        private UILogin login; //Loginformen
        
        public UIKalibrering(iOPVitalsBL myBl,UILogin UILogin)
        {
            InitializeComponent();
            this.currentBl = myBl;
            PointDeletet = false;
            myBl.InitiateDaqFromBL(false); //initaliserer den version af daqen der ikke benytter concurrentque
            login = UILogin;
        }

       

        private void AddMButton_Click(object sender, EventArgs e)
        {
           currentBl.AddToCalibrationlist(Convert.ToDouble(TrykTextBox.Text)); //Tilføjer et punkt til calibrationslisten
            SortList(currentBl.GetCalibrationList());
            if (PointDeletet == true) //Undersøger om der er slettet et punkt og hvis der er det sorteres listen
            {
                SortList(currentBl.GetCalibrationList()); //sorterer listen
                PointDeletet = false;
            }
           AddPointToListView(currentBl.GetCalibrationList()); //Metode der viser punktet i listview elementet på formen
           DrawChartPoints(); //Viser punktet som et punkt på en graf
            if (currentBl.GetCalibrationList().Count >= 3) //tjekker om listen indeholder minimum 3 punkter
            {
                DrawLinearRegression(); //laver lineær regression på de indtastede punkter og tegner denne
                RTextBox.Text = Convert.ToString(Math.Round(currentBl.GetRsquared_(),4)); //viser R^2 værdien på formen
            }
            TrykTextBox.Clear(); 
        

        }

        private void DrawChartPoints() //metoden tegner punkterne 
        {
            CalibrationChart.Series["Punkter"].Points.Clear(); 
            for (int i = 0; i < currentBl.GetCalibrationList().Count; i++)
            {
                CalibrationChart.Series["Punkter"].Points.AddXY(currentBl.GetCalibrationList()[i].Voltage_,
                    currentBl.GetCalibrationList()[i].Pressure_);
            }
        }

        private void DrawLinearRegression()
        {
            CalibrationChart.Series["LineærRegression"].Points.Clear();
            currentBl.LinearRegression(currentBl.GetCalibrationList()); //laver lineær regression over kalibreringslisten
            for (int i = 1; i < 2150; i++) //laver den linje der viser den lineære regression
            {
                CalibrationChart.Series["LineærRegression"].Points
                    .AddXY(i, i * currentBl.GetSlope_() + currentBl.GetYintercept_());
            }
        }

        private void AddPointToListView(List<CalibrationPointDTO> listofpoints) //tilføjer punkter til den liste der viser punkterne
        {
            Measurepoints.Items.Clear();
            for (int i = 0; i < listofpoints.Count; i++)
            {
                ListViewItem item = new ListViewItem(Math.Round(listofpoints[i].Voltage_).ToString()); //laver et listview element og sætter denne til at være spændingen
                item.SubItems.Add(listofpoints[i].Pressure_.ToString()); //sætter et subelement til listview elementet. Dette element er trykket
                Measurepoints.Items.Add(item); //Tilføjer punkterne til listview
            }
        }

        private void DeleteMPointButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Measurepoints.Items.Count; i++) //løber alle punkterne i listview elementet igennem
            {
                if (Measurepoints.Items[i].Selected) //tjekker om hver punkt er valgt
                {
                    Measurepoints.Items[i].Remove(); //sletter punktet fra listview elementet
                    currentBl.GetCalibrationList().RemoveAt(i); //sletter punktet fra kalibreringslisten
                    DrawChartPoints(); //tegner punkterne igen nu uden det slettede punkt
                    RTextBox.Clear(); //sletter R^2 værdien fra formen
                    if (currentBl.GetCalibrationList().Count >= 3) //tjekker om der er nok punkter til at lave lineær regression
                    {
                        DrawLinearRegression();
                        RTextBox.Text = Convert.ToString(currentBl.GetRsquared_());
                    }
                    if (currentBl.GetCalibrationList().Count < 3)
                    {
                        CalibrationChart.Series["LineærRegression"].Points.Clear();
                    }
                    i--; //tjek om dette er nødvendigt
                }
            }
            PointDeletet = true; //viser at der er slettet et punkt
        }

        private void SortList(List<CalibrationPointDTO> list) //denne metode benyttes til at sorterer listen
        {
            list.Sort((x,y) => x.Pressure_.CompareTo(y.Pressure_)); //sorterer listen efter tryk
        }

        private void TrykTextBox_KeyDown(object sender, KeyEventArgs e) //denne event sikre at når der trykkes enter tilføjes punktet
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMButton_Click(this,new EventArgs());
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e) //denne event dannes når der trykkes på godkend knappen
        {
            godkendKalibrering = new UIGodkendKalibrering();
            var result = godkendKalibrering.ShowDialog(); // laver UIGodkendKalibrering til en modalform
            if (result == DialogResult.OK) //hvis der er trykket på godkend kalibrering gemmes kalibreringen og login vises.
            {
                currentBl.SaveCalibration();
                Logout();
                this.Hide();
                login.Show();
                currentBl.GetCalibrationList().Clear();
            }
            if (result == DialogResult.Cancel) //hvis der trykkes på annuller lukkes modalformen
            {
                
            }
        }

        private void Logout()
        {
            currentBl.GetCalibrationList().Clear();
            Measurepoints.Items.Clear();
            CalibrationChart.Series["LineærRegression"].Points.Clear();
            CalibrationChart.Series["Punkter"].Points.Clear();
            RTextBox.Clear();

        }
        
    }
}
