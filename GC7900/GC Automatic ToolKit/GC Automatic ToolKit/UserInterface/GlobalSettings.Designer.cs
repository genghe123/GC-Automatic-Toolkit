namespace GC_Automatic_ToolKit.UserInterface
{
    partial class GlobalSettings
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
            this.lab_InstrumentKey = new System.Windows.Forms.Label();
            this.txtbox_InstrumentKey = new System.Windows.Forms.TextBox();
            this.lab_UserName = new System.Windows.Forms.Label();
            this.txtbox_UserName = new System.Windows.Forms.TextBox();
            this.lab_Password = new System.Windows.Forms.Label();
            this.txtbox_password = new System.Windows.Forms.TextBox();
            this.checkbox_saveinformation = new System.Windows.Forms.CheckBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lab_rstFilePath = new System.Windows.Forms.Label();
            this.txtbox_rstFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lab_InstrumentKey
            // 
            this.lab_InstrumentKey.AutoSize = true;
            this.lab_InstrumentKey.Location = new System.Drawing.Point(10, 67);
            this.lab_InstrumentKey.Name = "lab_InstrumentKey";
            this.lab_InstrumentKey.Size = new System.Drawing.Size(89, 12);
            this.lab_InstrumentKey.TabIndex = 0;
            this.lab_InstrumentKey.Text = "Instrument Key";
            // 
            // txtbox_InstrumentKey
            // 
            this.txtbox_InstrumentKey.Location = new System.Drawing.Point(107, 64);
            this.txtbox_InstrumentKey.Name = "txtbox_InstrumentKey";
            this.txtbox_InstrumentKey.Size = new System.Drawing.Size(100, 21);
            this.txtbox_InstrumentKey.TabIndex = 3;
            // 
            // lab_UserName
            // 
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Location = new System.Drawing.Point(14, 13);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(53, 12);
            this.lab_UserName.TabIndex = 2;
            this.lab_UserName.Text = "UserName";
            // 
            // txtbox_UserName
            // 
            this.txtbox_UserName.Location = new System.Drawing.Point(107, 10);
            this.txtbox_UserName.Name = "txtbox_UserName";
            this.txtbox_UserName.Size = new System.Drawing.Size(100, 21);
            this.txtbox_UserName.TabIndex = 1;
            // 
            // lab_Password
            // 
            this.lab_Password.AutoSize = true;
            this.lab_Password.Location = new System.Drawing.Point(12, 40);
            this.lab_Password.Name = "lab_Password";
            this.lab_Password.Size = new System.Drawing.Size(53, 12);
            this.lab_Password.TabIndex = 4;
            this.lab_Password.Text = "Password";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Location = new System.Drawing.Point(107, 37);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.PasswordChar = '*';
            this.txtbox_password.Size = new System.Drawing.Size(100, 21);
            this.txtbox_password.TabIndex = 2;
            this.txtbox_password.UseSystemPasswordChar = true;
            // 
            // checkbox_saveinformation
            // 
            this.checkbox_saveinformation.AutoSize = true;
            this.checkbox_saveinformation.Location = new System.Drawing.Point(41, 121);
            this.checkbox_saveinformation.Name = "checkbox_saveinformation";
            this.checkbox_saveinformation.Size = new System.Drawing.Size(120, 16);
            this.checkbox_saveinformation.TabIndex = 4;
            this.checkbox_saveinformation.Text = "Save Information";
            this.checkbox_saveinformation.UseVisualStyleBackColor = true;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Apply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Apply.Location = new System.Drawing.Point(24, 165);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 5;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(122, 165);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lab_rstFilePath
            // 
            this.lab_rstFilePath.AutoSize = true;
            this.lab_rstFilePath.Location = new System.Drawing.Point(10, 95);
            this.lab_rstFilePath.Name = "lab_rstFilePath";
            this.lab_rstFilePath.Size = new System.Drawing.Size(95, 12);
            this.lab_rstFilePath.TabIndex = 7;
            this.lab_rstFilePath.Text = "Result FilePath";
            // 
            // txtbox_rstFilePath
            // 
            this.txtbox_rstFilePath.Location = new System.Drawing.Point(107, 92);
            this.txtbox_rstFilePath.Name = "txtbox_rstFilePath";
            this.txtbox_rstFilePath.Size = new System.Drawing.Size(100, 21);
            this.txtbox_rstFilePath.TabIndex = 8;
            // 
            // GlobalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 200);
            this.Controls.Add(this.txtbox_rstFilePath);
            this.Controls.Add(this.lab_rstFilePath);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.checkbox_saveinformation);
            this.Controls.Add(this.txtbox_password);
            this.Controls.Add(this.lab_Password);
            this.Controls.Add(this.txtbox_UserName);
            this.Controls.Add(this.lab_UserName);
            this.Controls.Add(this.txtbox_InstrumentKey);
            this.Controls.Add(this.lab_InstrumentKey);
            this.Name = "GlobalSettings";
            this.Text = "GlobalSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_InstrumentKey;
        private System.Windows.Forms.TextBox txtbox_InstrumentKey;
        private System.Windows.Forms.Label lab_UserName;
        private System.Windows.Forms.TextBox txtbox_UserName;
        private System.Windows.Forms.Label lab_Password;
        private System.Windows.Forms.TextBox txtbox_password;
        private System.Windows.Forms.CheckBox checkbox_saveinformation;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lab_rstFilePath;
        private System.Windows.Forms.TextBox txtbox_rstFilePath;
    }
}