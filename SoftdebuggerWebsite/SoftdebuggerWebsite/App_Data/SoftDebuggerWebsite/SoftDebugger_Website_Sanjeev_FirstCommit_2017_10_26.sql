USE [SoftdebuggerWebsite]
GO
/****** Object:  Table [dbo].[CUSTOMERENQUIRY]    Script Date: 10/26/2017 23:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CUSTOMERENQUIRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QUERYTYPE] [varchar](20) NULL,
	[NAME] [varchar](100) NULL,
	[EMAIL] [varchar](100) NULL,
	[MOBILE] [varchar](20) NULL,
	[ENQUIRY] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyCulture]    Script Date: 10/26/2017 23:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyCulture](
	[CultureID] [int] IDENTITY(1,1) NOT NULL,
	[CultureName] [varchar](100) NULL,
	[CultureCode] [varchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyCulture] ON
INSERT [dbo].[CompanyCulture] ([CultureID], [CultureName], [CultureCode]) VALUES (1, N'United States(English)', N'en-US')
INSERT [dbo].[CompanyCulture] ([CultureID], [CultureName], [CultureCode]) VALUES (2, N'Brazilian', N'pt-BR')
SET IDENTITY_INSERT [dbo].[CompanyCulture] OFF
/****** Object:  Table [dbo].[LocalizationUser]    Script Date: 10/26/2017 23:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocalizationUser](
	[Email] [varchar](100) NULL,
	[ProfileName] [varchar](100) NULL,
	[Password] [varchar](50) NULL,
	[HasAccess] [bit] NULL,
	[Cultureaccess] [varchar](10) NULL,
	[LastLoginDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocalizationsHistory]    Script Date: 10/26/2017 23:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocalizationsHistory](
	[Email] [varchar](100) NULL,
	[UpdatedTextTime] [datetime] NULL,
	[Previouscontent] [nvarchar](max) NULL,
	[Recentcontent] [nvarchar](max) NULL,
	[PageFileName] [varchar](100) NULL,
	[Culture] [varchar](10) NULL,
	[SystemIPAddress] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localizations]    Script Date: 10/26/2017 23:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localizations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceKeyName] [varchar](100) NULL,
	[ResourceKeyValue] [nvarchar](max) NULL,
	[Culture] [varchar](10) NULL,
	[ResourceFileName] [varchar](50) NULL,
	[Timestamp] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Localizations] ON
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (1, N'TitleKey', N'SoftDebugger', N'en-US', N'Header', CAST(0x0000A81400D34854 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (2, N'HomeKey', N'Home', N'en-US', N'Header', CAST(0x0000A81400D37292 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (3, N'AboutKey', N'About', N'en-US', N'Header', CAST(0x0000A81400D3BBF6 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (4, N'ServicesKey', N'Services', N'en-US', N'Header', CAST(0x0000A81400D3D385 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (5, N'TimelineKey', N'Timeline', N'en-US', N'Header', CAST(0x0000A81400D3E9F8 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (6, N'Loginkey', N'Login', N'en-US', N'Header', CAST(0x0000A81400D402EE AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (7, N'ContactKey', N'Contact', N'en-US', N'Header', CAST(0x0000A81400D40EA4 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (8, N'ExtrasKey', N'Extras', N'en-US', N'Header', CAST(0x0000A81400D426B3 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (9, N'ExtrasContentKey', N'We are IT Technology service provider, You can contact us for any enquiry.', N'en-US', N'Header', CAST(0x0000A81400D44A62 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (10, N'OurServicesKey', N'Our Services', N'en-US', N'Header', CAST(0x0000A81400D46C78 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (11, N'TravelTechnologyServiceKey', N'Travel Technology Service''s', N'en-US', N'Header', CAST(0x0000A81400D47CFD AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (12, N'MedicalServicesKey', N'Medical Service''s', N'en-US', N'Header', CAST(0x0000A81400D4B010 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (13, N'AutomobileServicesKey', N'Automobiles IT Service''s', N'en-US', N'Header', CAST(0x0000A81400D4E8E0 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (14, N'EducationTrainingService', N'Educational and Training Service''s', N'en-US', N'Header', CAST(0x0000A81400D51207 AS DateTime))
INSERT [dbo].[Localizations] ([ID], [ResourceKeyName], [ResourceKeyValue], [Culture], [ResourceFileName], [Timestamp]) VALUES (15, N'UsefulInfoKey', N'Useful Info', N'en-US', N'Header', CAST(0x0000A81400D552A8 AS DateTime))
SET IDENTITY_INSERT [dbo].[Localizations] OFF
/****** Object:  StoredProcedure [dbo].[FSP_INSERTCONTACTDETAILS]    Script Date: 10/26/2017 23:08:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[FSP_INSERTCONTACTDETAILS]
(
@QUERYTYPE varchar(20),
@NAME varchar(50),
@EMAIL varchar(50),
@MOBILE varchar(13),
@ENQUIRY varchar(200)
)
AS BEGIN
if @QUERYTYPE='INSERT'
BEGIN
INSERT INTO CUSTOMERENQUIRY(NAME,EMAIL,MOBILE,ENQUIRY,QUERYTYPE) VALUES(@NAME,@EMAIL,@MOBILE,@ENQUIRY,@QUERYTYPE)
END
END
GO
/****** Object:  Default [DF__Localizat__Times__7E6CC920]    Script Date: 10/26/2017 23:08:30 ******/
ALTER TABLE [dbo].[Localizations] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
