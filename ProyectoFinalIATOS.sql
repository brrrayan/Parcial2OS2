USE [master]
GO
/****** Object:  Database [dbParcial2OS2]    Script Date: 15/4/2021 20:34:49 ******/
CREATE DATABASE [dbParcial2OS2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbParcial2OS2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\dbParcial2OS2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbParcial2OS2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\dbParcial2OS2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbParcial2OS2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbParcial2OS2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbParcial2OS2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbParcial2OS2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbParcial2OS2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbParcial2OS2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbParcial2OS2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [dbParcial2OS2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET RECOVERY FULL 
GO
ALTER DATABASE [dbParcial2OS2] SET  MULTI_USER 
GO
ALTER DATABASE [dbParcial2OS2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbParcial2OS2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbParcial2OS2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbParcial2OS2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbParcial2OS2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbParcial2OS2', N'ON'
GO
ALTER DATABASE [dbParcial2OS2] SET QUERY_STORE = OFF
GO
USE [dbParcial2OS2]
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 15/4/2021 20:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[ID_Almacen] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Almacenes] PRIMARY KEY CLUSTERED 
(
	[ID_Almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 15/4/2021 20:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID_Articulo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Existencia] [int] NOT NULL,
	[ID_TipoInventario] [int] NOT NULL,
	[CostoUnitario] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[ID_Articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsientosContables]    Script Date: 15/4/2021 20:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsientosContables](
	[ID_AsientoCOntable] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[ID_TipoInventario] [int] NOT NULL,
	[CuentaContable] [nvarchar](max) NULL,
	[TipoMovimiento] [nvarchar](max) NULL,
	[FechaAsiento] [datetime2](7) NOT NULL,
	[MontoAsiento] [int] NOT NULL,
	[Estado] [bit] NULL,
	[IdAsiento] [int] NULL,
 CONSTRAINT [PK_AsientosContables] PRIMARY KEY CLUSTERED 
(
	[ID_AsientoCOntable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInventario]    Script Date: 15/4/2021 20:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInventario](
	[ID_TipoInventario] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[CuentaContable] [nvarchar](50) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_TipoInventario] PRIMARY KEY CLUSTERED 
(
	[ID_TipoInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 15/4/2021 20:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[ID_Transaccion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Transaccion] [nvarchar](max) NULL,
	[ID_Articulo] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Monto] [int] NOT NULL,
 CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED 
(
	[ID_Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulos_TipoInventario] FOREIGN KEY([ID_TipoInventario])
REFERENCES [dbo].[TipoInventario] ([ID_TipoInventario])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulos_TipoInventario]
GO
ALTER TABLE [dbo].[AsientosContables]  WITH CHECK ADD  CONSTRAINT [FK_AsientosContables_TipoInventario] FOREIGN KEY([ID_TipoInventario])
REFERENCES [dbo].[TipoInventario] ([ID_TipoInventario])
GO
ALTER TABLE [dbo].[AsientosContables] CHECK CONSTRAINT [FK_AsientosContables_TipoInventario]
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_Articulos] FOREIGN KEY([ID_Articulo])
REFERENCES [dbo].[Articulos] ([ID_Articulo])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_Articulos]
GO
USE [master]
GO
ALTER DATABASE [dbParcial2OS2] SET  READ_WRITE 
GO
