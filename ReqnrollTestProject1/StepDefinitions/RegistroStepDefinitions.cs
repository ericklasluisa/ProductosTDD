using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class RegistroStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public RegistroStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("chrome");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("Que el usuario se encuentra en la pagina de login")]
        public void GivenQueElUsuarioSeEncuentraEnLaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            _test.Log(Status.Info, "Se ha ingresado a la página de login");
        }

        [When("Ingresa sus datos de nombre {string} y correo {string}")]
        public void WhenIngresaSusDatosDeNombreYCorreo(string name, string email)
        {
            _driver.FindElement(By.Name("name")).SendKeys(name);
            _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/input[3]")).SendKeys(email);

            _test.Log(Status.Info, $"Usuario ingresó el nombre {name} y el correo {email}");
        }

        [When("Hacer click en el boton de signup")]
        public void WhenHacerClickEnElBotonDeSignup()
        {
            _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/button")).Click();

            _test.Log(Status.Info, "Usuario hizo click en el botón de signup.");
        }

        [When("Ingresa sus los datos de password {string}, dia {string}, mes {string} y año {string}, nombre {string}, apellido {string}, address {string}, state {string}, city {string}, zip {string}, phone {string}")]
        public void WhenIngresaSusLosDatosDePasswordDiaMesYAnoNombreApellidoAddressStateCityZipPhone(string password, string dia, string mes, string año, string nombre, string apellido, string address, string state, string city, string zip, string phone)
        {
            _driver.FindElement(By.Id("id_gender1")).Click();
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _driver.FindElement(By.Name("days")).SendKeys(dia);
            _driver.FindElement(By.Name("months")).SendKeys(mes);
            _driver.FindElement(By.Name("years")).SendKeys(año);
            _driver.FindElement(By.Name("first_name")).SendKeys(nombre);
            _driver.FindElement(By.Name("last_name")).SendKeys(apellido);
            _driver.FindElement(By.Name("address1")).SendKeys(address);
            _driver.FindElement(By.Name("state")).SendKeys(state);
            _driver.FindElement(By.Name("city")).SendKeys(city);
            _driver.FindElement(By.Name("zipcode")).SendKeys(zip);
            _driver.FindElement(By.Name("mobile_number")).SendKeys(phone);

            _test.Log(Status.Info, $"Usuario ingresó la contraseña {password}, dia {dia}, mes {mes}, año {año}, nombre {nombre}, apellido {apellido}, address {address}, state {state}, city {city}, zip {zip}, phone {phone}");
        }

        [When("Hace click en el boton de create account")]
        public void WhenHaceClickEnElBotonDeCreateAccount()
        {
            _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/div[1]/form/button")).Click();

            _test.Log(Status.Info, "Usuario hizo click en el botón de create account.");
        }

        [Then("El usuario es redirigido a la pagina de cuenta creada")]
        public void ThenElUsuarioEsRedirigidoALaPaginaDeCuentaCreada()
        {
            try
            {
                bool cuentaCreada = _driver.Url
                    == "https://www.automationexercise.com/account_created";

                _test.Log(Status.Pass, "Se ha mostrado el mensaje de error.");

            }
            catch (Exception)
            {

                _test.Log(Status.Fail, "No se ha mostrado el mensaje de error.");
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
