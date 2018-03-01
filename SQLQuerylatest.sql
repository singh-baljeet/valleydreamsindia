USE [ValleyDreamsIndiaDB]
GO
/****** Object:  Table [dbo].[UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
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
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (12, N'12345', 12, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (13, N'11111', 12, NULL, NULL, NULL, 0, CAST(0x0000A894016D8404 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (14, N'af6183', 13, N'NEW', 1, CAST(0x0000A894016FCBA7 AS DateTime), 0, CAST(0x0000A89500068A44 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (15, N'c222d9', 13, N'NEW', 1, CAST(0x0000A894016FCBB1 AS DateTime), 0, CAST(0x0000A8950007B64B AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (16, N'd3cc6e', 14, N'NEW', 1, CAST(0x0000A894016FCBB3 AS DateTime), 0, CAST(0x0000A8950009D531 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (17, N'c92f52', 13, N'NEW', 1, CAST(0x0000A894016FCBB6 AS DateTime), 0, CAST(0x0000A895018188E1 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (18, NULL, 13, N'NEW', 0, CAST(0x0000A894016FCBB7 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (19, NULL, 13, N'NEW', 0, CAST(0x0000A894016FCBB7 AS DateTime), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsersDetails] OFF
SET ANSI_PADDING OFF
/****** Object:  Table [dbo].[RenewalPinDetails]    Script Date: 03/01/2018 11:15:15 ******/
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
SET IDENTITY_INSERT [dbo].[RenewalPinDetails] ON
INSERT [dbo].[RenewalPinDetails] ([Id], [SponsoredId], [RecipientId], [IsPinUsed], [PinCreatedOn], [Deleted]) VALUES (1, 13, NULL, 0, CAST(0x0000A89501873B53 AS DateTime), 0)
INSERT [dbo].[RenewalPinDetails] ([Id], [SponsoredId], [RecipientId], [IsPinUsed], [PinCreatedOn], [Deleted]) VALUES (2, 13, NULL, 0, CAST(0x0000A89501873B5E AS DateTime), 0)
INSERT [dbo].[RenewalPinDetails] ([Id], [SponsoredId], [RecipientId], [IsPinUsed], [PinCreatedOn], [Deleted]) VALUES (3, 13, NULL, 0, CAST(0x0000A89501873B60 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RenewalPinDetails] OFF
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 03/01/2018 11:15:15 ******/
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
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'/UploadedImages/bcb0aLighthouse.jpg', 12, N'2/27/2018 10:10:48 PM', NULL, N'LEFT', N'Male', N'Rajat', N'Sharma', N'Ram Gopal', N'02/07/2018', N'9866564344', N'9898989898', N'rajat@gmail.com', N'#123', N'CHD', N'CHD', N'CHD', N'140034', 13, 0, CAST(0x0000A894016D8418 AS DateTime), CAST(0x0000A8940187F41D AS DateTime))
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, NULL, 13, N'2/28/2018 12:23:48 AM', 13, N'LEFT', N'Male', N'Gopi', N'Sharma', N'Gopal', N'02/06/2018', N'3434343434', N'9090-99', N'gopi@yahoo.com', N'#233', N'CHD', N'CHD', N'CHD', N'434343', 14, 0, CAST(0x0000A89500068A4F AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, NULL, 13, N'2/28/2018 12:28:04 AM', 13, N'RIGHT', N'Female', N'Rajni', N'Sharma', N'Rammi', N'02/13/2018', N'0980980', N'9890809', N'rajni@yopmail.com', N'#232', N'PV', N'PB', N'PB', N'90090', 15, 0, CAST(0x0000A8950007B65C AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, NULL, 14, N'2/28/2018 12:35:48 AM', 14, N'LEFT', N'Male', N'Mukul', N'Verma', N'Mamcio', NULL, N'9344324', NULL, NULL, N'#43', NULL, NULL, NULL, NULL, 16, 0, CAST(0x0000A8950009D532 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [LegId], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, NULL, 13, N'2/28/2018 11:23:48 PM', 14, N'RIGHT', N'Male', N'kk', N'kk', N'kk', NULL, N'kk', NULL, NULL, N'kk', NULL, NULL, NULL, NULL, 17, 0, CAST(0x0000A895018190ED AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PersonalDetails] OFF
/****** Object:  Table [dbo].[ContributionDetails]    Script Date: 03/01/2018 11:15:15 ******/
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
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (1, 1, CAST(0x0000A894016D8424 AS DateTime), 1000, 2, CAST(0x0000A8A900000000 AS DateTime), 14, 13, 12, N'ADMIN', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (2, 1, CAST(0x0000A89500068A58 AS DateTime), 1000, 2, CAST(0x0000A8A900000000 AS DateTime), 14, 14, 13, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (3, 1, CAST(0x0000A8950007B661 AS DateTime), 1000, 2, CAST(0x0000A8A900000000 AS DateTime), 14, 15, 13, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (4, 1, CAST(0x0000A8950009D538 AS DateTime), 1000, 2, CAST(0x0000A8A900000000 AS DateTime), 14, 16, 14, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (6, 1, CAST(0x0000A89501819119 AS DateTime), 1000, 2, CAST(0x0000A8A900000000 AS DateTime), 14, 17, 13, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (7, 2, CAST(0x0000A89600112D9A AS DateTime), 1000, 3, CAST(0x0000A8C800000000 AS DateTime), 13, 13, 12, N'SPONSOR', 0)
INSERT [dbo].[ContributionDetails] ([Id], [ContribNumber], [ContribDate], [ContribAmount], [NextContribNumber], [NextContribDate], [RemainingContrib], [UserDetailsId], [SponsoredId], [PayedBy], [IsCompleted]) VALUES (8, 2, CAST(0x0000A8960014B2F4 AS DateTime), 1000, 3, CAST(0x0000A8C800000000 AS DateTime), 13, 14, 13, N'SPONSOR', 0)
SET IDENTITY_INSERT [dbo].[ContributionDetails] OFF
/****** Object:  Table [dbo].[BankDetails]    Script Date: 03/01/2018 11:15:15 ******/
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
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'Raju', N'Brother', N'ICICI Bank', N'Rajat verma', N'243343442', N'343432', N'12345', N'46d9ec', 13, 0, CAST(0x0000A894016D841F AS DateTime), CAST(0x0000A8940187F41D AS DateTime))
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'Ragav', N'Cousin', N'PNB', N'Gopi', N'908098098', N'9890', N'980808', N'991a02', 14, 0, CAST(0x0000A89500068A54 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'Ramio', N'Cousin', N'SBI', N'Ramio', N'9090909', N'0909090', N'98098', N'dfd42c', 15, 0, CAST(0x0000A8950007B65E AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'3f480c', 16, 0, CAST(0x0000A8950009D535 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'f4e3b7', 17, 0, CAST(0x0000A89501819114 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BankDetails] OFF
/****** Object:  ForeignKey [FK_UsersDetails_UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[UsersDetails]  WITH CHECK ADD  CONSTRAINT [FK_UsersDetails_UsersDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[UsersDetails] CHECK CONSTRAINT [FK_UsersDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_RenewalPinDetails_RenewalPinDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[RenewalPinDetails]  WITH CHECK ADD  CONSTRAINT [FK_RenewalPinDetails_RenewalPinDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[RenewalPinDetails] CHECK CONSTRAINT [FK_RenewalPinDetails_RenewalPinDetails]
GO
/****** Object:  ForeignKey [FK_RenewalPinDetails_UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[RenewalPinDetails]  WITH CHECK ADD  CONSTRAINT [FK_RenewalPinDetails_UsersDetails] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[RenewalPinDetails] CHECK CONSTRAINT [FK_RenewalPinDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_PersonalDetails_UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_ContributionDetails_UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[ContributionDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContributionDetails_UsersDetails] FOREIGN KEY([UserDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[ContributionDetails] CHECK CONSTRAINT [FK_ContributionDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_BankDetails_UsersDetails]    Script Date: 03/01/2018 11:15:15 ******/
ALTER TABLE [dbo].[BankDetails]  WITH CHECK ADD  CONSTRAINT [FK_BankDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[BankDetails] CHECK CONSTRAINT [FK_BankDetails_UsersDetails]
GO
