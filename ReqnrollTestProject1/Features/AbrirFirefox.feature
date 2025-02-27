Feature: AbrirFirefox

Test para validar que la aplicación web de Votaciones se ejecute en el navegador Firefox

@tag1
Scenario: Usuario abre la aplicacion web de Votaciones en Firefox
	Given El usuario abre el navegador Firefox
	When Inicia sesión con el correo "testuser@test.com" y la contraseña "TestLogin1" desde Firefox
	And Hacer clic en el botón de iniciar sesion desde Firefox
	Then La aplicación web de Votaciones muestra la página principal de registrador desde Firefox
