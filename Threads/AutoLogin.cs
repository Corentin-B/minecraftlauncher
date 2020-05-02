using MinecraftLauncher.MojangInformations;
using System;
using System.Threading;
using CmlLib.Launcher;

namespace MinecraftLauncher.Threads
{
    class AutoLogin
    {
        private readonly FormMain formMain;

        public AutoLogin(FormMain form)
        {
            formMain = form;
        }

        public void LoginAuto(string email, string password, string username, bool autorun, string ramamount)
        {
            Thread threadAutoLogin = new Thread(() => ThreadAutoLogin(email, password, username, autorun, ramamount));
            threadAutoLogin.Start();
        }

        private void ThreadAutoLogin(string email, string password, string username, bool autorun, string ramamount)
        {
            formMain.pannelswitch(false);
            MSession sessionUtilisateur = null;
            ThreadLogin threadLogin = new ThreadLogin(formMain);

            if (!String.IsNullOrEmpty(email) && !String.IsNullOrWhiteSpace(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrWhiteSpace(password))
            {
                Thread threadLoginMojang = new Thread(() => threadLogin.ThreadLoginMojang(email, password));
                threadLoginMojang.Start();
                threadLoginMojang.Join();
            }
            else if (String.IsNullOrEmpty(username) && String.IsNullOrWhiteSpace(username))
            {
                Thread threadLoginOffline = new Thread(() => threadLogin.ThreadLoginOffline(username));
                threadLoginOffline.Start();
                threadLoginOffline.Join();
            }

            sessionUtilisateur = formMain.SessionUtilisateur;

            if (sessionUtilisateur != null && autorun)
                AutoRun(ramamount);
        }

        private void AutoRun(string ramamount)
        {
            Thread threadRunGame = new Thread(() => ThreadRunGame(ramamount));
            threadRunGame.Start();
            formMain.InfoLabel("Running Minecraft");
            formMain.PannelLaunch(false);
        }

        private void ThreadRunGame(string ramAmount)
        {
            runMinecraft runMinecraft = new runMinecraft();
            MSession sessionUtilisateur = formMain.SessionUtilisateur;
            MProfile profileUtilisateur = formMain.ProfileUtilisateur;

            runMinecraft.Run(profileUtilisateur, sessionUtilisateur, ramAmount);
        }
    }
}
