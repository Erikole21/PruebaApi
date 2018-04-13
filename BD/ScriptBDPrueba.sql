USE [master]
GO
/****** Object:  Database [PRUEBA]    Script Date: 13/04/2018 2:46:33 p. m. ******/
CREATE DATABASE [PRUEBA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRUEBA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PRUEBA.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PRUEBA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PRUEBA_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PRUEBA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRUEBA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRUEBA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRUEBA] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRUEBA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRUEBA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRUEBA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRUEBA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRUEBA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRUEBA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRUEBA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRUEBA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRUEBA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRUEBA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRUEBA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRUEBA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRUEBA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRUEBA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRUEBA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRUEBA] SET  MULTI_USER 
GO
ALTER DATABASE [PRUEBA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRUEBA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRUEBA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRUEBA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PRUEBA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PRUEBA]
GO
/****** Object:  Table [dbo].[ClienteProductos]    Script Date: 13/04/2018 2:46:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteProductos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [ClienteProdouctoUniqueKey] UNIQUE NONCLUSTERED 
(
	[IdCliente] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 13/04/2018 2:46:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOrdenes]    Script Date: 13/04/2018 2:46:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOrdenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOrden] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[PrecioUnitario] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ValorTotal] [money] NOT NULL,
 CONSTRAINT [PK_Detalle_Ordenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 13/04/2018 2:46:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[DireccionEntrega] [varchar](255) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[ValorTotal] [money] NOT NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/04/2018 2:46:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleOrdenes] ADD  CONSTRAINT [DF_Detalle_Ordenes_Cantidad]  DEFAULT ((1)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Precio]  DEFAULT ((0)) FOR [Precio]
GO
ALTER TABLE [dbo].[ClienteProductos]  WITH CHECK ADD  CONSTRAINT [FK_ClienteProductos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[ClienteProductos] CHECK CONSTRAINT [FK_ClienteProductos_Clientes]
GO
ALTER TABLE [dbo].[ClienteProductos]  WITH CHECK ADD  CONSTRAINT [FK_ClienteProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[ClienteProductos] CHECK CONSTRAINT [FK_ClienteProductos_Productos]
GO
ALTER TABLE [dbo].[DetalleOrdenes]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ordenes_Ordenes] FOREIGN KEY([IdOrden])
REFERENCES [dbo].[Ordenes] ([Id])
GO
ALTER TABLE [dbo].[DetalleOrdenes] CHECK CONSTRAINT [FK_Detalle_Ordenes_Ordenes]
GO
ALTER TABLE [dbo].[DetalleOrdenes]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ordenes_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[DetalleOrdenes] CHECK CONSTRAINT [FK_Detalle_Ordenes_Productos]
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Clientes]
GO
/****** Object:  StoredProcedure [dbo].[STM_CLIENTES]    Script Date: 13/04/2018 2:46:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Erik Rodriguez
-- Create date: 12/04/2018
-- Description:	Consultas para administrar la tabla clientes
-- =============================================
CREATE PROCEDURE [dbo].[STM_CLIENTES]		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		
	SELECT Id, Nombre, Email FROM Clientes		

END
GO
/****** Object:  StoredProcedure [dbo].[STM_DETALLE_ORDENES]    Script Date: 13/04/2018 2:46:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Erik Rodriguez
-- Create date: 12/04/2018
-- Description:	Consultas para administrar la tabla detalleOrdenes
-- =============================================
CREATE PROCEDURE [dbo].[STM_DETALLE_ORDENES]	
	@ID_ORDEN INT,
	@ID_PRODUCTO INT = NULL,
	@PRECIO_UNITARIO MONEY = NULL,
	@CANTIDAD INT = NULL,
	@VALOR_TOTAL MONEY = NULL,
	@OPERACION  TINYINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Description:	inserta detalles de las ordenes y devuelve el id asignado
-- =============================================
	IF @OPERACION = 1
	BEGIN
		
		INSERT INTO DetalleOrdenes (IdOrden,IdProducto,PrecioUnitario,Cantidad,ValorTotal) 
		VALUES (@ID_ORDEN,@ID_PRODUCTO,@PRECIO_UNITARIO,@CANTIDAD,@VALOR_TOTAL)

		SELECT SCOPE_IDENTITY() 		

	END

-- Description:	Consulta todos los detalles de una orden enviada
-- =============================================
	IF @OPERACION = 2
	BEGIN		

		SELECT DetalleOrdenes.Id IdDetalle, Productos.Id, Nombre,PrecioUnitario,Cantidad, DetalleOrdenes.ValorTotal
		FROM Ordenes
		INNER JOIN DetalleOrdenes ON DetalleOrdenes.IdOrden = Ordenes.Id
		INNER JOIN Productos ON Productos.Id = DetalleOrdenes.IdProducto
		WHERE Ordenes.Id = @ID_ORDEN		

	END

END
GO
/****** Object:  StoredProcedure [dbo].[STM_ORDENES]    Script Date: 13/04/2018 2:46:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Erik Rodriguez
-- Create date: 12/04/2018
-- Description:	Consultas para administrar la tabla ordenes
-- =============================================
CREATE PROCEDURE [dbo].[STM_ORDENES]	
	@ID_CLIENTE INT,
	@DIRECCION_ENTREGA VARCHAR(255),
	@FECHA_INICIAL DATETIME = NULL,
	@FECHA_FINAL DATETIME = NULL,
	@OPERACION  TINYINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Description:	Inserta una orden y devuelve el id asignado
-- =============================================
	IF @OPERACION = 1
	BEGIN
		INSERT INTO Ordenes (IdCliente,DireccionEntrega,FechaRegistro) VALUES	(@ID_CLIENTE,@DIRECCION_ENTREGA,GETDATE())
	
		SELECT SCOPE_IDENTITY() 
	END

-- Description:	Listar las órdenes de un cliente por un rango de fechas. 
-- =============================================
	IF @OPERACION = 2
	BEGIN
		SELECT Id,FechaRegistro,ValorTotal,DireccionEntrega  FROM Ordenes
		WHERE
			IdCliente = @ID_CLIENTE
		AND
			FechaRegistro BETWEEN @FECHA_INICIAL AND @FECHA_FINAL
		
	END    
END
GO
/****** Object:  StoredProcedure [dbo].[STM_PRODUCTOS]    Script Date: 13/04/2018 2:46:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Erik Rodriguez
-- Create date: 12/04/2018
-- Description:	Consultas para administrar la tabla productos
-- =============================================
CREATE PROCEDURE [dbo].[STM_PRODUCTOS]	
	@NOMBRE VARCHAR(255),
	@PRECIO MONEY,	
	@IDCLIENTE INT =NULL,
	@OPERACION  TINYINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Description:	Consulta todos los productos permitidos para un cliente
-- =============================================
	IF @OPERACION = 1
	BEGIN
		
		SELECT Productos.Id, Nombre, Precio FROM Productos
		INNER JOIN ClienteProductos ON ClienteProductos.IdProducto = Productos.Id
		WHERE ClienteProductos.IdCliente = @IDCLIENTE

	END

-- Description:	Consulta la cantidad de productos adquiridos por un cliente
-- =============================================
	IF @OPERACION = 2
	BEGIN		

		SELECT COUNT(DetalleOrdenes.Id) as CantidadProductos
		FROM Ordenes
		INNER JOIN DetalleOrdenes ON DetalleOrdenes.IdOrden = Ordenes.Id
		INNER JOIN Productos ON Productos.Id = DetalleOrdenes.IdProducto
		WHERE Ordenes.IdCliente = @IDCLIENTE
		

	END

END
GO
USE [master]
GO
ALTER DATABASE [PRUEBA] SET  READ_WRITE 
GO
