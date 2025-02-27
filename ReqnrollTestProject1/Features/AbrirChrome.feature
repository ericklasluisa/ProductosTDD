Feature: AbrirChrome

Test para validar que la aplicación web de Votaciones se ejecute en el navegador Chrome

@tag1
Scenario: Usuario abre la aplicacion web de Votaciones en Chrome
	Given El usuario abre el navegador Chrome
	When Inicia sesión con el correo "testuser@test.com" y la contraseña "TestLogin1"
	And Hacer clic en el botón de iniciar sesion
	Then La aplicación web de Votaciones muestra la página principal de registrador
