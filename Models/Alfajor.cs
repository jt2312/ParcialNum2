using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.Models
{
    public class Alfajor
    {   
        public int AlfajorID { get; set; }
        public string NombreAlfajor { get; set; }
        public int Precio { get; set; }
        public int Calorias { get; set; }
        public virtual List<Marca> Marcas { get; set; }

    }
}
