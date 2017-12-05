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
            this.PulsValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MeanBloodPressureValue = new System.Windows.Forms.Label();
            this.DiaValue = new System.Windows.Forms.Label();
            this.SysValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // PulsValue
            // 
            this.PulsValue.AutoSize = true;
            this.PulsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PulsValue.Location = new System.Drawing.Point(1109, 248);
            this.PulsValue.Name = "PulsValue";
            this.PulsValue.Size = new System.Drawing.Size(30, 31);
            this.PulsValue.TabIndex = 39;
            this.PulsValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1048, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "Puls";
            // 
            // MeanBloodPressureValue
            // 
            this.MeanBloodPressureValue.AutoSize = true;
            this.MeanBloodPressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeanBloodPressureValue.Location = new System.Drawing.Point(1109, 199);
            this.MeanBloodPressureValue.Name = "MeanBloodPressureValue";
            this.MeanBloodPressureValue.Size = new System.Drawing.Size(30, 31);
            this.MeanBloodPressureValue.TabIndex = 37;
            this.MeanBloodPressureValue.Text = "0";
            // 
            // DiaValue
            // 
            this.DiaValue.AutoSize = true;
            this.DiaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaValue.ForeColor = System.Drawing.Color.Lime;
            this.DiaValue.Location = new System.Drawing.Point(1109, 150);
            this.DiaValue.Name = "DiaValue";
            this.DiaValue.Size = new System.Drawing.Size(30, 31);
            this.DiaValue.TabIndex = 36;
            this.DiaValue.Text = "0";
            // 
            // SysValue
            // 
            this.SysValue.AutoSize = true;
            this.SysValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysValue.ForeColor = System.Drawing.Color.Red;
            this.SysValue.Location = new System.Drawing.Point(1109, 103);
            this.SysValue.Name = "SysValue";
            this.SysValue.Size = new System.Drawing.Size(30, 31);
            this.SysValue.TabIndex = 35;
            this.SysValue.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1049, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "MBT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1049, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 24);
            this.label5.TabIndex = 33;
            this.label5.Text = "Dia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1048, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "Sys";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(19, 48);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1173, 399);
            this.chart1.TabIndex = 31;
            this.chart1.Text = "chart1";
            // 
            // UIMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 540);
            this.Controls.Add(this.PulsValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MeanBloodPressureValue);
            this.Controls.Add(this.DiaValue);
            this.Controls.Add(this.SysValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart1);
            this.Name = "UIMonitor";
            this.Text = "UIMonitor";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PulsValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MeanBloodPressureValue;
        private System.Windows.Forms.Label DiaValue;
        private System.Windows.Forms.Label SysValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}