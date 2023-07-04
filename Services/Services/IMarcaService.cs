using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;
namespace Parcial2.Services
{
    public interface IMarcaService
    {
        void Create(Marca obj);
        List<Marca> GetAll();
        void Update(Marca obj);
        void Delete(Marca obj);
        Marca? GetById(int id);
    }
}
    // void Create (Estudiante obj);
    // List<Estudiante?> GetAll();
    // void Update (Estudiante obj);
    // void Delete (Estudiante obj);
    // Estudiante? GetById(int id);