Feature: Registro

Test de registro en página https://www.automationexercise.com/login

@tag1
Scenario: Usuario crea una cuenta con exito
	Given Que el usuario se encuentra en la pagina de login
	When Ingresa sus datos de nombre "Erick Lasluisa" y correo "erickl@gmail.com"
	And Hacer click en el boton de signup
	And Ingresa sus los datos de password "pass123", dia "17", mes "09" y año "2003", nombre "Erick", apellido "Lasluisa", address "Villaflora", state "Pichincha", city "Quito", zip "170150", phone "0982347297"
	And Hace click en el boton de create account
	Then El usuario es redirigido a la pagina de cuenta creada
