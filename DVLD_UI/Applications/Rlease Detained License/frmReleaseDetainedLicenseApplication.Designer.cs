namespace DVLD_UI.Applications.Rlease_Detained_License
{
    partial class frmReleaseDetainedLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedLicenseApplication));
            this.llbl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Release = new System.Windows.Forms.Button();
            this.gp_DetainInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lbl_ApplicationID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_TotalFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lbl_ApplicationFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbl_FineFees = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbl_LicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CreatedByUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_DetainDate = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_DetainID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_UI.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.gp_DetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // llbl_ShowLicenseInfo
            // 
            this.llbl_ShowLicenseInfo.AutoSize = true;
            this.llbl_ShowLicenseInfo.Enabled = false;
            this.llbl_ShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.llbl_ShowLicenseInfo.Location = new System.Drawing.Point(242, 820);
            this.llbl_ShowLicenseInfo.Name = "llbl_ShowLicenseInfo";
            this.llbl_ShowLicenseInfo.Size = new System.Drawing.Size(180, 24);
            this.llbl_ShowLicenseInfo.TabIndex = 198;
            this.llbl_ShowLicenseInfo.TabStop = true;
            this.llbl_ShowLicenseInfo.Text = "Show Licenses Info";
            this.llbl_ShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_ShowLicenseInfo_LinkClicked);
            // 
            // llbl_ShowLicenseHistory
            // 
            this.llbl_ShowLicenseHistory.AutoSize = true;
            this.llbl_ShowLicenseHistory.Enabled = false;
            this.llbl_ShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F);
            this.llbl_ShowLicenseHistory.Location = new System.Drawing.Point(28, 820);
            this.llbl_ShowLicenseHistory.Name = "llbl_ShowLicenseHistory";
            this.llbl_ShowLicenseHistory.Size = new System.Drawing.Size(208, 24);
            this.llbl_ShowLicenseHistory.TabIndex = 197;
            this.llbl_ShowLicenseHistory.TabStop = true;
            this.llbl_ShowLicenseHistory.Text = "Show Licenses History";
            this.llbl_ShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_ShowLicenseHistory_LinkClicked);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Crimson;
            this.btn_Close.CausesValidation = false;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.ImageIndex = 0;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(805, 809);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(117, 46);
            this.btn_Close.TabIndex = 196;
            this.btn_Close.Text = "Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close_2.png");
            this.imageList1.Images.SetKeyName(1, "Release Detained License 512.png");
            // 
            // btn_Release
            // 
            this.btn_Release.BackColor = System.Drawing.Color.Green;
            this.btn_Release.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Release.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Release.ForeColor = System.Drawing.Color.White;
            this.btn_Release.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Release.ImageKey = "Release Detained License 512.png";
            this.btn_Release.ImageList = this.imageList1;
            this.btn_Release.Location = new System.Drawing.Point(930, 809);
            this.btn_Release.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Release.Name = "btn_Release";
            this.btn_Release.Size = new System.Drawing.Size(136, 46);
            this.btn_Release.TabIndex = 195;
            this.btn_Release.Text = "Release";
            this.btn_Release.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Release.UseVisualStyleBackColor = false;
            this.btn_Release.Click += new System.EventHandler(this.btn_Release_Click);
            // 
            // gp_DetainInfo
            // 
            this.gp_DetainInfo.Controls.Add(this.pictureBox8);
            this.gp_DetainInfo.Controls.Add(this.lbl_ApplicationID);
            this.gp_DetainInfo.Controls.Add(this.label9);
            this.gp_DetainInfo.Controls.Add(this.lbl_TotalFees);
            this.gp_DetainInfo.Controls.Add(this.label8);
            this.gp_DetainInfo.Controls.Add(this.pictureBox6);
            this.gp_DetainInfo.Controls.Add(this.lbl_ApplicationFees);
            this.gp_DetainInfo.Controls.Add(this.label7);
            this.gp_DetainInfo.Controls.Add(this.pictureBox5);
            this.gp_DetainInfo.Controls.Add(this.lbl_FineFees);
            this.gp_DetainInfo.Controls.Add(this.pictureBox7);
            this.gp_DetainInfo.Controls.Add(this.lbl_LicenseID);
            this.gp_DetainInfo.Controls.Add(this.label10);
            this.gp_DetainInfo.Controls.Add(this.pictureBox2);
            this.gp_DetainInfo.Controls.Add(this.pictureBox1);
            this.gp_DetainInfo.Controls.Add(this.label2);
            this.gp_DetainInfo.Controls.Add(this.lbl_CreatedByUser);
            this.gp_DetainInfo.Controls.Add(this.label3);
            this.gp_DetainInfo.Controls.Add(this.pictureBox3);
            this.gp_DetainInfo.Controls.Add(this.lbl_DetainDate);
            this.gp_DetainInfo.Controls.Add(this.pictureBox4);
            this.gp_DetainInfo.Controls.Add(this.label5);
            this.gp_DetainInfo.Controls.Add(this.lbl_DetainID);
            this.gp_DetainInfo.Controls.Add(this.label4);
            this.gp_DetainInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_DetainInfo.Location = new System.Drawing.Point(12, 592);
            this.gp_DetainInfo.Name = "gp_DetainInfo";
            this.gp_DetainInfo.Size = new System.Drawing.Size(1053, 208);
            this.gp_DetainInfo.TabIndex = 194;
            this.gp_DetainInfo.TabStop = false;
            this.gp_DetainInfo.Text = "Detain Info";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_UI.Properties.Resources.id;
            this.pictureBox8.Location = new System.Drawing.Point(609, 157);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 35);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 202;
            this.pictureBox8.TabStop = false;
            // 
            // lbl_ApplicationID
            // 
            this.lbl_ApplicationID.AutoSize = true;
            this.lbl_ApplicationID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ApplicationID.Location = new System.Drawing.Point(665, 157);
            this.lbl_ApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ApplicationID.Name = "lbl_ApplicationID";
            this.lbl_ApplicationID.Size = new System.Drawing.Size(37, 24);
            this.lbl_ApplicationID.TabIndex = 201;
            this.lbl_ApplicationID.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(434, 157);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 24);
            this.label9.TabIndex = 200;
            this.label9.Text = "Application ID:";
            // 
            // lbl_TotalFees
            // 
            this.lbl_TotalFees.AutoSize = true;
            this.lbl_TotalFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_TotalFees.Location = new System.Drawing.Point(215, 159);
            this.lbl_TotalFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TotalFees.Name = "lbl_TotalFees";
            this.lbl_TotalFees.Size = new System.Drawing.Size(43, 24);
            this.lbl_TotalFees.TabIndex = 199;
            this.lbl_TotalFees.Text = "$$$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(18, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 24);
            this.label8.TabIndex = 197;
            this.label8.Text = "Total Fees:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_UI.Properties.Resources.money_32;
            this.pictureBox6.Location = new System.Drawing.Point(162, 157);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 35);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 198;
            this.pictureBox6.TabStop = false;
            // 
            // lbl_ApplicationFees
            // 
            this.lbl_ApplicationFees.AutoSize = true;
            this.lbl_ApplicationFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ApplicationFees.Location = new System.Drawing.Point(661, 121);
            this.lbl_ApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ApplicationFees.Name = "lbl_ApplicationFees";
            this.lbl_ApplicationFees.Size = new System.Drawing.Size(43, 24);
            this.lbl_ApplicationFees.TabIndex = 196;
            this.lbl_ApplicationFees.Text = "$$$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(413, 121);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 24);
            this.label7.TabIndex = 194;
            this.label7.Text = "Application Fees:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_UI.Properties.Resources.money_32;
            this.pictureBox5.Location = new System.Drawing.Point(608, 119);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 195;
            this.pictureBox5.TabStop = false;
            // 
            // lbl_FineFees
            // 
            this.lbl_FineFees.AutoSize = true;
            this.lbl_FineFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_FineFees.Location = new System.Drawing.Point(213, 121);
            this.lbl_FineFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_FineFees.Name = "lbl_FineFees";
            this.lbl_FineFees.Size = new System.Drawing.Size(43, 24);
            this.lbl_FineFees.TabIndex = 193;
            this.lbl_FineFees.Text = "$$$";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_UI.Properties.Resources.Driver_License_48;
            this.pictureBox7.Location = new System.Drawing.Point(609, 29);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(31, 33);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 192;
            this.pictureBox7.TabStop = false;
            // 
            // lbl_LicenseID
            // 
            this.lbl_LicenseID.AutoSize = true;
            this.lbl_LicenseID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_LicenseID.Location = new System.Drawing.Point(665, 38);
            this.lbl_LicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LicenseID.Name = "lbl_LicenseID";
            this.lbl_LicenseID.Size = new System.Drawing.Size(37, 24);
            this.lbl_LicenseID.TabIndex = 191;
            this.lbl_LicenseID.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(473, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 24);
            this.label10.TabIndex = 190;
            this.label10.Text = "License ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.id;
            this.pictureBox2.Location = new System.Drawing.Point(161, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.person_svgrepo;
            this.pictureBox1.Location = new System.Drawing.Point(609, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(468, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 181;
            this.label2.Text = "Created By:";
            // 
            // lbl_CreatedByUser
            // 
            this.lbl_CreatedByUser.AutoSize = true;
            this.lbl_CreatedByUser.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_CreatedByUser.Location = new System.Drawing.Point(665, 82);
            this.lbl_CreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CreatedByUser.Name = "lbl_CreatedByUser";
            this.lbl_CreatedByUser.Size = new System.Drawing.Size(37, 24);
            this.lbl_CreatedByUser.TabIndex = 180;
            this.lbl_CreatedByUser.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(16, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 177;
            this.label3.Text = "Fine Fees:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(160, 119);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 178;
            this.pictureBox3.TabStop = false;
            // 
            // lbl_DetainDate
            // 
            this.lbl_DetainDate.AutoSize = true;
            this.lbl_DetainDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_DetainDate.Location = new System.Drawing.Point(213, 80);
            this.lbl_DetainDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DetainDate.Name = "lbl_DetainDate";
            this.lbl_DetainDate.Size = new System.Drawing.Size(98, 24);
            this.lbl_DetainDate.TabIndex = 176;
            this.lbl_DetainDate.Text = "??/??/????";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UI.Properties.Resources.date;
            this.pictureBox4.Location = new System.Drawing.Point(161, 80);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 175;
            this.pictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(16, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 24);
            this.label5.TabIndex = 174;
            this.label5.Text = "Detain Date:";
            // 
            // lbl_DetainID
            // 
            this.lbl_DetainID.AutoSize = true;
            this.lbl_DetainID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_DetainID.Location = new System.Drawing.Point(213, 38);
            this.lbl_DetainID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DetainID.Name = "lbl_DetainID";
            this.lbl_DetainID.Size = new System.Drawing.Size(37, 24);
            this.lbl_DetainID.TabIndex = 173;
            this.lbl_DetainID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 172;
            this.label4.Text = "Detain ID:";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(7, 65);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1064, 530);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 193;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<DVLD_Business.clsLicenses>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1074, 58);
            this.label1.TabIndex = 192;
            this.label1.Text = "Release Detained License";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReleaseDetainedLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(1074, 875);
            this.Controls.Add(this.llbl_ShowLicenseInfo);
            this.Controls.Add(this.llbl_ShowLicenseHistory);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Release);
            this.Controls.Add(this.gp_DetainInfo);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release Detained License";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicenseApplication_Load);
            this.gp_DetainInfo.ResumeLayout(false);
            this.gp_DetainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llbl_ShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbl_ShowLicenseHistory;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Release;
        private System.Windows.Forms.GroupBox gp_DetainInfo;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbl_LicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_CreatedByUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl_DetainDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_DetainID;
        private System.Windows.Forms.Label label4;
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ApplicationFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbl_FineFees;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lbl_ApplicationID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_TotalFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ImageList imageList1;
    }
}