using System;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class runMinecraft
    {

        public void run(MProfile profile, MSession session)
        {
            JavaPath javapath = new JavaPath();
            string javawlocation = javapath.GetJavaPath()+ @"/bin/javaw.exe";

            var option = new MLaunchOption()
            {
                // must require
                StartProfile = profile,
                //JavaPath = "java.exe", //SET YOUR JAVA PATH (if you want autoset, goto wiki)
                JavaPath = javawlocation,
                MaximumRamMb = 4096, // MB
                Session = session,

                // not require
                ServerIp = "", // connect server directly
                LauncherName = "Artemia", // display launcher name at main window
                CustomJavaParameter = "" // set your own java args
            };

            var launch = new MLaunch(option);
            var process = launch.GetProcess();
            process.Start();
        }
    }
}
