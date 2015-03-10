using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYF_Code_First_.Models
{
    public class Tarjeta
    {
        [Key]
        public int TarjetaID { get; set; }
        [Required]
        [Display(Name="Numero de Tarjeta")]
        //[MaxLength(19)]
        //[RegularExpression(@"[0-9]{4,4}+-[0-9]{4,4}+-[0-9]{4,4}+-[0-9]{4,4}", ErrorMessage="El numero de tarjeta insertado no es valido")]
        public string NumeroTarjeta { get; set; }
        [Required]
        [Display(Name = "Banco")]
        public string EntidadBancaria { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public int TarjetaTipoID { get; set; }
        [Required]
        public string Propietario { get; set; }
        [Required]
        [Display(Name = "Monto de la tarjeta")]
        public decimal Monto { get; set; }
        [Required]
        [Display(Name="Fecha de corte")]
        [DataType(DataType.Date)]
        public System.DateTime fechaCorte { get; set; }

        public virtual TarjetaTipo TarjetaTipo { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }

    }
}