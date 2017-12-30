Create Database CompanyAdmin_ERP_SD

DROP TABLE PackageModule_ERP_SD..Agent_Master 

CREATE TABLE [dbo].[Agent_Master](
	[AgentID] [int] Primary KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[ISAdmin] [bit] NULL,
	[ISActive] [bit] NULL,
	[Password] [varchar](200) NULL,
	 CompanyID varchar(10) ,
	 Tokenid varchar(100) ,
	[TIMESTAMP] [VARCHAR](100) NULL
) ON [PRIMARY]
GO


CREATE TABLE AgentAccess
(
AgentID int Foreign KEY References Agent_Master(AgentID),
VisitCount int,
DefaultURL VARCHAR(200)
)

ALTER TABLE AgentAccess Add SideBarMenu bit default(1)

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
