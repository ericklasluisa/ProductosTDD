using System;
using ProductosTDD.Models;
using Reqnroll;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class CalcularAreaStepDefinitions
    {

        private readonly AreaCirculo _areaCirculo = new AreaCirculo();
        private double _resultado;

        [Given("El radio es {int}")]
        public void GivenElRadioEs(int p0)
        {
            _areaCirculo.Radio = p0;
        }

        [When("Se calcula el area")]
        public void WhenSeCalculaElArea()
        {
            _resultado = _areaCirculo.CalcularArea();
        }

        [Then("El resultado es {float}")]
        public void ThenElResultadoEs(Double p0)
        {
            _resultado.CompareTo(p0);
        }
    }
}
