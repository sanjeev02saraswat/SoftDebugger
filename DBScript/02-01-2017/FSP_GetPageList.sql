
USE CompanyAdmin_ERP_SD
Create Procedure FSP_GetPageList

(
@CompanyID VARCHAR(2),
@ApplicationID INT
)

AS

BEGIN
SELECT PageID,PageName from PageMaster WHERE CompanyID=@CompanyID and ApplicationID=@ApplicationID

END