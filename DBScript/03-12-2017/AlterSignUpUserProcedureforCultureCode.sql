USE [PackageModule_ERP_SD]
GO
/****** Object:  StoredProcedure [dbo].[FSP_SignUpAgentUser]    Script Date: 12/03/2017 00:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[FSP_SignUpAgentUser]
(
@FirstName Varchar(100),
@LastName Varchar(100),
@Email Varchar(200),
@Password Varchar(50),
@CultureCode Varchar(10)='en-US'
)
AS
BEGIN
Insert into Agent_Master(FirstName,LastName,Email,Password) values(@FirstName,@LastName,@Email,@Password)
END