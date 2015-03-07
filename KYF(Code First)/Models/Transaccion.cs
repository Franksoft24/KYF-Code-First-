using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYF_Code_First_.Models
{
    public class Transaccion
    {
        [Key]
        public int TransaccionID { get; set; }
        [Required]
        [Display(Name="Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Monto")]
        public string Monto { get; set; }
        [Required]
        [Display(Name = "Motivo")]
        public int MotivoID { get; set; }
        [Required]
        [Display(Name = "Tarjeta")]
        public int TarjetaID { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public string fecha { get; set; }

        public virtual Motivo Motivo { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
    }
}