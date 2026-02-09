namespace DVLD_UI
{
    partial class frmTest
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
            this.ctrlPersonCard1 = new DVLD_UI.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ctrlPersonCard1.Location = new System.Drawing.Point(44, 90);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1126, 360);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.Load += new System.EventHandler(this.ctrlPersonCard1_Load_2);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 665);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
    }
}