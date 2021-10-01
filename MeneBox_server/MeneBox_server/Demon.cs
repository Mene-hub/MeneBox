using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO.Compression;

namespace MeneBox_server
{
    class Demon
    {
        TcpClient conn = null;
        List<Utente> Users = null;
        public Demon(TcpClient conn, ref List<Utente> Users)
        {
            this.conn = conn;
            new Thread(new ThreadStart(operazioni)).Start();
            this.Users = Users;
        }

        public void operazioni()
        {
            lock (this)
            {
                NetworkStream canale = conn.GetStream();
                byte[] msg = new byte[1024];
                byte[] code = new byte[3];
                canale.Read(msg, 0, msg.Length);
                string message = Encoding.ASCII.GetString(msg);
                string BCode = "200";
                Console.WriteLine("Richiesta arrivata");
                switch (message.Split('|')[0])
                {
                    //Gestione Login
                    case "L":
                        BCode = "400";
                        //controllo se l'utente esiste e se la password è corretta
                        if (!(message.Split('|')[1].Contains('\\') || message.Split('|')[1].Contains('/') || message.Split('|')[1].Contains('|') || message.Split('|')[1].Contains('"') || message.Split('|')[1].Contains(':') || message.Split('|')[1].Contains('*') || message.Split('|')[1].Contains('?') || message.Split('|')[1].Contains('<') || message.Split('|')[1].Contains('>')))
                            foreach (var item in Users)
                            {
                                if (message.Split('|')[1] == item.User && message.Split('|')[2] == item.Password)
                                {
                                    BCode = "200";
                                    break;
                                }
                            }
                        else
                            BCode = "401";

                        code = Encoding.ASCII.GetBytes(BCode);
                        canale.Write(code, 0, code.Length);
                        Console.WriteLine(BCode);
                        break;

                    //Gestione Registrazione
                    case "R":
                        //controllo se l'utente esiste e salvo le credenziali
                        if(Users!=null)
                            foreach(var item in Users)
                            {
                                if (message.Split('|')[1] == item.User)
                                {
                                    BCode = "400";
                                    break;
                                }
                            }

                        if (BCode == "200" )
                        {
                            Users.Add(new Utente(message.Split('|')[1], message.Split('|')[2]));
                            GestioneFileXML.ScriviUtenti(Users);
                        }

                        code = Encoding.ASCII.GetBytes(BCode);
                        canale.Write(code, 0, code.Length);
                        Console.WriteLine(BCode);
                        break;

                    //Gestione Update File
                    case "Update":
                        Update(message, canale);
                        break;

                    //Gestione Upload ffile del Client
                    case "Upload":
                        string Extension = message.Split('|')[1];

                        canale.Write(Encoding.ASCII.GetBytes(("200|")), 0, 4);

                        int length;
                        List<byte> listaRange = new List<byte>();
                        while ((length = canale.Read(msg, 0, msg.Length)) > 0 && canale.CanRead)
                        {
                            listaRange.AddRange(msg);
                        }
                        byte[] itemByte = listaRange.ToArray();

                        if (Encoding.ASCII.GetString(itemByte).Split('|')[0]!="400")
                            System.IO.File.WriteAllBytes(GestioneFileXML.Path + Extension, itemByte);

                        break;

                    //Gestione download file del client
                    case "Download":
                        byte[] file;
                        if (message.Split('|')[1].Split('/').Last().Split('.').Length == 2)
                            file = System.IO.File.ReadAllBytes(GestioneFileXML.Path + message.Split('|')[1]);
                        else
                        {
                            ZipFile.CreateFromDirectory(GestioneFileXML.Path + message.Split('|')[1], GestioneFileXML.Path + "temp.zip");
                            file = System.IO.File.ReadAllBytes(GestioneFileXML.Path + "temp.zip");
                            System.IO.File.Delete(GestioneFileXML.Path + "temp.zip");
                        }
                        canale.Write(file, 0, file.Length);
                        break;

                    case "DeleteAccount":
                        for (int i = 0; i < Users.Count; i++)
                        {
                            if(Users[i].User==message.Split('|')[1])
                            {
                                Users.RemoveAt(i);
                                break;
                            }
                        }
                        System.IO.Directory.Delete(GestioneFileXML.Path + "\\" + message.Split('|')[1], true);
                        GestioneFileXML.ScriviUtenti(Users);
                        break;

                    case "NewDyrectory":
                        System.IO.Directory.CreateDirectory(GestioneFileXML.Path + message.Split('|')[1]);
                        break;

                    case "NewTxt":
                        using (System.IO.StreamWriter NewFile = new System.IO.StreamWriter(GestioneFileXML.Path + "\\" + message.Split('|')[1], true))
                        {
                            NewFile.WriteLine(message.Split('|')[2]);
                        }
                        break;
                    case "DeleteFile":
                        if(message.Split('|')[1].Split('/').Last().Split('.').Length==2)
                            System.IO.File.Delete(GestioneFileXML.Path + "\\" + message.Split('|')[1]);
                        else
                            System.IO.Directory.Delete(GestioneFileXML.Path + "\\" + message.Split('|')[1], true);
                        break;
                }
                canale.Close();
                conn.Close();
            }
        }

        public void Update(string message, NetworkStream canale)
        {
            string messaggio = GestioneFileXML.Leggi_File(message.Split('|')[1]);
            byte[] UserFiles = Encoding.ASCII.GetBytes(messaggio).ToArray();
            canale.Write(UserFiles, 0, UserFiles.Length);
        }
    }
}
