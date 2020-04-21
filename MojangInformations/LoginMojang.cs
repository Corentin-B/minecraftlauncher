using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class LoginMojang
    {
        public LoginMojang()
        {
            Minecraft.Initialize("/game");
        }

        public MSession LoginToMinecraft(string username, string password)
        {
            MLogin login = new MLogin();
            MSession session = null;

            session = login.TryAutoLogin();
            
            if(session.Result != MLoginResult.Success)
            {
                session = login.Authenticate(username, password);

                if(session.Result != MLoginResult.Success)
                {
                    throw new Exception("Erreur de login : " + session.Result.ToString());
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
            MProfileInfo[] infos = MProfileInfo.GetProfiles();
            MessageBox.Show("Infos : " + infos.ToString());
            var local = MProfileInfo.GetProfilesFromLocal();
            MessageBox.Show("Local : " + local.ToString());
            return null;
        }
    }
}
