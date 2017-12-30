USE [PackageModule_ERP_SD]
GO

/****** Object:  Table [dbo].[PackageDetails]    Script Date: 12/17/2017 18:15:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PackageDetails](
CompanyID VARCHAR(2),
	[PackageCode] [varchar](10) NOT NULL Primary KEY,
	[PackageName] [varchar](200) NULL,
	[PackageLanguage] [varchar](5) NULL,
	[PackageTitle] [varchar](200) NULL,
	[SupplierRef] [varchar](100) NULL,
	[PackageRemarks] [varchar](500) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


