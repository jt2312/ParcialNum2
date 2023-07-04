using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.ViewModels
{
    public class MarcaCreateViewModel
    {
        public int MarcaID { get; set; }
        public string NombreMarca { get; set; }
        public string PaisMarca { get; set; }
        public List<int> MarcasIds { get; set; }
        public List<Marca> marcasss { get; set; } = new List<Marca>();


        //public string ? nameFilter { get; set; }
    }
}