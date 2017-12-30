ALTER PROCEDURE UPDATE_TIMESTAMP
(
@CompanyID VARCHAR(10),
@TokenID VARCHAR(100),
@TimeStamp Varchar(50)
)

AS

BEGIN

UPDATE Agent_Master SET TIMESTAMP=@TimeStamp WHERE CompanyID=@CompanyID and Tokenid=@TokenID
END

