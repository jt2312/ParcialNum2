
using Parcial2.Data;
using Parcial2.Models;
using Microsoft.EntityFrameworkCore;
using Parcial2.Services;

namespace Parcial2.Services;

    public class MarcaService : IMarcaService
    {
        private readonly AlfajorContext _context;

        public MarcaService(AlfajorContext context)
        {
            _context = context;
        }
        public void Create(Marca obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(Marca obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public List<Marca> GetAll()
        {
            return _context.Marca.Include(r => r.Alfajors).ToList();
        }

        public Marca? GetById(int id)
        {
            var marca = _context.Marca
                    .Include(r => r.Alfajors)
                    .FirstOrDefault(m => m.MarcaID == id);
            return marca;
        }

        public void Update(Marca obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }

