USE [master]
GO
/****** Object:  Database [MultilingualDictionary]    Script Date: 10/5/2015 4:25:44 PM ******/
CREATE DATABASE [MultilingualDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultilingualDictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultilingualDictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultilingualDictionary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MultilingualDictionary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionary', N'ON'
GO
USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[Dictionaries]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionaries](
	[DictionaryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dictionaries] PRIMARY KEY CLUSTERED 
(
	[DictionaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NULL,
	[LanguageID] [int] NULL,
	[Explanation] [text] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[Synonym] [nvarchar](50) NOT NULL,
	[WordID] [int] NULL,
	[SynonymID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[TranslationID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NULL,
	[WordID] [int] NULL,
	[Traslation] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 10/5/2015 4:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[DictionaryID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Dictionaries] FOREIGN KEY([DictionaryID])
REFERENCES [dbo].[Dictionaries] ([DictionaryID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Dictionaries]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionary] SET  READ_WRITE 
GO
