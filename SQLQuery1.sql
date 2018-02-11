USE [ValleyDreamsIndiaDB]
GO
/****** Object:  Table [dbo].[UsersDetails]    Script Date: 02/12/2018 01:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsersDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[SponsoredId] [int] NULL,
	[Deleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_UsersDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UsersDetails] ON
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'a0066', N'qq', NULL, 0, NULL, CAST(0x0000A88400D64654 AS DateTime))
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'kkk', N'88888', 1, 0, CAST(0x0000A88401006EB1 AS DateTime), CAST(0x0000A884010B148B AS DateTime))
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'jjj', N'test', 1, 0, CAST(0x0000A88401043391 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'myteam', N'test', 2, 0, CAST(0x0000A88401093BE5 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UsersDetails] OFF
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 02/12/2018 01:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonalDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](1000) NULL,
	[City] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PinCode] [varchar](10) NULL,
	[PhoneNumber1] [varchar](50) NULL,
	[PhoneNumber2] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[ProfilePic] [varchar](100) NULL,
	[PlacementSide] [varchar](50) NULL,
	[NomineeName] [varchar](50) NULL,
	[NomineeRelation] [varchar](50) NULL,
	[UsersDetailsId] [int] NULL,
	[Deleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_PersonalDetails_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalDetails] ON
INSERT [dbo].[PersonalDetails] ([Id], [Name], [FatherName], [Email], [Gender], [Address], [City], [District], [State], [PinCode], [PhoneNumber1], [PhoneNumber2], [Mobile], [ProfilePic], [PlacementSide], [NomineeName], [NomineeRelation], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'kkk', NULL, NULL, NULL, N'#888', N'888', NULL, N'888', NULL, N'888', NULL, N'88', NULL, NULL, NULL, NULL, 2, 0, CAST(0x0000A88401008588 AS DateTime), CAST(0x0000A884010A95AC AS DateTime))
INSERT [dbo].[PersonalDetails] ([Id], [Name], [FatherName], [Email], [Gender], [Address], [City], [District], [State], [PinCode], [PhoneNumber1], [PhoneNumber2], [Mobile], [ProfilePic], [PlacementSide], [NomineeName], [NomineeRelation], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'oij', N'jo', N'o', NULL, N'jo', N'ij', N'oij', N'oijio', N'j', N'oij', N'oj', NULL, NULL, N'LEFT', N'io', N'j', 3, 0, CAST(0x0000A88401043399 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [Name], [FatherName], [Email], [Gender], [Address], [City], [District], [State], [PinCode], [PhoneNumber1], [PhoneNumber2], [Mobile], [ProfilePic], [PlacementSide], [NomineeName], [NomineeRelation], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'frst', N'frst', N'frst', NULL, N'frst', N'frst', N'frst', N'frst', N'frst', N'frst', N'frst', NULL, NULL, N'LEFT', N'frst', N'frst', 4, 0, CAST(0x0000A88401093BEF AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PersonalDetails] OFF
/****** Object:  Table [dbo].[BankDetails]    Script Date: 02/12/2018 01:06:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](100) NULL,
	[AccountNumber] [varchar](50) NULL,
	[IFSCCode] [varchar](50) NULL,
	[PANNumber] [varchar](50) NULL,
	[UsersDetailsId] [int] NULL,
	[Deleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_BankDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BankDetails] ON
INSERT [dbo].[BankDetails] ([Id], [BankName], [AccountNumber], [IFSCCode], [PANNumber], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'kkk', N'8888888', N'8888888', N'888888', 2, 0, CAST(0x0000A8840100971C AS DateTime), CAST(0x0000A884010AECD5 AS DateTime))
INSERT [dbo].[BankDetails] ([Id], [BankName], [AccountNumber], [IFSCCode], [PANNumber], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, N'oi', N'j', N'oij', N'ji', 3, 0, CAST(0x0000A8840104339D AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [BankName], [AccountNumber], [IFSCCode], [PANNumber], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, N'frst', N'frst', N'frst', N'frst', 4, 0, CAST(0x0000A88401093BF5 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BankDetails] OFF
/****** Object:  ForeignKey [FK_UsersDetails_UsersDetails]    Script Date: 02/12/2018 01:06:12 ******/
ALTER TABLE [dbo].[UsersDetails]  WITH CHECK ADD  CONSTRAINT [FK_UsersDetails_UsersDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[UsersDetails] CHECK CONSTRAINT [FK_UsersDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_PersonalDetails_UsersDetails]    Script Date: 02/12/2018 01:06:12 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_BankDetails_UsersDetails]    Script Date: 02/12/2018 01:06:12 ******/
ALTER TABLE [dbo].[BankDetails]  WITH CHECK ADD  CONSTRAINT [FK_BankDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[BankDetails] CHECK CONSTRAINT [FK_BankDetails_UsersDetails]
GO
