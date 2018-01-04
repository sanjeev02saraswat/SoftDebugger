USE [master]
GO
/****** Object:  Database [CompanyAdmin_ERP_SD]    Script Date: 04-01-2018 14:58:05 ******/
CREATE DATABASE [CompanyAdmin_ERP_SD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyAdmin_ERP_SD', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CompanyAdmin_ERP_SD.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CompanyAdmin_ERP_SD_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CompanyAdmin_ERP_SD_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET COMPATIBILITY_LEVEL = 120
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
ALTER DATABASE [CompanyAdmin_ERP_SD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET READ_COMMITTED_SNAPSHOT OFF 
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
ALTER DATABASE [CompanyAdmin_ERP_SD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CompanyAdmin_ERP_SD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CompanyAdmin_ERP_SD', N'ON'
GO
USE [CompanyAdmin_ERP_SD]
GO
/****** Object:  Table [dbo].[Agent_Master]    Script Date: 04-01-2018 14:58:05 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AgentAccess]    Script Date: 04-01-2018 14:58:05 ******/
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
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicAtionMaster]    Script Date: 04-01-2018 14:58:05 ******/
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
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PageMaster]    Script Date: 04-01-2018 14:58:05 ******/
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
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Agent_Master] ON 

INSERT [dbo].[Agent_Master] ([AgentID], [FirstName], [LastName], [Email], [ISAdmin], [ISActive], [Password], [TIMESTAMP], [CompanyID], [Tokenid]) VALUES (1, N'Sanjeev', N'Saraswat', N'Sanjeev02Saraswat@Yandex.com', NULL, 1, N'krishnaa', N'Jan  4 2018  2:47PM', N'sd', N'4202f71f-7edf-4854-9d21-39fa2133bbaa')
SET IDENTITY_INSERT [dbo].[Agent_Master] OFF
SET IDENTITY_INSERT [dbo].[ApplicAtionMaster] ON 

INSERT [dbo].[ApplicAtionMaster] ([ApplicationID], [ApplicationName], [CompanyID]) VALUES (1, N'PackageModule', N'SD')
INSERT [dbo].[ApplicAtionMaster] ([ApplicationID], [ApplicationName], [CompanyID]) VALUES (2, N'SoftDebugger', N'SD')
INSERT [dbo].[ApplicAtionMaster] ([ApplicationID], [ApplicationName], [CompanyID]) VALUES (3, N'Listener', N'SD')
SET IDENTITY_INSERT [dbo].[ApplicAtionMaster] OFF
SET IDENTITY_INSERT [dbo].[PageMaster] ON 

INSERT [dbo].[PageMaster] ([PageID], [ApplicationID], [PageName], [CompanyID]) VALUES (1, 1, N'AddLocalization', N'SD')
SET IDENTITY_INSERT [dbo].[PageMaster] OFF
ALTER TABLE [dbo].[AgentAccess] ADD  DEFAULT ((1)) FOR [SideBarMenu]
GO
ALTER TABLE [dbo].[AgentAccess]  WITH CHECK ADD FOREIGN KEY([AgentID])
REFERENCES [dbo].[Agent_Master] ([AgentID])
GO
/****** Object:  StoredProcedure [dbo].[FSP_Agentlogin]    Script Date: 04-01-2018 14:58:05 ******/
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
IF (SELECT COUNT(*) FROM Agent_Master WHERE Email = @Email and Password=@Password and CompanyID=@CompnayID)>0  
  BEGIN
  
		Update Agent_Master set Tokenid=@TokenID,Timestamp=@TimeStamp where Email = @Email and Password=@Password
  
  SELECT 'True' as Status
  
  END
  ELSE  
BEGIN  
Select 'False' as Status
END  

END
GO
/****** Object:  StoredProcedure [dbo].[FSP_GetApplications]    Script Date: 04-01-2018 14:58:05 ******/
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
/****** Object:  StoredProcedure [dbo].[FSP_GetPageList]    Script Date: 04-01-2018 14:58:05 ******/
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
/****** Object:  StoredProcedure [dbo].[FSP_SignUpAgentUser]    Script Date: 04-01-2018 14:58:05 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAgentDetails]    Script Date: 04-01-2018 14:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetAgentDetails]
(
@CompnayID VARCHAR(2),
@Email VARCHAR(100),
@Password VARCHAR(100),
@TokenID VARCHAR(50),
@TimeStamp Varchar(50)
)
As

Begin

Select FirstName +' ' +LastName From Agent_master Where CompanyID=@CompnayID and TokenID=@TokenID and Email=@Email and Password=@Password

END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_TIMESTAMP]    Script Date: 04-01-2018 14:58:05 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidateToken]    Script Date: 04-01-2018 14:58:05 ******/
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
