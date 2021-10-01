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
using System.Windows.Shapes;
using System.Media;

namespace MeneBox
{
    /// <summary>
    /// Logica di interazione per Audio_listener.xaml
    /// </summary>
    public partial class Audio_listener : Window
    {
        SoundPlayer Sp;
        public Audio_listener(SoundPlayer S)
        {
            InitializeComponent();
            Sp = S;
        }

        private void BT_play_Click(object sender, RoutedEventArgs e)
        {
            Sp.Play();
        }

        private void BT_stop_Click(object sender, RoutedEventArgs e)
        {
            Sp.Stop();
        }
    }
}
