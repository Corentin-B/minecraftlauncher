using System;
using System.Threading;
using System.Windows.Forms;
using CmlLib.Launcher;
using MinecraftLauncher.MojangInformations;

namespace MinecraftLauncher.Threads
{
    class ThreadLogin
    {
        private readonly FormMain formMain;

        public ThreadLogin (FormMain form)
        {
            formMain = form;
        }

        public void LoginMojang(string email, string password)
        {
            Thread threadLoginMojang = new Thread(() => ThreadLoginMojang(email, password));
            threadLoginMojang.Start();
        }

        public void LoginMojang(string username)
        {
            Thread threadLoginOffline = new Thread(() => ThreadLoginOffline(username));
            threadLoginOffline.Start();
        }

        public void ThreadLoginMojang(string email, string password)
        {
            MSession sessionUtilisateur = null;

            try
            {
                LoginMojang loginMojang = new LoginMojang();
                sessionUtilisateur = loginMojang.LoginToMinecraft(email, password);

                formMain.AcountnameLabel("Bonjour " + sessionUtilisateur.Username);

                try
                {
                    Checkprofile();
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Erreur profil");
                }
            }
            catch (Exception ex)
            {
                formMain.InfoLabel("Error login incorrecte");
                formMain.PannelSwitch(true);
            }

            formMain.SessionUtilisateur = sessionUtilisateur;
        }

        public void ThreadLoginOffline(string username)
        {
            formMain.PannelSwitch(false);

            LoginMojang loginMojang = new LoginMojang();
            MSession sessionUtilisateur = loginMojang.LoginToMinecraftOffline(username);

            formMain.AcountnameLabel("Bonjour " + sessionUtilisateur.Username);
            Checkprofile();

            formMain.SessionUtilisateur = sessionUtilisateur;
        }

        private void Checkprofile()
        {
            LoginMojang loginMojang = new LoginMojang();
            MProfile profileUtilisateur = loginMojang.GetProfile();
            DownloadGame(profileUtilisateur);

            formMain.PannelLaunch(true);
            formMain.ProfileUtilisateur = profileUtilisateur;
        }

        private void DownloadGame(MProfile profile)
        {
            MDownloader downloader = new MDownloader(profile);
            downloader.ChangeFile += formMain.Downloader_ChangeFile;
            downloader.ChangeProgress += formMain.Downloader_ChangeProgress;
            downloader.DownloadAll();
        }
    }
}
