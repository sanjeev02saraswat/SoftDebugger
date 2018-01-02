CREATE DATABASE PkgLocalization

Create TABLE Localization
(
ID int Identity,
CompanyID VARCHAR(3),
ResourceID VARCHAR(200),
PageID INT,
ResourceValue VARCHAR(MAX),
Culture VARCHAR(10)
)


Alter Procedure FSP_InsertResources
(
@CompanyID VARCHAR(3),
@PageID int,
@ResourceID VARCHAR(200),
@ResourceValue VARCHAR(MAX),
@Culture VARCHAR(10)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Localization WHERE ResourceID = @ResourceID and Culture=@Culture and CompanyID=@CompanyID and PageID=@PageID)>0--AND(DATEDIFF(MINUTE,@SESSIONDIFF,GETDATE())>@EXPIREMINUTE
BEGIN
Select 'Record already exists'
END
ELSE
Begin
INSERT INTO Localization(CompanyID,ResourceID,ResourceValue,Culture,PageID) values(@CompanyID,@ResourceID,@ResourceValue,@Culture,@PageID)
END
END




