using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BGSupport.FileSupport
{
    static public class LoadFile
    {
        static public string Load(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                sr.Close();
                return text;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
