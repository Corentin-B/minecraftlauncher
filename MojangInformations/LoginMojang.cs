using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmlLib.Launcher;

namespace MinecraftLauncher.MojangInformations
{
    class LoginMojang
    {
        public LoginMojang()
        {
            Minecraft.Initialize("/game");
        }

        public string LoginOnlineOffline(string username, string password, bool offline)
        {
            if (offline)
            {
                return LoginToMinecraftOffline(username);
            }
            else
            {
                return LoginToMinecraft(username, password);
            }
        }

        private string LoginToMinecraft(string username, string password)
        {
            MLogin login = new MLogin();
            MSession session = null;

            session = login.TryAutoLogin();
            
            if(session.Result != MLoginResult.Success)
            {
                session = login.Authenticate(username, password);

                if(session.Result != MLoginResult.Success)
                {
                    return "Erreur de login : " + session.Result.ToString();
                   // throw new Exception("Erreur de login : " + session.Result.ToString());
                }
            }
            return session.Username;
        }

        private string LoginToMinecraftOffline(string username)
        {
            MSession session = MSession.GetOfflineSession(username);
            return session.Username;
        }
    }
}
