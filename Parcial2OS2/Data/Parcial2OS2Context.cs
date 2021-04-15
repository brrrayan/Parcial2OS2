using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial2OS2.Models;

namespace Parcial2OS2.Models
{
    public class Parcial2OS2Context : DbContext
    {
        internal object cuentacontable;

        public Parcial2OS2Context (DbContextOptions<Parcial2OS2Context> options)
            : base(options)
        {
        }

        public DbSet<Parcial2OS2.Models.Almacenes> Almacenes { get; set; }

        public DbSet<Parcial2OS2.Models.Articulos> Articulos { get; set; }

        public DbSet<Parcial2OS2.Models.AsientosContables> AsientosContables { get; set; }

        public DbSet<Parcial2OS2.Models.TipoInventario> TipoInventario { get; set; }

        public DbSet<Parcial2OS2.Models.Transacciones> Transacciones { get; set; }
    }
}
