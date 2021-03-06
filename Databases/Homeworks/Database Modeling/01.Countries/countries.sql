USE [master]
GO
/****** Object:  Database [Homework]    Script Date: 10/5/2015 12:42:55 AM ******/
CREATE DATABASE [Homework]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Homework_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Homework_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Homework] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework] SET  MULTI_USER 
GO
ALTER DATABASE [Homework] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Homework] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework', N'ON'
GO
USE [Homework]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 10/5/2015 12:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](100) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 10/5/2015 12:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/5/2015 12:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 10/5/2015 12:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10/5/2015 12:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (6, N'Address1', 4)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (8, N'Address2', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (9, N'Address3', 5)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe ')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (3, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (4, N'Australia ')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'France', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'Cambodia', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'Australia ', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'India', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (9, N'Egypt', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (11, N'Bulgaria', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Jone', N'Doe', 6)
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Jane', N'Doe', 9)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (1, N'Paris', 3)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (3, N'Gladstone', 5)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (4, N'Sofia', 11)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (5, N'Sozopol', 11)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [Homework] SET  READ_WRITE 
GO
