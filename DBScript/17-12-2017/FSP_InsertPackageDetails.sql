ALTER Procedure FSP_InsertPackageDetails
(
@CompanyID VARCHAR(2),
@PackageCode varchar(10),
@PackageName varchar(200),
@PackageLanguage varchar(5),
@PackageTitle varchar(200),
@PackageMarket varchar(10),
@PackageSaleMarket varchar(10),
@PackageValidityStartDate date,
@PackageValidityEndDate date,
@PackageBookingStartDate date,
@PackageBookingEndDate date,
@PackageDuration varchar(5),
@ChildMinAge varchar(2),
@ChildMaxAge varchar(2),
@PackageLastPaymentDue int,
@PackagePaymentCutOffDay int,
@DiscountonFullPayment varchar(10)

)
As

Begin
IF (SELECT COUNT(*) FROM PackageList WHERE PackageCode = @PackageCode and CompanyID=@CompanyID)=0
BEGIN
INSERT INTO PackageList(PackageCode,PackageName,CompanyID) values(@PackageCode,@PackageName,@CompanyID)
Insert INTO PackageDetails(CompanyID,PackageCode,PackageLangauge,PackageName,PackageTitle) Values (@CompanyID,@PackageCode,@PackageLanguage,@PackageName,@PackageTitle)

Insert Into PackageCriteria(PackageCode,PackageMarket,PackageSaleMarket,PackageValidityStartDate,PackageValidityEndDate,PackageBookingEndDate,PackageBookingStartDate,PackageDuration,ChildMinAge,ChildMaxAge,PackageLastPaymentDue,PackagePaymentCutOffDay,Discountonfullpayment) Values(@PackageCode,@PackageMarket,@PackageSaleMarket,@PackageValidityEndDate,@PackageValidityStartDate,@PackageBookingEndDate,@PackageBookingStartDate,@PackageDuration,@ChildMinAge,@ChildMaxAge,@PackageLastPaymentDue,@PackagePaymentCutOffDay,@Discountonfullpayment)
END
ELSE
BEGIN

UPDATE PackageList SET PackageName=@PackageName WHERE PackageCode=@PackageCode AND CompanyID=@CompanyID
UPDATE PackageDetails SET PackageLangauge=@PackageLanguage,PackageName=@PackageName,PackageTitle=@PackageTitle WHERE PackageCode=@PackageCode AND CompanyID=@CompanyID

UPDATE PackageCriteria SET PackageMarket=@PackageMarket,PackageSaleMarket=@PackageSaleMarket,PackageValidityStartDate=@PackageValidityStartDate,PackageValidityEndDate=@PackageValidityEndDate,PackageBookingEndDate=@PackageBookingEndDate,PackageBookingStartDate=@PackageBookingStartDate,PackageDuration=@PackageDuration,ChildMinAge=@ChildMinAge,ChildMaxAge=@ChildMaxAge,PackageLastPaymentDue=@PackageLastPaymentDue,PackagePaymentCutOffDay=@PackagePaymentCutOffDay,Discountonfullpayment=@Discountonfullpayment WHERE PackageCode=@PackageCode 

END
END