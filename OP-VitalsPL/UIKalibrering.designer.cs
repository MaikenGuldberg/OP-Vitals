namespace OP_VitalsPL
{
    partial class UIKalibrering
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIKalibrering));
            this.label1 = new System.Windows.Forms.Label();
            this.TrykTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddMButton = new System.Windows.Forms.Button();
            this.DeleteMPointButton = new System.Windows.Forms.Button();
            this.RTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CalibrationLogOut = new System.Windows.Forms.Button();
            this.CalibrationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Measurepoints = new System.Windows.Forms.ListView();
            this.Volts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pressure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CalibrationChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kalibrering af OP-Vitals";
            // 
            // TrykTextBox
            // 
            this.TrykTextBox.Location = new System.Drawing.Point(95, 31);
            this.TrykTextBox.Name = "TrykTextBox";
            this.TrykTextBox.Size = new System.Drawing.Size(80, 22);
            this.TrykTextBox.TabIndex = 2;
            this.TrykTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrykTextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tryk(mmHg)";
            // 
            // AddMButton
            // 
            this.AddMButton.Location = new System.Drawing.Point(195, 31);
            this.AddMButton.Name = "AddMButton";
            this.AddMButton.Size = new System.Drawing.Size(75, 23);
            this.AddMButton.TabIndex = 6;
            this.AddMButton.Text = "Tilføj Måling";
            this.AddMButton.UseVisualStyleBackColor = true;
            this.AddMButton.Click += new System.EventHandler(this.AddMButton_Click);
            // 
            // DeleteMPointButton
            // 
            this.DeleteMPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteMPointButton.Location = new System.Drawing.Point(12, 387);
            this.DeleteMPointButton.Name = "DeleteMPointButton";
            this.DeleteMPointButton.Size = new System.Drawing.Size(110, 32);
            this.DeleteMPointButton.TabIndex = 9;
            this.DeleteMPointButton.Text = "Slet Målepunkt";
            this.DeleteMPointButton.UseVisualStyleBackColor = true;
            this.DeleteMPointButton.Click += new System.EventHandler(this.DeleteMPointButton_Click);
            // 
            // RTextBox
            // 
            this.RTextBox.Enabled = false;
            this.RTextBox.Location = new System.Drawing.Point(937, 140);
            this.RTextBox.Name = "RTextBox";
            this.RTextBox.ReadOnly = true;
            this.RTextBox.Size = new System.Drawing.Size(111, 20);
            this.RTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(898, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "R^2";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptButton.Location = new System.Drawing.Point(937, 445);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(111, 30);
            this.AcceptButton.TabIndex = 12;
            this.AcceptButton.Text = "Godkend";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CalibrationLogOut
            // 
            this.CalibrationLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalibrationLogOut.Location = new System.Drawing.Point(967, 27);
            this.CalibrationLogOut.Name = "CalibrationLogOut";
            this.CalibrationLogOut.Size = new System.Drawing.Size(81, 25);
            this.CalibrationLogOut.TabIndex = 14;
            this.CalibrationLogOut.Text = "Log ud";
            this.CalibrationLogOut.UseVisualStyleBackColor = true;
            this.CalibrationLogOut.Click += new System.EventHandler(this.CalibrationLogOut_Click);
            // 
            // CalibrationChart
            // 
            this.CalibrationChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.CalibrationChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.CalibrationChart.Legends.Add(legend1);
            this.CalibrationChart.Location = new System.Drawing.Point(288, 72);
            this.CalibrationChart.Name = "CalibrationChart";
            this.CalibrationChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Punkter";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "LineærRegression";
            this.CalibrationChart.Series.Add(series1);
            this.CalibrationChart.Series.Add(series2);
            this.CalibrationChart.Size = new System.Drawing.Size(789, 300);
            this.CalibrationChart.TabIndex = 16;
            this.CalibrationChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TrykTextBox);
            this.groupBox1.Controls.Add(this.AddMButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 70);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // Measurepoints
            // 
            this.Measurepoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Volts,
            this.Pressure});
            this.Measurepoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Measurepoints.FullRowSelect = true;
            this.Measurepoints.GridLines = true;
            this.Measurepoints.Location = new System.Drawing.Point(12, 172);
            this.Measurepoints.Name = "Measurepoints";
            this.Measurepoints.Size = new System.Drawing.Size(270, 200);
            this.Measurepoints.TabIndex = 18;
            this.Measurepoints.UseCompatibleStateImageBehavior = false;
            this.Measurepoints.View = System.Windows.Forms.View.Details;
            // 
            // Volts
            // 
            this.Volts.Text = "Spænding(mV)";
            this.Volts.Width = 129;
            // 
            // Pressure
            // 
            this.Pressure.Text = "Tryk (mmHg)";
            this.Pressure.Width = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Spænding (mV)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tryk (mmHg)";
            // 
            // UIKalibrering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 501);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Measurepoints);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CalibrationLogOut);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RTextBox);
            this.Controls.Add(this.DeleteMPointButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalibrationChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIKalibrering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Vitals";
            ((System.ComponentModel.ISupportInitialize)(this.CalibrationChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TrykTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddMButton;
        private System.Windows.Forms.Button DeleteMPointButton;
        private System.Windows.Forms.TextBox RTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button CalibrationLogOut;
        private System.Windows.Forms.DataVisualization.Charting.Chart CalibrationChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView Measurepoints;
        private System.Windows.Forms.ColumnHeader Volts;
        private System.Windows.Forms.ColumnHeader Pressure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}