using Moq;
using NUnit.Framework;
using SistemaBancario.Controllers;
using SistemaBancario.Models;
using SistemaBancario.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaBancarioTest.TestUnitario
{
    [TestFixture]
    class Testeos
    {
        [Test]
        public void CrearCuentaIsNotNul() {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.listarCuentas()).Returns(new List<Cuenta>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.CrearCuenta() as ViewResult;
            Assert.IsNotNull(vista);
        }
        [Test]
        public void CrearCuentaIsList()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.listarCuentas()).Returns(new List<Cuenta>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.Index() as ViewResult;
            Assert.IsInstanceOf<List<Cuenta>>(vista.Model as List<Cuenta>);
        }
        [Test]
        public void CrearCuentaIsCuenta()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.listarCuentas()).Returns(new List<Cuenta>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.CrearCuenta() as ViewResult;
            Assert.IsInstanceOf<Cuenta>(  vista.Model as Cuenta);
        }
        [Test]
        public void CrearCuentaIsNotNull()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.listarCuentas()).Returns(new List<Cuenta>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.CrearCuenta() as ViewResult;
            Assert.IsNotNull(vista.Model);
        }
        [Test]
        public void CrearCuentaIsNotNullGET()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.CrearCuenta(new Cuenta()));

            var controller = new HomeController(mocky.Object);
            var vista = controller.CrearCuenta(new Cuenta()) as RedirectToRouteResult;
            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
            
        }
        // parte 2 
        [Test]
        public void HacerMov_NotNull()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.getCuenta(1)).Returns(new Cuenta { 
            nombre="cuneta1",categoria=1,saldoinicial=1500});

            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(1) as ViewResult;
            Assert.IsInstanceOf<Movimiento>((Movimiento)vista.Model);
         
        }
        [Test]
        public void HacerMov_NotNull2()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.getCuenta(1)).Returns(new Cuenta
            {
                nombre = "cuenta1",
                categoria = 1,
                saldoinicial = 1500
            });

            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(1) as ViewResult;
          
            Assert.IsNotNull((Cuenta)vista.ViewBag.cuenta);
         
        }
        [Test]
        public void HacerMov_TypeInstancePOST()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a=>a.getCuenta(1)).Returns(new Cuenta
            {
                id = 1, 
                nombre = "cuenta1",
                categoria = 1,
                saldoinicial = 500
            });
            
            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(new Movimiento
            {
                monto = 1500,
                tipomov = 2,
                idcuenta = 1
            }) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void HacerMov_NotNullPOST()
        {
            var mocky = new Mock<ICuentaService>();
            mocky.Setup(a => a.getCuenta(1)).Returns(new Cuenta
            {
                id = 1,
                nombre = "cuenta1",
                categoria = 1,
                saldoinicial = 500
            });

            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(new Movimiento
            {
                monto = 1500,
                tipomov = 2,
                idcuenta = 1
            }) as ViewResult;

            Assert.IsNotNull((Cuenta)vista.ViewBag.cuenta);
        }
        [Test]
        public void HacerRetiro_NotNullPOST()
        {
            var mocky = new Mock<ICuentaService>();
            
            mocky.Setup(a => a.getCuenta(1)).Returns(new Cuenta
            {
                id = 1,
                nombre = "cuenta1",
                categoria = 1,
                saldoinicial = 1500
            });

            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(new Movimiento
            {
                monto = 500,
                tipomov = 2,
                idcuenta = 1
            }) as RedirectToRouteResult;

            Assert.IsNotNull(vista);
        }
        //parte 3
        [Test]
        public void HacerRetiro_InstaPOST()
        {
            var mocky = new Mock<ICuentaService>();

            mocky.Setup(a => a.getCuenta(1)).Returns(new Cuenta
            {
                id = 1,
                nombre = "cuenta1",
                categoria = 1,
                saldoinicial = 1500
            });

            var controller = new HomeController(mocky.Object);
            var vista = controller.hacerMoviemiento(new Movimiento
            {
                monto = 500,
                tipomov = 2,
                idcuenta = 1
            }) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(vista);
        }
        [Test]
        public void listarMov_Instance()
        {
            var mocky = new Mock<ICuentaService>();

            mocky.Setup(a => a.listarMoviemiento(1)).Returns(new List<Movimiento>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.listarMoviemiento(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(vista);
        }
        [Test]
        public void listarMov_Isnotnull()
        {
            var mocky = new Mock<ICuentaService>();

            mocky.Setup(a => a.listarMoviemiento(1)).Returns(new List<Movimiento>());

            var controller = new HomeController(mocky.Object);
            var vista = controller.listarMoviemiento(1) as ViewResult;

            Assert.IsNotNull(vista);
        }
    }
}
