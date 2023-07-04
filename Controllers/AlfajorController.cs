using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;
using Parcial2.ViewModels;
using Parcial2.Services;

namespace Parcial2.Controllers
{
    public class AlfajorController : Controller
    {
        private IMarcaService _marcaService;

        private IAlfajorService _alfajorSerivce;

        public AlfajorController(IAlfajorService alfajorService,IMarcaService marcaService)
        {
            _alfajorSerivce = alfajorService;
            _marcaService = marcaService;
        }
        // public IActionResult Index()
        // {
        //     var list = _alfajorSerivce.GetAll();
        //     return View(list);
        // }
        // GET: Alfajor
        public IActionResult Index(string nameFilter)
        {
            var model = new AlfajorCreateViewModel();
            model.alfajors= _alfajorSerivce.GetAll(nameFilter);
            return View(model);
        }

        // GET: Alfajor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var alfajor = _alfajorSerivce.GetById(id.Value); 
            if (alfajor == null)
            {
                return NotFound();
            }

            return View(alfajor);
        }

        // GET: Alfajor/Create
        public IActionResult Create()
        {   
            var marcasList = _alfajorSerivce.GetAll();
            ViewData["Marcass"] = new SelectList(marcasList, "MarcaID", "NombreMarca");
            return View();
        }

        // POST: Alfajor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AlfajorID,NombreAlfajor,Precio,Calorias,")] AlfajorCreateViewModel alfajorView)
        {
            if (ModelState.IsValid)
            {
                var marcass = _marcaService.GetAll().Where(x=> alfajorView.MarcasIds.Contains(x.MarcaID)).ToList();

                var alfajor = new Alfajor{
                    NombreAlfajor = alfajorView.NombreAlfajor,
                    Precio = alfajorView.Precio,
                    Calorias = alfajorView.Calorias,
                    Marcas = marcass
                };      
                _alfajorSerivce.Create(alfajor);
                return RedirectToAction(nameof(Index));
            }
            return View(alfajorView);
        }

        

        // GET: Alfajor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alfajor = _alfajorSerivce.GetById(id.Value);
            if (alfajor == null)
            {
                return NotFound();
            }
            return View(alfajor);
        }

        // POST: Alfajor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AlfajorID,NombreAlfajor,Precio,Calorias,Marca")] Alfajor alfajor)
        {
            if (id != alfajor.AlfajorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  _alfajorSerivce.Update(alfajor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlfajorExists(alfajor.AlfajorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        
                        throw ;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alfajor);
        }

        // GET: Alfajor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alfajor = _alfajorSerivce.GetById(id.Value);
            if (alfajor == null)
            {
                return NotFound();
            }

            return View(alfajor);
        }

        // POST: Alfajor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var alfajor = _alfajorSerivce.GetById(id);
            if (alfajor != null)
            {
                _alfajorSerivce.Delete(alfajor);
            }
            return RedirectToAction(nameof(Index));

        }

        private bool AlfajorExists(int id)
        {
            return _alfajorSerivce.GetById(id) != null;  
        }
    }
}
