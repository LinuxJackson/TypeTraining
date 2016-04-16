using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AppFlags;

namespace BGSupport.FileSupport
{
    public class FileReader
    {
        private int fileLength;

        StreamReader sr;
        public FileReader(string filePath)
        {
            try
            {
                sr = new StreamReader(filePath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int FileLength
        {
            get
            {
                return fileLength;
            }

            set
            {
                fileLength = value;
            }
        }

        public string ReadNextLine()
        {
            try
            {
                if (sr.EndOfStream)
                {
                    sr.Close();
                    return Flag.FileLoadCompleteFlag;
                }
                return sr.ReadLine();
            }
            catch
            {
                sr.Close();
                return Flag.FileErrorFlag;
            }
        }

        public void CloseFile()
        {
            sr.Close();
        }
    }
}
