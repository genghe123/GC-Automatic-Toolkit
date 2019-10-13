namespace GC_Automatic_ToolKit.UserInterface
{
    partial class MainForm
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
            this.Apply_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Peroid_textbox = new System.Windows.Forms.TextBox();
            this.WaitingTime = new System.Windows.Forms.TextBox();
            this.Peroid_label = new System.Windows.Forms.Label();
            this.Waiting_Before_NextRun_label = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.RunTimes_textbox = new System.Windows.Forms.TextBox();
            this.RunTimes_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.systemSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runningSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Apply_button
            // 
            this.Apply_button.Location = new System.Drawing.Point(63, 356);
            this.Apply_button.Margin = new System.Windows.Forms.Padding(2);
            this.Apply_button.Name = "Apply_button";
            this.Apply_button.Size = new System.Drawing.Size(67, 20);
            this.Apply_button.TabIndex = 5;
            this.Apply_button.Text = "Start";
            this.Apply_button.UseVisualStyleBackColor = true;
            this.Apply_button.Click += new System.EventHandler(this.Apply_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(215, 355);
            this.Cancel_button.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(67, 20);
            this.Cancel_button.TabIndex = 6;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Peroid_textbox
            // 
            this.Peroid_textbox.Location = new System.Drawing.Point(4, 39);
            this.Peroid_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.Peroid_textbox.Name = "Peroid_textbox";
            this.Peroid_textbox.Size = new System.Drawing.Size(68, 21);
            this.Peroid_textbox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.Peroid_textbox, "GC采样时间\r\nDefault: 15min");
            this.Peroid_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Peroid_textbox_KeyPress);
            // 
            // WaitingTime
            // 
            this.WaitingTime.Location = new System.Drawing.Point(4, 117);
            this.WaitingTime.Margin = new System.Windows.Forms.Padding(2);
            this.WaitingTime.Name = "WaitingTime";
            this.WaitingTime.Size = new System.Drawing.Size(68, 21);
            this.WaitingTime.TabIndex = 4;
            this.toolTip1.SetToolTip(this.WaitingTime, "GC采样完成后至下次进样前等待时间\r\nDefault:30s");
            this.WaitingTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sequence_textbox_KeyPress);
            // 
            // Peroid_label
            // 
            this.Peroid_label.AutoSize = true;
            this.Peroid_label.Location = new System.Drawing.Point(4, 23);
            this.Peroid_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Peroid_label.Name = "Peroid_label";
            this.Peroid_label.Size = new System.Drawing.Size(29, 12);
            this.Peroid_label.TabIndex = 4;
            this.Peroid_label.Text = "周期";
            // 
            // Waiting_Before_NextRun_label
            // 
            this.Waiting_Before_NextRun_label.AutoSize = true;
            this.Waiting_Before_NextRun_label.Location = new System.Drawing.Point(4, 101);
            this.Waiting_Before_NextRun_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Waiting_Before_NextRun_label.Name = "Waiting_Before_NextRun_label";
            this.Waiting_Before_NextRun_label.Size = new System.Drawing.Size(113, 12);
            this.Waiting_Before_NextRun_label.TabIndex = 5;
            this.Waiting_Before_NextRun_label.Text = "下次运行前等待时间";
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(146, 52);
            this.Log.Margin = new System.Windows.Forms.Padding(2);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(214, 184);
            this.Log.TabIndex = 6;
            this.Log.TabStop = false;
            this.Log.Text = "";
            this.Log.UseWaitCursor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(367, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(42, 22);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemSettingsToolStripMenuItem,
            this.runningSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFeedbackToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // sendFeedbackToolStripMenuItem
            // 
            this.sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            this.sendFeedbackToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sendFeedbackToolStripMenuItem.Text = "Send Feedback";
            this.sendFeedbackToolStripMenuItem.Click += new System.EventHandler(this.sendFeedbackToolStripMenuItem_Click);
            // 
            // TimeProgressBar
            // 
            this.TimeProgressBar.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.TimeProgressBar.Location = new System.Drawing.Point(17, 261);
            this.TimeProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.TimeProgressBar.Name = "TimeProgressBar";
            this.TimeProgressBar.Size = new System.Drawing.Size(341, 18);
            this.TimeProgressBar.Step = 1;
            this.TimeProgressBar.TabIndex = 8;
            // 
            // RunTimes_textbox
            // 
            this.RunTimes_textbox.Location = new System.Drawing.Point(4, 77);
            this.RunTimes_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.RunTimes_textbox.Name = "RunTimes_textbox";
            this.RunTimes_textbox.Size = new System.Drawing.Size(68, 21);
            this.RunTimes_textbox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.RunTimes_textbox, "GC采样次数\r\nDefault: 1 time");
            this.RunTimes_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RunTimes_textbox_KeyPress);
            // 
            // RunTimes_label
            // 
            this.RunTimes_label.AutoSize = true;
            this.RunTimes_label.Location = new System.Drawing.Point(6, 63);
            this.RunTimes_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RunTimes_label.Name = "RunTimes_label";
            this.RunTimes_label.Size = new System.Drawing.Size(53, 12);
            this.RunTimes_label.TabIndex = 10;
            this.RunTimes_label.Text = "运行次数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.WaitingTime);
            this.groupBox1.Controls.Add(this.RunTimes_label);
            this.groupBox1.Controls.Add(this.Waiting_Before_NextRun_label);
            this.groupBox1.Controls.Add(this.RunTimes_textbox);
            this.groupBox1.Controls.Add(this.Peroid_textbox);
            this.groupBox1.Controls.Add(this.Peroid_label);
            this.groupBox1.Location = new System.Drawing.Point(17, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(125, 190);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "min";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // systemSettingsToolStripMenuItem
            // 
            this.systemSettingsToolStripMenuItem.Name = "systemSettingsToolStripMenuItem";
            this.systemSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.systemSettingsToolStripMenuItem.Text = "SystemSettings";
            this.systemSettingsToolStripMenuItem.Click += new System.EventHandler(this.systemSettingsToolStripMenuItem_Click);
            // 
            // runningSettingsToolStripMenuItem
            // 
            this.runningSettingsToolStripMenuItem.Name = "runningSettingsToolStripMenuItem";
            this.runningSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runningSettingsToolStripMenuItem.Text = "RunningSettings";
            this.runningSettingsToolStripMenuItem.Click += new System.EventHandler(this.runningSettingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TimeProgressBar);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Apply_button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "GC Automatic Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Apply_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.TextBox Peroid_textbox;
        private System.Windows.Forms.TextBox WaitingTime;
        private System.Windows.Forms.Label Peroid_label;
        private System.Windows.Forms.Label Waiting_Before_NextRun_label;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ProgressBar TimeProgressBar;
        private System.Windows.Forms.TextBox RunTimes_textbox;
        private System.Windows.Forms.Label RunTimes_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runningSettingsToolStripMenuItem;
    }
}