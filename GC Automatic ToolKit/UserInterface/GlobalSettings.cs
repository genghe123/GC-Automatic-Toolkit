using System;
using System.IO;
using System.Windows.Forms;
using GC_Automatic_ToolKit.GCConfig;
using GC_Automatic_ToolKit.Handler;

namespace GC_Automatic_ToolKit.UserInterface
{
    public partial class GlobalSettings : Form
    {
        private PerkinElmerConfig _config;

        public GlobalSettings()
        {
            InitializeComponent();

            _config = XmlHandle.XmlRead();
            txtbox_InstrumentKey.Text = _config.InstrumentKey;
            txtbox_UserName.Text = _config.UserId;
            txtbox_password.Text = _config.Password;
            txtbox_rstFilePath.Text = _config.ResultPath.FullName;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            _config.UserId = txtbox_UserName.Text;
            _config.Password = txtbox_password.Text;
            _config.InstrumentKey = txtbox_InstrumentKey.Text;
            _config.ResultPath = new DirectoryInfo(txtbox_rstFilePath.Text);

            XmlHandle.XmlWrite(_config);
            Close();
        }
    }
}
