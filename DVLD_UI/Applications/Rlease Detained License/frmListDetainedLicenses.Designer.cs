namespace DVLD_UI.Applications.Rlease_Detained_License
{
    partial class frmListDetainedLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDetainedLicenses));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_IsReleased = new System.Windows.Forms.ComboBox();
            this.lbl_NumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.cmb_AllFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_DetainLicense = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_ListDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.btn_ReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.cms_Applications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListDetainedLicenses)).BeginInit();
            this.cms_Applications.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_IsReleased
            // 
            this.cmb_IsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IsReleased.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_IsReleased.FormattingEnabled = true;
            this.cmb_IsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No",
            ""});
            this.cmb_IsReleased.Location = new System.Drawing.Point(330, 241);
            this.cmb_IsReleased.Name = "cmb_IsReleased";
            this.cmb_IsReleased.Size = new System.Drawing.Size(112, 29);
            this.cmb_IsReleased.TabIndex = 30;
            this.cmb_IsReleased.Visible = false;
            this.cmb_IsReleased.SelectedIndexChanged += new System.EventHandler(this.cmb_IsReleased_SelectedIndexChanged);
            // 
            // lbl_NumberOfRecords
            // 
            this.lbl_NumberOfRecords.AutoSize = true;
            this.lbl_NumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_NumberOfRecords.Location = new System.Drawing.Point(121, 720);
            this.lbl_NumberOfRecords.Name = "lbl_NumberOfRecords";
            this.lbl_NumberOfRecords.Size = new System.Drawing.Size(19, 24);
            this.lbl_NumberOfRecords.TabIndex = 29;
            this.lbl_NumberOfRecords.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 720);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "# Records:";
            // 
            // mtxt_Value
            // 
            this.mtxt_Value.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mtxt_Value.Location = new System.Drawing.Point(330, 242);
            this.mtxt_Value.Name = "mtxt_Value";
            this.mtxt_Value.Size = new System.Drawing.Size(325, 30);
            this.mtxt_Value.TabIndex = 27;
            this.mtxt_Value.TextChanged += new System.EventHandler(this.mtxt_Value_TextChanged);
            this.mtxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Value_KeyPress);
            // 
            // cmb_AllFilter
            // 
            this.cmb_AllFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_AllFilter.FormattingEnabled = true;
            this.cmb_AllFilter.Location = new System.Drawing.Point(117, 242);
            this.cmb_AllFilter.Name = "cmb_AllFilter";
            this.cmb_AllFilter.Size = new System.Drawing.Size(207, 29);
            this.cmb_AllFilter.TabIndex = 20;
            this.cmb_AllFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_AllFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Filter By:";
            // 
            // btn_DetainLicense
            // 
            this.btn_DetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btn_DetainLicense.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_DetainLicense.ImageIndex = 1;
            this.btn_DetainLicense.ImageList = this.imageList1;
            this.btn_DetainLicense.Location = new System.Drawing.Point(1212, 220);
            this.btn_DetainLicense.Name = "btn_DetainLicense";
            this.btn_DetainLicense.Size = new System.Drawing.Size(108, 50);
            this.btn_DetainLicense.TabIndex = 24;
            this.btn_DetainLicense.UseVisualStyleBackColor = false;
            this.btn_DetainLicense.Click += new System.EventHandler(this.btn_DetainLicense_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "Detain 512.png");
            this.imageList1.Images.SetKeyName(2, "Release Detained License 512.png");
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 0;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(1197, 720);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(123, 45);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(12, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1327, 56);
            this.label1.TabIndex = 22;
            this.label1.Text = "List Detained Licenses";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1339, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_ListDetainedLicenses
            // 
            this.dgv_ListDetainedLicenses.AllowUserToAddRows = false;
            this.dgv_ListDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgv_ListDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgv_ListDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListDetainedLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListDetainedLicenses.ContextMenuStrip = this.cms_Applications;
            this.dgv_ListDetainedLicenses.Location = new System.Drawing.Point(12, 276);
            this.dgv_ListDetainedLicenses.Name = "dgv_ListDetainedLicenses";
            this.dgv_ListDetainedLicenses.ReadOnly = true;
            this.dgv_ListDetainedLicenses.RowHeadersWidth = 51;
            this.dgv_ListDetainedLicenses.RowTemplate.Height = 26;
            this.dgv_ListDetainedLicenses.Size = new System.Drawing.Size(1308, 438);
            this.dgv_ListDetainedLicenses.TabIndex = 23;
            // 
            // btn_ReleaseDetainedLicense
            // 
            this.btn_ReleaseDetainedLicense.BackColor = System.Drawing.Color.Transparent;
            this.btn_ReleaseDetainedLicense.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ReleaseDetainedLicense.ImageIndex = 2;
            this.btn_ReleaseDetainedLicense.ImageList = this.imageList1;
            this.btn_ReleaseDetainedLicense.Location = new System.Drawing.Point(1098, 220);
            this.btn_ReleaseDetainedLicense.Name = "btn_ReleaseDetainedLicense";
            this.btn_ReleaseDetainedLicense.Size = new System.Drawing.Size(108, 50);
            this.btn_ReleaseDetainedLicense.TabIndex = 31;
            this.btn_ReleaseDetainedLicense.UseVisualStyleBackColor = false;
            this.btn_ReleaseDetainedLicense.Click += new System.EventHandler(this.btn_ReleaseDetainedLicense_Click);
            // 
            // cms_Applications
            // 
            this.cms_Applications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Applications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.cms_Applications.Name = "cms_Applications";
            this.cms_Applications.Size = new System.Drawing.Size(251, 142);
            this.cms_Applications.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Applications_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.person_card_details;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.LicenseView_400;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem1
            // 
            this.showLicenseDetailsToolStripMenuItem1.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_5121;
            this.showLicenseDetailsToolStripMenuItem1.Name = "showLicenseDetailsToolStripMenuItem1";
            this.showLicenseDetailsToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.showLicenseDetailsToolStripMenuItem1.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem1.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 6);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Release_Detained_License_512;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1339, 772);
            this.Controls.Add(this.btn_ReleaseDetainedLicense);
            this.Controls.Add(this.cmb_IsReleased);
            this.Controls.Add(this.lbl_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtxt_Value);
            this.Controls.Add(this.cmb_AllFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_DetainLicense);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgv_ListDetainedLicenses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListDetainedLicenses)).EndInit();
            this.cms_Applications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_IsReleased;
        private System.Windows.Forms.Label lbl_NumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxt_Value;
        private System.Windows.Forms.ComboBox cmb_AllFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_DetainLicense;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_ListDetainedLicenses;
        private System.Windows.Forms.Button btn_ReleaseDetainedLicense;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cms_Applications;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}