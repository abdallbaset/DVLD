namespace DVLD_UI.Applications.Local_Driving_License
{
    partial class frmMangeLocalDrivingLicesnseApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangeLocalDrivingLicesnseApplications));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_NumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.cmb_AllFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_ListLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.btn_AddNewApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_NumberOfRecords
            // 
            this.lbl_NumberOfRecords.AutoSize = true;
            this.lbl_NumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_NumberOfRecords.Location = new System.Drawing.Point(113, 768);
            this.lbl_NumberOfRecords.Name = "lbl_NumberOfRecords";
            this.lbl_NumberOfRecords.Size = new System.Drawing.Size(19, 24);
            this.lbl_NumberOfRecords.TabIndex = 18;
            this.lbl_NumberOfRecords.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 768);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records:";
            // 
            // mtxt_Value
            // 
            this.mtxt_Value.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mtxt_Value.Location = new System.Drawing.Point(330, 280);
            this.mtxt_Value.Name = "mtxt_Value";
            this.mtxt_Value.Size = new System.Drawing.Size(250, 30);
            this.mtxt_Value.TabIndex = 2;
            this.mtxt_Value.TextChanged += new System.EventHandler(this.mtxt_Value_TextChanged);
            this.mtxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Value_KeyPress);
            // 
            // cmb_AllFilter
            // 
            this.cmb_AllFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_AllFilter.FormattingEnabled = true;
            this.cmb_AllFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cmb_AllFilter.Location = new System.Drawing.Point(117, 280);
            this.cmb_AllFilter.Name = "cmb_AllFilter";
            this.cmb_AllFilter.Size = new System.Drawing.Size(207, 29);
            this.cmb_AllFilter.TabIndex = 1;
            this.cmb_AllFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_AllFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter By:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "New Application 64.png");
            this.imageList1.Images.SetKeyName(1, "close.png");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(3, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1715, 56);
            this.label1.TabIndex = 11;
            this.label1.Text = "Manage Local Driving License Applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(293, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(293, 6);
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.EditApplicationToolStripMenuItem,
            this.DeleteApplicationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.CancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sechduleTestsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(297, 248);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // ShowApplicationDetailsToolStripMenuItem
            // 
            this.ShowApplicationDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.person_card_details;
            this.ShowApplicationDetailsToolStripMenuItem.Name = "ShowApplicationDetailsToolStripMenuItem";
            this.ShowApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.ShowApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.ShowApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowApplicationDetailsToolStripMenuItem_Click);
            // 
            // EditApplicationToolStripMenuItem
            // 
            this.EditApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.edit;
            this.EditApplicationToolStripMenuItem.Name = "EditApplicationToolStripMenuItem";
            this.EditApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.EditApplicationToolStripMenuItem.Text = "Edit Application";
            this.EditApplicationToolStripMenuItem.Click += new System.EventHandler(this.EditApplicationToolStripMenuItem_Click);
            // 
            // DeleteApplicationToolStripMenuItem
            // 
            this.DeleteApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.close;
            this.DeleteApplicationToolStripMenuItem.Name = "DeleteApplicationToolStripMenuItem";
            this.DeleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.DeleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.DeleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.DeleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(293, 6);
            // 
            // CancelApplicationToolStripMenuItem
            // 
            this.CancelApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Delete_32;
            this.CancelApplicationToolStripMenuItem.Name = "CancelApplicationToolStripMenuItem";
            this.CancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.CancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CancelApplicationToolStripMenuItem_Click);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.sechduleTestsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Schedule_Test_512;
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Vision_512;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Written_Test_512;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Street_Test_32;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(293, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(293, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.LicenseView_400;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(293, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_512;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // dgv_ListLocalDrivingLicenseApplications
            // 
            this.dgv_ListLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgv_ListLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgv_ListLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgv_ListLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            this.dgv_ListLocalDrivingLicenseApplications.Location = new System.Drawing.Point(27, 314);
            this.dgv_ListLocalDrivingLicenseApplications.Name = "dgv_ListLocalDrivingLicenseApplications";
            this.dgv_ListLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgv_ListLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgv_ListLocalDrivingLicenseApplications.RowTemplate.Height = 26;
            this.dgv_ListLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1702, 438);
            this.dgv_ListLocalDrivingLicenseApplications.TabIndex = 4;
            this.dgv_ListLocalDrivingLicenseApplications.DoubleClick += new System.EventHandler(this.dgv_ListLocalDrivingLicenseApplications_DoubleClick);
            // 
            // btn_AddNewApplication
            // 
            this.btn_AddNewApplication.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddNewApplication.ImageIndex = 0;
            this.btn_AddNewApplication.ImageList = this.imageList1;
            this.btn_AddNewApplication.Location = new System.Drawing.Point(1606, 259);
            this.btn_AddNewApplication.Name = "btn_AddNewApplication";
            this.btn_AddNewApplication.Size = new System.Drawing.Size(108, 50);
            this.btn_AddNewApplication.TabIndex = 3;
            this.btn_AddNewApplication.UseVisualStyleBackColor = false;
            this.btn_AddNewApplication.Click += new System.EventHandler(this.btn_AddNewApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.Applications1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1733, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(1606, 758);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(123, 45);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frmMangeLocalDrivingLicesnseApplications
            // 
            this.AcceptButton = this.btn_AddNewApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1739, 824);
            this.Controls.Add(this.lbl_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtxt_Value);
            this.Controls.Add(this.cmb_AllFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddNewApplication);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.dgv_ListLocalDrivingLicenseApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMangeLocalDrivingLicesnseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmMangeLocalDrivingLicesnseApplications_Load);
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxt_Value;
        private System.Windows.Forms.ComboBox cmb_AllFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddNewApplication;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_ListLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}