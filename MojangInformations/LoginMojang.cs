using System;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class LoginMojang
    {
        public MSession LoginToMinecraft(string username, string password)
        {
            MLogin login = new MLogin();

            MSession session = login.TryAutoLogin();
            
            if(session.Result != MLoginResult.Success)
            {
                session = login.Authenticate(username, password);

                if(session.Result != MLoginResult.Success)
                {
                    throw new Exception(session.Result.ToString());
                }
            }
            return session;
        }

        public MSession LoginToMinecraftOffline(string username)
        {
            return MSession.GetOfflineSession(username);
        }

        public MProfile GetProfile()
        {
            Minecraft.Initialize("C:\\Users\\Corentin.B\\Documents\\GitHub\\minecraftlauncher\\bin\\Debug\\Minecraft\\.minecraft");

            MProfileInfo[] infos = MProfileInfo.GetProfiles();
            MProfile profile = MProfile.FindProfile(infos, "1.12.2");

            return profile;
        }
    }
}
