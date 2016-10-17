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
            this.btnManageDogSpeciesTraits = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewDog
            // 
            this.btnAddNewDog.Location = new System.Drawing.Point(28, 151);
            this.btnAddNewDog.Name = "btnAddNewDog";
            this.btnAddNewDog.Size = new System.Drawing.Size(191, 23);
            this.btnAddNewDog.TabIndex = 0;
            this.btnAddNewDog.Text = "Mangage Dog Species";
            this.btnAddNewDog.UseVisualStyleBackColor = true;
            this.btnAddNewDog.Click += new System.EventHandler(this.btnAddNewDog_Click);
            // 
            // btnManageDogAppearance
            // 
            this.btnManageDogAppearance.Location = new System.Drawing.Point(28, 209);
            this.btnManageDogAppearance.Name = "btnManageDogAppearance";
            this.btnManageDogAppearance.Size = new System.Drawing.Size(191, 23);
            this.btnManageDogAppearance.TabIndex = 1;
            this.btnManageDogAppearance.Text = "Manage Dog Appearance";
            this.btnManageDogAppearance.UseVisualStyleBackColor = true;
            this.btnManageDogAppearance.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManagePersonalityAndTraits
            // 
            this.btnManagePersonalityAndTraits.Location = new System.Drawing.Point(28, 238);
            this.btnManagePersonalityAndTraits.Name = "btnManagePersonalityAndTraits";
            this.btnManagePersonalityAndTraits.Size = new System.Drawing.Size(191, 23);
            this.btnManagePersonalityAndTraits.TabIndex = 2;
            this.btnManagePersonalityAndTraits.Text = "Manage Dog Appearance Traits";
            this.btnManagePersonalityAndTraits.UseVisualStyleBackColor = true;
            this.btnManagePersonalityAndTraits.Click += new System.EventHandler(this.btnManagePersonalityAndTraits_Click);
            // 
            // btnManageDogSpeciesTraits
            // 
            this.btnManageDogSpeciesTraits.Location = new System.Drawing.Point(28, 180);
            this.btnManageDogSpeciesTraits.Name = "btnManageDogSpeciesTraits";
            this.btnManageDogSpeciesTraits.Size = new System.Drawing.Size(191, 23);
            this.btnManageDogSpeciesTraits.TabIndex = 3;
            this.btnManageDogSpeciesTraits.Text = "Manage Dog Species Traits";
            this.btnManageDogSpeciesTraits.UseVisualStyleBackColor = true;
            this.btnManageDogSpeciesTraits.Click += new System.EventHandler(this.btnManageDogSpeciesTraits_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(28, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 104);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search for Perfect Dog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnManageDogSpeciesTraits);
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
        private System.Windows.Forms.Button btnManageDogSpeciesTraits;
        private System.Windows.Forms.Button button1;
    }
}

