using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace TestProductos
{
    public class UnitTest1
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        //public bool EsMailValido(string email)
        //{
        //    return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //}

        //[Theory]
        //[InlineData("usuario@gmail.com", true)]
        //[InlineData("test@empresa.com", true)]
        //[InlineData("correoprueba.com", true)]
        //[InlineData("sinarrobanicomcom", false)]
        //public void ValdarEmail_DeberiaDetectarCorreosValidso(string email, bool esperado)
        //{

        //    bool resultado = EsMailValido(email);
        //    Assert.Equal(esperado, resultado);
        //}

        [Fact]
        public void Test_NavegadorGoogle()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.bing.com");

                var buscarTexto = _wait.Until(d => d.FindElement(By.Name("q")));

                Thread.Sleep(3000);

                buscarTexto.SendKeys("Selenium");

                Thread.Sleep(3000);

                _driver.FindElement(By.Id("search_icon")).Click();

                Thread.Sleep(3000);

                var resultado = _wait.Until(d => d.FindElements(By.CssSelector("h3")));

                Assert.True(resultado.Count > 0, "No se encontraron resultados de la busqueda.");

                Console.WriteLine("Prueba exitosa");
                Console.WriteLine("Esperando 10 segundos para cerrar el navegador");

                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _driver.Quit();
            }
        }
    }
}