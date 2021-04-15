using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Parcial2OS2.Models
{
    public class Articulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID_Articulo { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La cantidad de caracteres requerida es de 2-50")]
        public string Descripcion { get; set; }
        
        public int Existencia { get; set; }

        [Display(Name = "Tipo de Inventario")]
        public int ID_TipoInventario { get; set; }

        [Display(Name = "Costo Unitario")]
        public int CostoUnitario { get; set; }
        
        public bool Estado { get; set; }

        [NotMapped]
        public List<SelectListItem> ListOfInventarios { get; set; }

        //[NotMapped]
        //public List<SelectListItem> ListOfTipoinventarios { get; set; }
    }
}
