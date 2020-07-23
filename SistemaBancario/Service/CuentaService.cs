
using SistemaBancario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Service
{
    public interface ICuentaService {
        List<Cuenta> listarCuentas();
       void  CrearCuenta(Cuenta cuenta);
        void hacerIngreso(Movimiento movimiento);
        Cuenta getCuenta(int id);
        void hacerEgreso(Movimiento movimiento);
        List<Movimiento> listarMoviemiento(int id);
    }
    public class CuentaService:ICuentaService 
    {
        Context Context = new Context();
        public List<Cuenta> listarCuentas() {
            return Context.Cuentas.ToList();
        }
        public List<Movimiento> listarMoviemiento(int id)
        {
            return Context.Movimientos.Where(a=>a.idcuenta==id).ToList();
        }
        public void CrearCuenta(Cuenta cuenta) {
            Context.Cuentas.Add(cuenta);
            Context.SaveChanges();
        }
        public void hacerIngreso(Movimiento movimiento) {
           
            if (movimiento.tipomov == 1)
            {
                movimiento.fecha = DateTime.Now;
                var cuenta = Context.Cuentas.Where(a=>a.id==movimiento.idcuenta).FirstOrDefault();
                cuenta.saldoinicial += movimiento.monto;
                Context.Movimientos.Add(movimiento);
                Context.SaveChanges();
               
                
            }
       
        }
        public void hacerEgreso(Movimiento movimiento)
        {

   
            if (movimiento.tipomov == 2) {
                movimiento.fecha = DateTime.Now;
                var cuenta = Context.Cuentas.Find(movimiento.idcuenta);
                cuenta.saldoinicial -= movimiento.monto;
                Context.Movimientos.Add(movimiento);
                Context.SaveChanges();
            } 
        }

        public Cuenta getCuenta(int id) {
            return Context.Cuentas.Find(id);
        }
    }
}