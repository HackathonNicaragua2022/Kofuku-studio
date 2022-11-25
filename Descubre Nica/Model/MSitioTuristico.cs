using System;
using System.Collections.Generic;
using System.Text;

namespace Descubre_Nica.Model
{
    public class MSitioTuristico
    {
        public Guid SitioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IdMunicipio { get; set; }
        public int IdTipo { get; set; }
    }
}
