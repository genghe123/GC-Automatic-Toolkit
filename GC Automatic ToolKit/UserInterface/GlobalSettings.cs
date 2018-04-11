using System;
using System.Windows.Forms;

namespace GC_Automatic_ToolKit.UserInterface
{
    public partial class GlobalSettings : Form
    {

        private string username;
        private string password;
        private string instrumentkey;
        private string rstfilepath;

        public string Rstfilepath { get => rstfilepath; set => rstfilepath = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Instrumentkey { get => instrumentkey; set => instrumentkey = value; }

        public GlobalSettings()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            Username = txtbox_UserName.Text;
            Password = txtbox_password.Text;
            Instrumentkey = txtbox_InstrumentKey.Text;
            Rstfilepath = txtbox_rstFilePath.Text;
            Close();
        }
    }
}
