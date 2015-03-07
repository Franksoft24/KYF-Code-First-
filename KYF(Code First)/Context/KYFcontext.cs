using KYF_Code_First_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KYF_Code_First_.Context
{
    public class KYFcontext : DbContext
    {
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<TarjetaTipo> TarjetaTipo { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Motivo> Motivo { get; set; }
    }
}