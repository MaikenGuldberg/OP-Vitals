using System.Drawing;

namespace OP_VitalsPL
{
    partial class UIKontrolform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIKontrolform));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.HourTextBox = new System.Windows.Forms.TextBox();
            this.MinuteTextBox = new System.Windows.Forms.TextBox();
            this.SecondsTextBox = new System.Windows.Forms.TextBox();
            this.NoComplications = new System.Windows.Forms.CheckBox();
            this.Complications = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.SaveComment = new System.Windows.Forms.Button();
            this.KontrolLogOutButton = new System.Windows.Forms.Button();
            this.FilterOff = new System.Windows.Forms.RadioButton();
            this.FilterOn = new System.Windows.Forms.RadioButton();
            this.StopKontrolButton = new System.Windows.Forms.Button();
            this.StartKontrolButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SysValue = new System.Windows.Forms.Label();
            this.DiaValue = new System.Windows.Forms.Label();
            this.MeanBloodPressureValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PulsValue = new System.Windows.Forms.Label();
            this.ShowMonitor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.chart1.Location = new System.Drawing.Point(306, 12);
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
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            chart1.ChartAreas[0].AxisY.Minimum = 20;
            chart1.ChartAreas[0].AxisY.Maximum = 240;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operationtid:";
            // 
            // HourTextBox
            // 
            this.HourTextBox.Location = new System.Drawing.Point(7, 51);
            this.HourTextBox.Name = "HourTextBox";
            this.HourTextBox.Size = new System.Drawing.Size(41, 22);
            this.HourTextBox.TabIndex = 3;
            this.HourTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HourTextBox.TextChanged += new System.EventHandler(this.HourTextBox_TextChanged);
            // 
            // MinuteTextBox
            // 
            this.MinuteTextBox.Location = new System.Drawing.Point(66, 51);
            this.MinuteTextBox.Name = "MinuteTextBox";
            this.MinuteTextBox.Size = new System.Drawing.Size(40, 22);
            this.MinuteTextBox.TabIndex = 4;
            this.MinuteTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MinuteTextBox.TextChanged += new System.EventHandler(this.MinuteTextBox_TextChanged);
            // 
            // SecondsTextBox
            // 
            this.SecondsTextBox.Location = new System.Drawing.Point(131, 51);
            this.SecondsTextBox.Name = "SecondsTextBox";
            this.SecondsTextBox.Size = new System.Drawing.Size(40, 22);
            this.SecondsTextBox.TabIndex = 5;
            this.SecondsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SecondsTextBox.TextChanged += new System.EventHandler(this.SecondsTextBox_TextChanged);
            // 
            // NoComplications
            // 
            this.NoComplications.AutoSize = true;
            this.NoComplications.Location = new System.Drawing.Point(6, 45);
            this.NoComplications.Name = "NoComplications";
            this.NoComplications.Size = new System.Drawing.Size(148, 20);
            this.NoComplications.TabIndex = 7;
            this.NoComplications.Text = "uden komplikationer";
            this.NoComplications.UseVisualStyleBackColor = true;
            this.NoComplications.CheckedChanged += new System.EventHandler(this.NoComplications_CheckedChanged);
            // 
            // Complications
            // 
            this.Complications.AutoSize = true;
            this.Complications.Location = new System.Drawing.Point(160, 45);
            this.Complications.Name = "Complications";
            this.Complications.Size = new System.Drawing.Size(97, 20);
            this.Complications.TabIndex = 8;
            this.Complications.Text = "kompliceret";
            this.Complications.UseVisualStyleBackColor = true;
            this.Complications.CheckedChanged += new System.EventHandler(this.Complications_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Beskrivelse";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(6, 111);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(243, 82);
            this.Description.TabIndex = 10;
            this.Description.Text = "";
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // SaveComment
            // 
            this.SaveComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveComment.Location = new System.Drawing.Point(12, 360);
            this.SaveComment.Name = "SaveComment";
            this.SaveComment.Size = new System.Drawing.Size(129, 35);
            this.SaveComment.TabIndex = 11;
            this.SaveComment.Text = "Gem Kommentar";
            this.SaveComment.UseVisualStyleBackColor = true;
            this.SaveComment.Click += new System.EventHandler(this.SaveComment_Click);
            // 
            // KontrolLogOutButton
            // 
            this.KontrolLogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KontrolLogOutButton.Location = new System.Drawing.Point(1634, 621);
            this.KontrolLogOutButton.Name = "KontrolLogOutButton";
            this.KontrolLogOutButton.Size = new System.Drawing.Size(75, 29);
            this.KontrolLogOutButton.TabIndex = 12;
            this.KontrolLogOutButton.Text = "Log  ud";
            this.KontrolLogOutButton.UseVisualStyleBackColor = true;
            this.KontrolLogOutButton.Click += new System.EventHandler(this.KontrolLogOutButton_Click);
            // 
            // FilterOff
            // 
            this.FilterOff.AutoSize = true;
            this.FilterOff.Location = new System.Drawing.Point(24, 36);
            this.FilterOff.Name = "FilterOff";
            this.FilterOff.Size = new System.Drawing.Size(75, 20);
            this.FilterOff.TabIndex = 14;
            this.FilterOff.Text = "Ufiltreret";
            this.FilterOff.UseVisualStyleBackColor = true;
            this.FilterOff.CheckedChanged += new System.EventHandler(this.FilterOff_CheckedChanged);
            // 
            // FilterOn
            // 
            this.FilterOn.AutoSize = true;
            this.FilterOn.Checked = true;
            this.FilterOn.Location = new System.Drawing.Point(149, 36);
            this.FilterOn.Name = "FilterOn";
            this.FilterOn.Size = new System.Drawing.Size(70, 20);
            this.FilterOn.TabIndex = 15;
            this.FilterOn.TabStop = true;
            this.FilterOn.Text = "Filtreret";
            this.FilterOn.UseVisualStyleBackColor = true;
            // 
            // StopKontrolButton
            // 
            this.StopKontrolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopKontrolButton.Location = new System.Drawing.Point(91, 521);
            this.StopKontrolButton.Name = "StopKontrolButton";
            this.StopKontrolButton.Size = new System.Drawing.Size(75, 23);
            this.StopKontrolButton.TabIndex = 16;
            this.StopKontrolButton.Text = "Stop";
            this.StopKontrolButton.UseVisualStyleBackColor = true;
            this.StopKontrolButton.Click += new System.EventHandler(this.StopKontrolButton_Click);
            // 
            // StartKontrolButton
            // 
            this.StartKontrolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartKontrolButton.Location = new System.Drawing.Point(9, 521);
            this.StartKontrolButton.Name = "StartKontrolButton";
            this.StartKontrolButton.Size = new System.Drawing.Size(75, 23);
            this.StartKontrolButton.TabIndex = 17;
            this.StartKontrolButton.Text = "Start";
            this.StartKontrolButton.UseVisualStyleBackColor = true;
            this.StartKontrolButton.Click += new System.EventHandler(this.StartKontrolButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HourTextBox);
            this.groupBox1.Controls.Add(this.MinuteTextBox);
            this.groupBox1.Controls.Add(this.SecondsTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operationsoplysninger";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NoComplications);
            this.groupBox2.Controls.Add(this.Complications);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Description);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 210);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General forløb af operation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FilterOff);
            this.groupBox3.Controls.Add(this.FilterOn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 66);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter indstillinger";
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
            // ShowMonitor
            // 
            this.ShowMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMonitor.Location = new System.Drawing.Point(172, 521);
            this.ShowMonitor.Name = "ShowMonitor";
            this.ShowMonitor.Size = new System.Drawing.Size(75, 23);
            this.ShowMonitor.TabIndex = 31;
            this.ShowMonitor.Text = "Monitor";
            this.ShowMonitor.UseVisualStyleBackColor = true;
            this.ShowMonitor.Click += new System.EventHandler(this.ShowMonitor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(164, 360);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Location = new System.Drawing.Point(1472, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 575);
            this.panel1.TabIndex = 33;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(798, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 34;
            this.label5.Text = "10 sekunder";
            // 
            // UIKontrolform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1766, 722);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ShowMonitor);
            this.Controls.Add(this.SaveComment);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartKontrolButton);
            this.Controls.Add(this.StopKontrolButton);
            this.Controls.Add(this.KontrolLogOutButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIKontrolform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Vitals";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HourTextBox;
        private System.Windows.Forms.TextBox MinuteTextBox;
        private System.Windows.Forms.TextBox SecondsTextBox;
        private System.Windows.Forms.CheckBox NoComplications;
        private System.Windows.Forms.CheckBox Complications;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox Description;
        private System.Windows.Forms.Button SaveComment;
        private System.Windows.Forms.Button KontrolLogOutButton;
        private System.Windows.Forms.RadioButton FilterOff;
        private System.Windows.Forms.RadioButton FilterOn;
        private System.Windows.Forms.Button StopKontrolButton;
        private System.Windows.Forms.Button StartKontrolButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label SysValue;
        private System.Windows.Forms.Label DiaValue;
        private System.Windows.Forms.Label MeanBloodPressureValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PulsValue;
        private System.Windows.Forms.Button ShowMonitor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}