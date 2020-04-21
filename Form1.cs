using MinecraftLauncher.MojangInformations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftLauncher
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            label_info.Text = "";
            label_progressbar.Text = "";
            label_progressbar.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            LoginMojang loginMojang = new LoginMojang();
            label_info.Text = loginMojang.LoginOnlineOffline(
                textBox_username.Text, 
                textBox_password.Text, 
                false);
        }

        private void button_login_offline_Click(object sender, EventArgs e)
        {
            LoginMojang loginMojang = new LoginMojang();
            label_info.Text = loginMojang.LoginOnlineOffline(
                textBox_username_offline.Text, 
                "", 
                true);
        }

        private void button_run_Click(object sender, EventArgs e)
        {

        }
    }
}
