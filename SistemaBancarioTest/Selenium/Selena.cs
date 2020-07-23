using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SistemaBancarioTest.Selenium
{
    [TestFixture]
    class Selena
    {
        [Test]
        public void CrearCuenta()
        {

            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://localhost:44315/";
            var ButtonArticulo = chrome.FindElement(By.CssSelector("#crearCuenta"));
            ButtonArticulo.Click();
            var form = chrome.FindElement(By.CssSelector("#nombre"));
            form.SendKeys("Cuenta Selena");
            form = chrome.FindElement(By.CssSelector("#saldo"));
            form.SendKeys("500");
            form = chrome.FindElement(By.CssSelector("#boton"));
            form.Click();
            Thread.Sleep(3000);
            chrome.Close();
        }
        [Test]
        public void HacerIngreso()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://localhost:44315/";
            var links = chrome.FindElements(By.CssSelector(".fedo"));
            links[0].Click();
            var form = chrome.FindElement(By.CssSelector("#descripcion"));
            form.SendKeys("Ingreso Selena");
            form = chrome.FindElement(By.CssSelector("#monto"));
            form.SendKeys("1000");
            form = chrome.FindElement(By.CssSelector("#boton"));
            form.Click();
            Thread.Sleep(3000);
            chrome.Close();
        }
        [Test]
        public void VerMovimientos(){
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://localhost:44315/";
            var links = chrome.FindElements(By.CssSelector(".dodo"));
            links[0].Click();
            Thread.Sleep(3000);
            chrome.Close();
        }
    }
}
