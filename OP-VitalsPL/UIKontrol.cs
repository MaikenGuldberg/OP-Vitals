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
using System.Threading;

namespace OP_VitalsPL
{
    public partial class UIKontrol : Form,MeanFilterObserver,CalcSysObserver, CalcDiaObserver,CalcMeanBloodPressureObserver,CalcPulsObserver
    {
        private iOPVitalsBL currentBl;
        private UILogin login;
        private UIMonitor monitor;
        private string _commentssaved =
            @"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\Flueben-200x198.png";

        private string _commentsnotsaved = @"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\Red-x.png";
        private bool monitorstartet;

        private string[] lines;
        private int houre;
        private int minute;
        private int second;
        private bool startpressed;
        public UIKontrol(iOPVitalsBL mybl,UILogin UILogin)
        {
            this.currentBl = mybl;
            login = UILogin;
            currentBl.AttachToMeanFilter(this);
            currentBl.AttachToCalcSys(this);
            currentBl.AttachToCalcDia(this);
            currentBl.AttachToMeanBloodPressure(this);
            currentBl.AttachToCalcPuls(this);
            InitializeComponent();
            monitorstartet = false;
            startpressed = false;

            DefaultComments();
        }

        private void DefaultComments()
        {
            lines = new[] { "Der er ikke indtastet kommentar" };
            houre = 0;
            minute = 0;
            second = 0;
        }

        public void UpdateDiaGUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    DiaValue.Text = Convert.ToString(currentBl.GetDia());

                });
            }
        }

        public void UpdateMeanBloodPressureGUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    MeanBloodPressureValue.Text = Convert.ToString(currentBl.GetMeanBloodPressure());
                });
            }
        }

        public void UpdateMeanFilterGUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    var showlist = currentBl.GetDisplayList();

                    chart1.Series["Series1"].Points.Clear();

                    for (int i = 1; i < showlist.Count; i++)
                    {
                        chart1.Series["Series1"].Points.AddXY(i, showlist[i]);
                    }
                });
            }
        }

        public void UpdatePulsGUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    PulsValue.Text = Convert.ToString(currentBl.GetPuls());

                });
            }
        }

        public void UpdateSysGUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)delegate
                {
                    SysValue.Text = Convert.ToString(currentBl.GetSys());

                });
            }
        }

        private void StartKontrolButton_Click(object sender, EventArgs e)
        {
            currentBl.StopThreads(false); //tjekkes om denne behøves
            currentBl.StartChartThread();
            startpressed = true;
        }

        private void StopKontrolButton_Click(object sender, EventArgs e)
        {
            string[] lines = new[] { "Der er ikke indtastet kommentar" };
            int houre = 0;
            int minute = 0;
            int second = 0;
            currentBl.StopThreads(true);
            currentBl.SaveComments(lines, houre, minute, second, ComplicationsCheck());
            currentBl.SaveInDatabase();
            startpressed = false;
        }

        private void KontrolLogOutButton_Click(object sender, EventArgs e)
        {
            currentBl.StopThreads(true);
            if (monitorstartet == true)
            {
                monitor.Hide();
            }
            if (startpressed == true)
            {
                currentBl.SaveInDatabase();
            }
            currentBl.SaveComments(lines,houre,minute,second,ComplicationsCheck());
            DefaultComments();
            this.Hide();
            login.Show();
        }

        private void ShowMonitor_Click(object sender, EventArgs e)
        {
            monitor = new UIMonitor(currentBl);
            monitor.Show();
            monitorstartet = true;
        }

        private void SaveComment_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(Description.Text)!=true)
            {
                lines = Description.Text.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);
            }
            if (string.IsNullOrWhiteSpace(HourTextBox.Text) != true)
            {
                houre = Convert.ToInt16(HourTextBox.Text);
            }
            if (string.IsNullOrWhiteSpace(MinuteTextBox.Text) != true)
            {
                minute = Convert.ToInt16(MinuteTextBox.Text);
            }
            if (string.IsNullOrWhiteSpace(SecondsTextBox.Text) != true)
            {
                second = Convert.ToInt16(SecondsTextBox.Text);
            }
            currentBl.SaveComments(lines, houre, minute, second,ComplicationsCheck());
            
            pictureBox1.Image = Image.FromFile(_commentssaved);
        }

        private int ComplicationsCheck()
        {
            if (NoComplications.Checked == true)
            {
                return 0;
            }
            else if (Complications.Checked == true)
            {
                return 1;
            }
            else
            {
                return 3;
            }
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void NoComplications_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void Complications_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void HourTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void MinuteTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void SecondsTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(_commentsnotsaved);
        }

        private void FilterOff_CheckedChanged(object sender, EventArgs e)
        {
            if (FilterOff.Checked == true)
            {
                currentBl.SetFilter("NoFilter");
            }
            else if (FilterOn.Checked == true)
            {
                currentBl.SetFilter("Butterworth");
            }
        }
    }
}
