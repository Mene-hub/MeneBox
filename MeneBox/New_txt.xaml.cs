using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
    /// Logica di interazione per New_txt.xaml
    /// </summary>
    public partial class New_txt : Window
    {
        string path;
        string ipserver;
        public New_txt(string ipserver, string path)
        {
            InitializeComponent();
            this.path = path;
            this.ipserver = ipserver;
        }

        private void BT_Salva_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (TB_Name.Text != "")
            {
                if (b.Name == "BT_Salva")
                {
                    TcpClient conn = new TcpClient("127.0.0.1", 20202);
                    NetworkStream canale = conn.GetStream();
                    byte[] msg = (Encoding.ASCII.GetBytes(("NewTxt|" + path + "\\" + TB_Name.Text + ".txt|" + TB_FileContent.Text + "|"))).ToArray();
                    canale.Write(msg, 0, msg.Length);
                    canale.Close();
                    conn.Close();
                    this.Close();
                }
                else
                    this.Close();
            }
            else
                MessageBox.Show("Nome del file non inserito");
        }
    }
}
