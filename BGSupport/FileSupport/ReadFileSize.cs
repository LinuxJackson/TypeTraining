using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BGSupport.FileSupport
{
    static public class ReadFileSize
    {
        static public int Read(string str)
        {
            StringReader sr = new StringReader(str);
            int size = 0;
            try
            {
                while (true)
                    size = size + sr.ReadLine().Trim().Length;
            }
            catch
            {

            }
            return size;
        }
    }
}
