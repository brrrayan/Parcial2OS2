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
    public class TransaccionesController : Controller
    {
        private readonly Parcial2OS2Context _context;

        public TransaccionesController(Parcial2OS2Context context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transacciones.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones
                .FirstOrDefaultAsync(m => m.ID_Transaccion == id);
            if (transacciones == null)
            {
                return NotFound();
            }

            return View(transacciones);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            var articulos = (from tipoinventarios in _context.Articulos select new SelectListItem() { Text = tipoinventarios.Descripcion, Value = tipoinventarios.ID_Articulo.ToString() }).ToList();
                        
            articulos.Insert(0, new SelectListItem()
            {
                Text = "Seleccione una opcion",
                Value = string.Empty
            });

            Transacciones asientocontableModel = new Transacciones();          
            asientocontableModel.ListOfArticles = articulos;

            return View(asientocontableModel);
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Transaccion,Tipo_Transaccion,ID_Articulo,Fecha,Cantidad,Monto")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                               
                _context.Add(transacciones);
                await _context.SaveChangesAsync();

                var article = _context.Articulos.FirstOrDefault(x => x.ID_Articulo == transacciones.ID_Articulo);
                if (transacciones.Tipo_Transaccion?.ToLower() == "entrada")
                {
                    article.Existencia += transacciones.Cantidad;
                }
                else
                {
                    article.Existencia -= transacciones.Cantidad;
                }
                _context.Update(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var articulos = (from tipoinventarios in _context.Articulos select new SelectListItem() { Text = tipoinventarios.Descripcion, Value = tipoinventarios.ID_Articulo.ToString() }).ToList();
           
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones.FindAsync(id);
            if (transacciones == null)
            {
                return NotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Transaccion,Tipo_Transaccion,ID_Articulo,Fecha,Cantidad,Monto")] Transacciones transacciones)
        {
            if (id != transacciones.ID_Transaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionesExists(transacciones.ID_Transaccion))
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
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones
                .FirstOrDefaultAsync(m => m.ID_Transaccion == id);
            if (transacciones == null)
            {
                return NotFound();
            }

            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacciones = await _context.Transacciones.FindAsync(id);
            _context.Transacciones.Remove(transacciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionesExists(int id)
        {
            return _context.Transacciones.Any(e => e.ID_Transaccion == id);
        }
    }
}
