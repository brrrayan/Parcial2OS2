using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2OS2.Models;

namespace Parcial2OS2.Controllers
{
    public class AlmacenesController : Controller
    {
        private readonly Parcial2OS2Context _context;

        public AlmacenesController(Parcial2OS2Context context)
        {
            _context = context;
        }

        // GET: Almacenes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Almacenes.ToListAsync());
        }

        // GET: Almacenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenes = await _context.Almacenes
                .FirstOrDefaultAsync(m => m.ID_Almacen == id);
            if (almacenes == null)
            {
                return NotFound();
            }

            return View(almacenes);
        }

        // GET: Almacenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Almacenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Almacen,Descripcion,Estado")] Almacenes almacenes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almacenes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacenes);
        }

        // GET: Almacenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenes = await _context.Almacenes.FindAsync(id);
            if (almacenes == null)
            {
                return NotFound();
            }
            return View(almacenes);
        }

        // POST: Almacenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Almacen,Descripcion,Estado")] Almacenes almacenes)
        {
            if (id != almacenes.ID_Almacen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenesExists(almacenes.ID_Almacen))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(almacenes);
        }

        // GET: Almacenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenes = await _context.Almacenes
                .FirstOrDefaultAsync(m => m.ID_Almacen == id);
            if (almacenes == null)
            {
                return NotFound();
            }

            return View(almacenes);
        }

        // POST: Almacenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almacenes = await _context.Almacenes.FindAsync(id);
            _context.Almacenes.Remove(almacenes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenesExists(int id)
        {
            return _context.Almacenes.Any(e => e.ID_Almacen == id);
        }
    }
}
