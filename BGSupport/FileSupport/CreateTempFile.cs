using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AppFlags;

namespace BGSupport.FileSupport
{
    //static public class CreateTempFile
    //{
        //static public int stringLength;
        //static public StringReader Create(string str)
        //{
        //    try
        //    {
        //        string result = "";

        //        StringReader sr = new StringReader(str);
        //        StringWriter sw = new StringWriter(new StringBuilder(result));
        //        string read = sr.ReadLine().Trim();
        //        int fileLength = 0;
        //        while (read != "\0")
        //        {
        //            sw.WriteLine(read);
        //            fileLength = fileLength + read.Length;
        //            try
        //            {
        //                read = sr.ReadLine().Trim();
        //            }
        //            catch { goto Finish; }
        //        }
        //        Finish:
        //        sw.Close();
        //        sr.Close();

        //        stringLength = fileLength;
        //        sr = new StringReader(result);
        //        return sr;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    //}
}
