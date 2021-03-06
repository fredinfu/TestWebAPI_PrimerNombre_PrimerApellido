USE [master]
GO
/****** Object:  Database [TestWebAPI_PrimerNombre_PrimerApellido]    Script Date: 11/4/2021 12:36:11 PM ******/
CREATE DATABASE [TestWebAPI_PrimerNombre_PrimerApellido]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestWebAPI_PrimerNombre_PrimerApellido', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\TestWebAPI_PrimerNombre_PrimerApellido.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestWebAPI_PrimerNombre_PrimerApellido_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\TestWebAPI_PrimerNombre_PrimerApellido_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestWebAPI_PrimerNombre_PrimerApellido].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET  MULTI_USER 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET QUERY_STORE = OFF
GO
USE [TestWebAPI_PrimerNombre_PrimerApellido]
GO
/****** Object:  Table [dbo].[Dosis]    Script Date: 11/4/2021 12:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosis](
	[DosisVacunaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Dosis] PRIMARY KEY CLUSTERED 
(
	[DosisVacunaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 11/4/2021 12:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteId] [int] IDENTITY(1,1) NOT NULL,
	[Expediente] [nvarchar](20) NULL,
	[Nombres] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[Sexo] [char](1) NULL,
	[Fecha Nacimiento] [date] NULL,
	[Edad] [int] NULL,
	[TipoEdad] [nvarchar](10) NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacunacion_Covid19]    Script Date: 11/4/2021 12:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacunacion_Covid19](
	[VacunacionId] [int] IDENTITY(1,1) NOT NULL,
	[FK_PacienteId] [int] NULL,
	[FK_VacunaId] [int] NULL,
	[FK_DosisId] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaUltimaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Vacunacion_Covid19] PRIMARY KEY CLUSTERED 
(
	[VacunacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacunas]    Script Date: 11/4/2021 12:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacunas](
	[VacunaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Vacunas] PRIMARY KEY CLUSTERED 
(
	[VacunaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dosis] ON 

INSERT [dbo].[Dosis] ([DosisVacunaId], [Descripcion], [Estado]) VALUES (1, N'1era Dosis', 1)
INSERT [dbo].[Dosis] ([DosisVacunaId], [Descripcion], [Estado]) VALUES (2, N'2da Dosis', 1)
INSERT [dbo].[Dosis] ([DosisVacunaId], [Descripcion], [Estado]) VALUES (3, N'4ta dosis', 0)
SET IDENTITY_INSERT [dbo].[Dosis] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 

INSERT [dbo].[Pacientes] ([PacienteId], [Expediente], [Nombres], [Apellidos], [Sexo], [Fecha Nacimiento], [Edad], [TipoEdad]) VALUES (1, N'0801199012345', N'Yadier Benjamín ', N'Molina Luciano', N'M', CAST(N'1982-07-13' AS Date), 39, N'AÑOS')
INSERT [dbo].[Pacientes] ([PacienteId], [Expediente], [Nombres], [Apellidos], [Sexo], [Fecha Nacimiento], [Edad], [TipoEdad]) VALUES (2, N'0801199010718', N'Fredin', N'Funez Carcamo', N'M', CAST(N'1990-11-04' AS Date), 31, N'AÑOS')
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Vacunacion_Covid19] ON 

INSERT [dbo].[Vacunacion_Covid19] ([VacunacionId], [FK_PacienteId], [FK_VacunaId], [FK_DosisId], [FechaCreacion], [FechaUltimaModificacion]) VALUES (1, 1, 1, 1, CAST(N'2021-11-04T08:59:13.273' AS DateTime), NULL)
INSERT [dbo].[Vacunacion_Covid19] ([VacunacionId], [FK_PacienteId], [FK_VacunaId], [FK_DosisId], [FechaCreacion], [FechaUltimaModificacion]) VALUES (2, 1, 1, 2, CAST(N'2021-11-04T08:59:27.930' AS DateTime), NULL)
INSERT [dbo].[Vacunacion_Covid19] ([VacunacionId], [FK_PacienteId], [FK_VacunaId], [FK_DosisId], [FechaCreacion], [FechaUltimaModificacion]) VALUES (3, 1, 1, 1, CAST(N'2021-11-04T08:59:54.520' AS DateTime), CAST(N'2021-11-04T08:59:27.930' AS DateTime))
INSERT [dbo].[Vacunacion_Covid19] ([VacunacionId], [FK_PacienteId], [FK_VacunaId], [FK_DosisId], [FechaCreacion], [FechaUltimaModificacion]) VALUES (4, 1, 1, 2, CAST(N'2021-11-04T12:30:20.550' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Vacunacion_Covid19] OFF
GO
SET IDENTITY_INSERT [dbo].[Vacunas] ON 

INSERT [dbo].[Vacunas] ([VacunaId], [Descripcion], [Estado]) VALUES (1, N'AstraZeneca', 1)
INSERT [dbo].[Vacunas] ([VacunaId], [Descripcion], [Estado]) VALUES (2, N'Sputnik V', 1)
INSERT [dbo].[Vacunas] ([VacunaId], [Descripcion], [Estado]) VALUES (3, N'Moderna', 1)
INSERT [dbo].[Vacunas] ([VacunaId], [Descripcion], [Estado]) VALUES (4, N'Pfizer', 1)
INSERT [dbo].[Vacunas] ([VacunaId], [Descripcion], [Estado]) VALUES (5, N'Vegito', 0)
SET IDENTITY_INSERT [dbo].[Vacunas] OFF
GO
ALTER TABLE [dbo].[Dosis] ADD  CONSTRAINT [DF_Dosis_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Vacunacion_Covid19] ADD  CONSTRAINT [DF_Vacunacion_Covid19_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Vacunas] ADD  CONSTRAINT [DF_Vacunas_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Vacunacion_Covid19]  WITH CHECK ADD  CONSTRAINT [FKDosis] FOREIGN KEY([FK_DosisId])
REFERENCES [dbo].[Dosis] ([DosisVacunaId])
GO
ALTER TABLE [dbo].[Vacunacion_Covid19] CHECK CONSTRAINT [FKDosis]
GO
ALTER TABLE [dbo].[Vacunacion_Covid19]  WITH CHECK ADD  CONSTRAINT [FKPaciente] FOREIGN KEY([FK_PacienteId])
REFERENCES [dbo].[Pacientes] ([PacienteId])
GO
ALTER TABLE [dbo].[Vacunacion_Covid19] CHECK CONSTRAINT [FKPaciente]
GO
ALTER TABLE [dbo].[Vacunacion_Covid19]  WITH CHECK ADD  CONSTRAINT [FKVacuna] FOREIGN KEY([FK_VacunaId])
REFERENCES [dbo].[Vacunas] ([VacunaId])
GO
ALTER TABLE [dbo].[Vacunacion_Covid19] CHECK CONSTRAINT [FKVacuna]
GO
USE [master]
GO
ALTER DATABASE [TestWebAPI_PrimerNombre_PrimerApellido] SET  READ_WRITE 
GO
