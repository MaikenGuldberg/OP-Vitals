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
    public partial class UIMonitor : Form, IMeanFilterObserver, ICalcSysObserver, ICalcDiaObserver, ICalcMeanBloodPressureObserver, ICalcPulsObserver
    {
        private iOPVitalsBL currentBl;
        public UIMonitor(iOPVitalsBL mybl)
        {
            InitializeComponent();
            currentBl = mybl;
            currentBl.AttachToMeanFilter(this);
            currentBl.AttachToCalcSys(this);
            currentBl.AttachToCalcDia(this);
            currentBl.AttachToMeanBloodPressure(this);
            currentBl.AttachToCalcPuls(this);
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
    }
}
