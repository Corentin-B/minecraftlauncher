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
using CmlLib.Launcher;

namespace MinecraftLauncher
{
    public partial class FormMain : Form
    {
        MSession sessionUtilisateur;
        MProfile profileUtilisateur;

        public FormMain()
        {
            InitializeComponent();
            label_info.Text = "";
            label_progressbar.Text = "";
            panel_launch_progress.Visible = false;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            sessionUtilisateur = null;
            LoginMojang loginMojang = new LoginMojang();
            MSession session = loginMojang.LoginToMinecraft(textBox_username.Text, textBox_password.Text);
            label_info.Text = session.Username;
            loginMojang.GetProfile();
            panel_offline.Visible = false;
            panel_online.Visible = false;
            panel_info.Visible = true;
        }

        private void button_login_offline_Click(object sender, EventArgs e)
        {
            sessionUtilisateur = null;
            LoginMojang loginMojang = new LoginMojang();
            MSession session = loginMojang.LoginToMinecraftOffline(textBox_username_offline.Text);
            label_info.Text = session.Username;
            panel_offline.Visible = false;
            panel_online.Visible = false;
            panel_info.Visible = true;
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            runMinecraft runMinecraft = new runMinecraft();
            runMinecraft.run(profileUtilisateur, sessionUtilisateur);
        }
    }
}
