using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class MovimientoMap : EntityTypeConfiguration<Movimiento>
    {
        public MovimientoMap()
        {
            ToTable("Movimiento");
            HasKey(a => a.id);
            Property(a => a.id).HasColumnName("id");

        }
    }
}