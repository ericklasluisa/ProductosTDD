Feature: login

Test de la página login del sitio https://www.automationexercise.com/login

@tag1
Scenario: Usuario inicia sesión incorrectamente
	Given Que el usuario se encuentra en la página de login
	When Ingresa las credenciales correo "testuser@mail.com" y la contraseña "pass123"
	And Hacer click en el botón de login
	Then Deberíá ver un mensaje de error
