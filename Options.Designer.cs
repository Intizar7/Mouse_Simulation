namespace Mouse_Simulation
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.web_recorder_settings = new System.Windows.Forms.Label();
            this.plugin_settings = new System.Windows.Forms.Label();
            this.runtime_settings = new System.Windows.Forms.Label();
            this.view = new System.Windows.Forms.Label();
            this.email_settings = new System.Windows.Forms.Label();
            this.email_notifications = new System.Windows.Forms.Label();
            this.login_settings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.web_recorder_settings);
            this.splitContainer1.Panel1.Controls.Add(this.plugin_settings);
            this.splitContainer1.Panel1.Controls.Add(this.runtime_settings);
            this.splitContainer1.Panel1.Controls.Add(this.view);
            this.splitContainer1.Panel1.Controls.Add(this.email_settings);
            this.splitContainer1.Panel1.Controls.Add(this.email_notifications);
            this.splitContainer1.Panel1.Controls.Add(this.login_settings);
            this.splitContainer1.Size = new System.Drawing.Size(508, 213);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 0;
            // 
            // web_recorder_settings
            // 
            this.web_recorder_settings.AutoSize = true;
            this.web_recorder_settings.Location = new System.Drawing.Point(12, 171);
            this.web_recorder_settings.Name = "web_recorder_settings";
            this.web_recorder_settings.Size = new System.Drawing.Size(118, 13);
            this.web_recorder_settings.TabIndex = 6;
            this.web_recorder_settings.Text = "Web Recorder Settings";
            this.web_recorder_settings.Click += new System.EventHandler(this.web_recorder_settings_Click);
            // 
            // plugin_settings
            // 
            this.plugin_settings.AutoSize = true;
            this.plugin_settings.Location = new System.Drawing.Point(12, 150);
            this.plugin_settings.Name = "plugin_settings";
            this.plugin_settings.Size = new System.Drawing.Size(77, 13);
            this.plugin_settings.TabIndex = 5;
            this.plugin_settings.Text = "Plugin Settings";
            this.plugin_settings.Click += new System.EventHandler(this.plugin_settings_Click);
            // 
            // runtime_settings
            // 
            this.runtime_settings.AutoSize = true;
            this.runtime_settings.Location = new System.Drawing.Point(12, 122);
            this.runtime_settings.Name = "runtime_settings";
            this.runtime_settings.Size = new System.Drawing.Size(87, 13);
            this.runtime_settings.TabIndex = 4;
            this.runtime_settings.Text = "Runtime Settings";
            // 
            // view
            // 
            this.view.AutoSize = true;
            this.view.Location = new System.Drawing.Point(12, 97);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(30, 13);
            this.view.TabIndex = 3;
            this.view.Text = "View";
            // 
            // email_settings
            // 
            this.email_settings.AutoSize = true;
            this.email_settings.Location = new System.Drawing.Point(12, 72);
            this.email_settings.Name = "email_settings";
            this.email_settings.Size = new System.Drawing.Size(73, 13);
            this.email_settings.TabIndex = 2;
            this.email_settings.Text = "Email Settings";
            // 
            // email_notifications
            // 
            this.email_notifications.AutoSize = true;
            this.email_notifications.Location = new System.Drawing.Point(12, 44);
            this.email_notifications.Name = "email_notifications";
            this.email_notifications.Size = new System.Drawing.Size(93, 13);
            this.email_notifications.TabIndex = 1;
            this.email_notifications.Text = "Email Notifications";
            // 
            // login_settings
            // 
            this.login_settings.AutoSize = true;
            this.login_settings.Location = new System.Drawing.Point(13, 16);
            this.login_settings.Name = "login_settings";
            this.login_settings.Size = new System.Drawing.Size(74, 13);
            this.login_settings.TabIndex = 0;
            this.login_settings.Text = "Login Settings";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 213);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Options";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label web_recorder_settings;
        private System.Windows.Forms.Label plugin_settings;
        private System.Windows.Forms.Label runtime_settings;
        private System.Windows.Forms.Label view;
        private System.Windows.Forms.Label email_settings;
        private System.Windows.Forms.Label email_notifications;
        private System.Windows.Forms.Label login_settings;
    }
}