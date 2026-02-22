namespace DVLD_UI.Users
{
    partial class frmAddNewAndEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewAndEditUser));
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_PersonInfo = new System.Windows.Forms.TabPage();
            this.btn_Next = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ctrlPersonCardWithFilter1 = new DVLD_UI.Controls.ctrlPersonCardWithFilter();
            this.tp_LoginInfo = new System.Windows.Forms.TabPage();
            this.btn_Back = new System.Windows.Forms.Button();
            this.ckb_IsActive = new System.Windows.Forms.CheckBox();
            this.txt_ConfirmPassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tp_PersonInfo.SuspendLayout();
            this.tp_LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Mode.Location = new System.Drawing.Point(4, 23);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(1199, 47);
            this.lbl_Mode.TabIndex = 1;
            this.lbl_Mode.Text = "Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_PersonInfo);
            this.tabControl1.Controls.Add(this.tp_LoginInfo);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(25, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1167, 654);
            this.tabControl1.TabIndex = 2;
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
            this.btn_Next.TabIndex = 17;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
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
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(19, 36);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1129, 504);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // tp_LoginInfo
            // 
            this.tp_LoginInfo.Controls.Add(this.btn_Back);
            this.tp_LoginInfo.Controls.Add(this.ckb_IsActive);
            this.tp_LoginInfo.Controls.Add(this.txt_ConfirmPassWord);
            this.tp_LoginInfo.Controls.Add(this.label3);
            this.tp_LoginInfo.Controls.Add(this.txt_PassWord);
            this.tp_LoginInfo.Controls.Add(this.label2);
            this.tp_LoginInfo.Controls.Add(this.txt_UserName);
            this.tp_LoginInfo.Controls.Add(this.label4);
            this.tp_LoginInfo.Controls.Add(this.lbl_UserID);
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
            this.tp_LoginInfo.Text = "Login Info";
            this.tp_LoginInfo.UseVisualStyleBackColor = true;
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
            this.btn_Back.TabIndex = 69;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // ckb_IsActive
            // 
            this.ckb_IsActive.AutoSize = true;
            this.ckb_IsActive.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_IsActive.Location = new System.Drawing.Point(314, 290);
            this.ckb_IsActive.Name = "ckb_IsActive";
            this.ckb_IsActive.Size = new System.Drawing.Size(100, 26);
            this.ckb_IsActive.TabIndex = 68;
            this.ckb_IsActive.Text = "Is Active";
            this.ckb_IsActive.UseVisualStyleBackColor = true;
            // 
            // txt_ConfirmPassWord
            // 
            this.txt_ConfirmPassWord.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfirmPassWord.Location = new System.Drawing.Point(314, 226);
            this.txt_ConfirmPassWord.Name = "txt_ConfirmPassWord";
            this.txt_ConfirmPassWord.PasswordChar = '*';
            this.txt_ConfirmPassWord.Size = new System.Drawing.Size(248, 29);
            this.txt_ConfirmPassWord.TabIndex = 67;
            this.txt_ConfirmPassWord.Tag = "Confirm PassWord";
            this.txt_ConfirmPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ConfirmPassWord_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 22);
            this.label3.TabIndex = 65;
            this.label3.Text = "Confirm PassWord :";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PassWord.Location = new System.Drawing.Point(314, 170);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.PasswordChar = '*';
            this.txt_PassWord.Size = new System.Drawing.Size(248, 29);
            this.txt_PassWord.TabIndex = 64;
            this.txt_PassWord.Tag = "Pass Word";
            this.txt_PassWord.Validating += new System.ComponentModel.CancelEventHandler(this.txt_PassWord_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 62;
            this.label2.Text = "PassWord :";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(314, 112);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(248, 29);
            this.txt_UserName.TabIndex = 61;
            this.txt_UserName.Tag = "User Name";
            this.txt_UserName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_UserName_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 58;
            this.label4.Text = "User Name :";
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.AutoSize = true;
            this.lbl_UserID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserID.Location = new System.Drawing.Point(310, 58);
            this.lbl_UserID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(40, 22);
            this.lbl_UserID.TabIndex = 56;
            this.lbl_UserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "User ID :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(255, 223);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(255, 167);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(255, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(255, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Crimson;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(895, 772);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(131, 52);
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
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
            this.btn_Save.Location = new System.Drawing.Point(1057, 772);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(131, 52);
            this.btn_Save.TabIndex = 15;
            this.btn_Save.Text = "Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frmAddNewAndEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1207, 846);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_Mode);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewAndEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewAndEditUser";
            this.Activated += new System.EventHandler(this.frmAddNewAndEditUser_Activated);
            this.Load += new System.EventHandler(this.frmAddNewAndEditUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_PersonInfo.ResumeLayout(false);
            this.tp_LoginInfo.ResumeLayout(false);
            this.tp_LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_PersonInfo;
        private System.Windows.Forms.TabPage tp_LoginInfo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_UserID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckb_IsActive;
        private System.Windows.Forms.TextBox txt_ConfirmPassWord;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}