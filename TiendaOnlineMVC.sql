USE [TiendaOnline]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[IdCarrito] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](150) NULL,
	[Email] [varchar](200) NULL,
	[Password] [varchar](20) NULL,
	[FechaRegistro] [date] NOT NULL,
	[Reestablecer] [bit] NULL,
	[Activo] [bit] NULL,
	[Admin] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[IdDetallePedido] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](10, 2) NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[IdDetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdTransaccion] [varchar](50) NULL,
	[FechaVenta] [date] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[TotalProductos] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](200) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[Precio] [decimal](10, 2) NULL,
	[Stock] [int] NULL,
	[UrlImagen] [varchar](300) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion], [Activo]) VALUES (14, N'Celulares', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion], [Activo]) VALUES (15, N'Audio', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion], [Activo]) VALUES (16, N'Hogar', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion], [Activo]) VALUES (17, N'Televisión', 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Descripcion], [Activo]) VALUES (18, N'Laptops', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (1, N'admin', N'admin', N'admin@yahoo.com', N'admin', CAST(N'2022-12-26' AS Date), 0, 1, 1)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (2, N'pepe', N'argento', N'pepe@hotmail.com', N'pepe123', CAST(N'2022-12-26' AS Date), 0, 0, 0)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (3, N'Monica', N'Argento', N'Moni@argento.com', N'Moni123', CAST(N'2022-12-27' AS Date), 0, 1, 0)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (7, N'Lionel', N'Messi', N'leomessi@hotmail.com', N'test123', CAST(N'2022-12-27' AS Date), 0, 0, 0)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (11, N'Angel', N'Di Maria', N'angelito@ndejdnn.com', N'test123', CAST(N'2022-12-29' AS Date), 0, 1, 0)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (12, N'camilo', N'rock', N'camila.gonzalez.ro.2@gmail.com', N'test123', CAST(N'2023-01-04' AS Date), 0, 1, NULL)
INSERT [dbo].[Cliente] ([IdCliente], [Nombre], [Apellido], [Email], [Password], [FechaRegistro], [Reestablecer], [Activo], [Admin]) VALUES (13, N'Juan', N'Perez', N'juan@hotmail.com', N'Juan123', CAST(N'2023-01-11' AS Date), 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallePedido] ON 

INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (1, 1, 1, 1, CAST(60000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (2, 2, 1, 1, CAST(60000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (3, 2, 7, 2, CAST(24000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (4, 3, 5, 1, CAST(13890.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (5, 3, 4, 2, CAST(14014.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (6, 4, 8, 1, CAST(28999.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (7, 4, 7, 1, CAST(12000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (8, 4, 10, 2, CAST(13438.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (9, 5, 4, 2, CAST(14014.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (10, 5, 9, 1, CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (11, 6, 10, 1, CAST(6720.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (12, 6, 13, 1, CAST(12000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (13, 7, 1, 1, CAST(60000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (14, 7, 10, 3, CAST(20159.00 AS Decimal(10, 2)))
INSERT [dbo].[DetallePedido] ([IdDetallePedido], [IdPedido], [IdProducto], [Cantidad], [Total]) VALUES (15, 7, 8, 1, CAST(28999.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetallePedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (1, N'Sony', 1)
INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (2, N'Samsung', 1)
INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (3, N'LG', 1)
INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (4, N'Noblex', 1)
INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (5, N'Lenovo', 1)
INSERT [dbo].[Marca] ([IdMarca], [Descripcion], [Activo]) VALUES (6, N'Liliana', 1)
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (1, 2, N'000001', CAST(N'2022-11-30' AS Date), CAST(60000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (2, 11, N'000002', CAST(N'2022-12-18' AS Date), CAST(84000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (3, 2, N'43db76', CAST(N'2023-01-07' AS Date), CAST(27904.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (4, 2, N'a5145b', CAST(N'2023-01-08' AS Date), CAST(54437.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (5, 3, N'b1ca9d', CAST(N'2023-01-08' AS Date), CAST(34014.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (6, 3, N'2207ea', CAST(N'2023-01-08' AS Date), CAST(18720.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Pedido] ([IdPedido], [IdCliente], [IdTransaccion], [FechaVenta], [MontoTotal], [TotalProductos]) VALUES (7, 13, N'847d4c', CAST(N'2023-01-11' AS Date), CAST(109158.00 AS Decimal(10, 2)), 5)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (1, N'Lenovo IdeaPad-20', N'PC portatil plateada pepe', 5, 18, CAST(60000.00 AS Decimal(10, 2)), 29, N'Producto-1.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (4, N'AURICULARES', N'auriculares sonido envolvente', 2, 15, CAST(7007.50 AS Decimal(10, 2)), 29, N'Producto-4.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (5, N'Licuadora', N'Licuadora negra', 6, 16, CAST(13890.00 AS Decimal(10, 2)), 49, N'Producto-5.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (6, N'Smart TV 678', N'TV smart 50'''' ', 3, 17, CAST(150300.00 AS Decimal(10, 2)), 20, N'Producto-6.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (7, N'Tostadora', N'Tostadora Samsung color negro', 6, 16, CAST(12000.00 AS Decimal(10, 2)), 44, N'Producto-7.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (8, N'Noblex A50', N'Noblex A50 + Dual Sim 32 Gb Negro 2 Gb Ram', 4, 14, CAST(28999.00 AS Decimal(10, 2)), 8, N'Producto-8.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (9, N'Parlante Bluetooth Noblex PSB1000', N'Parlante Sonido envolvente Noblex ', 4, 15, CAST(20000.00 AS Decimal(10, 2)), 19, N'Producto-9.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (10, N'Auriculares In ear SONY', N'Auriculares In ear SONY Bluetooth Inalámbricos | WI-C100 Azul', 1, 15, CAST(6719.70 AS Decimal(10, 2)), 44, N'Producto-10.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (11, N'Samsung Galaxy A03', N'Samsung Galaxy A03 32Gb Black 4Gb Ram SMA035MZKAAR', 2, 14, CAST(40000.00 AS Decimal(10, 2)), 12, N'Producto-11.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (12, N'Smart TV LED 65” 4K', N'Samsung
Smart TV LED 65” 4K UHD Samsung Crystal UN65BU8000GCFV', 2, 17, CAST(250000.00 AS Decimal(10, 2)), 30, N'Producto-12.jpg', 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [Precio], [Stock], [UrlImagen], [Activo]) VALUES (13, N'Turbo Ventilador Liliana VTF18P 18 Pulgadas', N'Turbo Ventilador Liliana VTF18P 18 Pulgadas', 6, 16, CAST(12000.00 AS Decimal(10, 2)), 39, N'Producto-13.jpg', 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Reestablecer]  DEFAULT ((0)) FOR [Reestablecer]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Marca] ADD  CONSTRAINT [DF_Marca_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Pedido] ADD  CONSTRAINT [DF_Pedido_FechaVenta]  DEFAULT (getdate()) FOR [FechaVenta]
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Cliente]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Producto]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Producto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([IdMarca])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearPedido]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CrearPedido]
@IdCliente int,
@IdTransaccion varchar(50),
@MontoTotal decimal,
@TotalProductos int,
@Resultado int output
as
insert into Pedido (IdCliente,IdTransaccion, MontoTotal, TotalProductos) values (@IdCliente,@IdTransaccion,@MontoTotal,@TotalProductos)
set @Resultado = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_DetallePedido]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[sp_DetallePedido]
@IdPedido int,
@IdProducto int,
@Cantidad int,
@Total decimal
as
insert into DetallePedido (IdPedido,IdProducto,Cantidad,Total) values (@IdPedido,@IdProducto,@Cantidad,@Total)
update Producto set Stock = Stock - @Cantidad where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_editarCategoria]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_editarCategoria]
@IdCategoria int,
@Descripcion varchar(100),
@Activo bit,
@Resultado bit output
as
IF NOT EXISTS (SELECT * FROM Categoria where Descripcion = @Descripcion AND IdCategoria != @IdCategoria)
	begin
	update Categoria set
	Descripcion = @Descripcion,
	Activo = @Activo
	where IdCategoria = @IdCategoria

	set @Resultado = 1
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_editarMarca]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_editarMarca]
@IdMarca int,
@Descripcion varchar(100),
@Activo bit,
@Resultado bit output
as
IF NOT EXISTS (SELECT * FROM Marca where Descripcion = @Descripcion AND IdMarca != @IdMarca)
	begin
	update Marca set
	Descripcion = @Descripcion,
	Activo = @Activo
	where IdMarca = @IdMarca

	set @Resultado = 1
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_EditarProducto]
@IdProducto int,
@Nombre varchar(100), 
@Descripcion varchar(200), 
@IdMarca int, 
@IdCategoria int, 
@Precio decimal(10,2), 
@Stock int, 
@Activo bit,
@Resultado int output
as
if not exists(select * from Producto where Nombre = @Nombre and IdProducto != @IdProducto)
	begin
	update Producto set Nombre = @Nombre,Descripcion = @Descripcion,
	IdMarca = @IdMarca, IdCategoria =@IdCategoria ,Precio = @Precio,
	Stock = @Stock , Activo=@Activo where IdProducto = @IdProducto
	
	set @Resultado = 1
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_editarUsuario]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_editarUsuario]
@IdCliente int,
@Nombre varchar(100),
@Apellido varchar(150),
@Email varchar(200),
@Activo bit,
@Resultado bit output
as
IF NOT EXISTS (SELECT * FROM Cliente WHERE Email =@Email AND IdCliente != @IdCliente)
	begin
	update Cliente set
	Nombre = @Nombre,
	Apellido = @Apellido,
	Email = @Email,
	Activo = @Activo
	where IdCliente = @IdCliente

	set @Resultado = 1
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminarUsuario]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_eliminarUsuario]
@IdCliente int,
@Resultado bit output
as
if exists (select * from Cliente where IdCliente = @IdCliente)
	begin
	delete from Cliente where IdCliente = @IdCliente
	set @Resultado = 1
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarPedidos]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ListarPedidos]
as
select P.FechaVenta as Fecha, CONCAT(C.Nombre,' ',C.Apellido) as Cliente, Pr.Nombre as Producto,
Pr.Precio, D.Cantidad, D.Total, P.IdTransaccion 
from Producto as Pr, Pedido as P
inner join Cliente as C on P.IdCliente = C.IdCliente
inner join DetallePedido as D on D.IdPedido = P.IdPedido
where D.IdProducto = Pr.IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_listarPedidosFiltro]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listarPedidosFiltro]
@fechaInicio varchar(20),
@fechaFin varchar(20),
@IdTransaccion varchar(20)
as
if(@IdTransaccion = '')
	begin
		select P.FechaVenta as Fecha, CONCAT(C.Nombre,' ',C.Apellido) as Cliente, Pr.Nombre as Producto,
		Pr.Precio, D.Cantidad, D.Total, P.IdTransaccion 
		from Producto as Pr, Pedido as P
		inner join Cliente as C on P.IdCliente = C.IdCliente
		inner join DetallePedido as D on D.IdPedido = P.IdPedido
		where D.IdProducto = Pr.IdProducto and P.FechaVenta between convert(date,@fechaInicio)  and convert(date,@fechaFin)
	end
else
	begin
		select P.FechaVenta as Fecha, CONCAT(C.Nombre,' ',C.Apellido) as Cliente, Pr.Nombre as Producto,
		Pr.Precio, D.Cantidad, D.Total, P.IdTransaccion 
		from Producto as Pr, Pedido as P
		inner join Cliente as C on P.IdCliente = C.IdCliente
		inner join DetallePedido as D on D.IdPedido = P.IdPedido
		where D.IdProducto = Pr.IdProducto and P.FechaVenta between convert(date,@fechaInicio) and convert(date,@fechaFin)
		and P.IdTransaccion = @IdTransaccion
	end






GO
/****** Object:  StoredProcedure [dbo].[sp_listarProductos]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_listarProductos]
as
select IdProducto,Nombre,P.Descripcion , P.IdMarca, M.Descripcion as Marca,
P.IdCategoria, C.Descripcion as Categoria, Precio, Stock, UrlImagen, P.Activo
from Producto as P
inner join Marca as M on M.IdMarca = P.IdMarca
inner join Categoria as C on C.IdCategoria = P.IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_RegistrarProducto]
@Nombre varchar(100), 
@Descripcion varchar(200), 
@IdMarca int, 
@IdCategoria int, 
@Precio decimal, 
@Stock int, 
@Activo bit,
@Resultado int output
as
if not exists(select * from Producto where Nombre = @Nombre)
	begin
	insert into Producto (Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,Activo) values 
	(@Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio, @Stock, @Activo)
	
	set @Resultado = SCOPE_IDENTITY()
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_registroCategoria]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_registroCategoria]
@Descripcion varchar(100),
@Activo bit,
@Resultado int output
as
IF not exists(select * from Categoria where Descripcion like @Descripcion)
	begin
	INSERT INTO Categoria(Descripcion,Activo) 
	values (@Descripcion,@Activo)

	set @Resultado = SCOPE_IDENTITY()
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_registroMarca]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_registroMarca]
@Descripcion varchar(100),
@Activo bit,
@Resultado int output
as
IF not exists(select * from Marca where Descripcion like @Descripcion)
	begin
	INSERT INTO Marca(Descripcion,Activo) 
	values (@Descripcion,@Activo)

	set @Resultado = SCOPE_IDENTITY()
	end
else
	set @Resultado = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_registroUsuario]    Script Date: 5/3/2023 02:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_registroUsuario]
@Nombre varchar(100),
@Apellido varchar(150),
@Email varchar(200),
@Password varchar(20),
@Activo bit,
@Resultado int output
as
IF not exists(select * from cliente where Email = @Email)
begin
INSERT INTO Cliente (Nombre,Apellido,Email,Password,Activo) 
values (@Nombre,@Apellido,@Email,@Password,@Activo)

set @Resultado = SCOPE_IDENTITY()
end
else
set @Resultado = 0

GO
