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
using System.IO;

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
            panel_offline.Visible = false;
            panel_online.Visible = false;
            sessionUtilisateur = null;
            LoginMojang loginMojang = new LoginMojang();
            try
            {
                sessionUtilisateur = loginMojang.LoginToMinecraft(textBox_username.Text, textBox_password.Text);

                if (sessionUtilisateur != null)
                {
                    label_info.Text = sessionUtilisateur.Username;
                    checkprofile(loginMojang);
                }
                else
                {
                    label_info.Text = "Erreur de login";
                    sessionUtilisateur = null;
                    panel_offline.Visible = true;
                    panel_online.Visible = true;
                }
            }
            catch (Exception ex)
            {
                label_info.Text = "Error Login : " + ex;
                panel_offline.Visible = true;
                panel_online.Visible = true;
            }
        }

        private void button_login_offline_Click(object sender, EventArgs e)
        {
            sessionUtilisateur = null;

            if (String.IsNullOrEmpty(textBox_username_offline.Text))
            {
                label_info.Text = "Entrez un nom d'utilisateur";
            }
            else
            {
                LoginMojang loginMojang = new LoginMojang();
                sessionUtilisateur = loginMojang.LoginToMinecraftOffline(textBox_username_offline.Text);
                label_info.Text = sessionUtilisateur.Username;

                checkprofile(loginMojang);

                panel_offline.Visible = false;
                panel_online.Visible = false;
            }
        }

        private void checkprofile(LoginMojang loginMojang)
        {
            profileUtilisateur = loginMojang.GetProfile();
            panel_launch_progress.Visible = true;
            DownloadGame(profileUtilisateur);
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            runMinecraft runMinecraft = new runMinecraft();
            runMinecraft.run(profileUtilisateur, sessionUtilisateur);
        }

        private void DownloadGame(MProfile profile)
        {
            MDownloader downloader = new MDownloader(profile);
            downloader.ChangeFile += Downloader_ChangeFile;
            downloader.ChangeProgress += Downloader_ChangeProgress;
            downloader.DownloadAll();
        }

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
    }
}
