using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;

namespace Parcial2.Services;

public class AlfajorServices : IAlfajorService
    {
        private readonly AlfajorContext _context;

        public AlfajorServices(AlfajorContext context)
        {
            _context = context;
        }
        
        public void Create(Alfajor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = GetById(id);
        
            if (obj != null){
                _context.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Delete(Alfajor obj)
        {
                _context.Remove(obj);
                _context.SaveChanges();
        }

        public List<Alfajor> GetAll()
        {
            var query = GetQuery();
            return query.ToList();       
        }


        public List<Alfajor> GetAll(string nameFilter)
        {
            var query = GetQuery();

            if(!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.NombreAlfajor.ToLower().Contains(nameFilter.ToLower())
                || x.Calorias.ToString().Contains(nameFilter.ToLower()) 
                || x.Precio.ToString().Contains(nameFilter));
                }

            return query.ToList();
        }


        public Alfajor? GetById(int id)
        {
            var alfajor = _context.Alfajor
                    .Include(r => r.Marcas)
                    .FirstOrDefault(m => m.AlfajorID == id);
            return alfajor;
        }

        public void Update(Alfajor obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
        
        private IQueryable<Alfajor> GetQuery()
        {
            return from Alfajor in _context.Alfajor select Alfajor;
        }
}



    
