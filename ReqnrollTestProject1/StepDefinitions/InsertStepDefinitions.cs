using System;
using ProductosTDD.Models;
using FluentAssertions;
using Reqnroll;
using ProductosTDD.Data;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace ReqnrollTestProject1.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {

        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("Llenar los campos dentro del Formulario")]
        public void GivenLlenarLosCamposDentroDelFormulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count();

            //Assert.True(resultado > 0);
            resultado.Should().BeGreaterThanOrEqualTo(1);
        }

        [When("Registros ingresados en la BD")]
        public void WhenRegistrosIngresadosEnLaBD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            foreach (var item in cliente)
            {
                var cls = new Cliente
                {
                    Cedula = item.Cedula,
                    Nombres = item.Nombres,
                    Apellidos = item.Apellidos,
                    FechaNacimiento = item.FechaNacimiento,
                    Mail = item.Mail,
                    Telefono = item.Telefono,
                    Direccion = item.Direccion,
                    Estado = item.Estado
                };

                _clienteDAL.AddClient(cls);
            }
        }

        [Then("Resultado del ingreso a la BD")]
        public void ThenResultadoDelIngresoALaBD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            var clientesDB = _clienteDAL.getAllCliente();

            int encontrado = 0;

            foreach (var clienteE in clientesDB)
            {
                if (clientesDB.Contains(clienteE))
                {
                    encontrado++;
                    break;
                }
            }

            Assert.True(encontrado > 0);
        }
    }
}
