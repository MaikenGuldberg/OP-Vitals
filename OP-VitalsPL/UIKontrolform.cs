﻿using System;
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
    public partial class UIKontrolform : Form,IMeanFilterObserver
    {
        private iOPVitalsBL currentBl;
        public UIKontrolform(iOPVitalsBL mybl)
        {
            this.currentBl = mybl;
            currentBl.AttachToMeanFilter(this);
            InitializeComponent();
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

        private void StartKontrolButton_Click(object sender, EventArgs e)
        {
            currentBl.StopThreads(false);
            currentBl.StartChartThread();
        }

        private void StopKontrolButton_Click(object sender, EventArgs e)
        {
            currentBl.StopThreads(true);
        }

       
        

       
    }
}
