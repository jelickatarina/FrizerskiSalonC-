USE [KJFS]
GO
ALTER TABLE [dbo].[Termin] DROP CONSTRAINT [FK_Termin_Usluga_UslugaId]
GO
ALTER TABLE [dbo].[Termin] DROP CONSTRAINT [FK_Termin_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Termin] DROP CONSTRAINT [FK_Termin_Korisnik_KorisnikFrizerId]
GO
/****** Object:  Index [TerminUniqueIndex]    Script Date: 23.01.2025 7:51:44 PM ******/
DROP INDEX [TerminUniqueIndex] ON [dbo].[Termin]
GO
/****** Object:  Index [IX_Termin_UslugaId]    Script Date: 23.01.2025 7:51:44 PM ******/
DROP INDEX [IX_Termin_UslugaId] ON [dbo].[Termin]
GO
/****** Object:  Index [IX_Termin_KorisnikId]    Script Date: 23.01.2025 7:51:44 PM ******/
DROP INDEX [IX_Termin_KorisnikId] ON [dbo].[Termin]
GO
/****** Object:  Index [IX_Termin_KorisnikFrizerId]    Script Date: 23.01.2025 7:51:44 PM ******/
DROP INDEX [IX_Termin_KorisnikFrizerId] ON [dbo].[Termin]
GO
/****** Object:  Table [dbo].[Usluga]    Script Date: 23.01.2025 7:51:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usluga]') AND type in (N'U'))
DROP TABLE [dbo].[Usluga]
GO
/****** Object:  Table [dbo].[Termin]    Script Date: 23.01.2025 7:51:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Termin]') AND type in (N'U'))
DROP TABLE [dbo].[Termin]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 23.01.2025 7:51:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Korisnik]') AND type in (N'U'))
DROP TABLE [dbo].[Korisnik]
GO
USE [master]
GO
/****** Object:  Database [KJFS]    Script Date: 23.01.2025 7:51:44 PM ******/
DROP DATABASE [KJFS]
GO
/****** Object:  Database [KJFS]    Script Date: 23.01.2025 7:51:44 PM ******/
CREATE DATABASE [KJFS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KJFZ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KJFZ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KJFZ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KJFZ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KJFS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KJFS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KJFS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KJFS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KJFS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KJFS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KJFS] SET ARITHABORT OFF 
GO
ALTER DATABASE [KJFS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KJFS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KJFS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KJFS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KJFS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KJFS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KJFS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KJFS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KJFS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KJFS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KJFS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KJFS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KJFS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KJFS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KJFS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KJFS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KJFS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KJFS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KJFS] SET  MULTI_USER 
GO
ALTER DATABASE [KJFS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KJFS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KJFS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KJFS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KJFS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KJFS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KJFS] SET QUERY_STORE = ON
GO
ALTER DATABASE [KJFS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KJFS]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 23.01.2025 7:51:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikId] [nvarchar](450) NOT NULL,
	[Lozinka] [nvarchar](max) NOT NULL,
	[Ime] [nvarchar](max) NOT NULL,
	[Prezime] [nvarchar](max) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Telefon] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Nivo] [int] NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[KorisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Termin]    Script Date: 23.01.2025 7:51:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Termin](
	[TerminId] [int] IDENTITY(1,1) NOT NULL,
	[UslugaId] [nvarchar](450) NOT NULL,
	[KorisnikId] [nvarchar](450) NOT NULL,
	[Datum] [date] NOT NULL,
	[Vreme] [int] NOT NULL,
	[Uradjeno] [bit] NOT NULL,
	[KorisnikFrizerId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Termin] PRIMARY KEY CLUSTERED 
(
	[TerminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usluga]    Script Date: 23.01.2025 7:51:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usluga](
	[UslugaId] [nvarchar](450) NOT NULL,
	[Cena] [int] NOT NULL,
	[Trajanje] [int] NOT NULL,
	[Opis] [nvarchar](max) NOT NULL,
	[Aktivna] [bit] NOT NULL,
 CONSTRAINT [PK_Usluga] PRIMARY KEY CLUSTERED 
(
	[UslugaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Korisnik] ([KorisnikId], [Lozinka], [Ime], [Prezime], [DatumRodjenja], [Telefon], [Email], [Nivo]) VALUES (N'Frizer1', N'frizer1', N'Jovana', N'Nikolic', CAST(N'2000-05-20' AS Date), N'065/6501337', N'jovananikolic@gmail.com', 2)
INSERT [dbo].[Korisnik] ([KorisnikId], [Lozinka], [Ime], [Prezime], [DatumRodjenja], [Telefon], [Email], [Nivo]) VALUES (N'Frizer2', N'frizer2', N'Ana', N'Petrović', CAST(N'2002-12-06' AS Date), N'0600214361', N'anapetr@gmail.com', 2)
INSERT [dbo].[Korisnik] ([KorisnikId], [Lozinka], [Ime], [Prezime], [DatumRodjenja], [Telefon], [Email], [Nivo]) VALUES (N'Kaca', N'Kaca', N'Katarina', N'Jelic', CAST(N'2003-06-25' AS Date), N'065/8501187', N'jelickat@gmail.com', 9)
INSERT [dbo].[Korisnik] ([KorisnikId], [Lozinka], [Ime], [Prezime], [DatumRodjenja], [Telefon], [Email], [Nivo]) VALUES (N'Klijent1', N'klijent1', N'Sara', N'Stankovic', CAST(N'2001-02-17' AS Date), N'062/8441157', N'sarastankovic@gmail.com', 1)
INSERT [dbo].[Korisnik] ([KorisnikId], [Lozinka], [Ime], [Prezime], [DatumRodjenja], [Telefon], [Email], [Nivo]) VALUES (N'klijent2', N'klijent2', N'Marina', N'Nedeljković', CAST(N'2000-01-01' AS Date), N'0648790054', N'marinaned@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[Termin] ON 

INSERT [dbo].[Termin] ([TerminId], [UslugaId], [KorisnikId], [Datum], [Vreme], [Uradjeno], [KorisnikFrizerId]) VALUES (1, N'Farbanje', N'klijent1', CAST(N'2025-01-30' AS Date), 18, 0, N'Frizer1')
INSERT [dbo].[Termin] ([TerminId], [UslugaId], [KorisnikId], [Datum], [Vreme], [Uradjeno], [KorisnikFrizerId]) VALUES (2, N'Feniranje', N'klijent2', CAST(N'2025-01-30' AS Date), 20, 0, N'Frizer1')
SET IDENTITY_INSERT [dbo].[Termin] OFF
GO
INSERT [dbo].[Usluga] ([UslugaId], [Cena], [Trajanje], [Opis], [Aktivna]) VALUES (N'Farbanje', 1500, 60, N'Pranje, farbanje i susenje kose', 1)
INSERT [dbo].[Usluga] ([UslugaId], [Cena], [Trajanje], [Opis], [Aktivna]) VALUES (N'Feniranje', 1000, 45, N'Pranje i feniranje kose', 1)
INSERT [dbo].[Usluga] ([UslugaId], [Cena], [Trajanje], [Opis], [Aktivna]) VALUES (N'Pranje kose', 750, 30, N'Pranje i susenje kose', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Termin_KorisnikFrizerId]    Script Date: 23.01.2025 7:51:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Termin_KorisnikFrizerId] ON [dbo].[Termin]
(
	[KorisnikFrizerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Termin_KorisnikId]    Script Date: 23.01.2025 7:51:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Termin_KorisnikId] ON [dbo].[Termin]
(
	[KorisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Termin_UslugaId]    Script Date: 23.01.2025 7:51:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Termin_UslugaId] ON [dbo].[Termin]
(
	[UslugaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [TerminUniqueIndex]    Script Date: 23.01.2025 7:51:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [TerminUniqueIndex] ON [dbo].[Termin]
(
	[Datum] ASC,
	[Vreme] ASC,
	[KorisnikFrizerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Termin]  WITH CHECK ADD  CONSTRAINT [FK_Termin_Korisnik_KorisnikFrizerId] FOREIGN KEY([KorisnikFrizerId])
REFERENCES [dbo].[Korisnik] ([KorisnikId])
GO
ALTER TABLE [dbo].[Termin] CHECK CONSTRAINT [FK_Termin_Korisnik_KorisnikFrizerId]
GO
ALTER TABLE [dbo].[Termin]  WITH CHECK ADD  CONSTRAINT [FK_Termin_Korisnik_KorisnikId] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnik] ([KorisnikId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Termin] CHECK CONSTRAINT [FK_Termin_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Termin]  WITH CHECK ADD  CONSTRAINT [FK_Termin_Usluga_UslugaId] FOREIGN KEY([UslugaId])
REFERENCES [dbo].[Usluga] ([UslugaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Termin] CHECK CONSTRAINT [FK_Termin_Usluga_UslugaId]
GO
USE [master]
GO
ALTER DATABASE [KJFS] SET  READ_WRITE 
GO
