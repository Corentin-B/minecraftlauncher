using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class runMinecraft
    {
        public void run()
        {
            var option = new MLaunchOption()
            {
                // must require
                StartProfile = profile,
                JavaPath = "java.exe", //SET YOUR JAVA PATH (if you want autoset, goto wiki)
                MaximumRamMb = 1024, // MB
                Session = session,

                // not require
                ServerIp = "", // connect server directly
                LauncherName = "", // display launcher name at main window
                CustomJavaParameter = "" // set your own java args
            };

            var launch = new MLaunch(option);
            var process = launch.GetProcess();
            process.Start();
        }
    }
}
