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
    public partial class UIKontrolform : Form,IMeanFilterObserver,ICalcSysObserver, ICalcDiaObserver,ICalcMeanBloodPressureObserver,ICalcPulsObserver
    {
        private iOPVitalsBL currentBl;
        public UIKontrolform(iOPVitalsBL mybl)
        {
            this.currentBl = mybl;
            currentBl.AttachToMeanFilter(this);
            currentBl.AttachToCalcSys(this);
            currentBl.AttachToCalcDia(this);
            currentBl.AttachToMeanBloodPressure(this);
            currentBl.AttachToCalcPuls(this);
            InitializeComponent();
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
            currentBl.StopThreads(false);
            currentBl.StartChartThread();
        }

        private void StopKontrolButton_Click(object sender, EventArgs e)
        {
            currentBl.StopThreads(true);
        }

        private void SaveComment_Click(object sender, EventArgs e)
        {
            currentBl.GetOperationDTO().DurationOperation_hour_ = Convert.ToInt32(HourTextBox.Text);
            currentBl.GetOperationDTO().DurationOperation_min_ = Convert.ToInt32(MinuteTextBox.Text);
            currentBl.GetOperationDTO().DurationOperation_sec_ = Convert.ToInt32(SecondsTextBox.Text);
            if (NoComplications.Checked == false && Complications.Checked == true)
            {
                currentBl.GetOperationDTO().Complikations_ = 1;
            }
            Description.Text.ToArray();
        }
    }
}
