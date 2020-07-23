using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class Movimiento
    {
        public int id { get; set; }
        public int idcuenta { get; set; }
        public int tipomov { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }

    }
}