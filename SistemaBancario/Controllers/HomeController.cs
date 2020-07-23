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

        public HomeController(ICuentaService service )
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
        public ActionResult CrearCuenta( Cuenta cuenta)
        {
            service.CrearCuenta(cuenta);
            return RedirectToAction("Index");
        }
       [HttpGet]
        public ActionResult  hacerMoviemiento(int id ) {
            ViewBag.cuenta = service.getCuenta(id);
            return View(new Movimiento());
        }
        public ActionResult listarMoviemiento(int id) {
            return View(service.listarMoviemiento(id));
        }
        [HttpPost]
        public ActionResult hacerMoviemiento(Movimiento movimiento)
        {
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
                saldototal += item.saldoinicial;
            }
            return saldototal;
        }
    }
}