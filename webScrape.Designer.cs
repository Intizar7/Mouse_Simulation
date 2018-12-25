namespace Mouse_Simulation
{
    partial class webScrape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(webScrape));
            this.txtlink = new System.Windows.Forms.TextBox();
            this.save_link = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtlink
            // 
            this.txtlink.Location = new System.Drawing.Point(5, 12);
            this.txtlink.Name = "txtlink";
            this.txtlink.Size = new System.Drawing.Size(371, 20);
            this.txtlink.TabIndex = 0;
            // 
            // save_link
            // 
            this.save_link.BackColor = System.Drawing.Color.DodgerBlue;
            this.save_link.Location = new System.Drawing.Point(382, 6);
            this.save_link.Name = "save_link";
            this.save_link.Size = new System.Drawing.Size(75, 31);
            this.save_link.TabIndex = 1;
            this.save_link.Text = "Save Link";
            this.save_link.UseVisualStyleBackColor = false;
            this.save_link.Click += new System.EventHandler(this.save_link_Click);
            // 
            // webScrape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 42);
            this.Controls.Add(this.save_link);
            this.Controls.Add(this.txtlink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "webScrape";
            this.Text = "webScrape";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtlink;
        private System.Windows.Forms.Button save_link;
    }
}