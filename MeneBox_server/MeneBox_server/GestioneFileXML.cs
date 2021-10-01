using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows;


namespace MeneBox_server
{
    static class GestioneFileXML
    {
        public static string Path;
        public static void ScriviUtenti(List<Utente> U)
        {
            string NomeFile = "Users.xml";
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Utente>));
                StreamWriter Sw = new StreamWriter(Path + NomeFile, false);
                xmls.Serialize(Sw, U);
                Sw.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static List<Utente> LeggiUtenti()
        {
            string NomeFile = "Users.xml";
                try
                {
                        XmlSerializer Xmls = new XmlSerializer(typeof(List<Utente>));
                        StreamReader Sr = new StreamReader(Path + NomeFile);
                        List<Utente> L = (List<Utente>)Xmls.Deserialize(Sr);
                        Sr.Close();
                        return L;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
        }

        public static string Leggi_File(string Nome)
        {
            string[] fileEntries = null;
            string UserFiles = "";

            string TempPath= Path + Nome;
            if (Directory.Exists(TempPath))
            {
                fileEntries = Directory.GetFileSystemEntries(TempPath, "*");
                if(fileEntries.Length>0)
                    for(int i=0;i<fileEntries.Length;i++)
                    {
                        fileEntries[i] = fileEntries[i].Split('\\').Last();
                        UserFiles = UserFiles + fileEntries[i] + "|";
                    }
            }
            else
                Directory.CreateDirectory(TempPath);
            return UserFiles;
        }

    }
}
