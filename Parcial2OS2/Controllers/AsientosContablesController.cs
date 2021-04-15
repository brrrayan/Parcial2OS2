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
    public class AsientosContablesController : Controller
    {
        private readonly Parcial2OS2Context _context;

        public AsientosContablesController(Parcial2OS2Context context)
        {
            _context = context;
        }

        // GET: AsientosContables
        public async Task<IActionResult> Index()
        {
            return View(await _context.AsientosContables.ToListAsync());
        }

        // GET: AsientosContables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosContables = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.ID_AsientoCOntable == id);
            if (asientosContables == null)
            {
                return NotFound();
            }

            return View(asientosContables);
        }

        // GET: AsientosContables/Create
        public IActionResult Create()
        {
            var tipoinventario = (from tipoinventarios in _context.TipoInventario select new SelectListItem() { Text = tipoinventarios.Descripcion, Value = tipoinventarios.ID_TipoInventario.ToString() }).ToList();
            var cuentacontable = (from tipoinventarios in _context.AsientosContables select new SelectListItem() { Text = tipoinventarios.Descripcion, Value = tipoinventarios.CuentaContable.ToString() }).ToList();
            var tipotransa = (from tipoinventarios in _context.Transacciones select new SelectListItem() { Text = tipoinventarios.Tipo_Transaccion, Value = tipoinventarios.ID_Transaccion.ToString() }).ToList();


            tipoinventario.Insert(0, new SelectListItem()
            {
                Text = "Seleccione una opcion",
                Value = string.Empty
            });

            cuentacontable.Insert(0, new SelectListItem()
            {
                Text = "Seleccione una opcion",
                Value = string.Empty
            });

            tipotransa.Insert(0, new SelectListItem()
            {
                Text = "Seleccione una opcion",
                Value = string.Empty
            });

            AsientosContables asientocontableModel = new AsientosContables();            
            asientocontableModel.ListOfInventarios = tipoinventario;
            asientocontableModel.ListOfCuentaContable = cuentacontable;
            asientocontableModel.ListOfTipoTransa = tipotransa;

            return View(asientocontableModel);   
            
            //return View();
        }

        // POST: AsientosContables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_AsientoCOntable,Descripcion,ID_TipoInventario,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContables asientosContables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asientosContables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asientosContables);
        }

        // GET: AsientosContables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientoscontables = await _context.AsientosContables.FindAsync(id);
            if (asientoscontables == null)
            {
                return NotFound();
            }
            return View(asientoscontables);
        }

        // POST: AsientosContables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_AsientoCOntable,Descripcion,ID_TipoInventario,CuentaContable,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContables asientosContables)
        {
            if (id != asientosContables.ID_AsientoCOntable)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientosContables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsientosContablesExists(asientosContables.ID_AsientoCOntable))
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
            return View(asientosContables);
        }

        // GET: AsientosContables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientosContables = await _context.AsientosContables
                .FirstOrDefaultAsync(m => m.ID_AsientoCOntable == id);
            if (asientosContables == null)
            {
                return NotFound();
            }

            return View(asientosContables);
        }

        // POST: AsientosContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientosContables = await _context.AsientosContables.FindAsync(id);
            _context.AsientosContables.Remove(asientosContables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsientosContablesExists(int id)
        {
            return _context.AsientosContables.Any(e => e.ID_AsientoCOntable == id);
        }
    }
}
