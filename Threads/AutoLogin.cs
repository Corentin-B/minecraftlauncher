using MinecraftLauncher.MojangInformations;
using System;
using System.Threading;

namespace MinecraftLauncher.Threads
{
    class AutoLogin
    {
        private readonly FormMain formMain;

        public AutoLogin(FormMain form, Connection_elements connection_elements)
        {
            formMain = form;
            Thread threadAutoLogin = new Thread(() => ThreadAutoLogin(connection_elements)) ;
            threadAutoLogin.Start();
        }

        private void ThreadAutoLogin(Connection_elements connection_elements)
        {
            formMain.PannelSwitch(false);
            ThreadLogin threadLogin = new ThreadLogin(formMain);

            if (!String.IsNullOrEmpty(connection_elements.Email) && !String.IsNullOrWhiteSpace(connection_elements.Email) && !String.IsNullOrEmpty(connection_elements.Password) && !String.IsNullOrWhiteSpace(connection_elements.Password))
            {
                threadLogin.ThreadLoginMojang(connection_elements.Email, connection_elements.Password);
            }
            else if (String.IsNullOrEmpty(connection_elements.Username) && String.IsNullOrWhiteSpace(connection_elements.Username))
            {
                threadLogin.ThreadLoginOffline(connection_elements.Username);
            }

            if (formMain.SessionUtilisateur != null && formMain.ProfileUtilisateur != null && connection_elements.Autorun)
                AutoRun(connection_elements.Ramamount);
        }

        private void AutoRun(string ramamount)
        {
            ThreadRunGame(ramamount);
            formMain.InfoLabel("Initialisation de Minecraft");
            formMain.PannelLaunch(false);
        }

        private void ThreadRunGame(string ramAmount)
        {
            RunMinecraft runMinecraft = new RunMinecraft();
            formMain.InfoLabel("Running Minecraft");
            runMinecraft.Run(formMain.ProfileUtilisateur, formMain.SessionUtilisateur, ramAmount);
            new CheckProgramRunning(formMain);
        }
    }
}
