using SistemaBancario.Models;
using SistemaBancario.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBancario.Controllers
{
    public class HomeController : Controller
    {

        private ICuentaService service;

        public HomeController(ICuentaService service)
        {
            this.service = service;
        }
        public HomeController()
        {
            service = new CuentaService();
        }
        public ActionResult Index()
        {
            ViewBag.saldototal = verSaldototal();
            return View(service.listarCuentas());
        }

        public ActionResult CrearCuenta()
        {
            return View(new Cuenta());
        }
        [HttpPost]
        public ActionResult CrearCuenta(Cuenta cuenta)
        {
            service.CrearCuenta(cuenta);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult hacerMoviemiento(int id) {
            ViewBag.cuenta = service.getCuenta(id);
            return View(new Movimiento());
        }
        public ActionResult listarMoviemiento(int id) {
            return View(service.listarMoviemiento(id));
        }

        public bool voidhacerValor(Movimiento movimiento) {
            decimal Lineatotal = service.getCuenta(movimiento.idcuenta).limiteSaldo;
            decimal debe = service.getCuenta(movimiento.idcuenta).saldoinicial;

            decimal valor = debe + movimiento.monto;
            return valor >= service.getCuenta((movimiento.idcuenta)).limiteSaldo;
        }
       
        [HttpPost]
        public ActionResult hacerMoviemiento(Movimiento movimiento)
        {
            if (service.getCuenta(movimiento.idcuenta).categoria == 2) {
                decimal Lineatotal = service.getCuenta(movimiento.idcuenta).limiteSaldo;
                decimal debe = service.getCuenta(movimiento.idcuenta).saldoinicial;
                ViewBag.cuenta = service.getCuenta(movimiento.idcuenta);
                if (Lineatotal < movimiento.monto)
                {
                    ModelState.AddModelError("saldo", "El monto es mayor");
                    
                    return View(new Movimiento());
                }
                else
                {

                    decimal valor = debe + movimiento.monto;
                    if (movimiento.tipomov == 1)
                    {
                        if (valor <= service.getCuenta((movimiento.idcuenta)).limiteSaldo)
                        {
                            HacerCuentaCredito(movimiento);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("saldo", "El monto es mayor");
                            ViewBag.cuenta = service.getCuenta(movimiento.idcuenta);
                            return View(new Movimiento());
                        }
                    }
                    else {

                        if (debe == 0 || debe<movimiento.monto)
                        { 
                            ModelState.AddModelError("saldo", "Usted no debe nada ");
                            return View(new Movimiento());
                        }
                        HacerCuentaCredito(movimiento);
                        return RedirectToAction("Index");
                    }

                }
            }
            if (movimiento.tipomov == 1)
            {
                service.hacerIngreso(movimiento);
                return RedirectToAction("Index");
            }
            if (service.getCuenta(movimiento.idcuenta).saldoinicial < movimiento.monto)
            {
                ModelState.AddModelError("saldo", "Saldo insuficiente...");
                ViewBag.cuenta = service.getCuenta(movimiento.idcuenta);
                return View(new Movimiento());
            }
            service.hacerEgreso(movimiento);
            return RedirectToAction("Index");
        }
        public decimal verSaldototal() {
            decimal saldototal = 0;
            foreach (var item in service.listarCuentas()) {
                if (item.categoria ==1)saldototal += item.saldoinicial;
            }
                
            return saldototal;
        }
        public void HacerCuentaCredito(Movimiento movimiento) {
          
          if (movimiento.tipomov == 1) service.hacerIngreso(movimiento);
          if (movimiento.tipomov == 2) service.hacerEgreso(movimiento);
          

        } 
    }
}