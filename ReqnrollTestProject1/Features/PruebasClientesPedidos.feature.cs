﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ReqnrollTestProject1.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class PruebasClientesPedidosFeature : object, Xunit.IClassFixture<PruebasClientesPedidosFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "PruebasClientesPedidos", "Pruebas para clientes y pedidos", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "PruebasClientesPedidos.feature"
#line hidden
        
        public PruebasClientesPedidosFeature(PruebasClientesPedidosFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Mostrar tabla de clientes con datos correctos")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Mostrar tabla de clientes con datos correctos")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task MostrarTablaDeClientesConDatosCorrectos()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Mostrar tabla de clientes con datos correctos", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
 await testRunner.GivenAsync("usuario esta en la pagina de tabla clientes", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 8
 await testRunner.WhenAsync("usuario visualiza tabla de clientes", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 9
 await testRunner.ThenAsync("numero de filas de la tabla es igual al de la base de datos de clientes", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Insertar clientes")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Insertar clientes")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task InsertarClientes()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Insertar clientes", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 13
 await testRunner.GivenAsync("usuario en pagina de agregar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table1.AddRow(new string[] {
                            "1726249442",
                            "Lasluisa",
                            "Erick",
                            "09/17/2003",
                            "erick@gmail.com",
                            "0982347297",
                            "Quito",
                            "1"});
#line 14
 await testRunner.WhenAsync("llenar los campos dentro del Formulario", ((string)(null)), table1, "When ");
#line hidden
#line 17
 await testRunner.AndAsync("Click en boton de guardar", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 18
 await testRunner.ThenAsync("Cliente agregado", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Insertar clientes con error")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Insertar clientes con error")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task InsertarClientesConError()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Insertar clientes con error", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 22
 await testRunner.GivenAsync("usuario esta en pagina de agregar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table2.AddRow(new string[] {
                            "10",
                            "Lasluisa",
                            "Erick",
                            "09/17/2003",
                            "erick@gmail.com",
                            "0982347297",
                            "Quito",
                            "1"});
#line 23
 await testRunner.WhenAsync("llenar el Formulario con los datos", ((string)(null)), table2, "When ");
#line hidden
#line 26
 await testRunner.AndAsync("Click en guardar", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 27
 await testRunner.ThenAsync("muestra mensaje de error", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Editar clientes")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Editar clientes")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EditarClientes()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Editar clientes", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 31
 await testRunner.GivenAsync("usuario en pagina de editar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 32
 await testRunner.WhenAsync("editar datos de cliente nombre: \"Martin\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 33
 await testRunner.AndAsync("click en boton guardar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 34
 await testRunner.ThenAsync("Cliente editado con exito", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Editar clientes con error")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Editar clientes con error")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EditarClientesConError()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Editar clientes con error", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 37
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 38
 await testRunner.GivenAsync("usuario esta en pagina de editar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 39
 await testRunner.WhenAsync("editar datos de cliente cedula: \"10\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 40
 await testRunner.AndAsync("click en boton editar", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 41
 await testRunner.ThenAsync("Muestra mensaje de error al editar", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Eliminar cliente")]
        [Xunit.TraitAttribute("FeatureTitle", "PruebasClientesPedidos")]
        [Xunit.TraitAttribute("Description", "Eliminar cliente")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EliminarCliente()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Eliminar cliente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 44
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 45
 await testRunner.GivenAsync("usuario en pagina eliminar cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 46
 await testRunner.WhenAsync("click en eliminar", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 47
 await testRunner.ThenAsync("usuario eliminado", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await PruebasClientesPedidosFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await PruebasClientesPedidosFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
