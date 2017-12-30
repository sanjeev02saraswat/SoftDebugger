CREATE PROCEDURE FSP_GetAutocompleteList
(
@LanguageCode VARCHAR(2),
@CompanyID VARCHAR(2),
@Query VARCHAR(100)
)
As


BEGIN

Select PackageName , PackageCode from PackageList Where PackageLanguage=@LanguageCode and CompanyID=@CompanyID and PackageName Like '%'+@Query+'%'
END