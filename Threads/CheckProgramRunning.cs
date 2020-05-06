using System.Diagnostics;
using System.Threading;

namespace MinecraftLauncher.Threads
{
    class CheckProgramRunning
    {
        private readonly FormMain formMain;

        public CheckProgramRunning(FormMain form)
        {
            formMain = form;
            WaitProgram();
        }

        private void WaitProgram()
        {
            int timeout = 0;
            while (!IsRunning() && timeout < 10)
            {
                Thread.Sleep(2000);
                timeout++;
            }

            if (timeout < 10)
                formMain.InfoLabel("Minecraft lancé");
            else
            {
                formMain.InfoLabel("Erreur de lancement : Timeout");
            }

            formMain.PannelLaunch(true);
            formMain.PannelSwitch(false);
        }

        private bool IsRunning()
        {
            bool processFind = false;

            Process[] listprocess = Process.GetProcessesByName("javaw");

            foreach (var item in listprocess)
            {
                if (item.MainWindowTitle == "Minecraft 1.12.2")
                    processFind = true;
            }

            return processFind;
        }
    }
}
