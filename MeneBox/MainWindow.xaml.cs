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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MeneBox
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegisterLogin(object sender, RoutedEventArgs e)
        {
            string Credential;
            TcpClient conn = new TcpClient("127.0.0.1", 20202);
            NetworkStream canale = conn.GetStream();
            if (((Button)sender).Content.ToString() == "LOGIN")
                Credential = "L|" + TB_User.Text + "|" + TB_Password.Password + "|";
            else
                Credential = "R|" + TB_User.Text + "|" + TB_Password.Password + "|";

            //trasformo una lista di byte in un array
            byte[] msg = (Encoding.ASCII.GetBytes(Credential)).ToArray();

            canale.Write(msg, 0, msg.Length);

            //attendo la risposta del server
            byte[] mesg = new byte[3];
            canale.Read(mesg, 0, mesg.Length);

            canale.Close();
            conn.Close();

            if (Encoding.ASCII.GetString(mesg) == "200")
            {
                //carico l'interfaccia del client
                new MeneBoxClient(TB_User.Text).Show();
                this.Close();
            }
            else
                if(((Button)sender).Content.ToString() == "LOGIN")
                    LB_Error.Content="User Name o Password Sabgliata";
            else
                LB_Error.Content = "User Name Già Esistente";
        }
    }
}
