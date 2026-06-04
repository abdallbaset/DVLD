namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    partial class ctrlDriverLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlDriverLicenseInfoWithFilter));
            this.grb_Filter = new System.Windows.Forms.GroupBox();
            this.btn_Research = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mtxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfo1 = new DVLD_UI.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfo();
            this.grb_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_Filter
            // 
            this.grb_Filter.Controls.Add(this.btn_Research);
            this.grb_Filter.Controls.Add(this.mtxt_Value);
            this.grb_Filter.Controls.Add(this.label2);
            this.grb_Filter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Filter.Location = new System.Drawing.Point(3, 6);
            this.grb_Filter.Name = "grb_Filter";
            this.grb_Filter.Size = new System.Drawing.Size(1054, 111);
            this.grb_Filter.TabIndex = 2;
            this.grb_Filter.TabStop = false;
            this.grb_Filter.Text = "Filter";
            // 
            // btn_Research
            // 
            this.btn_Research.BackColor = System.Drawing.Color.Transparent;
            this.btn_Research.ImageIndex = 0;
            this.btn_Research.ImageList = this.imageList1;
            this.btn_Research.Location = new System.Drawing.Point(443, 36);
            this.btn_Research.Name = "btn_Research";
            this.btn_Research.Size = new System.Drawing.Size(78, 45);
            this.btn_Research.TabIndex = 2;
            this.btn_Research.UseVisualStyleBackColor = false;
            this.btn_Research.Click += new System.EventHandler(this.btn_Research_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search-people.png");
            // 
            // mtxt_Value
            // 
            this.mtxt_Value.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mtxt_Value.Location = new System.Drawing.Point(151, 45);
            this.mtxt_Value.Name = "mtxt_Value";
            this.mtxt_Value.Size = new System.Drawing.Size(250, 30);
            this.mtxt_Value.TabIndex = 1;
            this.mtxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Value_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "LicenseID:";
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Licenses = null;
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(3, 123);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(1071, 404);
            this.ctrlDriverLicenseInfo1.TabIndex = 0;
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_Filter);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Name = "ctrlDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1079, 543);
            this.grb_Filter.ResumeLayout(false);
            this.grb_Filter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox grb_Filter;
        private System.Windows.Forms.Button btn_Research;
        private System.Windows.Forms.MaskedTextBox mtxt_Value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
    }
}
