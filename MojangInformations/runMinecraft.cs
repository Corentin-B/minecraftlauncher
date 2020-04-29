using CmlLib.Launcher;
using System;

namespace MinecraftLauncher.MojangInformations
{
    class runMinecraft
    {
        public void Run(MProfile profile, MSession session, string ram)
        {
            int ramNumber = Checkram(ram);

            MLaunchOption option = LaunchOption(profile, session, ramNumber);

            MLaunch launch = new MLaunch(option);
            launch.GetProcess().Start();
        }

        private MLaunchOption LaunchOption(MProfile profile, MSession session , int ramNumber)
        {
            return new MLaunchOption()
            {
                // must require
                StartProfile = profile,
                JavaPath = @"C:\Program Files (x86)\Minecraft Launcher\runtime\jre-x64\bin\javaw.exe", // javapath
                MaximumRamMb = ramNumber, // MB
                Session = session,

                // not require
                //ServerIp = "GAME-FR-251.MTXSERV.COM:27150", // connect server directly //Unknow Host
                LauncherName = "Artemia", // display launcher name at main window
                CustomJavaParameter = "-XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M" // set your own java args                                                                                                                                                                                       // set your own java args
            };
        }

        private int Checkram(string ram)
        {
            int ramNumber = Int32.Parse(ram);
            if (ramNumber % 1024 == 0)
            {
                return ramNumber;
            }
            else
            {
                return 4096;
            }
        }
    }
}
