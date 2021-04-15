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
    public class ArticulosController : Controller
    {
        private readonly Parcial2OS2Context _context;

        public ArticulosController(Parcial2OS2Context context)
        {
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            ViewBag.ListaInventario = _context.TipoInventario.ToList();
            return View(await _context.Articulos.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .FirstOrDefaultAsync(m => m.ID_Articulo == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            var tipoinventario = (from tipoinventarios in _context.TipoInventario select new SelectListItem() { Text = tipoinventarios.Descripcion, Value = tipoinventarios.ID_TipoInventario.ToString() }).ToList();
            tipoinventario.Insert(0, new SelectListItem()
            {
                Text = "Seleccione uno...",
                Value = string.Empty
            });
            Articulos articulosModel = new Articulos();
            articulosModel.ListOfInventarios = tipoinventario;
            return View(articulosModel);
            
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Articulo,Descripcion,Existencia,ID_TipoInventario,CostoUnitario,Estado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }
            return View(articulos);
             
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Articulo,Descripcion,Existencia,ID_TipoInventario,CostoUnitario,Estado")] Articulos articulos)
        {
            if (id != articulos.ID_Articulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulosExists(articulos.ID_Articulo))
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
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .FirstOrDefaultAsync(m => m.ID_Articulo == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulos = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulosExists(int id)
        {
            return _context.Articulos.Any(e => e.ID_Articulo == id);
        }
    }
}
