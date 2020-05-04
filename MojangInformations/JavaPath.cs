using Microsoft.Win32;
using System;
using System.IO;

namespace MinecraftLauncher.MojangInformations
{
    class JavaPath
    {
        public string chechJavawPath(string javawlocation)
        {
            if (String.IsNullOrEmpty(javawlocation))
                return GetJavaPath() + @"\bin\javaw.exe";
            else
            {
                if (File.Exists(javawlocation))
                    return javawlocation;
                else
                    return GetJavaPath() + @"\bin\javaw.exe";
            }
        }

        private string GetJavaPath()
        {
            //64 bits only
            string javalocation = checkRegsitry("JDK");

            if (javalocation != null && javalocation != "")
                return javalocation;
            else
                return checkRegsitry("Java Runtime Environment");
        }
        //"Java Runtime Environment - CurrentVersion"
        private string checkRegsitry(string typeJava)
        {
            const string PATH_JAVASOFT = @"HKEY_LOCAL_MACHINE\Software\JavaSoft";

            string javalocation = (string)Registry.GetValue(PATH_JAVASOFT + "\\" + typeJava, "CurrentVersion", " ");

            if (javalocation != null && javalocation != " ")
            {
                javalocation = (string)Registry.GetValue(PATH_JAVASOFT + "\\" + typeJava + "\\" + javalocation, "JavaHome", " ");
                return javalocation;
            }
            return null;
        }
    }
}
