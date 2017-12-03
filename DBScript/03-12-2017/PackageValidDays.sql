USE [PackageModule_ERP_SD]
GO

/****** Object:  Table [dbo].[PackageValidDays]    Script Date: 12/3/2017 9:08:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PackageValidDays](
	[ValidonMonday] [varchar](5) NULL,
	[ValidonTuesday] [varchar](5) NULL,
	[ValidonWednesday] [varchar](5) NULL,
	[ValidonThursday] [varchar](5) NULL,
	[ValidonFriday] [varchar](5) NULL,
	[ValidonSaturday] [varchar](5) NULL,
	[ValidonSunday] [varchar](5) NULL
) ON [PRIMARY]

GO

