namespace DVLD_UI.Applications.International_License
{
    partial class frmListInternationalLicesnseApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListInternationalLicesnseApplications));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_NumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_AllFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_NewApplication = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_ListInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmb_IsActive = new System.Windows.Forms.ComboBox();
            this.mtxt_Value = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListInternationalLicenses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_NumberOfRecords
            // 
            this.lbl_NumberOfRecords.AutoSize = true;
            this.lbl_NumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_NumberOfRecords.Location = new System.Drawing.Point(113, 795);
            this.lbl_NumberOfRecords.Name = "lbl_NumberOfRecords";
            this.lbl_NumberOfRecords.Size = new System.Drawing.Size(19, 24);
            this.lbl_NumberOfRecords.TabIndex = 18;
            this.lbl_NumberOfRecords.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 795);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records:";
            // 
            // cmb_AllFilter
            // 
            this.cmb_AllFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_AllFilter.FormattingEnabled = true;
            this.cmb_AllFilter.Location = new System.Drawing.Point(117, 307);
            this.cmb_AllFilter.Name = "cmb_AllFilter";
            this.cmb_AllFilter.Size = new System.Drawing.Size(207, 29);
            this.cmb_AllFilter.TabIndex = 1;
            this.cmb_AllFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_AllFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter By:";
            // 
            // btn_NewApplication
            // 
            this.btn_NewApplication.BackColor = System.Drawing.Color.Transparent;
            this.btn_NewApplication.FlatAppearance.BorderSize = 0;
            this.btn_NewApplication.ImageIndex = 1;
            this.btn_NewApplication.ImageList = this.imageList1;
            this.btn_NewApplication.Location = new System.Drawing.Point(1264, 286);
            this.btn_NewApplication.Name = "btn_NewApplication";
            this.btn_NewApplication.Size = new System.Drawing.Size(72, 50);
            this.btn_NewApplication.TabIndex = 3;
            this.btn_NewApplication.UseVisualStyleBackColor = false;
            this.btn_NewApplication.Click += new System.EventHandler(this.btn_NewApplication_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            this.imageList1.Images.SetKeyName(1, "New Application 64.png");
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 0;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(1213, 785);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(123, 45);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(4, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1332, 56);
            this.label1.TabIndex = 11;
            this.label1.Text = "International License Applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1339, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_ListInternationalLicenses
            // 
            this.dgv_ListInternationalLicenses.AllowUserToAddRows = false;
            this.dgv_ListInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgv_ListInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgv_ListInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListInternationalLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ListInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListInternationalLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_ListInternationalLicenses.Location = new System.Drawing.Point(16, 342);
            this.dgv_ListInternationalLicenses.Name = "dgv_ListInternationalLicenses";
            this.dgv_ListInternationalLicenses.ReadOnly = true;
            this.dgv_ListInternationalLicenses.RowHeadersWidth = 51;
            this.dgv_ListInternationalLicenses.RowTemplate.Height = 26;
            this.dgv_ListInternationalLicenses.Size = new System.Drawing.Size(1324, 438);
            this.dgv_ListInternationalLicenses.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 82);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.person_card_details;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.LicenseView_400;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_5121;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.globe;
            this.pictureBox2.Location = new System.Drawing.Point(736, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // cmb_IsActive
            // 
            this.cmb_IsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IsActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_IsActive.FormattingEnabled = true;
            this.cmb_IsActive.Location = new System.Drawing.Point(330, 307);
            this.cmb_IsActive.Name = "cmb_IsActive";
            this.cmb_IsActive.Size = new System.Drawing.Size(112, 29);
            this.cmb_IsActive.TabIndex = 22;
            this.cmb_IsActive.Visible = false;
            this.cmb_IsActive.SelectedIndexChanged += new System.EventHandler(this.cmb_IsActive_SelectedIndexChanged);
            // 
            // mtxt_Value
            // 
            this.mtxt_Value.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mtxt_Value.Location = new System.Drawing.Point(330, 306);
            this.mtxt_Value.Name = "mtxt_Value";
            this.mtxt_Value.Size = new System.Drawing.Size(325, 30);
            this.mtxt_Value.TabIndex = 2;
            this.mtxt_Value.TextChanged += new System.EventHandler(this.mtxt_Value_TextChanged);
            this.mtxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Value_KeyPress);
            // 
            // frmListInternationalLicesnseApplications
            // 
            this.AcceptButton = this.btn_NewApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1348, 841);
            this.Controls.Add(this.cmb_IsActive);
            this.Controls.Add(this.mtxt_Value);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_AllFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_NewApplication);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgv_ListInternationalLicenses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListInternationalLicesnseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List International Licesnse Applications";
            this.Load += new System.EventHandler(this.frmListInternationalLicesnseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListInternationalLicenses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_AllFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_NewApplication;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_ListInternationalLicenses;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmb_IsActive;
        private System.Windows.Forms.MaskedTextBox mtxt_Value;
    }
}