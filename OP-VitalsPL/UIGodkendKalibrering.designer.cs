namespace OP_VitalsPL
{
    partial class UIGodkendKalibrering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIGodkendKalibrering));
            this.label1 = new System.Windows.Forms.Label();
            this.CalibrationAccept = new System.Windows.Forms.Button();
            this.CalibrationCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Skal Kalibrering godkendes ?";
            // 
            // CalibrationAccept
            // 
            this.CalibrationAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalibrationAccept.Location = new System.Drawing.Point(59, 111);
            this.CalibrationAccept.Name = "CalibrationAccept";
            this.CalibrationAccept.Size = new System.Drawing.Size(78, 30);
            this.CalibrationAccept.TabIndex = 1;
            this.CalibrationAccept.Text = "Godkend";
            this.CalibrationAccept.UseVisualStyleBackColor = true;
            this.CalibrationAccept.Click += new System.EventHandler(this.CalibrationAccept_Click);
            // 
            // CalibrationCancel
            // 
            this.CalibrationCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalibrationCancel.Location = new System.Drawing.Point(178, 111);
            this.CalibrationCancel.Name = "CalibrationCancel";
            this.CalibrationCancel.Size = new System.Drawing.Size(80, 30);
            this.CalibrationCancel.TabIndex = 2;
            this.CalibrationCancel.Text = "Annuller";
            this.CalibrationCancel.UseVisualStyleBackColor = true;
            this.CalibrationCancel.Click += new System.EventHandler(this.CalibrationCancel_Click);
            // 
            // UIGodkendKalibrering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 184);
            this.Controls.Add(this.CalibrationCancel);
            this.Controls.Add(this.CalibrationAccept);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIGodkendKalibrering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Vitals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CalibrationAccept;
        private System.Windows.Forms.Button CalibrationCancel;
    }
}