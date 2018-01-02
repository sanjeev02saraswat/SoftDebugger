USE [master]
GO
/****** Object:  Database [SoftdebuggerWebsite]    Script Date: 02-01-2018 01:00:44 ******/
CREATE DATABASE [SoftdebuggerWebsite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoftdebuggerWebsite', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SoftdebuggerWebsite.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SoftdebuggerWebsite_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SoftdebuggerWebsite_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SoftdebuggerWebsite] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoftdebuggerWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET RECOVERY FULL 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoftdebuggerWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SoftdebuggerWebsite] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SoftdebuggerWebsite', N'ON'
GO
USE [SoftdebuggerWebsite]
GO
/****** Object:  Table [dbo].[CompanyCulture]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyCulture](
	[CultureID] [int] IDENTITY(1,1) NOT NULL,
	[CultureName] [varchar](100) NULL,
	[CultureCode] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CUSTOMERENQUIRY]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CUSTOMERENQUIRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QUERYTYPE] [varchar](20) NULL,
	[NAME] [varchar](100) NULL,
	[EMAIL] [varchar](100) NULL,
	[MOBILE] [varchar](20) NULL,
	[ENQUIRY] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localizations]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localizations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceKeyName] [varchar](100) NULL,
	[ResourceKeyValue] [nvarchar](max) NULL,
	[Culture] [varchar](10) NULL,
	[ResourceFileName] [varchar](50) NULL,
	[Timestamp] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocalizationsHistory]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocalizationsHistory](
	[Email] [varchar](100) NULL,
	[UpdatedTextTime] [datetime] NULL,
	[Previouscontent] [nvarchar](max) NULL,
	[Recentcontent] [nvarchar](max) NULL,
	[PageFileName] [varchar](100) NULL,
	[Culture] [varchar](10) NULL,
	[SystemIPAddress] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocalizationUser]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocalizationUser](
	[Email] [varchar](100) NULL,
	[ProfileName] [varchar](100) NULL,
	[Password] [varchar](50) NULL,
	[HasAccess] [bit] NULL,
	[Cultureaccess] [varchar](10) NULL,
	[LastLoginDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MAIL_TEMPLATE]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MAIL_TEMPLATE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAILTYPE] [varchar](50) NULL,
	[MAILSUBJECT] [varchar](max) NULL,
	[MAILBODY] [varchar](max) NULL,
	[LOGOURL] [varchar](100) NULL,
	[APPLICATIONNAME] [varchar](100) NULL,
	[From_address] [varchar](50) NULL,
	[CC_Address] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SMTP_DETAILS]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMTP_DETAILS](
	[mail_id] [int] IDENTITY(1,1) NOT NULL,
	[smtp_server] [varchar](100) NOT NULL,
	[smtp_user] [varchar](100) NOT NULL,
	[smtp_password] [varchar](100) NOT NULL,
	[SSL_TLS] [bit] NULL DEFAULT ((0)),
	[smtp_port] [int] NULL,
	[isActive] [bit] NULL DEFAULT ((0)),
	[application_name] [varchar](150) NULL,
	[mail_from] [varchar](100) NULL,
	[DisplayName] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[FSP_INSERTCONTACTDETAILS]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[FSP_INSERTCONTACTDETAILS]
(
@QUERYTYPE varchar(20)='contact',
@NAME varchar(50),
@EMAIL varchar(50),
@MOBILE varchar(13),
@ENQUIRY varchar(200)
)
AS BEGIN

INSERT INTO CUSTOMERENQUIRY(NAME,EMAIL,MOBILE,ENQUIRY,QUERYTYPE) VALUES(@NAME,@EMAIL,@MOBILE,@ENQUIRY,@QUERYTYPE)

END

GO
/****** Object:  StoredProcedure [dbo].[Get_MailValue]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Get_MailValue]
(
@MAILTYPE varchar(50)
)
AS BEGIN

select MAILBODY,MAILSUBJECT from MAIL_TEMPLATE where MAILTYPE=@MAILTYPE

END

GO
/****** Object:  StoredProcedure [dbo].[GET_SMTPDETAILS]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GET_SMTPDETAILS]
(
@Application_Name varchar(150),
@Mail_Type varchar(200)='',
@QUERYTYPE INT=1
)

AS BEGIN
IF @QUERYTYPE=1
BEGIN
SELECT * FROM smtp_details WHERE application_name=@Application_Name and isactive='True'
END
IF @QUERYTYPE=2
BEGIN
SELECT * FROM smtp_details WHERE application_name=@Application_Name and isactive='True'
END
END

GO
/****** Object:  StoredProcedure [dbo].[GetMailTeplate]    Script Date: 02-01-2018 01:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetMailTeplate]
(
@ApplicationName Varchar(100),

@MailType Varchar(50)
)
As 
Begin
SELECT TOP 1 * from MAIL_TEMPLATE where APPLICATIONNAME=@ApplicationName and MAILTYPE=@MailType

End

GO
USE [master]
GO
ALTER DATABASE [SoftdebuggerWebsite] SET  READ_WRITE 
GO
