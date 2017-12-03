USE [PackageModule_ERP_SD]
GO

/****** Object:  Table [dbo].[PackageDetails]    Script Date: 12/3/2017 9:04:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackageDetails](
	[PackageCode] [varchar](10) NULL,
	[PackageName] [varchar](200) NULL,
	[PackageLangauge] [varchar](5) NULL,
	[PackageTitle] [varchar](200) NULL,
	[SupplierRef] [varchar](100) NULL,
	[PackageRemarks] [varchar](500) NULL
) ON [PRIMARY]

GO

