Alter Procedure GetPackageImages
(
@PackageCode VARCHAR(10),

@CompanyID VARCHAR(2)
)

AS

BEGIN

Select  PackageImageName As Name,PackageImageTitle As TItle from PackageImages Where CompanyID=@CompanyID and PAckageCode=@PackageCode

eND