using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace SistemaBancario.Models
{
    public class Context : DbContext
    {
        public IDbSet<Movimiento> Movimientos { get; set; }
        public IDbSet<Cuenta> Cuentas { get; set; }
        public  Context()
        {
            Database.SetInitializer<Context>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MovimientoMap());
            modelBuilder.Configurations.Add(new CuentaMap());
        }
    }
}