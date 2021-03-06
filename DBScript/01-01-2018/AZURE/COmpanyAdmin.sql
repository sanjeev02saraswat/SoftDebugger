USE [master]
GO
/****** Object:  Database [CompanyAdmin_ERP_SD]    Script Date: 16-02-2018 23:42:06 ******/
CREATE DATABASE [CompanyAdmin_ERP_SD]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyAdmin_ERP_SD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET RECOVERY FULL 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET DB_CHAINING OFF 
GO
USE [CompanyAdmin_ERP_SD]
GO
/****** Object:  Table [dbo].[Agent_BasicProfile]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agent_BasicProfile](
	[AgentID] [int] NULL,
	[CompanyID] [varchar](2) NULL,
	[Language] [varchar](5) NULL,
	[DefaultPage] [varchar](200) NULL,
	[Address] [varchar](200) NULL,
	[ProfileImageLink] [varchar](200) NULL,
	[Country] [varchar](2) NULL,
	[Phone] [varchar](12) NULL,
	[IsPhonePrivate] [bit] NULL,
	[IsAddressPrivate] [bit] NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Agent_Master]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agent_Master](
	[AgentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[ISAdmin] [bit] NULL,
	[ISActive] [bit] NULL,
	[Password] [varchar](200) NULL,
	[TIMESTAMP] [varchar](100) NULL,
	[CompanyID] [varchar](10) NULL,
	[Tokenid] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AgentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AgentAccess]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AgentAccess](
	[AgentID] [int] NULL,
	[VisitCount] [int] NULL,
	[DefaultURL] [varchar](200) NULL,
	[SideBarMenu] [bit] NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicAtionMaster]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ApplicAtionMaster](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [varchar](100) NULL,
	[CompanyID] [varchar](3) NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyDetails]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyDetails](
	[CompanyID] [varchar](3) NULL,
	[CompanyName] [varchar](500) NULL,
	[CompanyAddress] [varchar](500) NULL,
	[Country] [varchar](2) NULL,
	[CurrencyCode] [varchar](3) NULL,
	[DefaultLanguage] [varchar](5) NULL,
	[CompanyEmail] [varchar](50) NULL,
	[Phone] [varchar](15) NULL,
	[FAX] [varchar](50) NULL,
	[CompanyPostalCode] [varchar](10) NULL,
	[CompanyPANNumber] [varchar](20) NULL,
	[CompanyTANNumber] [varchar](20) NULL,
	[CompanyWebsite] [varchar](50) NULL,
	[CompanyLogoURL] [varchar](100) NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PageMaster]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageMaster](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NULL,
	[PageName] [varchar](300) NULL,
	[CompanyID] [varchar](3) NULL
)

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AgentAccess] ADD  DEFAULT ((1)) FOR [SideBarMenu]
GO
ALTER TABLE [dbo].[Agent_BasicProfile]  WITH CHECK ADD FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent_Master] ([AgentID])
GO
ALTER TABLE [dbo].[AgentAccess]  WITH CHECK ADD FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent_Master] ([AgentID])
GO
/****** Object:  StoredProcedure [dbo].[FSP_Agentlogin]    Script Date: 16-02-2018 23:42:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FSP_Agentlogin]
(
@CompnayID VARCHAR(10),
@Email VARCHAR(50),
@Password VARCHAR(50),
@TokenID VARCHAR(100),
@TimeStamp Varchar(50)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Agent_Master WHERE Email = @Email and Password COLLATE Latin1_General_CS_AI=@Password and CompanyID=@CompnayID)>0  
  BEGIN
  
		Update Agent_Master set Tokenid=@TokenID,Timestamp=@TimeStamp where Email = @Email and Password COLLATE Latin1_General_CS_AI=@Password
  
  SELECT 'True' as Status
  
  END
  ELSE  
BEGIN  
Select 'False' as Status
END  

END

GO
/****** Object:  StoredProcedure [dbo].[FSP_GetAgentProfileDetails]    Script Date: 16-02-2018 23:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FSP_GetAgentProfileDetails]
(
@CompanyID VARCHAR(2),
@TokenID VARCHAR(100)
)
AS

BEGIN

IF (SELECT COUNT(*) FROM Agent_Master WHERE Tokenid=@TokenID and CompanyID=@CompanyID)>0  

BEGIN
DECLARE @AgentID AS INT
SET @AgentID=(Select AgentID from Agent_Master WHERE Tokenid=@TokenID and CompanyID=@CompanyID)

SELECT  AM.AgentID,FirstName ,LastName,Email,ABP.Phone,ABP.Language,ABP.DefaultPage,ABP.Address,ABP.Country FROM Agent_Master AM Inner JOIN Agent_BasicProfile ABP ON AM.AgentID=@AgentID AND AM.CompanyID=@CompanyID
END
END

GO
/****** Object:  StoredProcedure [dbo].[FSP_GetApplications]    Script Date: 16-02-2018 23:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FSP_GetApplications]
(
@CompanyID VARCHAR(3)
)
AS

BEGIN
SELECT ApplicationID,ApplicationName from ApplicAtionMaster WHERE CompanyID=@CompanyID

END

GO
/****** Object:  StoredProcedure [dbo].[FSP_GetCompanyDetails]    Script Date: 16-02-2018 23:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FSP_GetCompanyDetails]
(
@CompanyID VARCHAR(3),
@TokenID VARCHAR(50)
)
AS
BEGIN
Select CD.*,''+AM.FirstName+' '+AM.LastName+'' AS AgentName from CompanyDetails CD Inner JOIN Agent_Master AM ON CD.CompanyID=@CompanyID AND AM.Tokenid=@TokenID
END

GO
/****** Object:  StoredProcedure [dbo].[FSP_GetPageList]    Script Date: 16-02-2018 23:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[FSP_GetPageList]

(
@CompanyID VARCHAR(2),
@ApplicationID INT
)

AS

BEGIN
SELECT PageID,PageName from PageMaster WHERE CompanyID=@CompanyID and ApplicationID=@ApplicationID

END

GO
/****** Object:  StoredProcedure [dbo].[FSP_SignUpAgentUser]    Script Date: 16-02-2018 23:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[FSP_SignUpAgentUser]
(
@FirstName Varchar(100),
@LastName Varchar(100),
@Email Varchar(200),
@Password Varchar(50),
@CultureCode Varchar(10)='en-US',
@CompanyID VARCHAR(2)
)
AS
BEGIN
Insert into Agent_Master(FirstName,LastName,Email,Password,CompanyID) values(@FirstName,@LastName,@Email,@Password,@CompanyID)
END

GO
/****** Object:  StoredProcedure [dbo].[FSP_UpdateAgentProfile]    Script Date: 16-02-2018 23:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FSP_UpdateAgentProfile]
(
@TokenID VARCHAR(100),
@CompanyID VARCHAR(2),
@FirstName Varchar(100),
@LastName Varchar(100),
@Language Varchar(5),
@Country Varchar(2),
@Address varchar(200),
@Phone Varchar(12),
@Email Varchar(100),
@DefaultPage Varchar(200)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Agent_Master WHERE Tokenid=@TokenID and CompanyID=@CompanyID)>0  

BEGIN
DECLARE @AgentID AS INT
SET @AgentID=(Select AgentID from Agent_Master WHERE Tokenid=@TokenID and CompanyID=@CompanyID)
Update Agent_Master Set FirstName=@FirstName,LastName=@LastName,Email=@Email Where AgentID=@AgentID and CompanyID=@CompanyID

Update Agent_BasicProfile Set Language=@Language,Country=@Country,Address=@Address,Phone=@Phone,DefaultPage=@DefaultPage Where AgentID=@AgentID and CompanyID=@CompanyID

END
END

GO
/****** Object:  StoredProcedure [dbo].[FSP_UpdateCompanyDetails]    Script Date: 16-02-2018 23:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FSP_UpdateCompanyDetails]
(

@CompanyID VARCHAR(3),
@CompanyName VARCHAR(500),
@CompanyAddress VARCHAR(500),
@Country VARCHAR(2),
@CurrencyCode VARCHAR(3),
@DefaultLanguage VARCHAR(5),
@CompanyEmail VARCHAR(50),
@Phone VARCHAR(15),
@FAX VARCHAR(50)=Null,
@CompanyPostalCode VARCHAR(10),
@CompanyPANNumber VARCHAR(20)=NULL,
@CompanyTANNumber VARCHAR(20)=NULL,
@CompanyWebsite VARCHAR(50)=NULL,
@CompanyLogoURL VARCHAR(100)=null

)

AS

BEGIN
IF (SELECT COUNT(*) FROM CompanyDetails WHERE  CompanyID=@CompanyID)=0

BEGIN
INSERT INTO CompanyDetails(CompanyID,CompanyName,CompanyAddress,Country,CurrencyCode,DefaultLanguage,CompanyEmail,Phone,FAX,CompanyPostalCode,CompanyPANNumber,CompanyTANNumber,CompanyWebsite,CompanyLogoURL) values(@CompanyID,@CompanyName,@CompanyAddress,@Country,@CurrencyCode,@DefaultLanguage,@CompanyEmail,@Phone,@FAX,@CompanyPostalCode,@CompanyPANNumber,@CompanyTANNumber,@CompanyWebsite,@CompanyLogoURL)

END

ELSE

BEGIN
Update CompanyDetails SET CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,Country=@Country,DefaultLanguage=@DefaultLanguage,CompanyEmail=@CompanyEmail,Phone=@Phone,FAX=@FAX,CompanyPostalCode=@CompanyPostalCode,CompanyPANNumber=@CompanyPANNumber,CompanyTANNumber=@CompanyTANNumber,CompanyWebsite=@CompanyWebsite,CompanyLogoURL=@CompanyLogoURL WHERE CompanyID=@CompanyID

END

END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_TIMESTAMP]    Script Date: 16-02-2018 23:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPDATE_TIMESTAMP]
(
@CompanyID VARCHAR(10),
@TokenID VARCHAR(100),
@TimeStamp Varchar(50)
)

AS

BEGIN

UPDATE Agent_Master SET TIMESTAMP=@TimeStamp WHERE CompanyID=@CompanyID and Tokenid=@TokenID
END



GO
/****** Object:  StoredProcedure [dbo].[ValidateToken]    Script Date: 16-02-2018 23:42:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[ValidateToken]
(
@CompanyID varchar(2),
@TokenID varchar(100),
@ExpireMinute  int
)
as

BEGIN
--Declare @SESSIONDIFF AS INT;
--SET @SESSIONDIFF=SELECT Email FROM Agent_Master WHERE Tokenid = @TokenID;
IF (SELECT COUNT(*) FROM Agent_Master WHERE Tokenid = @TokenID and CompanyID=@CompanyID)>0--AND(DATEDIFF(MINUTE,@SESSIONDIFF,GETDATE())>@EXPIREMINUTE
BEGIN
Select * from Agent_Master Where Tokenid = @TokenID
END

END

GO
USE [master]
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET  READ_WRITE 
GO
