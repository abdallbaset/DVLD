namespace DVLD_UI.Test.Test_Type
{
    partial class frmManageTestTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTestTypes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_NumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgv_ListTestTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplictionsTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListTestTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_NumberOfRecords
            // 
            this.lbl_NumberOfRecords.AutoSize = true;
            this.lbl_NumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_NumberOfRecords.Location = new System.Drawing.Point(126, 716);
            this.lbl_NumberOfRecords.Name = "lbl_NumberOfRecords";
            this.lbl_NumberOfRecords.Size = new System.Drawing.Size(19, 24);
            this.lbl_NumberOfRecords.TabIndex = 19;
            this.lbl_NumberOfRecords.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 716);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "# Records:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "person-add.png");
            this.imageList1.Images.SetKeyName(1, "close.png");
            // 
            // dgv_ListTestTypes
            // 
            this.dgv_ListTestTypes.AllowUserToAddRows = false;
            this.dgv_ListTestTypes.AllowUserToDeleteRows = false;
            this.dgv_ListTestTypes.AllowUserToOrderColumns = true;
            this.dgv_ListTestTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListTestTypes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListTestTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListTestTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_ListTestTypes.Location = new System.Drawing.Point(19, 263);
            this.dgv_ListTestTypes.Name = "dgv_ListTestTypes";
            this.dgv_ListTestTypes.ReadOnly = true;
            this.dgv_ListTestTypes.RowHeadersWidth = 51;
            this.dgv_ListTestTypes.RowTemplate.Height = 26;
            this.dgv_ListTestTypes.Size = new System.Drawing.Size(942, 438);
            this.dgv_ListTestTypes.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplictionsTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 30);
            // 
            // editApplictionsTypeToolStripMenuItem
            // 
            this.editApplictionsTypeToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.edit_32;
            this.editApplictionsTypeToolStripMenuItem.Name = "editApplictionsTypeToolStripMenuItem";
            this.editApplictionsTypeToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.editApplictionsTypeToolStripMenuItem.Text = "Edit Test Type";
            this.editApplictionsTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplictionsTypeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(3, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(966, 56);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mange Test Types";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(832, 707);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(123, 45);
            this.btn_Close.TabIndex = 17;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.TestType_512;
            this.pictureBox1.Location = new System.Drawing.Point(1, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(971, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(973, 766);
            this.Controls.Add(this.lbl_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.dgv_ListTestTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Test Types";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListTestTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_ListTestTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplictionsTypeToolStripMenuItem;
    }
}