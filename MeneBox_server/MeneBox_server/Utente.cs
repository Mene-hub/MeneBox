using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeneBox_server
{
    public class Utente
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Utente() { }
        public Utente (string U, string P)
        {
            User = U;
            Password = P;
        }
    }
}
