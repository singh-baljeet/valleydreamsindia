USE [ValleyDreamsIndiaDB]
GO
/****** Object:  Table [dbo].[NodesDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeftNodes] [int] NULL,
	[RightNodes] [int] NULL,
 CONSTRAINT [PK_NodesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[SrNo] [int] IDENTITY(0,1) NOT NULL,
	[EmpCode]  AS ('EMP'+right('0000'+CONVERT([varchar](5),[SrNo],0),(5))) PERSISTED,
	[EmpName] [varchar](100) NULL,
	[EmpSalary] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON
GO
SET IDENTITY_INSERT [dbo].[EMPLOYEE] ON
INSERT [dbo].[EMPLOYEE] ([SrNo], [EmpName], [EmpSalary]) VALUES (0, N'Dummy', CAST(1000.00 AS Decimal(10, 2)))
INSERT [dbo].[EMPLOYEE] ([SrNo], [EmpName], [EmpSalary]) VALUES (1, N'Admin', CAST(2000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[EMPLOYEE] OFF
SET ANSI_PADDING OFF
/****** Object:  Table [dbo].[AdminDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](100) NULL,
	[Deleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[UserName]  AS ('A'+right('00000'+CONVERT([varchar](6),[Id],(0)),(6))) PERSISTED,
 CONSTRAINT [PK_AdminDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON
GO
SET IDENTITY_INSERT [dbo].[AdminDetails] ON
INSERT [dbo].[AdminDetails] ([Id], [Password], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'12345', 0, CAST(0x0000A88401043391 AS DateTime), CAST(0x0000A88401043391 AS DateTime))
SET IDENTITY_INSERT [dbo].[AdminDetails] OFF
SET ANSI_PADDING OFF
/****** Object:  Table [dbo].[UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsersDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](100) NULL,
	[SponsoredId] [int] NULL,
	[PinType] [varchar](50) NULL,
	[IsPinUsed] [int] NULL,
	[PinCreatedOn] [datetime] NULL,
	[Deleted] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[UserName]  AS ('B'+right('00000'+CONVERT([varchar](6),[Id],(0)),(6))) PERSISTED,
 CONSTRAINT [PK_UsersDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON
GO
SET IDENTITY_INSERT [dbo].[UsersDetails] ON
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (41, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (42, N'12345', 41, NULL, NULL, NULL, -1, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (43, N'2f2c32', 42, NULL, NULL, NULL, 0, CAST(0x0000A8990167A34F AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (44, N'bf85fe', 42, NULL, NULL, NULL, 0, CAST(0x0000A8990168FD13 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (45, N'65c433', 42, NULL, NULL, NULL, 0, CAST(0x0000A899016B2496 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (46, N'405198', 42, NULL, NULL, NULL, 0, CAST(0x0000A899016DB9C1 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (47, N'd5baa0', 42, NULL, NULL, NULL, 0, CAST(0x0000A8990186B7CD AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (48, N'298b8b', 42, NULL, NULL, NULL, 0, CAST(0x0000A89901878F1C AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (49, N'fc6e5a', 43, N'NEW', 1, CAST(0x0000A89B000CD76C AS DateTime), 0, CAST(0x0000A89C017ED657 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (50, N'416f3c', 43, N'NEW', 1, CAST(0x0000A89B000CD7CA AS DateTime), 0, CAST(0x0000A89C017FA3B1 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (51, N'5b232a', 43, N'NEW', 1, CAST(0x0000A89B000CD7CC AS DateTime), 0, CAST(0x0000A89C01805D6F AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (52, NULL, 43, N'NEW', 0, CAST(0x0000A89B000CD7CF AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (53, NULL, 43, N'NEW', 0, CAST(0x0000A89B000CD7D0 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (54, NULL, 43, N'NEW', 0, CAST(0x0000A89C017E593F AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (55, NULL, 43, N'NEW', 0, CAST(0x0000A89C017E594B AS DateTime), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsersDetails] OFF
SET ANSI_PADDING OFF
/****** Object:  Table [dbo].[RenewalPinDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RenewalPinDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SponsoredId] [int] NULL,
	[RecipientId] [int] NULL,
	[IsPinUsed] [int] NULL,
	[PinCreatedOn] [datetime] NULL,
	[Deleted] [int] NULL,
 CONSTRAINT [PK_RenewalPinDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonalDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilePic] [varchar](100) NULL,
	[SponsoredId] [int] NULL,
	[JoinedOn] [varchar](50) NULL,
	[UsersDetailsId] [int] NULL,
	[LegId] [int] NULL,
	[PlacementSide] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[BirthDate] [varchar](50) NULL,
	[PhoneNumber1] [varchar](50) NULL,
	[PhoneNumber2] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](1000) NULL,
	[State] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[PinCode] [varchar](10) NULL,
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
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 9:49:24 PM', 43, 42, N'LEFT', N'Male', N'Company', N'One', N'Ones Parent', N'03/05/2000', N'111111111111', N'1111111111', N'companyone@gmail.com', N'111', N'CHD', N'CHD', N'CHD', N'160001', 0, CAST(0x0000A8990167A350 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 9:54:19 PM', 44, 42, N'RIGHT', N'Male', N'Company', N'Two', N'Twos Parent', N'03/13/2002', N'2222222222', N'2222222222', N'companytwo@gmail.com', N'222', N'PB', N'PB', N'PB', N'160002', 0, CAST(0x0000A8990168FD15 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 10:02:09 PM', 45, 43, N'LEFT', N'Male', N'Company', N'Three', N'Threes Parent', N'03/09/1998', N'3333333333', N'3333333333', N'companythree@gmail.com', N'3333', N'HP', N'HP', N'HP', N'160003', 0, CAST(0x0000A899016B2499 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 10:11:34 PM', 46, 43, N'RIGHT', N'Male', N'Company', N'Four', N'Fours Parent', N'03/15/2002', N'444444444444', N'444444444444', N'companyfour@gmail.com', N'4444', N'JK', N'JK', N'JK', N'160004', 0, CAST(0x0000A899016DB9D5 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (5, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 11:42:33 PM', 47, 44, N'LEFT', N'Male', N'Company', N'Five', N'Fives Parent', N'03/20/2089', N'555555555555', N'555555555555', N'companyfive@gmail.com', N'5555', N'Orissa', N'Orissa', N'Orissa', N'160005', 0, CAST(0x0000A8990186B7DB AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'/UploadedTeamImages/default1_avatar_small.png', 42, N'3/4/2018 11:45:37 PM', 48, 44, N'RIGHT', N'Male', N'Company', N'Six', N'Sixes Parent', N'03/14/2018', N'6666666666', N'6666666666', N'companysix@gmail.com', N'6666', N'USA', N'USA', N'USA', N'160006', 0, CAST(0x0000A89901878F1F AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, N'/UploadedTeamImages/default1_avatar_small.png', NULL, N'3/4/2018 11:45:37 PM', 42, NULL, NULL, N'Male', N'Admin', N'Panel', N'Admin Parent', N'03/14/2018', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A89901878F1F AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, N'/UploadedTeamImages/default1_avatar_small.png', 43, N'3/7/2018 11:13:52 PM', 49, 45, N'LEFT', N'Male', N'Baljeet', N'Singh', N'Harjeet', NULL, N'8437001923', NULL, NULL, N'#1234', NULL, NULL, NULL, NULL, 0, CAST(0x0000A89C017ED65B AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (9, N'/UploadedTeamImages/default1_avatar_small.png', 43, N'3/7/2018 11:16:47 PM', 50, 45, N'RIGHT', N'Male', N'Kamal', N'Deep', N'Rajan', NULL, N'8437001923', NULL, NULL, N'#123', NULL, NULL, NULL, NULL, 0, CAST(0x0000A89C017FA3BA AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [UsersDetailsId], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (10, N'/UploadedTeamImages/default1_avatar_small.png', 43, N'3/7/2018 11:19:25 PM', 51, 46, N'LEFT', N'Male', N'Rani', N'Sharma', N'Rajani', NULL, N'8437001923', NULL, NULL, N'#123', NULL, NULL, NULL, NULL, 0, CAST(0x0000A89C01805D7A AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PersonalDetails] OFF
/****** Object:  Table [dbo].[ContributionDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContributionDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContribNumber] [int] NULL,
	[ContribDate] [datetime] NULL,
	[ContribAmount] [int] NULL,
	[NextContribNumber] [int] NULL,
	[NextContribDate] [datetime] NULL,
	[RemainingContrib] [int] NULL,
	[UserDetailsId] [int] NULL,
	[SponsoredId] [int] NULL,
	[PayedBy] [varchar](50) NULL,
	[IsCompleted] [int] NULL,
 CONSTRAINT [PK_ContributionDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ContributionDetails] ON
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (1, 1, CAST(0x0000A8990167A36B AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 43, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (2, 1, CAST(0x0000A8990168FD18 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 44, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (3, 1, CAST(0x0000A899016B249C AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 45, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (4, 1, CAST(0x0000A899016DB9DD AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 46, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (5, 1, CAST(0x0000A8990186B7E6 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 47, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (6, 1, CAST(0x0000A89901878F23 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 48, 42, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (7, 1, CAST(0x0000A89C017ED665 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 49, 43, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (8, 1, CAST(0x0000A89C017FA3C3 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 50, 43, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (9, 1, CAST(0x0000A89C01805D82 AS DateTime), 1000, 2, CAST(0x0000A8C800000000 AS DateTime), 14, 51, 43, N'SPONSOR', 0)
SET IDENTITY_INSERT [dbo].[ContributionDetails] OFF
/****** Object:  Table [dbo].[BankDetails]    Script Date: 03/08/2018 03:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomineeName] [varchar](50) NULL,
	[NomineeRelation] [varchar](50) NULL,
	[BankName] [varchar](100) NULL,
	[AccountHolderName] [varchar](50) NULL,
	[AccountNumber] [varchar](50) NULL,
	[IFSCCode] [varchar](50) NULL,
	[PANNumber] [varchar](50) NULL,
	[TransactionPassword] [varchar](50) NULL,
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
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'One Nominee', N'Self', N'ICICI Bank', N'Company One Holder', N'111111111111', N'COMONE11111', N'1111111', N'9a3c4e', 43, 0, CAST(0x0000A8990167A353 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'Two Nominee', N'Self', N'PNB', N'Company Two Holder', N'222222222222', N'COMTWO2222', N'2222222', N'55432c', 44, 0, CAST(0x0000A8990168FD16 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'Three Nominee', N'Self', N'HDFC', N'Company Three Holder', N'333333333333', N'COMTHREE3333', N'3333333', N'c27325', 45, 0, CAST(0x0000A899016B249B AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'Four Nominee', N'Self', N'Canara Bank', N'Company Four Holder', N'44444444444444', N'COMFOUR4444', N'4444444', N'2ebeca', 46, 0, CAST(0x0000A899016DB9DA AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (5, N'Five Nominee', N'Self', N'SBI', N'Company Five Holder', N'555555555555', N'COMFIVE5555', N'5555555', N'0f944d', 47, 0, CAST(0x0000A8990186B7E2 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'Six Nominee', N'Self', N'Yes Bank', N'Company Six Holder', N'666666666666', N'COMSIX6666', N'6666666', N'1b7eb0', 48, 0, CAST(0x0000A89901878F21 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'337dc4', 49, 0, CAST(0x0000A89C017ED660 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'd357fb', 50, 0, CAST(0x0000A89C017FA3BF AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8f0295', 51, 0, CAST(0x0000A89C01805D7E AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BankDetails] OFF
/****** Object:  StoredProcedure [dbo].[CountPlacementSideSP]    Script Date: 03/08/2018 03:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec CountPlacementSide


create procedure [dbo].[CountPlacementSideSP](@USERSDETAILSID INTEGER) as
BEGIN
with cte as (
       select
               UsersDetailsId, LegId, placementside,
               null lnode,
               null rnode
       from PersonalDetails where UsersDetailsId = @USERSDETAILSID
       union all
       select
               t.usersdetailsid, t.sponsoredid, t.placementside,
               ISNULL(cte.lnode, CASE WHEN t.placementside = 'LEFT' THEN 1 ELSE 0 END) lnode,
               ISNULL(cte.rnode, CASE WHEN t.placementside = 'RIGHT' THEN 1 ELSE 0 END) rnode
       from PersonalDetails t
       inner join cte
               on cte.UsersDetailsId = t.LegId
)
select  SUM(lnode)LeftNodes,SUM(rnode)RightNodes from cte option (maxrecursion 0)

END
GO
/****** Object:  StoredProcedure [dbo].[CountPlacementSide]    Script Date: 03/08/2018 03:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec CountPlacementSide


create procedure [dbo].[CountPlacementSide](@USERSDETAILSID INTEGER) as
BEGIN
with cte as (
       select
               UsersDetailsId, LegId, placementside,
               null lnode,
               null rnode
       from PersonalDetails where UsersDetailsId = @USERSDETAILSID
       union all
       select
               t.usersdetailsid, t.sponsoredid, t.placementside,
               ISNULL(cte.lnode, CASE WHEN t.placementside = 'LEFT' THEN 1 ELSE 0 END) lnode,
               ISNULL(cte.rnode, CASE WHEN t.placementside = 'RIGHT' THEN 1 ELSE 0 END) rnode
       from PersonalDetails t
       inner join cte
               on cte.UsersDetailsId = t.LegId
)
select  SUM(lnode)LeftNodes,SUM(rnode)RightNodes from cte option (maxrecursion 0)

END
GO
/****** Object:  ForeignKey [FK_UsersDetails_UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[UsersDetails]  WITH CHECK ADD  CONSTRAINT [FK_UsersDetails_UsersDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[UsersDetails] CHECK CONSTRAINT [FK_UsersDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_RenewalPinDetails_RenewalPinDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[RenewalPinDetails]  WITH CHECK ADD  CONSTRAINT [FK_RenewalPinDetails_RenewalPinDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[RenewalPinDetails] CHECK CONSTRAINT [FK_RenewalPinDetails_RenewalPinDetails]
GO
/****** Object:  ForeignKey [FK_RenewalPinDetails_UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[RenewalPinDetails]  WITH CHECK ADD  CONSTRAINT [FK_RenewalPinDetails_UsersDetails] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[RenewalPinDetails] CHECK CONSTRAINT [FK_RenewalPinDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_PersonalDetails_UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_ContributionDetails_UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[ContributionDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContributionDetails_UsersDetails] FOREIGN KEY([UserDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[ContributionDetails] CHECK CONSTRAINT [FK_ContributionDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_BankDetails_UsersDetails]    Script Date: 03/08/2018 03:23:29 ******/
ALTER TABLE [dbo].[BankDetails]  WITH CHECK ADD  CONSTRAINT [FK_BankDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[BankDetails] CHECK CONSTRAINT [FK_BankDetails_UsersDetails]
GO
