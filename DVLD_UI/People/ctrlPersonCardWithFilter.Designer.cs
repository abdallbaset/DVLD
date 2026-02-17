namespace DVLD_UI.Controls
{
    partial class ctrlPersonCardWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardWithFilter));
            this.grb_Filter = new System.Windows.Forms.GroupBox();
            this.btn_Research = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mtxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.cmb_AllFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddPerson = new System.Windows.Forms.Button();
            this.ctrlPersonCard = new DVLD_UI.ctrlPersonCard();
            this.grb_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_Filter
            // 
            this.grb_Filter.Controls.Add(this.btn_Research);
            this.grb_Filter.Controls.Add(this.mtxt_Value);
            this.grb_Filter.Controls.Add(this.cmb_AllFilter);
            this.grb_Filter.Controls.Add(this.label2);
            this.grb_Filter.Controls.Add(this.btn_AddPerson);
            this.grb_Filter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_Filter.Location = new System.Drawing.Point(5, 3);
            this.grb_Filter.Name = "grb_Filter";
            this.grb_Filter.Size = new System.Drawing.Size(1119, 122);
            this.grb_Filter.TabIndex = 1;
            this.grb_Filter.TabStop = false;
            this.grb_Filter.Text = "Filter";
            // 
            // btn_Research
            // 
            this.btn_Research.BackColor = System.Drawing.Color.Transparent;
            this.btn_Research.ImageIndex = 1;
            this.btn_Research.ImageList = this.imageList1;
            this.btn_Research.Location = new System.Drawing.Point(616, 37);
            this.btn_Research.Name = "btn_Research";
            this.btn_Research.Size = new System.Drawing.Size(78, 45);
            this.btn_Research.TabIndex = 2;
            this.btn_Research.UseVisualStyleBackColor = false;
            this.btn_Research.Click += new System.EventHandler(this.btn_Research_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "person-add.png");
            this.imageList1.Images.SetKeyName(1, "search-people.png");
            // 
            // mtxt_Value
            // 
            this.mtxt_Value.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mtxt_Value.Location = new System.Drawing.Point(346, 46);
            this.mtxt_Value.Name = "mtxt_Value";
            this.mtxt_Value.Size = new System.Drawing.Size(250, 30);
            this.mtxt_Value.TabIndex = 1;
            this.mtxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxt_Value_KeyPress);
            // 
            // cmb_AllFilter
            // 
            this.cmb_AllFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmb_AllFilter.FormattingEnabled = true;
            this.cmb_AllFilter.Items.AddRange(new object[] {
            "Person ID",
            "National NO"});
            this.cmb_AllFilter.Location = new System.Drawing.Point(133, 46);
            this.cmb_AllFilter.Name = "cmb_AllFilter";
            this.cmb_AllFilter.Size = new System.Drawing.Size(207, 29);
            this.cmb_AllFilter.TabIndex = 0;
            this.cmb_AllFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_AllFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter By:";
            // 
            // btn_AddPerson
            // 
            this.btn_AddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddPerson.ImageIndex = 0;
            this.btn_AddPerson.ImageList = this.imageList1;
            this.btn_AddPerson.Location = new System.Drawing.Point(700, 37);
            this.btn_AddPerson.Name = "btn_AddPerson";
            this.btn_AddPerson.Size = new System.Drawing.Size(79, 45);
            this.btn_AddPerson.TabIndex = 3;
            this.btn_AddPerson.UseVisualStyleBackColor = false;
            this.btn_AddPerson.Click += new System.EventHandler(this.btn_AddPerson_Click);
            // 
            // ctrlPersonCard
            // 
            this.ctrlPersonCard.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlPersonCard.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ctrlPersonCard.Location = new System.Drawing.Point(5, 138);
            this.ctrlPersonCard.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrlPersonCard.Name = "ctrlPersonCard";
            this.ctrlPersonCard.Size = new System.Drawing.Size(1119, 360);
            this.ctrlPersonCard.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_Filter);
            this.Controls.Add(this.ctrlPersonCard);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(1129, 504);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.grb_Filter.ResumeLayout(false);
            this.grb_Filter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard;
        private System.Windows.Forms.GroupBox grb_Filter;
        private System.Windows.Forms.Button btn_Research;
        private System.Windows.Forms.MaskedTextBox mtxt_Value;
        private System.Windows.Forms.ComboBox cmb_AllFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddPerson;
        private System.Windows.Forms.ImageList imageList1;
    }
}
