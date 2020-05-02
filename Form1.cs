using MinecraftLauncher.MojangInformations;
using MinecraftLauncher.Threads;
using System;
using System.Windows.Forms;
using CmlLib.Launcher;
using System.Threading;

namespace MinecraftLauncher
{
    public partial class FormMain : Form
    {
        private MSession sessionUtilisateur;
        private MProfile profileUtilisateur;

        public MSession SessionUtilisateur { get => sessionUtilisateur; set => sessionUtilisateur = value; }
        public MProfile ProfileUtilisateur { get => profileUtilisateur; set => profileUtilisateur = value; }

        public FormMain()
        {
            InitializeComponent();
            label_info.Text = "";
            label_acountname.Text = "";
            label_progressbar.Text = "";
        }

        #region Events

        private void FormMain_Load(object sender, EventArgs e)
        {
            bool autorun = checkBox_autorun.Checked = Properties.Settings.Default.autorun;
            checkBox_autologin.Checked = Properties.Settings.Default.autologin;
            string ram = comboBox_ramamount.Text = Properties.Settings.Default.ramAmount;
            string email = textBox_email.Text = Properties.Settings.Default.email;
            string password = textBox_password.Text = Properties.Settings.Default.password;
            string username = textBox_username_offline.Text = Properties.Settings.Default.offlineUsername;

            if (checkBox_autologin.Checked)
            {
                AutoLogin autoLogin = new AutoLogin(this);
                autoLogin.LoginAuto(email, password, username, autorun, ram);
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            pannelswitch(false);
            sessionUtilisateur = null;
            label_info.Text = "";

            if (!String.IsNullOrEmpty(textBox_email.Text) && !String.IsNullOrWhiteSpace(textBox_email.Text))
            {
                if (!String.IsNullOrEmpty(textBox_password.Text) && !String.IsNullOrWhiteSpace(textBox_password.Text))
                {
                    textBox_username_offline.Text = "";
                    ThreadLogin threadLogin = new ThreadLogin(this);
                    threadLogin.ThreadLoginMojang(textBox_email.Text, textBox_password.Text);
                }
                else
                    label_info.Text = "Entrez votre mot de passe";
            }
            else
                label_info.Text = "Entrez votre adresse mail";
        }

        private void button_login_offline_Click(object sender, EventArgs e)
        {
            sessionUtilisateur = null;

            if (!String.IsNullOrEmpty(textBox_username_offline.Text) && !String.IsNullOrWhiteSpace(textBox_username_offline.Text))
            {
                textBox_email.Text = "";
                textBox_password.Text = "";

                ThreadLogin threadLogin = new ThreadLogin(this);
                threadLogin.ThreadLoginOffline(textBox_username_offline.Text);
            }
            else
                label_info.Text = "Entrez un nom d'utilisateur";
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            panel_parameters.Enabled = false;
            string ramamount = comboBox_ramamount.Text;

            Thread threadRunGame = new Thread(() => ThreadRunGame(ramamount));
            threadRunGame.Start();
            label_info.Text = "Running Minecraft";
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            sessionUtilisateur = null;
            profileUtilisateur = null;
            pannelswitch(true);
        }

        private void comboBox_ramamount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ramAmount = comboBox_ramamount.Text;
            Properties.Settings.Default.Save();
        }

        private void checkBox_autologin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autologin = checkBox_autologin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_autorun_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autorun = checkBox_autorun.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion

        private void ThreadRunGame(string ramAmount)
        {
            runMinecraft runMinecraft = new runMinecraft();
            runMinecraft.Run(profileUtilisateur, sessionUtilisateur, ramAmount);
        }

        #region Update Interface

        public void Downloader_ChangeProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.ProgressPercentage;
            });
        }

        public void Downloader_ChangeFile(DownloadFileChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                label_progressbar.Text = e.FileKind.ToString() + " : " + e.FileName;
                progressBar2.Maximum = e.TotalFileCount;
                progressBar2.Value = e.ProgressedFileCount;
            });
        }

        public void pannelswitch(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                panel_offline.Enabled = value;
                panel_online.Enabled = value;
                panel_parameters.Enabled = !value;
            });
        }

        public void PannelLaunch(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                panel_launch_progress.Enabled = value;
            });
        }

        public void InfoLabel(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                label_info.Text = message;
            });
        }

        public void AcountnameLabel(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                label_acountname.Text = message;
            });
        }

        #endregion
    }
}
