namespace DVLD_UI.Licenses
{
    partial class frmShowPersonLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPersonLicenseHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ctrlDriverLicenses1 = new DVLD_UI.Licenses.Controls.ctrlDriverLicenses();
            this.ctrlPersonCardWithFilter1 = new DVLD_UI.Controls.ctrlPersonCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 21F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(4, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1128, 52);
            this.label1.TabIndex = 22;
            this.label1.Text = "License History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_5121;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1129, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 0;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(1009, 933);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(123, 45);
            this.btn_Close.TabIndex = 26;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.DriverID = 0;
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(11, 663);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1121, 264);
            this.ctrlDriverLicenses1.TabIndex = 25;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(3, 158);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1129, 499);
            this.ctrlPersonCardWithFilter1.TabIndex = 24;
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1134, 984);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DVLD_UI.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Controls.ctrlDriverLicenses ctrlDriverLicenses1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ImageList imageList1;
    }
}