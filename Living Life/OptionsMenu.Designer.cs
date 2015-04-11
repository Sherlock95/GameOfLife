namespace Living_Life
{
    partial class OptionsMenu
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.btnBuyHouse = new System.Windows.Forms.Button();
            this.btnBuyCar = new System.Windows.Forms.Button();
            this.btnGetJob = new System.Windows.Forms.Button();
            this.btnGoToCollege = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.chkChurch = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(35, 29);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(206, 24);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Would You Like To:  ";
            // 
            // btnBuyHouse
            // 
            this.btnBuyHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyHouse.Location = new System.Drawing.Point(39, 70);
            this.btnBuyHouse.Name = "btnBuyHouse";
            this.btnBuyHouse.Size = new System.Drawing.Size(202, 51);
            this.btnBuyHouse.TabIndex = 1;
            this.btnBuyHouse.Text = "Buy a new house";
            this.btnBuyHouse.UseVisualStyleBackColor = true;
            this.btnBuyHouse.Click += new System.EventHandler(this.btnBuyHouse_Click);
            // 
            // btnBuyCar
            // 
            this.btnBuyCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyCar.Location = new System.Drawing.Point(39, 127);
            this.btnBuyCar.Name = "btnBuyCar";
            this.btnBuyCar.Size = new System.Drawing.Size(202, 51);
            this.btnBuyCar.TabIndex = 2;
            this.btnBuyCar.Text = "Buy a car";
            this.btnBuyCar.UseVisualStyleBackColor = true;
            this.btnBuyCar.Click += new System.EventHandler(this.btnBuyCar_Click);
            // 
            // btnGetJob
            // 
            this.btnGetJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetJob.Location = new System.Drawing.Point(39, 184);
            this.btnGetJob.Name = "btnGetJob";
            this.btnGetJob.Size = new System.Drawing.Size(202, 51);
            this.btnGetJob.TabIndex = 3;
            this.btnGetJob.Text = "Get a new job";
            this.btnGetJob.UseVisualStyleBackColor = true;
            this.btnGetJob.Click += new System.EventHandler(this.btnGetJob_Click);
            // 
            // btnGoToCollege
            // 
            this.btnGoToCollege.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToCollege.Location = new System.Drawing.Point(39, 241);
            this.btnGoToCollege.Name = "btnGoToCollege";
            this.btnGoToCollege.Size = new System.Drawing.Size(202, 51);
            this.btnGoToCollege.TabIndex = 4;
            this.btnGoToCollege.Text = "Go to college";
            this.btnGoToCollege.UseVisualStyleBackColor = true;
            this.btnGoToCollege.Click += new System.EventHandler(this.btnGoToCollege_Click);
            // 
            // btnOther
            // 
            this.btnOther.Enabled = false;
            this.btnOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOther.Location = new System.Drawing.Point(39, 298);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(202, 51);
            this.btnOther.TabIndex = 5;
            this.btnOther.Text = "<Other option>";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Visible = false;
            // 
            // chkChurch
            // 
            this.chkChurch.AutoSize = true;
            this.chkChurch.Location = new System.Drawing.Point(39, 355);
            this.chkChurch.Name = "chkChurch";
            this.chkChurch.Size = new System.Drawing.Size(88, 17);
            this.chkChurch.TabIndex = 6;
            this.chkChurch.Text = "Go to church";
            this.chkChurch.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(39, 388);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(202, 51);
            this.btnContinue.TabIndex = 7;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // OptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 451);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.chkChurch);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnGoToCollege);
            this.Controls.Add(this.btnGetJob);
            this.Controls.Add(this.btnBuyCar);
            this.Controls.Add(this.btnBuyHouse);
            this.Controls.Add(this.lblPrompt);
            this.Name = "OptionsMenu";
            this.Text = "What to do?  ";
            this.Load += new System.EventHandler(this.OptionsMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Button btnBuyHouse;
        private System.Windows.Forms.Button btnBuyCar;
        private System.Windows.Forms.Button btnGetJob;
        private System.Windows.Forms.Button btnGoToCollege;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.CheckBox chkChurch;
        private System.Windows.Forms.Button btnContinue;
    }
}