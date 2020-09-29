USE [master]
GO
/****** Object:  Database [TuCancha]    Script Date: 29-09-2020 17:23:44 ******/
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
/****** Object:  Table [dbo].[admin]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[edad] [int] NULL,
	[correo] [varchar](50) NULL,
	[contraseña] [nchar](10) NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cancha]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cancha](
	[cod_cancha] [varchar](50) NOT NULL,
	[nombre_cancha] [varchar](50) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_cancha] PRIMARY KEY CLUSTERED 
(
	[cod_cancha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[rut] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[edad] [int] NULL,
	[contraseña] [nchar](10) NULL,
	[correo] [nchar](10) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[horario]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horario](
	[cod_horario] [varchar](50) NOT NULL,
	[fecha_incial] [datetime] NULL,
	[fecha_final] [datetime] NULL,
 CONSTRAINT [PK_horario] PRIMARY KEY CLUSTERED 
(
	[cod_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recinto]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recinto](
	[cod_recinto] [varchar](50) NOT NULL,
	[nombre_recinto] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_recinto] PRIMARY KEY CLUSTERED 
(
	[cod_recinto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reserva]    Script Date: 29-09-2020 17:23:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reserva](
	[cod_reserva] [int] NOT NULL,
	[cliente] [varchar](50) NULL,
	[cancha] [varchar](50) NULL,
	[horario_for] [varchar](50) NULL,
	[recinto] [varchar](50) NULL,
	[confirmacion] [bit] NULL,
	[comentarios] [varchar](150) NULL,
 CONSTRAINT [PK_reserva] PRIMARY KEY CLUSTERED 
(
	[cod_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_cancha] FOREIGN KEY([cancha])
REFERENCES [dbo].[cancha] ([cod_cancha])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_cancha]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_cliente] FOREIGN KEY([cliente])
REFERENCES [dbo].[cliente] ([rut])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_cliente]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_horario] FOREIGN KEY([horario_for])
REFERENCES [dbo].[horario] ([cod_horario])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_horario]
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD  CONSTRAINT [FK_reserva_recinto] FOREIGN KEY([recinto])
REFERENCES [dbo].[recinto] ([cod_recinto])
GO
ALTER TABLE [dbo].[reserva] CHECK CONSTRAINT [FK_reserva_recinto]
GO
USE [master]
GO
ALTER DATABASE [TuCancha] SET  READ_WRITE 
GO
