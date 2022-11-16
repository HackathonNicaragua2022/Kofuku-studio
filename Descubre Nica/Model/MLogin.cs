using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Descubre_Nica.Model
{
    public class MLogin
    {
        public FileImageSource imagen{get; set;}
        public string Nombre{ get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NUser { get; set; }
        public string Clave { get; set; }
    }
}
