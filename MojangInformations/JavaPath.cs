

using Microsoft.Win32;
using System;

namespace MinecraftLauncher.MojangInformations
{
    class JavaPath
    {
        public string GetJavaPath()
        {
            //64 bits
            string javalocation = checkRegsitry("JDK");

            if (javalocation != null)
            {
                return javalocation;
            }
            else
            {
                return checkRegsitry("JRE");
            }
        }

        private string checkRegsitry(string typeJava)
        {
            const string PATH_JAVASOFT = @"HKEY_LOCAL_MACHINE\Software\JavaSoft";

            string javalocation = (string)Registry.GetValue(PATH_JAVASOFT + @"\" + typeJava, "CurrentVersion", " ");

            if (javalocation != null)
            {
                javalocation = (string)Registry.GetValue(PATH_JAVASOFT + @"\" + typeJava + @"\" + javalocation, "JavaHome", " ");
                return javalocation;
            }
            return null;
        }
    }
}
