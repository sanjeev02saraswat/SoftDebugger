USE [PackageModule_ERP_SD]
GO

/****** Object:  Table [dbo].[PackageCriteria]    Script Date: 12/3/2017 8:57:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackageCriteria](
	[PackageCode] [varchar](10) NULL,
	[PackageMarket] [varchar](10) NULL,
	[PackageSaleMarket] [varchar](10) NULL,
	[PackageValidityStartDate] [date] NULL,
	[PackageValidityLastDate] [date] NULL,
	[PackageBookingLastDate] [date] NULL,
	[PackageBookingStartDate] [date] NULL,
	[PackageDuration] [varchar](5) NULL,
	[ChildMinAge] [varchar](2) NULL,
	[ChildMaxAge] [varchar](2) NULL,
	[PackageLastPaymentDue] [date] NULL,
	[PackagePaymentCutOffDate] [date] NULL,
	[Discountonfullpayment] [varchar](10) NULL
) ON [PRIMARY]

GO

