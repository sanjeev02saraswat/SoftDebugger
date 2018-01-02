USE [master]
GO
/****** Object:  Database [PackageModule_ERP_SD]    Script Date: 02-01-2018 01:05:27 ******/
CREATE DATABASE [PackageModule_ERP_SD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PackageModule_ERP_SD', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PackageModule_ERP_SD.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PackageModule_ERP_SD_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PackageModule_ERP_SD_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PackageModule_ERP_SD] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PackageModule_ERP_SD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET RECOVERY FULL 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET  MULTI_USER 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PackageModule_ERP_SD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PackageModule_ERP_SD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PackageModule_ERP_SD', N'ON'
GO
USE [PackageModule_ERP_SD]
GO
/****** Object:  Table [dbo].[PackageCriteria]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageCriteria](
	[PackageCode] [varchar](10) NULL,
	[PackageMarket] [varchar](10) NULL,
	[PackageSaleMarket] [varchar](10) NULL,
	[PackageValidityStartDate] [date] NULL,
	[PackageValidityEndDate] [date] NULL,
	[PackageBookingEndDate] [date] NULL,
	[PackageBookingStartDate] [date] NULL,
	[PackageDuration] [varchar](5) NULL,
	[ChildMinAge] [varchar](2) NULL,
	[ChildMaxAge] [varchar](2) NULL,
	[PackageLastPaymentDue] [int] NULL,
	[PackagePaymentCutOffDay] [int] NULL,
	[Discountonfullpayment] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PackageDetails]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageDetails](
	[CompanyID] [varchar](2) NULL,
	[PackageCode] [varchar](10) NOT NULL,
	[PackageName] [varchar](200) NULL,
	[PackageLanguage] [varchar](5) NULL,
	[PackageTitle] [varchar](200) NULL,
	[SupplierRef] [varchar](100) NULL,
	[PackageRemarks] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PackageImages]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageImages](
	[CompanyID] [varchar](2) NULL,
	[PackageCode] [varchar](10) NULL,
	[PackageImageName] [varchar](200) NULL,
	[PackageImageTitle] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PackageList]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageList](
	[CompanyID] [varchar](2) NULL,
	[PackageCode] [varchar](10) NOT NULL,
	[PackageName] [varchar](200) NULL,
	[PackageLanguage] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PackageValidDays]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageValidDays](
	[ValidonMonday] [varchar](5) NULL,
	[ValidonTuesday] [varchar](5) NULL,
	[ValidonWednesday] [varchar](5) NULL,
	[ValidonThursday] [varchar](5) NULL,
	[ValidonFriday] [varchar](5) NULL,
	[ValidonSaturday] [varchar](5) NULL,
	[ValidonSunday] [varchar](5) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PackageCriteria]  WITH CHECK ADD FOREIGN KEY([PackageCode])
REFERENCES [dbo].[PackageDetails] ([PackageCode])
GO
ALTER TABLE [dbo].[PackageImages]  WITH CHECK ADD FOREIGN KEY([PackageCode])
REFERENCES [dbo].[PackageList] ([PackageCode])
GO
/****** Object:  StoredProcedure [dbo].[FSP_GetAutocompleteList]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FSP_GetAutocompleteList]
(
@LanguageCode VARCHAR(5),
@CompanyID VARCHAR(2),
@Query VARCHAR(100)
)
As


BEGIN

Select PackageName , PackageCode from PackageList Where PackageLanguage=@LanguageCode and CompanyID=@CompanyID and PackageName Like '%'+@Query+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[FSP_GetPackageDetails]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[FSP_GetPackageDetails]
(
@CompanyID VARCHAR(2),
@PackageCode varchar(10),
@PackageLanguage varchar(5)
)
As

Begin
IF (SELECT COUNT(*) FROM PackageList WHERE PackageCode = @PackageCode and CompanyID=@CompanyID)>0
BEGIN

SELECT PackageCode,PackageName,PackageLanguage,PackageTitle FROM PackageDetails AS BasicPackageDetails  WHERE PackageCode = @PackageCode and CompanyID=@CompanyID AND PackageLanguage=@PackageLanguage

SELECT PackageMarket,PackageSaleMarket,PackageValidityStartDate,PackageValidityEndDate,PackageBookingEndDate,PackageBookingStartDate,PackageDuration,ChildMinAge,ChildMaxAge,PackageLastPaymentDue,PackagePaymentCutOffDay,DiscountonFullPayment FROM PackageCriteria AS BasicPackageCreteria where PackageCode=@PackageCode 
END

END
GO
/****** Object:  StoredProcedure [dbo].[FSP_InsertPackageDetails]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FSP_InsertPackageDetails]
(
@CompanyID VARCHAR(2),
@PackageCode varchar(10),
@PackageName varchar(200),
@PackageLanguage varchar(5),
@PackageTitle varchar(200),
@PackageMarket varchar(10),
@PackageSaleMarket varchar(10),
@PackageValidityStartDate date,
@PackageValidityEndDate date,
@PackageBookingStartDate date,
@PackageBookingEndDate date,
@PackageDuration varchar(5),
@ChildMinAge varchar(2),
@ChildMaxAge varchar(2),
@PackageLastPaymentDue int,
@PackagePaymentCutOffDay int,
@DiscountonFullPayment varchar(10)

)
As

Begin
IF (SELECT COUNT(*) FROM PackageList WHERE PackageCode = @PackageCode and CompanyID=@CompanyID)=0
BEGIN
INSERT INTO PackageList(PackageCode,PackageName,CompanyID,PackageLanguage) values(@PackageCode,@PackageName,@CompanyID,@PackageLanguage)
Insert INTO PackageDetails(CompanyID,PackageCode,PackageLanguage,PackageName,PackageTitle) Values (@CompanyID,@PackageCode,@PackageLanguage,@PackageName,@PackageTitle)

Insert Into PackageCriteria(PackageCode,PackageMarket,PackageSaleMarket,PackageValidityStartDate,PackageValidityEndDate,PackageBookingEndDate,PackageBookingStartDate,PackageDuration,ChildMinAge,ChildMaxAge,PackageLastPaymentDue,PackagePaymentCutOffDay,Discountonfullpayment) Values(@PackageCode,@PackageMarket,@PackageSaleMarket,@PackageValidityEndDate,@PackageValidityStartDate,@PackageBookingEndDate,@PackageBookingStartDate,@PackageDuration,@ChildMinAge,@ChildMaxAge,@PackageLastPaymentDue,@PackagePaymentCutOffDay,@Discountonfullpayment)
END
ELSE
BEGIN

UPDATE PackageList SET PackageName=@PackageName WHERE PackageCode=@PackageCode AND CompanyID=@CompanyID
UPDATE PackageDetails SET PackageTitle=@PackageTitle WHERE PackageCode=@PackageCode AND CompanyID=@CompanyID

UPDATE PackageCriteria SET PackageMarket=@PackageMarket,PackageSaleMarket=@PackageSaleMarket,PackageValidityStartDate=@PackageValidityStartDate,PackageValidityEndDate=@PackageValidityEndDate,PackageBookingEndDate=@PackageBookingEndDate,PackageBookingStartDate=@PackageBookingStartDate,PackageDuration=@PackageDuration,ChildMinAge=@ChildMinAge,ChildMaxAge=@ChildMaxAge,PackageLastPaymentDue=@PackageLastPaymentDue,PackagePaymentCutOffDay=@PackagePaymentCutOffDay,Discountonfullpayment=@Discountonfullpayment WHERE PackageCode=@PackageCode 

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetPackageCode]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetPackageCode]
As Begin

select Count(*)+1 from PackageList

END

GO
/****** Object:  StoredProcedure [dbo].[GetPackageImages]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetPackageImages]
(
@PackageCode VARCHAR(10),

@CompanyID VARCHAR(2)
)

AS

BEGIN

Select  PackageImageName As Name,PackageImageTitle As TItle from PackageImages Where CompanyID=@CompanyID and PAckageCode=@PackageCode

eND
GO
/****** Object:  StoredProcedure [dbo].[InsertPackageImages]    Script Date: 02-01-2018 01:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertPackageImages]
(
@CompanyID VARCHAR(2),
@PackageCode VARCHAR(5),
@PackageImageName VARCHAR(200),
@PackageImageTitle VARCHAR(200)
)

As

Begin

INSERT INTO PackageImages(CompanyID,PackageCode,PackageImageName,PackageImageTitle) VALUES(@CompanyID,@PackageCode,@PackageImageName,@PackageImageTitle)

END
GO
USE [master]
GO
ALTER DATABASE [PackageModule_ERP_SD] SET  READ_WRITE 
GO
