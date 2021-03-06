USE [PkgLocalization]
GO
/****** Object:  StoredProcedure [dbo].[FSP_InsertResources]    Script Date: 03-01-2018 22:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[FSP_InsertResources]
(
@CompanyID VARCHAR(3),
@PageID int,
@ApplicationID INT,
@ResourceID VARCHAR(200),
@ResourceValue VARCHAR(MAX),
@Culture VARCHAR(10)
)

AS

BEGIN
IF (SELECT COUNT(*) FROM Localization WHERE ResourceID = @ResourceID and Culture=@Culture and CompanyID=@CompanyID and PageID=@PageID)>0--AND(DATEDIFF(MINUTE,@SESSIONDIFF,GETDATE())>@EXPIREMINUTE
BEGIN
Select 'false'
END
ELSE
Begin
INSERT INTO Localization(CompanyID,ResourceID,ResourceValue,Culture,PageID) values(@CompanyID,@ResourceID,@ResourceValue,@Culture,@PageID)

select 'true'
END
END



