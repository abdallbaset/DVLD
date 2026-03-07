namespace DVLD_UI.Applications.Local_Driving_License
{
    partial class frmAddUpdateLocalDrivingLicesnseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateLocalDrivingLicesnseApplication));
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_PersonInfo = new System.Windows.Forms.TabPage();
            this.btn_Next = new System.Windows.Forms.Button();
            this.tp_LoginInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbl_ApplicationDate = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_LocalDrivingLicenseApplicationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCardWithFilter1 = new DVLD_UI.Controls.ctrlPersonCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tp_PersonInfo.SuspendLayout();
            this.tp_LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Crimson;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(882, 812);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(131, 52);
            this.btn_Close.TabIndex = 67;
            this.btn_Close.Text = "Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "save.png");
            this.imageList1.Images.SetKeyName(1, "close_2.png");
            this.imageList1.Images.SetKeyName(2, "next.png");
            this.imageList1.Images.SetKeyName(3, "chevron-back.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_PersonInfo);
            this.tabControl1.Controls.Add(this.tp_LoginInfo);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1167, 654);
            this.tabControl1.TabIndex = 18;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tp_PersonInfo
            // 
            this.tp_PersonInfo.Controls.Add(this.btn_Next);
            this.tp_PersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tp_PersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tp_PersonInfo.Location = new System.Drawing.Point(4, 33);
            this.tp_PersonInfo.Name = "tp_PersonInfo";
            this.tp_PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PersonInfo.Size = new System.Drawing.Size(1159, 617);
            this.tp_PersonInfo.TabIndex = 0;
            this.tp_PersonInfo.Text = "Person Info";
            this.tp_PersonInfo.UseVisualStyleBackColor = true;
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Next.ForeColor = System.Drawing.Color.White;
            this.btn_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Next.ImageIndex = 2;
            this.btn_Next.ImageList = this.imageList1;
            this.btn_Next.Location = new System.Drawing.Point(1015, 547);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(115, 52);
            this.btn_Next.TabIndex = 65;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // tp_LoginInfo
            // 
            this.tp_LoginInfo.Controls.Add(this.lblCreatedByUser);
            this.tp_LoginInfo.Controls.Add(this.label6);
            this.tp_LoginInfo.Controls.Add(this.pictureBox5);
            this.tp_LoginInfo.Controls.Add(this.lblAppFees);
            this.tp_LoginInfo.Controls.Add(this.cbLicenseClass);
            this.tp_LoginInfo.Controls.Add(this.lbl_ApplicationDate);
            this.tp_LoginInfo.Controls.Add(this.btn_Back);
            this.tp_LoginInfo.Controls.Add(this.label3);
            this.tp_LoginInfo.Controls.Add(this.label2);
            this.tp_LoginInfo.Controls.Add(this.label4);
            this.tp_LoginInfo.Controls.Add(this.lbl_LocalDrivingLicenseApplicationID);
            this.tp_LoginInfo.Controls.Add(this.label1);
            this.tp_LoginInfo.Controls.Add(this.pictureBox4);
            this.tp_LoginInfo.Controls.Add(this.pictureBox3);
            this.tp_LoginInfo.Controls.Add(this.pictureBox2);
            this.tp_LoginInfo.Controls.Add(this.pictureBox1);
            this.tp_LoginInfo.Location = new System.Drawing.Point(4, 33);
            this.tp_LoginInfo.Name = "tp_LoginInfo";
            this.tp_LoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tp_LoginInfo.Size = new System.Drawing.Size(1159, 617);
            this.tp_LoginInfo.TabIndex = 1;
            this.tp_LoginInfo.Text = "Application Info";
            this.tp_LoginInfo.UseVisualStyleBackColor = true;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(311, 290);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(40, 22);
            this.lblCreatedByUser.TabIndex = 75;
            this.lblCreatedByUser.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(114, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 22);
            this.label6.TabIndex = 73;
            this.label6.Text = "Created By:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_UI.Properties.Resources.person_svgrepo;
            this.pictureBox5.Location = new System.Drawing.Point(256, 284);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 74;
            this.pictureBox5.TabStop = false;
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(310, 229);
            this.lblAppFees.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(43, 22);
            this.lblAppFees.TabIndex = 72;
            this.lblAppFees.Text = "$$$";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(314, 169);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(382, 32);
            this.cbLicenseClass.TabIndex = 71;
            // 
            // lbl_ApplicationDate
            // 
            this.lbl_ApplicationDate.AutoSize = true;
            this.lbl_ApplicationDate.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ApplicationDate.Location = new System.Drawing.Point(310, 115);
            this.lbl_ApplicationDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_ApplicationDate.Name = "lbl_ApplicationDate";
            this.lbl_ApplicationDate.Size = new System.Drawing.Size(110, 22);
            this.lbl_ApplicationDate.TabIndex = 70;
            this.lbl_ApplicationDate.Text = "??/??/????";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Back.ForeColor = System.Drawing.Color.White;
            this.btn_Back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Back.ImageIndex = 3;
            this.btn_Back.ImageList = this.imageList1;
            this.btn_Back.Location = new System.Drawing.Point(7, 558);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(115, 52);
            this.btn_Back.TabIndex = 76;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 22);
            this.label3.TabIndex = 65;
            this.label3.Text = "Application Fees:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 22);
            this.label2.TabIndex = 62;
            this.label2.Text = "License Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 22);
            this.label4.TabIndex = 58;
            this.label4.Text = "Application Date :";
            // 
            // lbl_LocalDrivingLicenseApplicationID
            // 
            this.lbl_LocalDrivingLicenseApplicationID.AutoSize = true;
            this.lbl_LocalDrivingLicenseApplicationID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LocalDrivingLicenseApplicationID.Location = new System.Drawing.Point(310, 58);
            this.lbl_LocalDrivingLicenseApplicationID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_LocalDrivingLicenseApplicationID.Name = "lbl_LocalDrivingLicenseApplicationID";
            this.lbl_LocalDrivingLicenseApplicationID.Size = new System.Drawing.Size(40, 22);
            this.lbl_LocalDrivingLicenseApplicationID.TabIndex = 56;
            this.lbl_LocalDrivingLicenseApplicationID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "D.L.Application ID:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UI.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(255, 223);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox3.Location = new System.Drawing.Point(255, 167);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.date;
            this.pictureBox2.Location = new System.Drawing.Point(255, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(255, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Green;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.ImageIndex = 0;
            this.btn_Save.ImageList = this.imageList1;
            this.btn_Save.Location = new System.Drawing.Point(1044, 812);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(131, 52);
            this.btn_Save.TabIndex = 66;
            this.btn_Save.Text = "Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Mode.Location = new System.Drawing.Point(1, 9);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(1199, 89);
            this.lbl_Mode.TabIndex = 17;
            this.lbl_Mode.Text = "Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(19, 36);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1129, 504);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // frmAddUpdateLocalDrivingLicesnseApplication
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1202, 878);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_Mode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateLocalDrivingLicesnseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdateLocalDrivingLicesnseApplication";
            this.Activated += new System.EventHandler(this.frmAddUpdateLocalDrivingLicesnseApplication_Activated);
            this.Load += new System.EventHandler(this.frmAddAndUpdateApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_PersonInfo.ResumeLayout(false);
            this.tp_LoginInfo.ResumeLayout(false);
            this.tp_LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_PersonInfo;
        private System.Windows.Forms.Button btn_Next;
        private Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tp_LoginInfo;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_LocalDrivingLicenseApplicationID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_ApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}