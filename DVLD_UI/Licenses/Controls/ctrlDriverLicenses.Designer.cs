namespace DVLD_UI.Licenses.Controls
{
    partial class ctrlDriverLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcDriverLicenses = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_LocalLicensesRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_LocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternationalLicenses = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_InternationalLicensesRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_InternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsInterenationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInterenationalLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcDriverLicenses.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalLicensesHistory)).BeginInit();
            this.cmsLicenseHistory.SuspendLayout();
            this.tbInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InternationalLicensesHistory)).BeginInit();
            this.cmsInterenationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDriverLicenses
            // 
            this.tcDriverLicenses.Controls.Add(this.tpLocalLicenses);
            this.tcDriverLicenses.Controls.Add(this.tbInternationalLicenses);
            this.tcDriverLicenses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tcDriverLicenses.Location = new System.Drawing.Point(3, 2);
            this.tcDriverLicenses.Name = "tcDriverLicenses";
            this.tcDriverLicenses.SelectedIndex = 0;
            this.tcDriverLicenses.Size = new System.Drawing.Size(1116, 266);
            this.tcDriverLicenses.TabIndex = 5;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.Controls.Add(this.label1);
            this.tpLocalLicenses.Controls.Add(this.lbl_LocalLicensesRecords);
            this.tpLocalLicenses.Controls.Add(this.label2);
            this.tpLocalLicenses.Controls.Add(this.dgv_LocalLicensesHistory);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 33);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(1108, 229);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local";
            this.tpLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Licenses History:";
            // 
            // lbl_LocalLicensesRecords
            // 
            this.lbl_LocalLicensesRecords.AutoSize = true;
            this.lbl_LocalLicensesRecords.Location = new System.Drawing.Point(133, 201);
            this.lbl_LocalLicensesRecords.Name = "lbl_LocalLicensesRecords";
            this.lbl_LocalLicensesRecords.Size = new System.Drawing.Size(28, 24);
            this.lbl_LocalLicensesRecords.TabIndex = 4;
            this.lbl_LocalLicensesRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 133;
            this.label2.Text = "# Records:";
            // 
            // dgv_LocalLicensesHistory
            // 
            this.dgv_LocalLicensesHistory.AllowUserToAddRows = false;
            this.dgv_LocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgv_LocalLicensesHistory.AllowUserToResizeRows = false;
            this.dgv_LocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgv_LocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LocalLicensesHistory.ContextMenuStrip = this.cmsLicenseHistory;
            this.dgv_LocalLicensesHistory.Location = new System.Drawing.Point(11, 48);
            this.dgv_LocalLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_LocalLicensesHistory.MultiSelect = false;
            this.dgv_LocalLicensesHistory.Name = "dgv_LocalLicensesHistory";
            this.dgv_LocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LocalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_LocalLicensesHistory.RowHeadersWidth = 51;
            this.dgv_LocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LocalLicensesHistory.Size = new System.Drawing.Size(1090, 147);
            this.dgv_LocalLicensesHistory.TabIndex = 3;
            this.dgv_LocalLicensesHistory.TabStop = false;
            // 
            // cmsLicenseHistory
            // 
            this.cmsLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsLicenseHistory.Size = new System.Drawing.Size(215, 58);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.LicenseView_400;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // tbInternationalLicenses
            // 
            this.tbInternationalLicenses.Controls.Add(this.label3);
            this.tbInternationalLicenses.Controls.Add(this.lbl_InternationalLicensesRecords);
            this.tbInternationalLicenses.Controls.Add(this.label5);
            this.tbInternationalLicenses.Controls.Add(this.dgv_InternationalLicensesHistory);
            this.tbInternationalLicenses.Location = new System.Drawing.Point(4, 33);
            this.tbInternationalLicenses.Name = "tbInternationalLicenses";
            this.tbInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternationalLicenses.Size = new System.Drawing.Size(1108, 229);
            this.tbInternationalLicenses.TabIndex = 1;
            this.tbInternationalLicenses.Text = "International";
            this.tbInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "International Licenses History:";
            // 
            // lbl_InternationalLicensesRecords
            // 
            this.lbl_InternationalLicensesRecords.AutoSize = true;
            this.lbl_InternationalLicensesRecords.Location = new System.Drawing.Point(131, 197);
            this.lbl_InternationalLicensesRecords.Name = "lbl_InternationalLicensesRecords";
            this.lbl_InternationalLicensesRecords.Size = new System.Drawing.Size(28, 24);
            this.lbl_InternationalLicensesRecords.TabIndex = 8;
            this.lbl_InternationalLicensesRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 137;
            this.label5.Text = "# Records:";
            // 
            // dgv_InternationalLicensesHistory
            // 
            this.dgv_InternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgv_InternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgv_InternationalLicensesHistory.AllowUserToResizeRows = false;
            this.dgv_InternationalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgv_InternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InternationalLicensesHistory.ContextMenuStrip = this.cmsInterenationalLicenseHistory;
            this.dgv_InternationalLicensesHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_InternationalLicensesHistory.Location = new System.Drawing.Point(14, 45);
            this.dgv_InternationalLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_InternationalLicensesHistory.MultiSelect = false;
            this.dgv_InternationalLicensesHistory.Name = "dgv_InternationalLicensesHistory";
            this.dgv_InternationalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_InternationalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_InternationalLicensesHistory.RowHeadersWidth = 51;
            this.dgv_InternationalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_InternationalLicensesHistory.Size = new System.Drawing.Size(1090, 147);
            this.dgv_InternationalLicensesHistory.TabIndex = 7;
            this.dgv_InternationalLicensesHistory.TabStop = false;
            // 
            // cmsInterenationalLicenseHistory
            // 
            this.cmsInterenationalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInterenationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInterenationalLicenseInfoToolStripMenuItem});
            this.cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsInterenationalLicenseHistory.Size = new System.Drawing.Size(297, 30);
            // 
            // showInterenationalLicenseInfoToolStripMenuItem
            // 
            this.showInterenationalLicenseInfoToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.LicenseView_400;
            this.showInterenationalLicenseInfoToolStripMenuItem.Name = "showInterenationalLicenseInfoToolStripMenuItem";
            this.showInterenationalLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showInterenationalLicenseInfoToolStripMenuItem.Text = "Show Interenational License Info";
            this.showInterenationalLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showInterenationalLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcDriverLicenses);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1139, 271);
            this.tcDriverLicenses.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LocalLicensesHistory)).EndInit();
            this.cmsLicenseHistory.ResumeLayout(false);
            this.tbInternationalLicenses.ResumeLayout(false);
            this.tbInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InternationalLicensesHistory)).EndInit();
            this.cmsInterenationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDriverLicenses;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LocalLicensesRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_LocalLicensesHistory;
        private System.Windows.Forms.TabPage tbInternationalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_InternationalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_InternationalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showInterenationalLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
