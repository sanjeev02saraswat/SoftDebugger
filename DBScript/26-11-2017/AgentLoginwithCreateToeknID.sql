CREATE PROCEDURE FSP_Agentlogin
(
@CompnayID VARCHAR(10),
@Email VARCHAR(50),
@Password VARCHAR(50),
@TokenID VARCHAR(100)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Agent_Master WHERE Email = @Email and Password=@Password and CompanyID=@CompnayID)>0  
  BEGIN
  
		Update Agent_Master set Tokenid=@TokenID where Email = @Email and Password=@Password
  
  SELECT 1 as Status
  
  END
  ELSE  
BEGIN  
Select 0 as Status
END  

END