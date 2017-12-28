CREATE TABLE PackageImages
(
CompanyID VARCHAR(2),
PackageCode VARCHAR(10) FOREIGN KEY REFERENCES PackageList(PackageCode),
PackageImageName VARCHAR(200),
PackageImageTitle VARCHAR(200)
)

ALTER PROCEDURE InsertPackageImages
(
@CompanyID VARCHAR(2),
@PackageCode VARCHAR(5),
@PackageImageName VARCHAR(200),
@PackageImageTitle VARCHAR(200)
)

As

Begin

INSERT INTO PackageImages(CompanyID,PackageCode,PackageImageName,PackageImageTitle) VALUES(@CompanyID,@PackageCode,@PackageImageName,@PackageImageTitle)

END