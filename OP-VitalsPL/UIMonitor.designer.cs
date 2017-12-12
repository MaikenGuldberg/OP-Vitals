namespace OP_VitalsPL
{
    partial class UIMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIMonitor));
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PulsValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DiaValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SysValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MeanBloodPressureValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(474, 557);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "10 sekunder";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Orange;
            chartArea1.AxisX.MajorGrid.LineWidth = 2;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Red;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.Red;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Orange;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Red;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Red;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.BorderColor = System.Drawing.Color.White;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1169, 575);
            this.chart1.TabIndex = 35;
            this.chart1.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(35, 212);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "mmHg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(35, 196);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "(middel)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(32, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "mmHg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(32, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "bpm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "PULS";
            // 
            // PulsValue
            // 
            this.PulsValue.AutoSize = true;
            this.PulsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsValue.ForeColor = System.Drawing.Color.Lime;
            this.PulsValue.Location = new System.Drawing.Point(132, 25);
            this.PulsValue.Name = "PulsValue";
            this.PulsValue.Size = new System.Drawing.Size(62, 42);
            this.PulsValue.TabIndex = 30;
            this.PulsValue.Text = "60";
            this.PulsValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(29, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "BT";
            // 
            // DiaValue
            // 
            this.DiaValue.AutoSize = true;
            this.DiaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaValue.ForeColor = System.Drawing.Color.Red;
            this.DiaValue.Location = new System.Drawing.Point(132, 124);
            this.DiaValue.Name = "DiaValue";
            this.DiaValue.Size = new System.Drawing.Size(62, 42);
            this.DiaValue.TabIndex = 27;
            this.DiaValue.Text = "80";
            this.DiaValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(31, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "BT";
            // 
            // SysValue
            // 
            this.SysValue.AutoSize = true;
            this.SysValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysValue.ForeColor = System.Drawing.Color.Red;
            this.SysValue.Location = new System.Drawing.Point(110, 82);
            this.SysValue.Name = "SysValue";
            this.SysValue.Size = new System.Drawing.Size(84, 42);
            this.SysValue.TabIndex = 26;
            this.SysValue.Text = "120";
            this.SysValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PulsValue);
            this.panel1.Controls.Add(this.MeanBloodPressureValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DiaValue);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.SysValue);
            this.panel1.Location = new System.Drawing.Point(1190, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 599);
            this.panel1.TabIndex = 36;
            // 
            // MeanBloodPressureValue
            // 
            this.MeanBloodPressureValue.AutoSize = true;
            this.MeanBloodPressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeanBloodPressureValue.ForeColor = System.Drawing.Color.Blue;
            this.MeanBloodPressureValue.Location = new System.Drawing.Point(154, 186);
            this.MeanBloodPressureValue.Name = "MeanBloodPressureValue";
            this.MeanBloodPressureValue.Size = new System.Drawing.Size(40, 42);
            this.MeanBloodPressureValue.TabIndex = 28;
            this.MeanBloodPressureValue.Text = "0";
            this.MeanBloodPressureValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UIMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1441, 624);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Vitals";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PulsValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DiaValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label SysValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MeanBloodPressureValue;
    }
}