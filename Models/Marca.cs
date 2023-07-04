using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.Models
{
    public class Marca
    {
        public int MarcaID { get; set; }
        public string NombreMarca { get; set; }
        public string PaisMarca { get; set; }
        public virtual List<Alfajor> Alfajors { get; set; }       
        
        // = new List<Alfajor>();  
    }
}