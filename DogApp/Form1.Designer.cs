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
            this.button1 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Manage Dog Appearance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddNewDog);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewDog;
        private System.Windows.Forms.Button button1;
    }
}

