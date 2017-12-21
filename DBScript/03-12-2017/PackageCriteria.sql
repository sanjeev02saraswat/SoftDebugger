USE [PackageModule_ERP_SD]
GO

/****** Object:  Table [dbo].[PackageCriteria]    Script Date: 12/17/2017 18:09:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PackageCriteria](
	[PackageCode] [varchar](10) NULL Foreign KEy references PackageDetails(PackageCode),
	[PackageMarket] [varchar](10) NULL,
	[PackageSaleMarket] [varchar](10) NULL,
	[PackageValidityStartDate] [date] NULL,
	[PackageValidityEndDate] [date] NULL,
	[PackageBookingEndDate] [date] NULL,
	[PackageBookingStartDate] [date] NULL,
	[PackageDuration] [varchar](5) NULL,
	[ChildMinAge] [varchar](2) NULL,
	[ChildMaxAge] [varchar](2) NULL,
	[PackageLastPaymentDue] [int] NULL,
	[PackagePaymentCutOffDay] [int] NULL,
	[Discountonfullpayment] [varchar](10) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


