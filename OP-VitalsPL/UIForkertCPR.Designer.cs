namespace OP_VitalsPL
{
    partial class UIForkertCPR
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CPRWrongButton = new System.Windows.Forms.Button();
            this.CPROKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Det indtastede CPR-nummer\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "er ikke et gyldigt";
            // 
            // CPRWrongButton
            // 
            this.CPRWrongButton.Location = new System.Drawing.Point(45, 151);
            this.CPRWrongButton.Name = "CPRWrongButton";
            this.CPRWrongButton.Size = new System.Drawing.Size(118, 30);
            this.CPRWrongButton.TabIndex = 2;
            this.CPRWrongButton.Text = "Indtast CPR igen";
            this.CPRWrongButton.UseVisualStyleBackColor = true;
            this.CPRWrongButton.Click += new System.EventHandler(this.CPRWrongButton_Click);
            // 
            // CPROKButton
            // 
            this.CPROKButton.Location = new System.Drawing.Point(194, 151);
            this.CPROKButton.Name = "CPROKButton";
            this.CPROKButton.Size = new System.Drawing.Size(111, 30);
            this.CPROKButton.TabIndex = 3;
            this.CPROKButton.Text = "Godtag CPR";
            this.CPROKButton.UseVisualStyleBackColor = true;
            this.CPROKButton.Click += new System.EventHandler(this.CPROKButton_Click);
            // 
            // UIForkertCPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 211);
            this.Controls.Add(this.CPROKButton);
            this.Controls.Add(this.CPRWrongButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UIForkertCPR";
            this.Text = "UIForkertCPR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CPRWrongButton;
        private System.Windows.Forms.Button CPROKButton;
    }
}