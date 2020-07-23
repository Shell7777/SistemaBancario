using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class Cuenta
    {
        public int? id { get; set; }
        public string nombre { get; set; }
        public int categoria { get; set; }
        public decimal  saldoinicial { get; set; }
        public decimal limiteSaldo { get; set; }

    }
}