USE [master]
GO
/****** Object:  Database [TuCancha]    Script Date: 20-12-2020 0:19:07 ******/
CREATE DATABASE [TuCancha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TuCancha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TuCancha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TuCancha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TuCancha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TuCancha] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TuCancha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TuCancha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TuCancha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TuCancha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TuCancha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TuCancha] SET ARITHABORT OFF 
GO
ALTER DATABASE [TuCancha] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TuCancha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TuCancha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TuCancha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TuCancha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TuCancha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TuCancha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TuCancha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TuCancha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TuCancha] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TuCancha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TuCancha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TuCancha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TuCancha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TuCancha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TuCancha] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TuCancha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TuCancha] SET RECOVERY FULL 
GO
ALTER DATABASE [TuCancha] SET  MULTI_USER 
GO
ALTER DATABASE [TuCancha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TuCancha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TuCancha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TuCancha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TuCancha] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TuCancha] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TuCancha] SET QUERY_STORE = OFF
GO
USE [TuCancha]
GO
/****** Object:  User [User1]    Script Date: 20-12-2020 0:19:07 ******/
CREATE USER [User1] FOR LOGIN [User1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [User1]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administradores](
	[id_administrador] [int] IDENTITY(1,1) NOT NULL,
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [date] NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contraseña] [varchar](10) NOT NULL,
	[comuna] [int] NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[id_administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Canchas]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canchas](
	[id_cancha] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[recinto] [int] NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_final] [time](7) NOT NULL,
	[deporte] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Canchas] PRIMARY KEY CLUSTERED 
(
	[id_cancha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[rut] [varchar](10) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[edad] [date] NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[comuna] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunas]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunas](
	[id_comuna] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cuidad] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Comunas] PRIMARY KEY CLUSTERED 
(
	[id_comuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuidades]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuidades](
	[id_cuidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[region] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Cuidades] PRIMARY KEY CLUSTERED 
(
	[id_cuidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deportes]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deportes](
	[id_deporte] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Deportes] PRIMARY KEY CLUSTERED 
(
	[id_deporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id_jugadores] [int] IDENTITY(1,1) NOT NULL,
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [date] NOT NULL,
	[comuna] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
	[cliente] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Jugadores_1] PRIMARY KEY CLUSTERED 
(
	[id_jugadores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recintos]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recintos](
	[id_recinto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[estado] [bit] NULL,
	[administrador] [int] NOT NULL,
	[comuna] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Recintos] PRIMARY KEY CLUSTERED 
(
	[id_recinto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regiones]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regiones](
	[id_regiones] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Regiones] PRIMARY KEY CLUSTERED 
(
	[id_regiones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 20-12-2020 0:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[id_reserva] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [varchar](10) NOT NULL,
	[cancha] [int] NOT NULL,
	[confirmacion] [bit] NULL,
	[comentarios] [varchar](150) NULL,
	[monto_abono] [int] NULL,
	[monto_total] [int] NULL,
	[metodo_pago] [varchar](50) NULL,
	[cant_personas] [int] NULL,
	[equipo_a] [int] NULL,
	[equipo_b] [int] NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administradores]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Administradores] CHECK CONSTRAINT [FK_Administradores_Comunas]
GO
ALTER TABLE [dbo].[Canchas]  WITH CHECK ADD  CONSTRAINT [FK_Canchas_Deportes] FOREIGN KEY([deporte])
REFERENCES [dbo].[Deportes] ([id_deporte])
GO
ALTER TABLE [dbo].[Canchas] CHECK CONSTRAINT [FK_Canchas_Deportes]
GO
ALTER TABLE [dbo].[Canchas]  WITH CHECK ADD  CONSTRAINT [FK_Canchas_Recintos] FOREIGN KEY([recinto])
REFERENCES [dbo].[Recintos] ([id_recinto])
GO
ALTER TABLE [dbo].[Canchas] CHECK CONSTRAINT [FK_Canchas_Recintos]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Comunas]
GO
ALTER TABLE [dbo].[Comunas]  WITH CHECK ADD  CONSTRAINT [FK_Comunas_Cuidades] FOREIGN KEY([cuidad])
REFERENCES [dbo].[Cuidades] ([id_cuidad])
GO
ALTER TABLE [dbo].[Comunas] CHECK CONSTRAINT [FK_Comunas_Cuidades]
GO
ALTER TABLE [dbo].[Cuidades]  WITH CHECK ADD  CONSTRAINT [FK_Cuidades_Regiones] FOREIGN KEY([region])
REFERENCES [dbo].[Regiones] ([id_regiones])
GO
ALTER TABLE [dbo].[Cuidades] CHECK CONSTRAINT [FK_Cuidades_Regiones]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Clientes] FOREIGN KEY([cliente])
REFERENCES [dbo].[Clientes] ([rut])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Clientes]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Comunas]
GO
ALTER TABLE [dbo].[Recintos]  WITH CHECK ADD  CONSTRAINT [FK_Recintos_Administradores] FOREIGN KEY([administrador])
REFERENCES [dbo].[Administradores] ([id_administrador])
GO
ALTER TABLE [dbo].[Recintos] CHECK CONSTRAINT [FK_Recintos_Administradores]
GO
ALTER TABLE [dbo].[Recintos]  WITH CHECK ADD  CONSTRAINT [FK_Recintos_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Recintos] CHECK CONSTRAINT [FK_Recintos_Comunas]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Canchas] FOREIGN KEY([cancha])
REFERENCES [dbo].[Canchas] ([id_cancha])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Canchas]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Clientes] FOREIGN KEY([cliente])
REFERENCES [dbo].[Clientes] ([rut])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Clientes]
GO
USE [master]
GO
ALTER DATABASE [TuCancha] SET  READ_WRITE 
GO
