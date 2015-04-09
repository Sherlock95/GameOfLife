namespace Living_Life
{
    partial class BuyCar
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
            this.lstCars = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstCars
            // 
            this.lstCars.FormattingEnabled = true;
            this.lstCars.Location = new System.Drawing.Point(13, 13);
            this.lstCars.Name = "lstCars";
            this.lstCars.Size = new System.Drawing.Size(742, 524);
            this.lstCars.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnConfirm.Location = new System.Drawing.Point(13, 570);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(172, 48);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(583, 570);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 48);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWarning.Location = new System.Drawing.Point(209, 583);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(351, 20);
            this.lblWarning.TabIndex = 3;
            this.lblWarning.Text = "Remember: You can only have one car at a time!";
            // 
            // BuyCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 654);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lstCars);
            this.Name = "BuyCar";
            this.Text = "Buy Car";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCars;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWarning;
    }
}