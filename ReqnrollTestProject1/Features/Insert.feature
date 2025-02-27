Feature: Insert

Ingreso de la información del formulario cliente a la BD

@tag1
Scenario: Insertar clientes
	Given Llenar los campos dentro del Formulario
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
	| 1726249442 | Lasluisa  | Erick   | 09/17/2003      | erick@gmail.com | 0982347297 | Quito     | 1      |
	When Registros ingresados en la BD
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
	| 1726249442 | Lasluisa  | Erick   | 09/17/2003      | erick@gmail.com | 0982347297 | Quito     | 1      |
	Then Resultado del ingreso a la BD
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
	| 1726249442 | Lasluisa  | Erick   | 09/17/2003      | erick@gmail.com | 0982347297 | Quito     | 1      |
