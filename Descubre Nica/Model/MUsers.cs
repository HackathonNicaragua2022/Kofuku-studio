using System;
using Firebase.Auth;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Firebase.Database;

namespace Descubre_Nica.Model
{
    public class MUsers
    {
        public Guid UserID { get; set; }
        public string NUser { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
