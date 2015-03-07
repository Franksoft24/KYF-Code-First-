using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYF_Code_First_.Models
{
    public class TarjetaTipo
    {
        [Key]
        public int TarjetatipoID { get; set;}
        [Required]
        public string Descripcion { get; set; }


        public virtual ICollection<Tarjeta> Tarjetas { get; set; }

    }
}