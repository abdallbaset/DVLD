namespace DVLD_UI.Test
{
    partial class frmListTestAppointments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_NumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ListTestAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_AddNewAppointment = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pb_TestTypeImage = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLD_UI.Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListTestAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_TestTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Title.Location = new System.Drawing.Point(4, 123);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(857, 46);
            this.lbl_Title.TabIndex = 73;
            this.lbl_Title.Text = "Titale";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_NumberOfRecords
            // 
            this.lbl_NumberOfRecords.AutoSize = true;
            this.lbl_NumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_NumberOfRecords.Location = new System.Drawing.Point(121, 863);
            this.lbl_NumberOfRecords.Name = "lbl_NumberOfRecords";
            this.lbl_NumberOfRecords.Size = new System.Drawing.Size(19, 24);
            this.lbl_NumberOfRecords.TabIndex = 82;
            this.lbl_NumberOfRecords.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 863);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 81;
            this.label3.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(16, 688);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 24);
            this.label2.TabIndex = 79;
            this.label2.Text = "Appointments:";
            // 
            // dgv_ListTestAppointments
            // 
            this.dgv_ListTestAppointments.AllowUserToAddRows = false;
            this.dgv_ListTestAppointments.AllowUserToDeleteRows = false;
            this.dgv_ListTestAppointments.AllowUserToOrderColumns = true;
            this.dgv_ListTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListTestAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_ListTestAppointments.Location = new System.Drawing.Point(12, 718);
            this.dgv_ListTestAppointments.Name = "dgv_ListTestAppointments";
            this.dgv_ListTestAppointments.ReadOnly = true;
            this.dgv_ListTestAppointments.RowHeadersWidth = 51;
            this.dgv_ListTestAppointments.RowTemplate.Height = 26;
            this.dgv_ListTestAppointments.Size = new System.Drawing.Size(839, 135);
            this.dgv_ListTestAppointments.TabIndex = 76;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 84);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "person-add.png");
            this.imageList1.Images.SetKeyName(1, "close.png");
            // 
            // btn_AddNewAppointment
            // 
            this.btn_AddNewAppointment.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddNewAppointment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_AddNewAppointment.Image = global::DVLD_UI.Properties.Resources.AddAppointment_32;
            this.btn_AddNewAppointment.Location = new System.Drawing.Point(790, 672);
            this.btn_AddNewAppointment.Name = "btn_AddNewAppointment";
            this.btn_AddNewAppointment.Size = new System.Drawing.Size(61, 40);
            this.btn_AddNewAppointment.TabIndex = 77;
            this.btn_AddNewAppointment.UseVisualStyleBackColor = false;
            this.btn_AddNewAppointment.Click += new System.EventHandler(this.btn_AddNewAppointment_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(743, 863);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(110, 40);
            this.btn_Close.TabIndex = 78;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // pb_TestTypeImage
            // 
            this.pb_TestTypeImage.Image = global::DVLD_UI.Properties.Resources.Vision_5121;
            this.pb_TestTypeImage.Location = new System.Drawing.Point(4, 12);
            this.pb_TestTypeImage.Name = "pb_TestTypeImage";
            this.pb_TestTypeImage.Size = new System.Drawing.Size(857, 108);
            this.pb_TestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_TestTypeImage.TabIndex = 72;
            this.pb_TestTypeImage.TabStop = false;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(4, 172);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(849, 495);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 74;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 920);
            this.Controls.Add(this.lbl_NumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddNewAppointment);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.dgv_ListTestAppointments);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.pb_TestTypeImage);
            this.Controls.Add(this.lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Test Appointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListTestAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_TestTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_TestTypeImage;
        private System.Windows.Forms.Label lbl_Title;
        private Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label lbl_NumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddNewAppointment;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_ListTestAppointments;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}