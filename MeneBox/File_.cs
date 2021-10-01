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
    class File_
    {
        public string Nome { get; set; }
        public string Ico { get; set; }

        public File_(string N)
        {
            Nome = N;
            if (Nome.Split('.').Length >= 2)
            {
                switch (Nome.Split('.').Last())
                {
                    case "txt":
                    case "doc":
                    case "docx":
                        Ico = "../Img/doc.png";
                        break;
                    case "png":
                    case "jpg":
                    case "jpeg":
                    case "ico":
                        Ico = "../Img/Image.png";
                        break;

                    case "mp4":
                    case "avi":
                    case "mpeg":
                        Ico = "../Img/Video.png";
                        break;

                    case "mp3":
                    case "wav":
                    case "ogg":
                    case "midi":
                        Ico = "../Img/Audio.png";
                        break;

                    case "":
                        Ico = "../Img/Folder.png";
                        break;

                    case "pdf":
                        Ico = "../Img/Pdf.png";
                        break;

                    default:
                        Ico = "../Img/File.png";
                        break;
                }
            }
            else
                Ico = "../Img/Folder.png";
        }
    }
}
