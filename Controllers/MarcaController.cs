using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;
using Parcial2.Services;
using Parcial2.ViewModels;

namespace Parcial2.Controllers
{
    public class MarcaController : Controller
    {
        
        private IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;   
        }

        // GET: Marca
        public IActionResult Index()
        {
            var list = _marcaService.GetAll();
            return View(list);
        }


        // GET: Marca/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) // || _context.Marca == null
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id.Value); 
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {   
            // ViewData["Marcass"]= new SelectList(_context.Marca.ToList(), "MarcaID", "NombreMarca");
            // //esto luego va a la view del create del modelo Marca
            // return View();
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MarcaID,NombreMarca,PaisMarca")] MarcaCreateViewModel marcaView)
        {
            if (ModelState.IsValid)
            {              
                var marca = new Marca{
                NombreMarca = marcaView.NombreMarca,
                PaisMarca = marcaView.PaisMarca
            };
                _marcaService.Create(marca);
                // await _.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaView);
        }

        // GET: Marca/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id.Value)    ; 
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MarcaID,NombreMarca,PaisMarca")] Marca marca)
        {
            if (id != marca.MarcaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               _marcaService.Update(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marca/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id.Value);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var marca = _marcaService.GetById(id);
            if (marca != null)
            {
                _marcaService.Delete(marca);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
        return _marcaService.GetById(id) != null;

        }
    }
}
