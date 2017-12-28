CREATE PROCEDURE UPDATE_TIMESTAMP
(
@CompnayID VARCHAR(10),
@TokenID VARCHAR(100),
@TimeStamp Varchar(50)
)

AS

BEGIN

UPDATE Agent_Master SET TIMESTAMP=@TimeStamp WHERE CompanyID=@CompnayID and Tokenid=@TokenID
END

