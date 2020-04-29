using MinecraftLauncher.MojangInformations;
using System;
using System.Windows.Forms;
using CmlLib.Launcher;
using System.Threading;
using System.IO;

namespace MinecraftLauncher
{
    public partial class FormMain : Form
    {
        MSession sessionUtilisateur = null;
        MProfile profileUtilisateur = null;

        public FormMain()
        {
            InitializeComponent();
            label_info.Text = "";
            label_acountname.Text = "";
            label_progressbar.Text = "";
            panel_launch_progress.Enabled = false;
            panel_parameters.Enabled = false;
        }

        #region Events

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkBox_autorun.Checked = Properties.Settings.Default.autorun;
            comboBox_ramamount.Text = Properties.Settings.Default.ramAmount;
            textBox_email.Text = Properties.Settings.Default.email;
            textBox_password.Text = Properties.Settings.Default.password;
            textBox_username_offline.Text = Properties.Settings.Default.offlineUsername;

            string email = textBox_email.Text;
            string password = textBox_password.Text;
            string username = textBox_username_offline.Text;
            bool autorun = checkBox_autorun.Checked;
            string ram = comboBox_ramamount.Text;

            if (checkBox_autorun.Checked)
            {
                Thread threadAutoLogin = new Thread(() => ThreadAutoLogin(email, password, username, autorun, ram));
                threadAutoLogin.Start();
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
                    Thread threadLoginMojang = new Thread(new ThreadStart(ThreadLoginMojang));
                    threadLoginMojang.Start();
                    textBox_username_offline.Text = "";
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
                Thread threadLoginOffline = new Thread(new ThreadStart(ThreadLoginOffline));
                threadLoginOffline.Start();
                textBox_email.Text = "";
                textBox_password.Text = "";
            }
            else
            {
                label_info.Text = "Entrez un nom d'utilisateur";
            }
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

        private void checkBox_autorun_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autorun = checkBox_autorun.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion

        private void ThreadAutoLogin(string email, string password, string username, bool autorun, string ramamount)
        {
            pannelswitch(false);
            sessionUtilisateur = null;

            if (!String.IsNullOrEmpty(email) && !String.IsNullOrWhiteSpace(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrWhiteSpace(password))
            {
                Thread threadLoginMojang = new Thread(new ThreadStart(ThreadLoginMojang));
                threadLoginMojang.Start();
                threadLoginMojang.Join();
            }
            else if (String.IsNullOrEmpty(username) && String.IsNullOrWhiteSpace(username))
            {
                Thread threadLoginOffline = new Thread(new ThreadStart(ThreadLoginOffline));
                threadLoginOffline.Start();
                threadLoginOffline.Join();
            }
            
            if (sessionUtilisateur != null && autorun)
                AutoRun(ramamount);
        }

        private void AutoRun(string ramamount)
        {
            Thread threadRunGame = new Thread(() => ThreadRunGame(ramamount));
            threadRunGame.Start();
            infoLabel("Running Minecraft");
            PannelLaunch(false);
        }

        private void ThreadLoginMojang()
        {
            try
            {
                LoginMojang loginMojang = new LoginMojang();
                sessionUtilisateur = loginMojang.LoginToMinecraft(textBox_email.Text, textBox_password.Text);

                if (sessionUtilisateur != null)
                {
                    acountnameLabel("Bonjour " + sessionUtilisateur.Username);
                }
                else
                {
                    infoLabel("Erreur de login");
                    sessionUtilisateur = null;
                    pannelswitch(true);
                }
            }
            catch (Exception ex)
            {
                infoLabel("Error login incorrecte \n" + ex);//TODO Traiter les Exceptions
                sessionUtilisateur = null;
                pannelswitch(true);
            }
            try
            {
                if (sessionUtilisateur != null)
                {
                    Checkprofile();
                }
            }
            catch (Exception exep)
            {
                MessageBox.Show("Erreur profil");
            }
        }

        private void ThreadLoginOffline()
        {
            pannelswitch(false);

            LoginMojang loginMojang = new LoginMojang();
            sessionUtilisateur = loginMojang.LoginToMinecraftOffline(textBox_username_offline.Text);

            acountnameLabel("Bonjour " + sessionUtilisateur.Username);
            Checkprofile();
        }

        private void Checkprofile()
        {
            LoginMojang loginMojang = new LoginMojang();
            profileUtilisateur = loginMojang.GetProfile();
            DownloadGame(profileUtilisateur);

            Invoke((MethodInvoker)delegate
            {
                panel_launch_progress.Enabled = true;
            });
        }

        private void DownloadGame(MProfile profile)
        {
            MDownloader downloader = new MDownloader(profile);
            downloader.ChangeFile += Downloader_ChangeFile;
            downloader.ChangeProgress += Downloader_ChangeProgress;
            downloader.DownloadAll();
        }

        private void ThreadRunGame(string ramAmount)
        {
            runMinecraft runMinecraft = new runMinecraft();
            runMinecraft.Run(profileUtilisateur, sessionUtilisateur, ramAmount);
        }

        #region Update Interface

        private void Downloader_ChangeProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.ProgressPercentage;
            });
        }

        private void Downloader_ChangeFile(DownloadFileChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                label_progressbar.Text = e.FileKind.ToString() + " : " + e.FileName;
                progressBar2.Maximum = e.TotalFileCount;
                progressBar2.Value = e.ProgressedFileCount;
            });
        }

        private void pannelswitch(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                panel_offline.Enabled = value;
                panel_online.Enabled = value;
                panel_parameters.Enabled = !value;
            });
        }

        private void PannelLaunch(bool value)
        {
            Invoke((MethodInvoker)delegate
            {
                panel_launch_progress.Enabled = value;
            });
        }

        private void infoLabel(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                label_info.Text = message;
            });
        }

        private void acountnameLabel(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                label_acountname.Text = message;
            });
        }

        #endregion
    }
}
