using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model_TP_AC33;

namespace BGSupport.UserRecord
{
    static public class ReadWriteRecord
    {
        static private void CheckCreateFile()
        {
            if (!File.Exists(AppFlags.Directories.temp + "Records.txt"))
                File.Create(AppFlags.Directories.temp + "Records.txt");
        }

        static public class ReadRecord
        {
            static public string[] Read()
            {
                try
                {
                    CheckCreateFile();
                    StreamReader sr = new StreamReader(AppFlags.Directories.temp + "Records.txt");
                    List<string> list = new List<string>();

                    while (!sr.EndOfStream)
                        list.Add(sr.ReadLine());
                    sr.Close();

                    string[] sResult = list.ToArray();
                    return sResult;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        static public void InsertRecord(Record_mod mod)
        {
            try
            {
                StreamReader sr = new StreamReader(AppFlags.Directories.temp + "Records.txt");
                string str = sr.ReadToEnd();
                sr.Close();

                str += mod.RecordTime.ToString("yy/MM/dd hh:mm") + "," + mod.Length + "," + mod.Speed + "\n";
                StreamWriter sw = new StreamWriter(AppFlags.Directories.temp + "Records.txt");
                sw.WriteLine(str);
                sw.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        static public void DeleteRecord(Record_mod mod)
        {
            try
            {
            }
            catch
            {
            }
        }
    }
}
