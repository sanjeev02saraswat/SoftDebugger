USE [master]
GO
/****** Object:  Database [PkgLocalization]    Script Date: 02-01-2018 20:22:35 ******/
CREATE DATABASE [PkgLocalization]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PkgLocalization', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PkgLocalization.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PkgLocalization_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PkgLocalization_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PkgLocalization] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PkgLocalization].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PkgLocalization] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PkgLocalization] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PkgLocalization] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PkgLocalization] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PkgLocalization] SET ARITHABORT OFF 
GO
ALTER DATABASE [PkgLocalization] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PkgLocalization] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PkgLocalization] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PkgLocalization] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PkgLocalization] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PkgLocalization] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PkgLocalization] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PkgLocalization] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PkgLocalization] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PkgLocalization] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PkgLocalization] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PkgLocalization] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PkgLocalization] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PkgLocalization] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PkgLocalization] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PkgLocalization] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PkgLocalization] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PkgLocalization] SET RECOVERY FULL 
GO
ALTER DATABASE [PkgLocalization] SET  MULTI_USER 
GO
ALTER DATABASE [PkgLocalization] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PkgLocalization] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PkgLocalization] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PkgLocalization] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PkgLocalization] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PkgLocalization', N'ON'
GO
USE [PkgLocalization]
GO
/****** Object:  Table [dbo].[Localization]    Script Date: 02-01-2018 20:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [varchar](3) NULL,
	[ResourceID] [varchar](200) NULL,
	[PageID] [int] NULL,
	[ResourceValue] [varchar](max) NULL,
	[Culture] [varchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Localization] ON 

INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (1, N'SD', N'errorSelectApplication', 1, N'Please Select Application Name First.', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (2, N'SD', N'AddLocalizationKey', 1, N'Add Localization', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (3, N'SD', N'AddLocalizationForAvailableResources', 1, N'Add localization for available resources', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (4, N'SD', N'SelectApplicationKey', 1, N'Select Application', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (5, N'SD', N'ApplicationNameKey', 1, N'Application Name', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (6, N'SD', N'SelectResourcePageKey', 1, N'Select Resource Page', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (7, N'SD', N'ResourcePageKey', 1, N'Resource Page', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (8, N'SD', N'NextStepKey', 1, N'Next Step', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (9, N'SD', N'SelectCultureLanguageKey', 1, N'Select Culture Language', N'en-US')
INSERT [dbo].[Localization] ([ID], [CompanyID], [ResourceID], [PageID], [ResourceValue], [Culture]) VALUES (10, N'SD', N'LanguageKey', 1, N'Language', N'en-US')
SET IDENTITY_INSERT [dbo].[Localization] OFF
/****** Object:  StoredProcedure [dbo].[FSP_GetPageResources]    Script Date: 02-01-2018 20:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FSP_GetPageResources]
(
@CompanyID varchar(2),
@ApplicationName varchar(100),
@PageName varchar(100),
@Culture varchar(5)
)

AS
BEGIN
DECLARE @PageID as int
DECLARE @ApplicationID AS INT
SET @ApplicationID=(Select ApplicationID from CompanyAdmin_ERP_SD..ApplicAtionMaster WHERE ApplicationName=@ApplicationName)
SET @PageID=(Select PageID from CompanyAdmin_ERP_SD..PageMaster WHERE PageName=@PageName AND ApplicationID=@ApplicationID)
select ResourceID,ResourceValue FROM Localization WHERE PageID=@PageID AND CompanyID=@CompanyID AND Culture=@Culture

END
GO
/****** Object:  StoredProcedure [dbo].[FSP_GETResources]    Script Date: 02-01-2018 20:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[FSP_GETResources]
(
@CompanyID VARCHAR(3),
@PageID int,
@Culture VARCHAR(10)
)

AS

BEGIN

SELECT ResourceID,ResourceValue from Localization where CompanyID=@CompanyID and PageID=@PageID and Culture=@Culture
END
GO
/****** Object:  StoredProcedure [dbo].[FSP_InsertResources]    Script Date: 02-01-2018 20:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FSP_InsertResources]
(
@CompanyID VARCHAR(3),
@PageID int,
@ResourceID VARCHAR(200),
@ResourceValue VARCHAR(MAX),
@Culture VARCHAR(10)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Localization WHERE ResourceID = @ResourceID and Culture=@Culture and CompanyID=@CompanyID and PageID=@PageID)>0--AND(DATEDIFF(MINUTE,@SESSIONDIFF,GETDATE())>@EXPIREMINUTE
BEGIN
Select 'Record already exists'
END
ELSE
Begin
INSERT INTO Localization(CompanyID,ResourceID,ResourceValue,Culture,PageID) values(@CompanyID,@ResourceID,@ResourceValue,@Culture,@PageID)
END
END




GO
USE [master]
GO
ALTER DATABASE [PkgLocalization] SET  READ_WRITE 
GO
