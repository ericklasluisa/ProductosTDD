Feature: AbrirEdge

Test para validar que la aplicación web de Votaciones se ejecute en el navegador Edge

@tag1
Scenario: Usuario abre la aplicacion web de Votaciones en Edge
	Given El usuario abre el navegador Edge
	When Inicia sesión con el correo "testuser@test.com" y la contraseña "TestLogin1" desde Edge
	And Hacer clic en el botón de iniciar sesion desde Edge
	Then La aplicación web de Votaciones muestra la página principal de registrador desde Edge
