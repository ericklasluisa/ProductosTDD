Feature: PruebasClientesPedidos

Pruebas para clientes y pedidos

@tag1
Scenario: Mostrar tabla de clientes con datos correctos
	Given usuario esta en la pagina de tabla clientes
	When usuario visualiza tabla de clientes
	Then numero de filas de la tabla es igual al de la base de datos de clientes

@tag1
Scenario: Insertar clientes
	Given usuario en pagina de agregar cliente
	When llenar los campos dentro del Formulario
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
	| 1726249442 | Lasluisa  | Erick   | 09/17/2003      | erick@gmail.com | 0982347297 | Quito     | 1      |
	And Click en boton de guardar
	Then Cliente agregado

@tag1
Scenario: Insertar clientes con error
	Given usuario esta en pagina de agregar cliente
	When llenar el Formulario con los datos
	| Cedula | Apellidos | Nombres | FechaNacimiento | Mail            | Telefono   | Direccion | Estado |
	| 10     | Lasluisa  | Erick   | 09/17/2003      | erick@gmail.com | 0982347297 | Quito     | 1      |
	And Click en guardar
	Then muestra mensaje de error

@tag1
Scenario: Editar clientes
	Given usuario en pagina de editar cliente
	When editar datos de cliente nombre: "Martin"
	And click en boton guardar cliente
	Then Cliente editado con exito

@tag1
Scenario: Editar clientes con error
	Given usuario esta en pagina de editar cliente
	When editar datos de cliente cedula: "10"
	And click en boton editar
	Then Muestra mensaje de error al editar

@tag1
Scenario: Eliminar cliente
	Given usuario en pagina eliminar cliente
	When click en eliminar
	Then usuario eliminado
