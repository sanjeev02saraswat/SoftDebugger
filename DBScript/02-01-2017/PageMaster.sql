USE [CompanyAdmin_ERP_SD]
GO
DROP TABLE PageMaster
/****** Object:  Table [dbo].[PageMaster]    Script Date: 02-01-2018 11:35:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PageMaster](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] INT NULL,
	[PageName] [varchar](300) NULL,
	[CompanyID] [varchar](3) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


