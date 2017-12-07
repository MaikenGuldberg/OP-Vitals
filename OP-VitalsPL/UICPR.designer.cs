namespace OP_VitalsPL
{
    partial class UICPR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UICPR));
            this.label1 = new System.Windows.Forms.Label();
            this.CPRTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CPRFindesIkkeCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UICPROKButton = new System.Windows.Forms.Button();
            this.CPR = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DiaNormal = new System.Windows.Forms.TextBox();
            this.SysNormal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CPR.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Information :";
            // 
            // CPRTextBox
            // 
            this.CPRTextBox.Location = new System.Drawing.Point(103, 37);
            this.CPRTextBox.Name = "CPRTextBox";
            this.CPRTextBox.Size = new System.Drawing.Size(145, 22);
            this.CPRTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPR-nummer:";
            // 
            // CPRFindesIkkeCheckBox
            // 
            this.CPRFindesIkkeCheckBox.AutoSize = true;
            this.CPRFindesIkkeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPRFindesIkkeCheckBox.Location = new System.Drawing.Point(9, 75);
            this.CPRFindesIkkeCheckBox.Name = "CPRFindesIkkeCheckBox";
            this.CPRFindesIkkeCheckBox.Size = new System.Drawing.Size(122, 20);
            this.CPRFindesIkkeCheckBox.TabIndex = 3;
            this.CPRFindesIkkeCheckBox.Text = "CPR findes ikke";
            this.CPRFindesIkkeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // UICPROKButton
            // 
            this.UICPROKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UICPROKButton.Location = new System.Drawing.Point(142, 325);
            this.UICPROKButton.Name = "UICPROKButton";
            this.UICPROKButton.Size = new System.Drawing.Size(86, 29);
            this.UICPROKButton.TabIndex = 10;
            this.UICPROKButton.Text = "OK";
            this.UICPROKButton.UseVisualStyleBackColor = true;
            this.UICPROKButton.Click += new System.EventHandler(this.UICPROKButton_Click);
            // 
            // CPR
            // 
            this.CPR.Controls.Add(this.CPRFindesIkkeCheckBox);
            this.CPR.Controls.Add(this.CPRTextBox);
            this.CPR.Controls.Add(this.label2);
            this.CPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPR.Location = new System.Drawing.Point(26, 43);
            this.CPR.Name = "CPR";
            this.CPR.Size = new System.Drawing.Size(312, 117);
            this.CPR.TabIndex = 11;
            this.CPR.TabStop = false;
            this.CPR.Text = "CPR";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DiaNormal);
            this.groupBox1.Controls.Add(this.SysNormal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 116);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NormalBlodtryk";
            // 
            // DiaNormal
            // 
            this.DiaNormal.Location = new System.Drawing.Point(102, 63);
            this.DiaNormal.Name = "DiaNormal";
            this.DiaNormal.Size = new System.Drawing.Size(145, 22);
            this.DiaNormal.TabIndex = 6;
            this.DiaNormal.Text = "80";
            this.DiaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SysNormal
            // 
            this.SysNormal.Location = new System.Drawing.Point(102, 31);
            this.SysNormal.Name = "SysNormal";
            this.SysNormal.Size = new System.Drawing.Size(145, 22);
            this.SysNormal.TabIndex = 4;
            this.SysNormal.Text = "120";
            this.SysNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Dia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sys:";
            // 
            // UICPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 381);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UICPROKButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CPR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UICPR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Vitals";
            this.CPR.ResumeLayout(false);
            this.CPR.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CPRTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CPRFindesIkkeCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UICPROKButton;
        private System.Windows.Forms.GroupBox CPR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DiaNormal;
        private System.Windows.Forms.TextBox SysNormal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}