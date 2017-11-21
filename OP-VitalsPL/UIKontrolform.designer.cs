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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SysValue = new System.Windows.Forms.Label();
            this.DiaValue = new System.Windows.Forms.Label();
            this.MeanBloodPressureValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(265, -10);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1173, 399);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operationtid";
            // 
            // HourTextBox
            // 
            this.HourTextBox.Location = new System.Drawing.Point(7, 51);
            this.HourTextBox.Name = "HourTextBox";
            this.HourTextBox.Size = new System.Drawing.Size(41, 20);
            this.HourTextBox.TabIndex = 3;
            // 
            // MinuteTextBox
            // 
            this.MinuteTextBox.Location = new System.Drawing.Point(66, 51);
            this.MinuteTextBox.Name = "MinuteTextBox";
            this.MinuteTextBox.Size = new System.Drawing.Size(40, 20);
            this.MinuteTextBox.TabIndex = 4;
            // 
            // SecondsTextBox
            // 
            this.SecondsTextBox.Location = new System.Drawing.Point(131, 51);
            this.SecondsTextBox.Name = "SecondsTextBox";
            this.SecondsTextBox.Size = new System.Drawing.Size(40, 20);
            this.SecondsTextBox.TabIndex = 5;
            // 
            // NoComplications
            // 
            this.NoComplications.AutoSize = true;
            this.NoComplications.Location = new System.Drawing.Point(6, 19);
            this.NoComplications.Name = "NoComplications";
            this.NoComplications.Size = new System.Drawing.Size(121, 17);
            this.NoComplications.TabIndex = 7;
            this.NoComplications.Text = "uden komplikationer";
            this.NoComplications.UseVisualStyleBackColor = true;
            // 
            // Complications
            // 
            this.Complications.AutoSize = true;
            this.Complications.Location = new System.Drawing.Point(152, 19);
            this.Complications.Name = "Complications";
            this.Complications.Size = new System.Drawing.Size(80, 17);
            this.Complications.TabIndex = 8;
            this.Complications.Text = "kompliceret";
            this.Complications.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Beskrivelse";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(6, 78);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(170, 52);
            this.Description.TabIndex = 10;
            this.Description.Text = "";
            // 
            // SaveComment
            // 
            this.SaveComment.Location = new System.Drawing.Point(9, 142);
            this.SaveComment.Name = "SaveComment";
            this.SaveComment.Size = new System.Drawing.Size(127, 23);
            this.SaveComment.TabIndex = 11;
            this.SaveComment.Text = "Gem Kommentar";
            this.SaveComment.UseVisualStyleBackColor = true;
            // 
            // KontrolLogOutButton
            // 
            this.KontrolLogOutButton.Location = new System.Drawing.Point(562, 477);
            this.KontrolLogOutButton.Name = "KontrolLogOutButton";
            this.KontrolLogOutButton.Size = new System.Drawing.Size(75, 23);
            this.KontrolLogOutButton.TabIndex = 12;
            this.KontrolLogOutButton.Text = "Log  ud";
            this.KontrolLogOutButton.UseVisualStyleBackColor = true;
            // 
            // FilterOff
            // 
            this.FilterOff.AutoSize = true;
            this.FilterOff.Location = new System.Drawing.Point(5, 36);
            this.FilterOff.Name = "FilterOff";
            this.FilterOff.Size = new System.Drawing.Size(64, 17);
            this.FilterOff.TabIndex = 14;
            this.FilterOff.TabStop = true;
            this.FilterOff.Text = "Ufiltreret";
            this.FilterOff.UseVisualStyleBackColor = true;
            // 
            // FilterOn
            // 
            this.FilterOn.AutoSize = true;
            this.FilterOn.Location = new System.Drawing.Point(102, 36);
            this.FilterOn.Name = "FilterOn";
            this.FilterOn.Size = new System.Drawing.Size(59, 17);
            this.FilterOn.TabIndex = 15;
            this.FilterOn.TabStop = true;
            this.FilterOn.Text = "Filtreret";
            this.FilterOn.UseVisualStyleBackColor = true;
            // 
            // StopKontrolButton
            // 
            this.StopKontrolButton.Location = new System.Drawing.Point(450, 477);
            this.StopKontrolButton.Name = "StopKontrolButton";
            this.StopKontrolButton.Size = new System.Drawing.Size(75, 23);
            this.StopKontrolButton.TabIndex = 16;
            this.StopKontrolButton.Text = "Stop";
            this.StopKontrolButton.UseVisualStyleBackColor = true;
            this.StopKontrolButton.Click += new System.EventHandler(this.StopKontrolButton_Click);
            // 
            // StartKontrolButton
            // 
            this.StartKontrolButton.Location = new System.Drawing.Point(345, 477);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 100);
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
            this.groupBox2.Controls.Add(this.SaveComment);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 179);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General forløb af operation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FilterOff);
            this.groupBox3.Controls.Add(this.FilterOn);
            this.groupBox3.Location = new System.Drawing.Point(307, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(179, 66);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter indstillinger";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1273, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Puls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1294, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sys";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1295, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 24);
            this.label5.TabIndex = 24;
            this.label5.Text = "Dia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1295, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "MBT";
            // 
            // SysValue
            // 
            this.SysValue.AutoSize = true;
            this.SysValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SysValue.ForeColor = System.Drawing.Color.Red;
            this.SysValue.Location = new System.Drawing.Point(1355, 45);
            this.SysValue.Name = "SysValue";
            this.SysValue.Size = new System.Drawing.Size(30, 31);
            this.SysValue.TabIndex = 26;
            this.SysValue.Text = "0";
            // 
            // DiaValue
            // 
            this.DiaValue.AutoSize = true;
            this.DiaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaValue.ForeColor = System.Drawing.Color.Lime;
            this.DiaValue.Location = new System.Drawing.Point(1355, 92);
            this.DiaValue.Name = "DiaValue";
            this.DiaValue.Size = new System.Drawing.Size(30, 31);
            this.DiaValue.TabIndex = 27;
            this.DiaValue.Text = "0";
            // 
            // MeanBloodPressureValue
            // 
            this.MeanBloodPressureValue.AutoSize = true;
            this.MeanBloodPressureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeanBloodPressureValue.Location = new System.Drawing.Point(1355, 141);
            this.MeanBloodPressureValue.Name = "MeanBloodPressureValue";
            this.MeanBloodPressureValue.Size = new System.Drawing.Size(30, 31);
            this.MeanBloodPressureValue.TabIndex = 28;
            this.MeanBloodPressureValue.Text = "0";
            // 
            // UIKontrolform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 578);
            this.Controls.Add(this.MeanBloodPressureValue);
            this.Controls.Add(this.DiaValue);
            this.Controls.Add(this.SysValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartKontrolButton);
            this.Controls.Add(this.StopKontrolButton);
            this.Controls.Add(this.KontrolLogOutButton);
            this.Controls.Add(this.chart1);
            this.Name = "UIKontrolform";
            this.Text = "UIKontrolform";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label SysValue;
        private System.Windows.Forms.Label DiaValue;
        private System.Windows.Forms.Label MeanBloodPressureValue;
    }
}