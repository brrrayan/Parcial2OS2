using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2OS2.Models
{
    public class AsientosContables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID_AsientoCOntable { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La cantidad de caracteres requerida es de 2-50")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de Inventario")]
        public int ID_TipoInventario { get; set; }

        [Display(Name = "Cuenta Contable")]
        public string CuentaContable { get; set; }

        [Display(Name = "Tipo de Movimiento")]
        public string TipoMovimiento { get; set; }

        [Display(Name = "Fecha de Asiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAsiento { get; set; }


        [Display(Name = "Monto de Asiento")]
        public int MontoAsiento { get; set; }

        //[display(name = "id asiento")]
        //public int idasiento { get; set; }

        public bool Estado { get; set; }


        [NotMapped]
        public List<SelectListItem> ListOfInventarios { get; set; }
        [NotMapped]
        public List<SelectListItem> ListOfTipoTransa { get; set; }
        [NotMapped]
        public List<SelectListItem> ListOfCuentaContable { get; set; }

    }
}
