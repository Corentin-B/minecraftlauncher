using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftLauncher.Threads
{
    class CheckProgramRunning
    {
        private readonly FormMain formMain;

        public CheckProgramRunning(FormMain form, string program)
        {
            formMain = form;
            Thread threadWaitProgram = new Thread(() => WaitProgram(program));
            threadWaitProgram.Start();
        }

        private void WaitProgram(string program)
        {
            int timeout = 0;
            while (!IsRunning(program) && timeout < 10)
            {
                Thread.Sleep(3000);
                timeout++;
            }

            if (timeout < 10)
                formMain.InfoLabel("Lancement complet");
            else
            {
                formMain.InfoLabel("Erreur de lancement : Timeout");
                formMain.PannelLaunch(true);
            }
        }

        private bool IsRunning(string program)
        {
            Process[] listprocess = Process.GetProcessesByName(program);

            MessageBox.Show(listprocess.ToString());

            if (listprocess.Length != 0)
                return true;
            else
                return false;
        }
    }
}
