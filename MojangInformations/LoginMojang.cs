using System;
using System.IO;
using System.Windows.Forms;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class LoginMojang
    {
        private const string MINECRAFT_VERSION = "1.12.2-forge1.12.2-14.23.5.2847";

        public MSession LoginToMinecraft(string email, string password)
        {
            MLogin login = new MLogin();

            MSession session = login.Authenticate(email, password);

            if (session.Result != MLoginResult.Success)
            {
                throw new Exception(session.Result.ToString());
            }

            Properties.Settings.Default.email = email;
            Properties.Settings.Default.password = password;
            Properties.Settings.Default.Save();

            return session;
        }

        public MSession LoginToMinecraftOffline(string username)
        {
            Properties.Settings.Default.offlineUsername = username;
            Properties.Settings.Default.Save();

            return MSession.GetOfflineSession(username);
        }

        public MSession AutoLogin()
        {
            MLogin login = new MLogin();

            MSession session = login.TryAutoLogin();

            if (session.Result != MLoginResult.Success)
            {
                return null;
            }
            return session;
        }

        public MProfile GetProfile()
        {
            Minecraft.Initialize(Directory.GetCurrentDirectory() + @"\Minecraft\.minecraft");

            MProfileInfo[] versions = MProfileInfo.GetProfiles();
            MProfile profile = MProfile.FindProfile(versions, MINECRAFT_VERSION);

            return profile;
        }
    }
}
