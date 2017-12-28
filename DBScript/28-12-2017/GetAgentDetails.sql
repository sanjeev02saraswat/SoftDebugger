Alter Procedure GetAgentDetails
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