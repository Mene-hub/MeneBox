using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MeneBox_server
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Utente> Users = new List<Utente>();
            string path = @"" + Directory.GetCurrentDirectory();
            GestioneFileXML.Path = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));

            if(File.Exists(GestioneFileXML.Path + "Users.xml"))
                Users = GestioneFileXML.LeggiUtenti();


            TcpListener listener = null;
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 20202);
            try
            {
                listener = new TcpListener(ip);
                listener.Start();
                while (true)
                {
                    TcpClient conn = listener.AcceptTcpClient();
                    new Demon(conn, ref Users);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
