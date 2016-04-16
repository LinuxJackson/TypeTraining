using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BGSupport.FileSupport
{
    public static class FileCheck
    {
        public static void CheckCreate()
        {
            string dir = Environment.CurrentDirectory;
            if (!Directory.Exists(dir + @"\bgData\"))
            {
                Directory.CreateDirectory(dir + @"\bgData\");
                Directory.CreateDirectory(dir + @"\bgData\Temp\");
                Directory.CreateDirectory(dir + @"\bgData\user_passages\");
                Directory.CreateDirectory(dir + @"\bgData\user_settings\");
            }
            else
            {
                if (!Directory.Exists(dir + @"\bgData\Temp\"))
                    Directory.CreateDirectory(dir + @"\bgData\Temp\");
                if (!Directory.Exists(dir + @"\bgData\user_passages\"))
                    Directory.CreateDirectory(dir + @"\bgData\user_passages\");
                if (!Directory.Exists(dir + @"\bgData\user_settings\"))
                    Directory.CreateDirectory(dir + @"\bgData\user_settings\");
            }
            AppFlags.Directories.temp = dir + @"\bgData\Temp\";
            AppFlags.Directories.user_passage = dir + @"\bgData\user_passages\";
            AppFlags.Directories.user_settings = dir + @"\bgData\user_settings\";
        }
    }
}
