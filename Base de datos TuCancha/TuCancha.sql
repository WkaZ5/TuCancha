USE [master]
GO
/****** Object:  Database [TuCancha]    Script Date: 29-10-2020 18:17:05 ******/
CREATE DATABASE [TuCancha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TuCancha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TuCancha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TuCancha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TuCancha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
EXEC sys.sp_db_vardecimal_storage_format N'TuCancha', N'ON'
GO
ALTER DATABASE [TuCancha] SET QUERY_STORE = OFF
GO
USE [TuCancha]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administradores](
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[comuna] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha](
	[cod_cancha] [varchar](50) NOT NULL,
	[nombre_cancha] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[recinto] [varchar](50) NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NOT NULL,
	[tipo_cancha] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Cancha_1] PRIMARY KEY CLUSTERED 
(
	[cod_cancha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[id_ciudades] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[region] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Ciudades_1] PRIMARY KEY CLUSTERED 
(
	[id_ciudades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[comuna] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunas]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunas](
	[id_comuna] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Comunas] PRIMARY KEY CLUSTERED 
(
	[id_comuna] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[id_equipo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[id_equipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id_jugadores] [varchar](50) NOT NULL,
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[equipos] [varchar](50) NOT NULL,
	[comuna] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[id_jugadores] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recintos]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recintos](
	[cod_recinto] [varchar](50) NOT NULL,
	[nombre_recinto] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[administrador] [varchar](50) NOT NULL,
	[comuna] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Recintos] PRIMARY KEY CLUSTERED 
(
	[cod_recinto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regiones]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regiones](
	[id_regiones] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_Regiones_1] PRIMARY KEY CLUSTERED 
(
	[id_regiones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[cod_reserva] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [varchar](50) NOT NULL,
	[cancha] [varchar](50) NOT NULL,
	[recinto] [varchar](50) NOT NULL,
	[confirmacion] [bit] NOT NULL,
	[comentarios] [varchar](150) NULL,
	[comuna] [varchar](50) NOT NULL,
	[monto_abono] [int] NULL,
	[monto_total] [int] NOT NULL,
	[metodo_pago] [varchar](50) NOT NULL,
	[jugadores] [varchar](50) NOT NULL,
	[cant_personas] [int] NOT NULL,
	[equipo_a] [varchar](50) NULL,
	[equipo_b] [varchar](50) NULL,
	[fecha_hora] [datetime] NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[cod_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCanchas]    Script Date: 29-10-2020 18:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCanchas](
	[id_tipo] [varchar](50) NOT NULL,
	[cant_jugadores] [int] NOT NULL,
	[eliminado] [bit] NULL,
	[fecha_elim] [datetime] NULL,
 CONSTRAINT [PK_TipoCanchas] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administradores]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Administradores] CHECK CONSTRAINT [FK_Administradores_Comunas]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [FK_Cancha_Recintos] FOREIGN KEY([recinto])
REFERENCES [dbo].[Recintos] ([cod_recinto])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [FK_Cancha_Recintos]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [FK_Cancha_TipoCanchas] FOREIGN KEY([tipo_cancha])
REFERENCES [dbo].[TipoCanchas] ([id_tipo])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [FK_Cancha_TipoCanchas]
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD  CONSTRAINT [FK_Ciudades_Regiones] FOREIGN KEY([region])
REFERENCES [dbo].[Regiones] ([id_regiones])
GO
ALTER TABLE [dbo].[Ciudades] CHECK CONSTRAINT [FK_Ciudades_Regiones]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Comunas]
GO
ALTER TABLE [dbo].[Comunas]  WITH CHECK ADD  CONSTRAINT [FK_Comunas_Ciudades] FOREIGN KEY([ciudad])
REFERENCES [dbo].[Ciudades] ([id_ciudades])
GO
ALTER TABLE [dbo].[Comunas] CHECK CONSTRAINT [FK_Comunas_Ciudades]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Comunas]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Equipos] FOREIGN KEY([equipos])
REFERENCES [dbo].[Equipos] ([id_equipo])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Equipos]
GO
ALTER TABLE [dbo].[Recintos]  WITH CHECK ADD  CONSTRAINT [FK_Recintos_Administradores] FOREIGN KEY([administrador])
REFERENCES [dbo].[Administradores] ([rut])
GO
ALTER TABLE [dbo].[Recintos] CHECK CONSTRAINT [FK_Recintos_Administradores]
GO
ALTER TABLE [dbo].[Recintos]  WITH CHECK ADD  CONSTRAINT [FK_Recintos_Comunas] FOREIGN KEY([comuna])
REFERENCES [dbo].[Comunas] ([id_comuna])
GO
ALTER TABLE [dbo].[Recintos] CHECK CONSTRAINT [FK_Recintos_Comunas]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Cancha] FOREIGN KEY([cancha])
REFERENCES [dbo].[Cancha] ([cod_cancha])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Cancha]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Clientes] FOREIGN KEY([cliente])
REFERENCES [dbo].[Clientes] ([rut])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Clientes]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Equipos] FOREIGN KEY([equipo_a])
REFERENCES [dbo].[Equipos] ([id_equipo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Equipos]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Equipos_b] FOREIGN KEY([equipo_b])
REFERENCES [dbo].[Equipos] ([id_equipo])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Equipos_b]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Jugadores] FOREIGN KEY([jugadores])
REFERENCES [dbo].[Jugadores] ([id_jugadores])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Jugadores]
GO
USE [master]
GO
ALTER DATABASE [TuCancha] SET  READ_WRITE 
GO
