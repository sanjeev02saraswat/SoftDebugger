USE PkgLocalization
CREATE PROCEDURE FSP_GetPageResources
(
@CompanyID varchar(2),
@ApplicationName varchar(100),
@PageName varchar(100),
@Culture varchar(5)
)

AS
BEGIN
DECLARE @PageID as int
SET @PageID=(Select PageID from CompanyAdmin_ERP_SD..PageMaster WHERE PageName=@PageName)
select ResourceID,ResourceValue FROM Localization WHERE PageID=@PageID AND CompanyID=@CompanyID AND Culture=@Culture

END