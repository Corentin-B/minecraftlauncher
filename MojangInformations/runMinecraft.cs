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
        private void Downloader_ChangeProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // when download file was changed
            // 20%, 30%, 80%, ...
            Console.WriteLine("{0}%", e.ProgressPercentage);
        }

        private void Downloader_ChangeFile(DownloadFileChangedEventArgs e)
        {
            // when the progress of current downloading file was changed
            // [Library] hi.jar - 3/51
            Console.WriteLine("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount);
        }

        public void run(MProfile profile, MSession session)
        {
            MDownloader downloader = new MDownloader(profile);
            downloader.ChangeFile += change_file;
            downloader.ChangeProgress += change_progress;
            downloader.DownloadAll();

            var option = new MLaunchOption()
            {
                // must require
                StartProfile = profile,
                JavaPath = "java.exe", //SET YOUR JAVA PATH (if you want autoset, goto wiki)
                MaximumRamMb = 4096, // MB
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
