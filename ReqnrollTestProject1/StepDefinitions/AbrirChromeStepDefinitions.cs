using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject1.Utilities;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class AbrirChromeStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public AbrirChromeStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReportChrome.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("chrome");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("El usuario abre el navegador Chrome")]
        public void GivenElUsuarioAbreElNavegadorChrome()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173");

            _test.Log(Status.Info, "Se ha ingresado a la aplicación desde el navegador Chrome");
        }

        [When("Inicia sesión con el correo {string} y la contraseña {string}")]
        public void WhenIniciaSesionConElCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(email);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);

            _test.Log(Status.Info, $"Usuario ingresó el correo {email} y la contraseña {password}");
        }

        [When("Hacer clic en el botón de iniciar sesion")]
        public void WhenHacerClicEnElBoton()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).Click();

            _test.Log(Status.Info, "Usuario hizo click en el botón de iniciar sesión.");
        }

        [Then("La aplicación web de Votaciones muestra la página principal de registrador")]
        public void ThenLaAplicacionWebDeVotacionesMuestraLaPaginaPrincipalDeRegistrador()
        {
            try
            {
                Thread.Sleep(2000);
                bool IsSessionStarted = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/img")) != null;

                _test.Log(Status.Pass, "Se ha iniciado sesión con éxito desde Chrome");

            }
            catch (NoSuchElementException)
            {

                _test.Log(Status.Fail, "No se inició sesión con éxito desde Chrome");
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
