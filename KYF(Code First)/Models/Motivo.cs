using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYF_Code_First_.Models
{
    public class Motivo
    {
        [Key]
        public int MotivoID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }

    }
}