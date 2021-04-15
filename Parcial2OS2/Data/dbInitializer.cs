using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2OS2.Models;

namespace Parcial2OS2.Data
{
    public class dbInitializer
    {
        public static void Initialize(Parcial2OS2Context context)
        {
            context.Database.EnsureCreated();

            //Busca si existen registros en la tabla
            if (context.Almacenes.Any())
            {
                return;
            }
            var almacenes = new Almacenes[]
            {
                new Almacenes{ID_Almacen= 1, Descripcion= "Primera Prueba", Estado= true }

            };
            foreach (Almacenes A in almacenes)
            {
                context.Almacenes.Add(A);                
            }
            context.SaveChanges();

            
        }

    }

    }
       
    

