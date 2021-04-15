using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2OS2.Models
{
    public class TipoInventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID_TipoInventario { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La cantidad de caracteres requerida es de 2-50")]
        public string Descripcion { get; set; }

        [Display(Name = "Cuenta Contable")]        
        public string CuentaContable { get; set; }
        
        public bool Estado { get; set; }

    }
}
