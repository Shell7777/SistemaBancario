using SistemaBancario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class CuentaMap : EntityTypeConfiguration<Cuenta>
    {
        public CuentaMap()
        {
            ToTable("Cuenta");
            HasKey(a => a.id);
            Property(a => a.id).HasColumnName("id");

        }
    }
}