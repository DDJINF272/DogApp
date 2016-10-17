namespace DogApp
{
    partial class ManageDogAppearance
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxTailType = new System.Windows.Forms.ComboBox();
            this.cbxCoatType = new System.Windows.Forms.ComboBox();
            this.cbxHeadType = new System.Windows.Forms.ComboBox();
            this.cbxEarType = new System.Windows.Forms.ComboBox();
            this.cbxBodyType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAppearanceID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAppearance = new System.Windows.Forms.Button();
            this.btnUpdateAppearance = new System.Windows.Forms.Button();
            this.btnDeleteAppearance = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 361);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxTailType);
            this.tabPage1.Controls.Add(this.cbxCoatType);
            this.tabPage1.Controls.Add(this.cbxHeadType);
            this.tabPage1.Controls.Add(this.cbxEarType);
            this.tabPage1.Controls.Add(this.cbxBodyType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbxAppearanceID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Appearance Details:";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxTailType
            // 
            this.cbxTailType.FormattingEnabled = true;
            this.cbxTailType.Location = new System.Drawing.Point(107, 168);
            this.cbxTailType.Name = "cbxTailType";
            this.cbxTailType.Size = new System.Drawing.Size(164, 21);
            this.cbxTailType.TabIndex = 25;
            // 
            // cbxCoatType
            // 
            this.cbxCoatType.FormattingEnabled = true;
            this.cbxCoatType.Location = new System.Drawing.Point(107, 141);
            this.cbxCoatType.Name = "cbxCoatType";
            this.cbxCoatType.Size = new System.Drawing.Size(164, 21);
            this.cbxCoatType.TabIndex = 24;
            // 
            // cbxHeadType
            // 
            this.cbxHeadType.FormattingEnabled = true;
            this.cbxHeadType.Location = new System.Drawing.Point(107, 114);
            this.cbxHeadType.Name = "cbxHeadType";
            this.cbxHeadType.Size = new System.Drawing.Size(164, 21);
            this.cbxHeadType.TabIndex = 23;
            // 
            // cbxEarType
            // 
            this.cbxEarType.FormattingEnabled = true;
            this.cbxEarType.Location = new System.Drawing.Point(107, 87);
            this.cbxEarType.Name = "cbxEarType";
            this.cbxEarType.Size = new System.Drawing.Size(164, 21);
            this.cbxEarType.TabIndex = 22;
            // 
            // cbxBodyType
            // 
            this.cbxBodyType.FormattingEnabled = true;
            this.cbxBodyType.Location = new System.Drawing.Point(107, 60);
            this.cbxBodyType.Name = "cbxBodyType";
            this.cbxBodyType.Size = new System.Drawing.Size(164, 21);
            this.cbxBodyType.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tail Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "(Select in case of update or delete) ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Coat Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Head Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ear Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Body Type:";
            // 
            // cbxAppearanceID
            // 
            this.cbxAppearanceID.FormattingEnabled = true;
            this.cbxAppearanceID.Location = new System.Drawing.Point(127, 18);
            this.cbxAppearanceID.Name = "cbxAppearanceID";
            this.cbxAppearanceID.Size = new System.Drawing.Size(144, 21);
            this.cbxAppearanceID.TabIndex = 3;
            this.cbxAppearanceID.SelectedIndexChanged += new System.EventHandler(this.cbxAppearanceID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Appearance ID:";
            // 
            // btnAddAppearance
            // 
            this.btnAddAppearance.Location = new System.Drawing.Point(12, 379);
            this.btnAddAppearance.Name = "btnAddAppearance";
            this.btnAddAppearance.Size = new System.Drawing.Size(177, 23);
            this.btnAddAppearance.TabIndex = 5;
            this.btnAddAppearance.Text = "Add New Appearance";
            this.btnAddAppearance.UseVisualStyleBackColor = true;
            this.btnAddAppearance.Click += new System.EventHandler(this.btnAddAppearnace_Click);
            // 
            // btnUpdateAppearance
            // 
            this.btnUpdateAppearance.Location = new System.Drawing.Point(195, 379);
            this.btnUpdateAppearance.Name = "btnUpdateAppearance";
            this.btnUpdateAppearance.Size = new System.Drawing.Size(177, 23);
            this.btnUpdateAppearance.TabIndex = 3;
            this.btnUpdateAppearance.Text = "Update Selected Appearance";
            this.btnUpdateAppearance.UseVisualStyleBackColor = true;
            this.btnUpdateAppearance.Click += new System.EventHandler(this.btnUpdateAppearance_Click);
            // 
            // btnDeleteAppearance
            // 
            this.btnDeleteAppearance.Location = new System.Drawing.Point(12, 408);
            this.btnDeleteAppearance.Name = "btnDeleteAppearance";
            this.btnDeleteAppearance.Size = new System.Drawing.Size(177, 23);
            this.btnDeleteAppearance.TabIndex = 4;
            this.btnDeleteAppearance.Text = "Delete Selected Appearance";
            this.btnDeleteAppearance.UseVisualStyleBackColor = true;
            this.btnDeleteAppearance.Click += new System.EventHandler(this.btnDeleteAppearance_Click);
            // 
            // ManageDogAppearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 443);
            this.Controls.Add(this.btnAddAppearance);
            this.Controls.Add(this.btnUpdateAppearance);
            this.Controls.Add(this.btnDeleteAppearance);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManageDogAppearance";
            this.Text = "ManageDogAppearance";
            this.Load += new System.EventHandler(this.ManageDogAppearance_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAppearanceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAppearance;
        private System.Windows.Forms.Button btnUpdateAppearance;
        private System.Windows.Forms.Button btnDeleteAppearance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTailType;
        private System.Windows.Forms.ComboBox cbxCoatType;
        private System.Windows.Forms.ComboBox cbxHeadType;
        private System.Windows.Forms.ComboBox cbxEarType;
        private System.Windows.Forms.ComboBox cbxBodyType;
    }
}