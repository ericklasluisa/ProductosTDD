using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProductosTDD.Data;
using ProductosTDD.Models;

namespace TestCliente
{
    public class TestCliente : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly ClienteDataAccessLayer objClienteDAL;

        public void Dispose()
        {
            _driver.Dispose();
        }

        public TestCliente()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            objClienteDAL = new ClienteDataAccessLayer();
        }

        [Fact]
        public void VerificarTablaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.getAllCliente().ToList();
            int expectedRowCount = clientes.Count;

            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");

            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));

            Thread.Sleep(1000);

            var rows = _driver.FindElements(By.CssSelector("table.table tbody tr"));
            Thread.Sleep(1000);

            int actualRowCount = rows.Count;

            Assert.Equal(expectedRowCount, actualRowCount);
            Thread.Sleep(1000);
        }

        [Fact]
        public void CrearCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _driver.FindElement(By.Name("Cedula")).SendKeys("0915280838");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Lucio");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Alexander");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("17/09/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("erick2@gmail.com");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0982347297");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Estado")).SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            Assert.Equal("https://localhost:7010/Cliente", _driver.Url);
        }

        [Fact]
        public void CrearClienteConCedulaInvalida()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _driver.FindElement(By.Name("Cedula")).SendKeys("1234567890");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Lasluisa Lucio");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Erick Alexander");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("17/09/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("erick1@gmail.com");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0982347297");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Estado")).SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            var cedulaField = _driver.FindElement(By.Name("Cedula"));
            Assert.Contains("Cédula inválida", cedulaField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void CrearClienteConCorreoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _driver.FindElement(By.Name("Cedula")).SendKeys("1711878967");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Lasluisa Lucio");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Erick Alexander");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("17/09/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("erick1gmail.com");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("0982347297");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Estado")).SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            var mailField = _driver.FindElement(By.Name("Mail"));
            Assert.Contains("Incluye un signo \"@\" en la dirección", mailField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void CrearClienteConTelefonoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _driver.FindElement(By.Name("Cedula")).SendKeys("1726249442");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Lasluisa");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Erick");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("17/09/2003");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Mail")).SendKeys("erick1@gmail.com");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Estado")).SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            var telefonoField = _driver.FindElement(By.Name("Telefono"));
            Assert.Contains("Haz coincidir el formato solicitado", telefonoField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void EditarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");
            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            var editButton = _driver.FindElement(By.CssSelector("table.table tbody tr:first-child a.btn-warning"));
            editButton.Click();
            Thread.Sleep(1000);

            var cedulaField = _driver.FindElement(By.Name("Cedula"));
            cedulaField.Clear();
            cedulaField.SendKeys("1758187742");
            Thread.Sleep(1000);

            var apellidosField = _driver.FindElement(By.Name("Apellidos"));
            apellidosField.Clear();
            apellidosField.SendKeys("Silva");
            Thread.Sleep(1000);

            var nombresField = _driver.FindElement(By.Name("Nombres"));
            nombresField.Clear();
            nombresField.SendKeys("Juan");
            Thread.Sleep(1000);

            var fechaNacimientoField = _driver.FindElement(By.Name("FechaNacimiento"));
            fechaNacimientoField.Clear();
            fechaNacimientoField.SendKeys("01/01/1990");
            Thread.Sleep(1000);

            var mailField = _driver.FindElement(By.Name("Mail"));
            mailField.Clear();
            mailField.SendKeys("juan.perez@gmail.com");
            Thread.Sleep(1000);

            var telefonoField = _driver.FindElement(By.Name("Telefono"));
            telefonoField.Clear();
            telefonoField.SendKeys("0987654321");
            Thread.Sleep(1000);

            var direccionField = _driver.FindElement(By.Name("Direccion"));
            direccionField.Clear();
            direccionField.SendKeys("Pomasqui");
            Thread.Sleep(1000);

            var estadoField = _driver.FindElement(By.Name("Estado"));
            estadoField.SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            Thread.Sleep(1000);

            Assert.Equal("https://localhost:7010/Cliente", _driver.Url);
        }

        [Fact]
        public void EditarClienteConCedulaInvalida()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");
            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            var editButton = _driver.FindElement(By.CssSelector("table.table tbody tr:first-child a.btn-warning"));
            editButton.Click();
            Thread.Sleep(1000);

            var cedulaField = _driver.FindElement(By.Name("Cedula"));
            cedulaField.Clear();
            cedulaField.SendKeys("1234567890");
            Thread.Sleep(1000);

            var apellidosField = _driver.FindElement(By.Name("Apellidos"));
            apellidosField.Clear();
            apellidosField.SendKeys("Silva");
            Thread.Sleep(1000);

            var nombresField = _driver.FindElement(By.Name("Nombres"));
            nombresField.Clear();
            nombresField.SendKeys("Juan");
            Thread.Sleep(1000);

            var fechaNacimientoField = _driver.FindElement(By.Name("FechaNacimiento"));
            fechaNacimientoField.Clear();
            fechaNacimientoField.SendKeys("01/01/1990");
            Thread.Sleep(1000);

            var mailField = _driver.FindElement(By.Name("Mail"));
            mailField.Clear();
            mailField.SendKeys("juan.perez@gmail.com");
            Thread.Sleep(1000);

            var telefonoField = _driver.FindElement(By.Name("Telefono"));
            telefonoField.Clear();
            telefonoField.SendKeys("0987654321");
            Thread.Sleep(1000);

            var direccionField = _driver.FindElement(By.Name("Direccion"));
            direccionField.Clear();
            direccionField.SendKeys("Pomasqui");
            Thread.Sleep(1000);

            var estadoField = _driver.FindElement(By.Name("Estado"));
            estadoField.SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            Thread.Sleep(1000);

            Assert.Contains("Cédula inválida", cedulaField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void EditarClienteConCorreoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");
            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            var editButton = _driver.FindElement(By.CssSelector("table.table tbody tr:first-child a.btn-warning"));
            editButton.Click();
            Thread.Sleep(1000);

            var cedulaField = _driver.FindElement(By.Name("Cedula"));
            cedulaField.Clear();
            cedulaField.SendKeys("1758187742");
            Thread.Sleep(1000);

            var apellidosField = _driver.FindElement(By.Name("Apellidos"));
            apellidosField.Clear();
            apellidosField.SendKeys("Silva");
            Thread.Sleep(1000);

            var nombresField = _driver.FindElement(By.Name("Nombres"));
            nombresField.Clear();
            nombresField.SendKeys("Juan");
            Thread.Sleep(1000);

            var fechaNacimientoField = _driver.FindElement(By.Name("FechaNacimiento"));
            fechaNacimientoField.Clear();
            fechaNacimientoField.SendKeys("01/01/1990");
            Thread.Sleep(1000);

            var mailField = _driver.FindElement(By.Name("Mail"));
            mailField.Clear();
            mailField.SendKeys("juan.perezgmail.com");
            Thread.Sleep(1000);

            var telefonoField = _driver.FindElement(By.Name("Telefono"));
            telefonoField.Clear();
            telefonoField.SendKeys("0987654321");
            Thread.Sleep(1000);

            var direccionField = _driver.FindElement(By.Name("Direccion"));
            direccionField.Clear();
            direccionField.SendKeys("Pomasqui");
            Thread.Sleep(1000);

            var estadoField = _driver.FindElement(By.Name("Estado"));
            estadoField.SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            Thread.Sleep(1000);

            Assert.Contains("Incluye un signo \"@\" en la dirección", mailField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void EditarClienteConTelefonoInvalido()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");
            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            var editButton = _driver.FindElement(By.CssSelector("table.table tbody tr:first-child a.btn-warning"));
            editButton.Click();
            Thread.Sleep(1000);

            var cedulaField = _driver.FindElement(By.Name("Cedula"));
            cedulaField.Clear();
            cedulaField.SendKeys("1758187742");
            Thread.Sleep(1000);

            var apellidosField = _driver.FindElement(By.Name("Apellidos"));
            apellidosField.Clear();
            apellidosField.SendKeys("Silva");
            Thread.Sleep(1000);

            var nombresField = _driver.FindElement(By.Name("Nombres"));
            nombresField.Clear();
            nombresField.SendKeys("Juan");
            Thread.Sleep(1000);

            var fechaNacimientoField = _driver.FindElement(By.Name("FechaNacimiento"));
            fechaNacimientoField.Clear();
            fechaNacimientoField.SendKeys("01/01/1990");
            Thread.Sleep(1000);

            var mailField = _driver.FindElement(By.Name("Mail"));
            mailField.Clear();
            mailField.SendKeys("juan.perez@gmail.com");
            Thread.Sleep(1000);

            var telefonoField = _driver.FindElement(By.Name("Telefono"));
            telefonoField.Clear();
            telefonoField.SendKeys("12345");
            Thread.Sleep(1000);

            var direccionField = _driver.FindElement(By.Name("Direccion"));
            direccionField.Clear();
            direccionField.SendKeys("Pomasqui");
            Thread.Sleep(1000);

            var estadoField = _driver.FindElement(By.Name("Estado"));
            estadoField.SendKeys("Activo");
            Thread.Sleep(1000);

            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            Thread.Sleep(1000);

            Assert.Contains("Haz coincidir el formato solicitado", telefonoField.GetAttribute("validationMessage"));
        }

        [Fact]
        public void EliminarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");
            _wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            var deleteButton = _driver.FindElement(By.CssSelector("table.table tbody tr:first-child a.btn-danger"));
            deleteButton.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnSubmitEliminar")).Click();
            Thread.Sleep(1000);

            Assert.Equal("https://localhost:7010/Cliente", _driver.Url);
        }
    }
}
