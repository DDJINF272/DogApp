namespace DogApp
{
    partial class Form1
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
            this.btnAddNewDog = new System.Windows.Forms.Button();
            this.btnManageDogAppearance = new System.Windows.Forms.Button();
            this.btnManagePersonalityAndTraits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewDog
            // 
            this.btnAddNewDog.Location = new System.Drawing.Point(28, 22);
            this.btnAddNewDog.Name = "btnAddNewDog";
            this.btnAddNewDog.Size = new System.Drawing.Size(191, 23);
            this.btnAddNewDog.TabIndex = 0;
            this.btnAddNewDog.Text = "Mangage Dog Species";
            this.btnAddNewDog.UseVisualStyleBackColor = true;
            this.btnAddNewDog.Click += new System.EventHandler(this.btnAddNewDog_Click);
            // 
            // btnManageDogAppearance
            // 
            this.btnManageDogAppearance.Location = new System.Drawing.Point(28, 51);
            this.btnManageDogAppearance.Name = "btnManageDogAppearance";
            this.btnManageDogAppearance.Size = new System.Drawing.Size(191, 23);
            this.btnManageDogAppearance.TabIndex = 1;
            this.btnManageDogAppearance.Text = "Manage Dog Appearance";
            this.btnManageDogAppearance.UseVisualStyleBackColor = true;
            this.btnManageDogAppearance.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManagePersonalityAndTraits
            // 
            this.btnManagePersonalityAndTraits.Location = new System.Drawing.Point(28, 80);
            this.btnManagePersonalityAndTraits.Name = "btnManagePersonalityAndTraits";
            this.btnManagePersonalityAndTraits.Size = new System.Drawing.Size(191, 23);
            this.btnManagePersonalityAndTraits.TabIndex = 2;
            this.btnManagePersonalityAndTraits.Text = "Manage Dog Appearance Traits";
            this.btnManagePersonalityAndTraits.UseVisualStyleBackColor = true;
            this.btnManagePersonalityAndTraits.Click += new System.EventHandler(this.btnManagePersonalityAndTraits_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 315);
            this.Controls.Add(this.btnManagePersonalityAndTraits);
            this.Controls.Add(this.btnManageDogAppearance);
            this.Controls.Add(this.btnAddNewDog);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewDog;
        private System.Windows.Forms.Button btnManageDogAppearance;
        private System.Windows.Forms.Button btnManagePersonalityAndTraits;
    }
}

