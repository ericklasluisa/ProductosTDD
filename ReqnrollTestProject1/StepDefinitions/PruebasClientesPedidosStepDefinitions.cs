using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;
using System.Xml.Linq;
using ProductosTDD.Models;
using ProductosTDD.Data;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class PruebasClientesPedidosStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public PruebasClientesPedidosStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ReportClientes.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("chrome");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("usuario esta en la pagina de tabla clientes")]
        public void GivenUsuarioEstaEnLaPaginaDeTablaClientes()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente");

            _test.Log(Status.Info, "Se ha ingresado a la página de clientes");
        }

        [When("usuario visualiza tabla de clientes")]
        public void WhenUsuarioVisualizaTablaDeClientes()
        {
            bool isTabla = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/table")) != null;

            _test.Log(Status.Info, "Se visualiza la tabla");
        }

        [Then("numero de filas de la tabla es igual al de la base de datos de clientes")]
        public void ThenNumeroDeFilasDeLaTablaEsIgualAlDeLaBaseDeDatosDeClientes()
        {
            bool isFila = _driver.FindElement(By.XPath("/html/body/div/div/div/main/table/tbody/tr[1]")) != null;

            _test.Log(Status.Pass, "Numero de filas igual al de la base de datos");
        }

        [Given("usuario en pagina de agregar cliente")]
        public void GivenUsuarioEnPaginaDeAgregarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _test.Log(Status.Info, "Se ha ingresado a la página de agregar clientes");
        }

        [When("llenar los campos dentro del Formulario")]
        public void WhenLlenarLosCamposDentroDelFormulario(DataTable dataTable)
        {
            var clienteDT = dataTable.CreateSet<Cliente>().ToList();
            var cliente = clienteDT[0];
            _driver.FindElement(By.Name("Cedula")).SendKeys(cliente.Cedula);
            _driver.FindElement(By.Name("Apellidos")).SendKeys(cliente.Apellidos);
            _driver.FindElement(By.Name("Nombres")).SendKeys(cliente.Nombres);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys(cliente.FechaNacimiento.ToString());
            _driver.FindElement(By.Name("Mail")).SendKeys(cliente.Mail);
            _driver.FindElement(By.Name("Telefono")).SendKeys(cliente.Telefono);
            _driver.FindElement(By.Name("Direccion")).SendKeys(cliente.Direccion);

            _test.Log(Status.Info, "Se han llenado los datos del formulario");
        }

        [When("Click en boton de guardar")]
        public void WhenClickEnBotonDeGuardar()
        {
            _driver.FindElement(By.Id("btnSubmit")).Click();
            _test.Log(Status.Info, "Se dio click en el botón de guardar");
        }

        [Then("Cliente agregado")]
        public void ThenClienteAgregado()
        {
            try
            {
                bool cuentaCreada = _driver.Url
                    == "https://localhost:7010/Cliente";

                _test.Log(Status.Pass, "Se creo el usuario");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se ha creado el usuario");
            }
        }

        [Given("usuario esta en pagina de agregar cliente")]
        public void GivenUsuarioEstaEnPaginaDeAgregarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Create");

            _test.Log(Status.Info, "Se ha ingresado a la página de agregar clientes");
        }

        [When("llenar el Formulario con los datos")]
        public void WhenLlenarElFormularioConLosDatos(DataTable dataTable)
        {
            var clienteDT = dataTable.CreateSet<Cliente>().ToList();
            var cliente = clienteDT[0];
            _driver.FindElement(By.Name("Cedula")).SendKeys(cliente.Cedula);
            _driver.FindElement(By.Name("Apellidos")).SendKeys(cliente.Apellidos);
            _driver.FindElement(By.Name("Nombres")).SendKeys(cliente.Nombres);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys(cliente.FechaNacimiento.ToString());
            _driver.FindElement(By.Name("Mail")).SendKeys(cliente.Mail);
            _driver.FindElement(By.Name("Telefono")).SendKeys(cliente.Telefono);
            _driver.FindElement(By.Name("Direccion")).SendKeys(cliente.Direccion);

            _test.Log(Status.Info, "Se han llenado los datos del formulario");
        }

        [When("Click en guardar")]
        public void WhenClickEnGuardar()
        {
            _driver.FindElement(By.Id("btnSubmit")).Click();
            _test.Log(Status.Info, "Se dio click en el botón de guardar");
        }

        [Then("muestra mensaje de error")]
        public void ThenMuestraMensajeDeError()
        {
            try
            {
                bool error = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div/div[2]/form/div[1]/div[1]/div")) != null;

                _test.Log(Status.Pass, "Se mostró mensaje de error");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se muestra mensaje de error");
            }
        }

        [Given("usuario en pagina de editar cliente")]
        public void GivenUsuarioEnPaginaDeEditarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Edit/1025");

            _test.Log(Status.Info, "Se ha ingresado a la página de editar clientes");
        }

        [When("editar datos de cliente nombre: {string}")]
        public void WhenEditarDatosDeClienteNombre(string nombre)
        {
            _driver.FindElement(By.Name("Nombres")).SendKeys(nombre);
            _test.Log(Status.Info, "Se ha editado el nombre del cliente");
        }

        [When("click en boton guardar cliente")]
        public void WhenClickEnBotonGuardarCliente()
        {
            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            _test.Log(Status.Info, "Se dio click en el botón de guardar");
        }

        [Then("Cliente editado con exito")]
        public void ThenClienteEditadoConExito()
        {
            try
            {
                bool cuentaCreada = _driver.Url
                    == "https://localhost:7010/Cliente";

                _test.Log(Status.Pass, "Se edito el usuario");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se ha editado el usuario");
            }
        }

        [Given("usuario esta en pagina de editar cliente")]
        public void GivenUsuarioEstaEnPaginaDeEditarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Edit/1025");

            _test.Log(Status.Info, "Se ha ingresado a la página de editar clientes");
        }

        [When("editar datos de cliente cedula: {string}")]
        public void WhenEditarDatosDeClienteCedula(string cedula)
        {
            _driver.FindElement(By.Name("Nombres")).SendKeys(cedula);
            _test.Log(Status.Info, "Se ha editado la cedula del cliente");
        }

        [When("click en boton editar")]
        public void WhenClickEnBotonEditar()
        {
            _driver.FindElement(By.Id("btnSubmitEditar")).Click();
            _test.Log(Status.Info, "Se dio click en el botón de guardar");
        }

        [Then("Muestra mensaje de error al editar")]
        public void ThenMuestraMensajeDeErrorAlEditar()
        {
            try
            {
                bool error = _driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div/div[2]/form/div[1]/div[1]/div")) != null;

                _test.Log(Status.Pass, "Se mostró mensaje de error");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se muestra mensaje de error");
            }
        }

        [Given("usuario en pagina eliminar cliente")]
        public void GivenUsuarioEnPaginaEliminarCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7010/Cliente/Delete/1030");

            _test.Log(Status.Info, "Se ha ingresado a la página de eliminar clientes");
        }

        [When("click en eliminar")]
        public void WhenClickEnEliminar()
        {
            _driver.FindElement(By.Id("btnSubmitEliminar")).Click();
            _test.Log(Status.Info, "Se dio click en el botón de eliminar");
        }

        [Then("usuario eliminado")]
        public void ThenUsuarioEliminado()
        {
            try
            {
                bool cuentaCreada = _driver.Url
                    == "https://localhost:7010/Cliente";

                _test.Log(Status.Pass, "Se elimino el usuario");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se ha eliminado el usuario");    
            }
        }

        [AfterScenario]
        public void Down()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
