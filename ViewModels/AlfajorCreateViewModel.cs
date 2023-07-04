using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.ViewModels
{
    public class AlfajorCreateViewModel
    {
        public int AlfajorID { get; set; }
        public string NombreAlfajor { get; set; }
        public int Precio { get; set; }
        public int Calorias { get; set; }
        public List<int> MarcasIds { get; set; }
        public List<Alfajor> alfajors { get; set; } = new List<Alfajor>();
        public string ? nameFilter {get;set;}
    }
}   