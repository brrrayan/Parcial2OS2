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
    public class TipoInventariosController : Controller
    {
        private readonly Parcial2OS2Context _context;

        public TipoInventariosController(Parcial2OS2Context context)
        {
            _context = context;
        }

        // GET: TipoInventarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInventario.ToListAsync());
        }

        // GET: TipoInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInventario = await _context.TipoInventario
                .FirstOrDefaultAsync(m => m.ID_TipoInventario == id);
            if (tipoInventario == null)
            {
                return NotFound();
            }

            return View(tipoInventario);
        }

        // GET: TipoInventarios/Create
        public IActionResult Create()
        {
            return View();           
        }

        // POST: TipoInventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_TipoInventario,Descripcion,CuentaContable,Estado")] TipoInventario tipoInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInventario);
        }

        // GET: TipoInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInventario = await _context.TipoInventario.FindAsync(id);
            if (tipoInventario == null)
            {
                return NotFound();
            }
            return View(tipoInventario);
        }

        // POST: TipoInventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_TipoInventario,Descripcion,CuentaContable,Estado")] TipoInventario tipoInventario)
        {
            if (id != tipoInventario.ID_TipoInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInventarioExists(tipoInventario.ID_TipoInventario))
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
            return View(tipoInventario);
        }

        // GET: TipoInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInventario = await _context.TipoInventario
                .FirstOrDefaultAsync(m => m.ID_TipoInventario == id);
            if (tipoInventario == null)
            {
                return NotFound();
            }

            return View(tipoInventario);
        }

        // POST: TipoInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInventario = await _context.TipoInventario.FindAsync(id);
            _context.TipoInventario.Remove(tipoInventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInventarioExists(int id)
        {
            return _context.TipoInventario.Any(e => e.ID_TipoInventario == id);
        }
    }
}
