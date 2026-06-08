namespace DVLD_UI.Applications.ReplaceLostOrDamagedLicense
{
    partial class frmReplaceLostOrDamagedLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplaceLostOrDamagedLicenseApplication));
            this.llbl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_IssueReplacement = new System.Windows.Forms.Button();
            this.gp_ApplicationInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lbl_OldLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbl_ReplacedLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CreatedByUser = new System.Windows.Forms.Label();
            this.lbl_ApplicationFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_ApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_ApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_UI.Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.gb_ReplacementFor = new System.Windows.Forms.GroupBox();
            this.rb_LostLicense = new System.Windows.Forms.RadioButton();
            this.rb_DamagedLicense = new System.Windows.Forms.RadioButton();
            this.gp_ApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.gb_ReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // llbl_ShowLicenseInfo
            // 
            this.llbl_ShowLicenseInfo.AutoSize = true;
            this.llbl_ShowLicenseInfo.Enabled = false;
            this.llbl_ShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.llbl_ShowLicenseInfo.Location = new System.Drawing.Point(234, 856);
            this.llbl_ShowLicenseInfo.Name = "llbl_ShowLicenseInfo";
            this.llbl_ShowLicenseInfo.Size = new System.Drawing.Size(180, 24);
            this.llbl_ShowLicenseInfo.TabIndex = 190;
            this.llbl_ShowLicenseInfo.TabStop = true;
            this.llbl_ShowLicenseInfo.Text = "Show Licenses Info";
            this.llbl_ShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_ShowLicenseInfo_LinkClicked);
            // 
            // llbl_ShowLicenseHistory
            // 
            this.llbl_ShowLicenseHistory.AutoSize = true;
            this.llbl_ShowLicenseHistory.Enabled = false;
            this.llbl_ShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F);
            this.llbl_ShowLicenseHistory.Location = new System.Drawing.Point(20, 856);
            this.llbl_ShowLicenseHistory.Name = "llbl_ShowLicenseHistory";
            this.llbl_ShowLicenseHistory.Size = new System.Drawing.Size(208, 24);
            this.llbl_ShowLicenseHistory.TabIndex = 189;
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
            this.btn_Close.Location = new System.Drawing.Point(713, 845);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(117, 46);
            this.btn_Close.TabIndex = 188;
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
            this.imageList1.Images.SetKeyName(1, "Renew Driving License 32.png");
            // 
            // btn_IssueReplacement
            // 
            this.btn_IssueReplacement.BackColor = System.Drawing.Color.Green;
            this.btn_IssueReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IssueReplacement.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_IssueReplacement.ForeColor = System.Drawing.Color.White;
            this.btn_IssueReplacement.ImageIndex = 1;
            this.btn_IssueReplacement.ImageList = this.imageList1;
            this.btn_IssueReplacement.Location = new System.Drawing.Point(838, 845);
            this.btn_IssueReplacement.Margin = new System.Windows.Forms.Padding(4);
            this.btn_IssueReplacement.Name = "btn_IssueReplacement";
            this.btn_IssueReplacement.Size = new System.Drawing.Size(228, 46);
            this.btn_IssueReplacement.TabIndex = 187;
            this.btn_IssueReplacement.Text = "Issue Replacement";
            this.btn_IssueReplacement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_IssueReplacement.UseVisualStyleBackColor = false;
            this.btn_IssueReplacement.Click += new System.EventHandler(this.btn_IssueReplacement_Click);
            // 
            // gp_ApplicationInfo
            // 
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox8);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_OldLicenseID);
            this.gp_ApplicationInfo.Controls.Add(this.label12);
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox7);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_ReplacedLicenseID);
            this.gp_ApplicationInfo.Controls.Add(this.label10);
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox2);
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox1);
            this.gp_ApplicationInfo.Controls.Add(this.label2);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_CreatedByUser);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_ApplicationFees);
            this.gp_ApplicationInfo.Controls.Add(this.label3);
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox3);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_ApplicationDate);
            this.gp_ApplicationInfo.Controls.Add(this.pictureBox4);
            this.gp_ApplicationInfo.Controls.Add(this.label5);
            this.gp_ApplicationInfo.Controls.Add(this.lbl_ApplicationID);
            this.gp_ApplicationInfo.Controls.Add(this.label4);
            this.gp_ApplicationInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_ApplicationInfo.Location = new System.Drawing.Point(12, 578);
            this.gp_ApplicationInfo.Name = "gp_ApplicationInfo";
            this.gp_ApplicationInfo.Size = new System.Drawing.Size(1055, 161);
            this.gp_ApplicationInfo.TabIndex = 186;
            this.gp_ApplicationInfo.TabStop = false;
            this.gp_ApplicationInfo.Text = "Application Info for License Replacement";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_UI.Properties.Resources.Driver_License_481;
            this.pictureBox8.Location = new System.Drawing.Point(837, 64);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 34);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 195;
            this.pictureBox8.TabStop = false;
            // 
            // lbl_OldLicenseID
            // 
            this.lbl_OldLicenseID.AutoSize = true;
            this.lbl_OldLicenseID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_OldLicenseID.Location = new System.Drawing.Point(875, 72);
            this.lbl_OldLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_OldLicenseID.Name = "lbl_OldLicenseID";
            this.lbl_OldLicenseID.Size = new System.Drawing.Size(37, 24);
            this.lbl_OldLicenseID.TabIndex = 194;
            this.lbl_OldLicenseID.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(638, 74);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 24);
            this.label12.TabIndex = 193;
            this.label12.Text = "Old License ID:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_UI.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox7.Location = new System.Drawing.Point(837, 31);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(31, 33);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 192;
            this.pictureBox7.TabStop = false;
            // 
            // lbl_ReplacedLicenseID
            // 
            this.lbl_ReplacedLicenseID.AutoSize = true;
            this.lbl_ReplacedLicenseID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ReplacedLicenseID.Location = new System.Drawing.Point(875, 38);
            this.lbl_ReplacedLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ReplacedLicenseID.Name = "lbl_ReplacedLicenseID";
            this.lbl_ReplacedLicenseID.Size = new System.Drawing.Size(37, 24);
            this.lbl_ReplacedLicenseID.TabIndex = 191;
            this.lbl_ReplacedLicenseID.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(606, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 24);
            this.label10.TabIndex = 190;
            this.label10.Text = "Replaced License ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.id;
            this.pictureBox2.Location = new System.Drawing.Point(218, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.person_svgrepo;
            this.pictureBox1.Location = new System.Drawing.Point(838, 99);
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
            this.label2.Location = new System.Drawing.Point(639, 109);
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
            this.lbl_CreatedByUser.Location = new System.Drawing.Point(876, 107);
            this.lbl_CreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CreatedByUser.Name = "lbl_CreatedByUser";
            this.lbl_CreatedByUser.Size = new System.Drawing.Size(46, 24);
            this.lbl_CreatedByUser.TabIndex = 180;
            this.lbl_CreatedByUser.Text = "????";
            // 
            // lbl_ApplicationFees
            // 
            this.lbl_ApplicationFees.AutoSize = true;
            this.lbl_ApplicationFees.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ApplicationFees.Location = new System.Drawing.Point(257, 109);
            this.lbl_ApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ApplicationFees.Name = "lbl_ApplicationFees";
            this.lbl_ApplicationFees.Size = new System.Drawing.Size(43, 24);
            this.lbl_ApplicationFees.TabIndex = 179;
            this.lbl_ApplicationFees.Text = "$$$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 24);
            this.label3.TabIndex = 177;
            this.label3.Text = "Application Fees:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(218, 107);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 178;
            this.pictureBox3.TabStop = false;
            // 
            // lbl_ApplicationDate
            // 
            this.lbl_ApplicationDate.AutoSize = true;
            this.lbl_ApplicationDate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ApplicationDate.Location = new System.Drawing.Point(256, 74);
            this.lbl_ApplicationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ApplicationDate.Name = "lbl_ApplicationDate";
            this.lbl_ApplicationDate.Size = new System.Drawing.Size(98, 24);
            this.lbl_ApplicationDate.TabIndex = 176;
            this.lbl_ApplicationDate.Text = "??/??/????";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UI.Properties.Resources.date;
            this.pictureBox4.Location = new System.Drawing.Point(218, 72);
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
            this.label5.Location = new System.Drawing.Point(16, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 24);
            this.label5.TabIndex = 174;
            this.label5.Text = "Application Date:";
            // 
            // lbl_ApplicationID
            // 
            this.lbl_ApplicationID.AutoSize = true;
            this.lbl_ApplicationID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_ApplicationID.Location = new System.Drawing.Point(256, 40);
            this.lbl_ApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ApplicationID.Name = "lbl_ApplicationID";
            this.lbl_ApplicationID.Size = new System.Drawing.Size(37, 24);
            this.lbl_ApplicationID.TabIndex = 173;
            this.lbl_ApplicationID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 24);
            this.label4.TabIndex = 172;
            this.label4.Text = "L.R.Application ID:";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(7, 51);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1064, 530);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 185;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<DVLD_Business.clsLicenses>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(1079, 58);
            this.lbl_Title.TabIndex = 191;
            this.lbl_Title.Text = "License Replacement";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_ReplacementFor
            // 
            this.gb_ReplacementFor.Controls.Add(this.rb_LostLicense);
            this.gb_ReplacementFor.Controls.Add(this.rb_DamagedLicense);
            this.gb_ReplacementFor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ReplacementFor.Location = new System.Drawing.Point(12, 745);
            this.gb_ReplacementFor.Name = "gb_ReplacementFor";
            this.gb_ReplacementFor.Size = new System.Drawing.Size(1055, 94);
            this.gb_ReplacementFor.TabIndex = 192;
            this.gb_ReplacementFor.TabStop = false;
            this.gb_ReplacementFor.Text = "Repalcement For:";
            // 
            // rb_LostLicense
            // 
            this.rb_LostLicense.AutoSize = true;
            this.rb_LostLicense.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_LostLicense.Location = new System.Drawing.Point(9, 55);
            this.rb_LostLicense.Name = "rb_LostLicense";
            this.rb_LostLicense.Size = new System.Drawing.Size(140, 28);
            this.rb_LostLicense.TabIndex = 1;
            this.rb_LostLicense.Text = "Lost License";
            this.rb_LostLicense.UseVisualStyleBackColor = true;
            // 
            // rb_DamagedLicense
            // 
            this.rb_DamagedLicense.AutoSize = true;
            this.rb_DamagedLicense.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_DamagedLicense.Location = new System.Drawing.Point(8, 27);
            this.rb_DamagedLicense.Name = "rb_DamagedLicense";
            this.rb_DamagedLicense.Size = new System.Drawing.Size(189, 28);
            this.rb_DamagedLicense.TabIndex = 0;
            this.rb_DamagedLicense.Text = "Damaged License";
            this.rb_DamagedLicense.UseVisualStyleBackColor = true;
            this.rb_DamagedLicense.CheckedChanged += new System.EventHandler(this.rb_DamagedLicense_CheckedChanged);
            // 
            // frmReplaceLostOrDamagedLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 901);
            this.Controls.Add(this.gb_ReplacementFor);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.llbl_ShowLicenseInfo);
            this.Controls.Add(this.llbl_ShowLicenseHistory);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_IssueReplacement);
            this.Controls.Add(this.gp_ApplicationInfo);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceLostOrDamagedLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Replacement";
            this.Load += new System.EventHandler(this.frmReplaceLostOrDamagedLicenseApplication_Load);
            this.gp_ApplicationInfo.ResumeLayout(false);
            this.gp_ApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.gb_ReplacementFor.ResumeLayout(false);
            this.gb_ReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llbl_ShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbl_ShowLicenseHistory;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_IssueReplacement;
        private System.Windows.Forms.GroupBox gp_ApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lbl_OldLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbl_ReplacedLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_CreatedByUser;
        private System.Windows.Forms.Label lbl_ApplicationFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl_ApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_ApplicationID;
        private System.Windows.Forms.Label label4;
        private Licenses.Local_Licenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.GroupBox gb_ReplacementFor;
        private System.Windows.Forms.RadioButton rb_LostLicense;
        private System.Windows.Forms.RadioButton rb_DamagedLicense;
        private System.Windows.Forms.ImageList imageList1;
    }
}