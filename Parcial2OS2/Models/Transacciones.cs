using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2OS2.Models
{
    public class Transacciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]        
        public int ID_Transaccion {get; set; }

        [Display(Name = "Tipo de Transaccion")]
        public string Tipo_Transaccion { get; set; }

        [Display(Name = "Articulo")]
        public int ID_Articulo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Monto { get; set; }

        [NotMapped]
        public List<SelectListItem> ListOfInventarios { get; set; }
        [NotMapped]
        public List<SelectListItem> ListOfTipoTransa { get; set; }
        [NotMapped]
        public List<SelectListItem> ListOfCuentaContable { get; set; }
        [NotMapped]
        public List<SelectListItem> ListOfArticles { get; set; }
    }
}
