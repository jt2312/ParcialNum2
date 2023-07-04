using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.Services
{
    public interface IAlfajorService
    {
        void Create(Alfajor obj);
        List<Alfajor> GetAll(string filter);
        List<Alfajor> GetAll();
        void Update(Alfajor obj);
        void Delete(Alfajor id);
        Alfajor? GetById(int id);        
    }
}