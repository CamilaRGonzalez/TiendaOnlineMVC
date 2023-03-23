Tienda online con sistema de gestion de productos y usuarios  desarrollada con .net framework MVC + SQL Server 2018.
Los permisos de acceso a las vistas de la aplicación estan dividisos en dos: perfil de administrador y perfil cliente.
El cliente puede ver los productos, su detalle y agregarlos al carrito simulando una compra, y el administrador puede ver listas de los productos, categorias y marcas pudiendo agregar, editar y eliminar los mismos.

Requerimientos
Para correr este proyecto, necesitas tener instalado:

Visual Studio 2019 o superior
SQL Server 2016 o superior
.NET Framework 4.8

Instalación
Clona este repositorio en tu computadora.
Crea una base de datos en SQL Server y ejecuta el script TiendaOnlineMVC.sql para crear las tablas y procedimientos almacenados necesarios.
Abre la solución del proyecto en Visual Studio.
Modifica la cadena de conexión en el constructor de la clase AccesoDB.
Compila y corre el proyecto.

Uso
La tienda virtual muestra los productos disponibles en la página principal. 
Puedes agregar productos al carrito de compras y acceder a los pedidos hechos por el cliente, para ello debes loguearte como cliente con las credenciales de la base de datos.

Para acceder al sistema de gestión de productos, necesitas loguearte como administrador. Para hacerlo, debes usar las credenciales de la base de datos correspondientes al administrador
Una vez logueado, podrás agregar, editar y eliminar productos. Tambien podrás ver los pedidos de los clientes y descargar un informe en archivo excel



  
  
  
  
  
  
  
  
  
  
  
  
  
  
