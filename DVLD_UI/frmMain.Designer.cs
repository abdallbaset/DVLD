namespace DVLD_UI
{
    partial class frmMain
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
            this.mst_Header = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mst_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // mst_Header
            // 
            this.mst_Header.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mst_Header.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mst_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.mst_Header.Location = new System.Drawing.Point(0, 0);
            this.mst_Header.Name = "mst_Header";
            this.mst_Header.Size = new System.Drawing.Size(1461, 48);
            this.mst_Header.TabIndex = 1;
            this.mst_Header.Text = "MenuHeader";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.people_list;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(175, 44);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.people;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(125, 44);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.id_card;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(127, 44);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.users;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(113, 44);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.settings_account_box;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(209, 44);
            this.accountSettingsToolStripMenuItem.Text = "AccountSettings";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 811);
            this.Controls.Add(this.mst_Header);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mst_Header;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mst_Header.ResumeLayout(false);
            this.mst_Header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mst_Header;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
    }
}

