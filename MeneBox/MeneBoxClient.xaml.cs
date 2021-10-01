using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MeneBox
{
    /// <summary>
    /// Logica di interazione per MeneBoxClient.xaml
    /// </summary>
    public partial class MeneBoxClient : Window
    {
        string User;
        List<File_> Files = new List<File_>();
        string Current_path;
        string ipserver = "127.0.0.1";
        public MeneBoxClient(string UserName)
        {
            //so che non si dovrebe fare ma ho messo l'assegnazione prima dell'metodo altrimenti non sarebbe stato inviato correttamente il messaggio
            User = UserName;
            Current_path = User;
            InitializeComponent();
        }

        private void Update(object sender, EventArgs e)
        {
            update_List();
            File_Directory.ItemsSource = Files;
            File_Directory.Items.Refresh();

            User_Logo.Content = User;
            User_Logo.Icon = (User.ToArray())[0];

        }

        private void BT_Carica_Click(object sender, RoutedEventArgs e)
        {
            //istaznzio la finestra per il caricamento
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Title = "Seleziona File";
            OpenFile.Filter = "Tutti i file|*.*";
            OpenFile.InitialDirectory = "";
            string File = "";

            //memorizzo le proprieta
            if (OpenFile.ShowDialog() == true)
            {
                File = OpenFile.FileName;
            }

            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();

            byte[] file;
            if (OpenFile.FileName != "")
            {
                file = System.IO.File.ReadAllBytes(File);
                if (file.Length <= 50000000)
                {
                    //instanzio la connessione per l'invio del file
                    byte[] msg = new byte[1024];
                    msg = Encoding.ASCII.GetBytes(("Upload|" + Current_path + "\\" + OpenFile.FileName.Split('\\').Last() + "|"));
                    canale.Write(msg, 0, msg.Length);
                    //faccio un handshake perchè altrimenti non funziona potrei provare a fare un thread sleep
                    canale.Read(msg, 0, msg.Length);
                    if (Encoding.ASCII.GetString(msg).Split('|')[0] == "200")
                    {
                        canale.Write(file, 0, file.Length);
                    }
                    Files.Add(new File_(OpenFile.FileName.Split('\\').Last()));
                }
                else
                    MessageBox.Show("Il File che stai tentanto di caricare è troppo pesante");
            }
            else
                canale.Write(Encoding.ASCII.GetBytes(("400|")), 0, 4);
            conn.Close();
            canale.Close();

            File_Directory.Items.Refresh();
        }

        private void DownloadFile(object sender, RoutedEventArgs e)
        {
            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();
            byte[] msg = (Encoding.ASCII.GetBytes(("Download|" + Current_path + "\\" + ((File_)File_Directory.SelectedItem).Nome + "|"))).ToArray();
            canale.Write(msg, 0, msg.Length);

            //Ricevo il file
            int length;
            List<byte> listaRange = new List<byte>();
            while ((length = canale.Read(msg, 0, msg.Length)) > 0 && canale.CanRead)
            {
                listaRange.AddRange(msg);
            }
            byte[] itemByte = listaRange.ToArray();
            string path = @"" + Directory.GetCurrentDirectory();
            path = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));
            try
            {
                string path_ = select_download_directory();
                if(((File_)File_Directory.SelectedItem).Nome.Split('.').Length==2)
                System.IO.File.WriteAllBytes(path_ + "\\" + ((File_)File_Directory.SelectedItem).Nome, itemByte);
                else
                    System.IO.File.WriteAllBytes(path_ + "\\" + ((File_)File_Directory.SelectedItem).Nome + ".zip", itemByte);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
            conn.Close();
            canale.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Delete_Account_Click(object sender, RoutedEventArgs e)
        {
            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();
            byte[] msg = (Encoding.ASCII.GetBytes(("DeleteAccount|" + User + "|"))).ToArray();
            canale.Write(msg, 0, msg.Length);
            canale.Close();
            conn.Close();
            new MainWindow().Show();
            this.Close();
        }

        private void update_List()
        {
            File_Directory.SelectedIndex = -1;
            Download_File.IsEnabled = false;
            Delete_File.IsEnabled = false;

            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();
            byte[] msg = (Encoding.ASCII.GetBytes(("Update|" + Current_path + "|"))).ToArray();
            canale.Write(msg, 0, msg.Length);
            Files.Clear();
            //attendo la risposta del server con la lista di file

            byte[] B = new byte[1024];
            canale.Read(B, 0, B.Length);

            string message = Encoding.ASCII.GetString(B);

            if (B.Length > 0)
            {
                if (message.Split('|').Length > 1)
                    for (int i = 0; i < message.Split('|').Length - 1; i++)
                    {
                        Files.Add(new File_(message.Split('|')[i]));
                    }
                else
                    if (message.Split('|').Length == 1 && message.Split('|')[0].Split('\0')[0] != "")
                {
                    Files.Add(new File_(message.Split('|')[0]));
                }
            }
            conn.Close();
            canale.Close();

            Files.OrderBy(o => o.Nome).ToList();
        }

        private string select_download_directory()
        {
            string dw = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                dw=dialog.FileName;
            }

            return dw;
        }

        private void File_selected(object sender, SelectionChangedEventArgs e)
        {
            if (File_Directory.SelectedIndex > -1)
            {
                Download_File.IsEnabled = true;
                Delete_File.IsEnabled = true;
            }
        }

        private void DirectoryChange(object sender, MouseButtonEventArgs e)
        {
            //quando faccio double click sulla list view controlle se è un item
            string[] item;
            if ((item = ((File_)((ListView)sender).SelectedItem).Nome.Split('.')).Length == 1)
            {
                Current_path += "/" + item[0];
                update_List();
                File_Directory.Items.Refresh();
            }
            else
            {
                switch (((File_)((ListView)sender).SelectedItem).Nome.Split('.').Last()) 
                {
                    case "png":
                    case "jpg":
                    case "jpeg":
                        byte[] Byte = cose();
                        MemoryStream ms = new MemoryStream(Byte.ToArray());
                        BitmapImage bit = new BitmapImage();
                        bit.BeginInit();
                        bit.StreamSource = ms;
                        bit.EndInit();
                        new Image_visualizer(bit).Show();
                        break;
                    case "wav":
                        byte[] Bytes = cose();
                        MemoryStream Ms = new MemoryStream(Bytes.ToArray());
                        SoundPlayer Sp = new SoundPlayer();
                        Sp.Stream = Ms;
                        new Audio_listener(Sp).Show();
                        break;
                }
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            if (Current_path != User)
            {
                Current_path = Current_path.Replace(Current_path.Split('/').Last(), "*");
                Current_path = Current_path.Replace("/*", "");

                update_List();
                File_Directory.Items.Refresh();
            }
        }

        private void New_Directory_Click(object sender, RoutedEventArgs e)
        {
            new New_Directory(ipserver, Current_path).ShowDialog();
            update_List();
            File_Directory.Items.Refresh();
        }

            private void Download_Click(object sender, RoutedEventArgs e)
            {
                string pathd = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                pathd += "\\" + "Downloads";
                System.Diagnostics.Process.Start("explorer.exe", pathd);
            }

        private void BT_testo_Click(object sender, RoutedEventArgs e)
        {
            new New_txt(ipserver, Current_path).ShowDialog();
            update_List();
            File_Directory.Items.Refresh();
        }

        private void Delete_File_Click(object sender, RoutedEventArgs e)
        {
            string file = Current_path + "/" + ((File_)File_Directory.SelectedItem).Nome;
            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();
            byte[] msg = (Encoding.ASCII.GetBytes(("DeleteFile|" + file + "|"))).ToArray();
            canale.Write(msg, 0, msg.Length);
            conn.Close();
            canale.Close();
            update_List();
            File_Directory.Items.Refresh();
        }

        private byte[] cose()
        {
            TcpClient conn = new TcpClient(ipserver, 20202);
            NetworkStream canale = conn.GetStream();
            byte[] msg = (Encoding.ASCII.GetBytes(("Download|" + Current_path + "\\" + ((File_)File_Directory.SelectedItem).Nome + "|"))).ToArray();
            canale.Write(msg, 0, msg.Length);

            int length;
            List<byte> listaRange = new List<byte>();
            while ((length = canale.Read(msg, 0, msg.Length)) > 0 && canale.CanRead)
            {
                listaRange.AddRange(msg);
            }
            byte[] itemByte = listaRange.ToArray();

            return itemByte;
        }
    }
}
