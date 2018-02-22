USE [ValleyDreamsIndiaDB]
GO
/****** Object:  Table [dbo].[UsersDetails]    Script Date: 02/23/2018 01:26:50 ******/
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
	[PinType] [varchar](50) NULL,
	[IsPinUsed] [int] NULL,
	[PinCreatedOn] [datetime] NULL,
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
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (1, N'a0066', N'qq', NULL, NULL, NULL, NULL, 0, NULL, CAST(0x0000A88400D64654 AS DateTime))
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'a', N'a', 1, NULL, NULL, NULL, 0, CAST(0x0000A88401043391 AS DateTime), CAST(0x0000A88E00DF5CFE AS DateTime))
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'jjj', N'jjj', 1, NULL, NULL, NULL, 0, CAST(0x0000A88401043391 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'b', N'b', 2, NULL, NULL, NULL, 0, CAST(0x0000A88401093BE5 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (5, N'c', N'c', 2, NULL, NULL, NULL, 0, CAST(0x0000A8860010BF35 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'd', N'd', 2, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, N'bleft', N'bleft', 4, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, N'bright', N'bright', 4, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (9, N'cleft', N'cleft', 5, NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (10, NULL, N'kkkkkk', 2, NULL, NULL, NULL, 0, CAST(0x0000A88D016F22B1 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (11, N'A000', N'12', 2, NULL, NULL, NULL, 0, CAST(0x0000A88D0173DB7F AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (12, N'A0011', N'kljklj', 1, NULL, NULL, NULL, 0, CAST(0x0000A88D017701F0 AS DateTime), NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (13, N'A0012', N'123', 2, NULL, NULL, NULL, 0, CAST(0x0000A88D01777DC0 AS DateTime), CAST(0x0000A88E00022C28 AS DateTime))
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (24, N'A0023', NULL, 3, N'NEW', 0, CAST(0x0000A88F017B2A25 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (25, N'A0024', NULL, 3, N'NEW', 0, CAST(0x0000A88F017B2A30 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (26, N'A0025', NULL, 3, N'NEW', 0, CAST(0x0000A88F017B2A33 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (27, N'A0026', NULL, 2, N'NEW', 0, CAST(0x0000A88F017B2A35 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (28, N'A0027', NULL, 2, N'NEW', 0, CAST(0x0000A88F017B2A36 AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (29, N'A0028', NULL, 2, N'RENEW', 0, CAST(0x0000A88F017B95FC AS DateTime), 0, NULL, NULL)
INSERT [dbo].[UsersDetails] ([Id], [Username], [Password], [SponsoredId], [PinType], [IsPinUsed], [PinCreatedOn], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (30, N'A0029', NULL, 2, N'RENEW', 0, CAST(0x0000A88F017B95FE AS DateTime), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UsersDetails] OFF
/****** Object:  Table [dbo].[PersonalDetails]    Script Date: 02/23/2018 01:26:50 ******/
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
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (2, N'/UploadedImages/1447fTulips.jpg', 1, N'02/15/2018', N'LEFT', N'Male', N'ffffff', N'last', N'father', N'02/01/2018', N'contact1', N'contact2', N'kkk@gmail.com', N'address', N'state', N'district', N'city', N'67676', 2, 0, CAST(0x0000A8840104328C AS DateTime), CAST(0x0000A88F0008780A AS DateTime))
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (3, NULL, 1, NULL, N'DIRECT', NULL, N'oij', NULL, N'jo', NULL, N'oij', N'oj', N'o', N'jo', N'oijio', N'oij', N'ij', N'j', 3, 0, CAST(0x0000A88401043399 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (4, NULL, 2, NULL, N'LEFT', NULL, N'frst', NULL, N'frst', NULL, N'frst', N'frst', N'frst', N'frst', N'frst', N'frst', N'frst', N'frst', 4, 0, CAST(0x0000A88401093BEF AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (5, NULL, 2, NULL, N'DIRECT', N'Female', N'newjoin', NULL, N'newjoin', NULL, N'newjoin', N'newjoin', N'newjoin', N'newjoin', N'newjoin', N'newjoin', N'newjoin', N'newjoin', 5, 0, CAST(0x0000A8860010BF3A AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'djoin', 2, NULL, N'DIRECT', N'male', N'djoin', NULL, N'djoin', NULL, N'djoin', N'djoin', N'djoin', N'djoin', N'djoin', N'djoin', N'djoin', N'djoin', 6, 0, NULL, NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, N'bleft', 4, NULL, N'LEFT', N'male', N'bleft', NULL, N'bleft', NULL, N'bleft', N'bleft', N'bleft', N'bleft', N'bleft', N'bleft', N'bleft', N'bleft', 7, 0, NULL, NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, N'bright', 4, NULL, N'RIGHT', N'bright', N'bright', NULL, N'bright', NULL, N'bright', N'bright', N'bright', N'bright', N'bright', N'bright', N'bright', N'bright', 8, 0, NULL, NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (9, N'cleft', 5, NULL, N'LEFT', N'cleft', N'cleft', NULL, N'cleft', NULL, N'cleft', N'cleft', N'cleft', N'cleft', N'cleft', N'cleft', N'cleft', N'cleft', 9, 0, NULL, NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (10, NULL, 2, N'02/15/2018', N'LEFT', N'Male', N'oiuiou', N'uoiuiou', N'iuiouio', N'02/15/2018', N'809809', N'980980', N'jljklj@dsfd.sfsd', N'fasdf', N'sdf', N'dsf', N'fedsf', N'234324', 10, 0, CAST(0x0000A88D016F37CF AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (11, N'/UploadedTeamImages/caa63Tulips.jpg', 2, N'02/15/2018', N'LEFT', N'Male', N'aa', N'ddd', N'dff', N'02/23/2018', N'808098009', N'8098098098', N'safd@edfds.fsdfd', N'lkjlkjkl', N'kljlkj', N'lkjlkj', N'lkjlk', N'98989', 11, 0, CAST(0x0000A88D0173DB88 AS DateTime), NULL)
INSERT [dbo].[PersonalDetails] ([Id], [ProfilePic], [SponsoredId], [JoinedOn], [PlacementSide], [Gender], [FirstName], [LastName], [FatherName], [BirthDate], [PhoneNumber1], [PhoneNumber2], [Email], [Address], [State], [District], [City], [PinCode], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (12, N'/UploadedTeamImages/caa63Tulips.jpg', 2, N'02/01/2018', N'LEFT', N'Male', N'jljk', N'lkj', N'lkj', N'02/09/2018', N'lkjlk', N'jkl', N'jkl', N'lkjk', N'ljlk', N'jkl', N'jkl', N'jlk', 13, 0, CAST(0x0000A88D01777DC8 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PersonalDetails] OFF
/****** Object:  Table [dbo].[BankDetails]    Script Date: 02/23/2018 01:26:50 ******/
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
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (6, N'nomineetest', N'relation', N'bank', N'holder', N'accno', N'ifsc', N'pan', N'1234', 2, 0, CAST(0x0000A8840104328C AS DateTime), CAST(0x0000A88F0008780B AS DateTime))
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (7, NULL, NULL, N'oi', NULL, N'j', N'oij', N'ji', N'111', 3, 0, CAST(0x0000A8840104339D AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (8, NULL, NULL, N'frst', NULL, N'frst', N'frst', N'frst', NULL, 4, 0, CAST(0x0000A88401093BF5 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (9, NULL, NULL, N'newjoin', NULL, N'newjoin', N'newjoin', N'newjoin', NULL, 5, 0, CAST(0x0000A8860010BF3F AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (10, N'8877', N'kjlkj', N'lkjkl', NULL, N'jklj', N'lkjlk', N'jlk', N'jlkj', 10, 0, CAST(0x0000A88D016F573C AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (11, N'9808098', N'kjlkljlk', N'jklj', N'kamal', N'9898989', N'98989', N'99898', N'test', 11, 0, CAST(0x0000A88D0173DB91 AS DateTime), NULL)
INSERT [dbo].[BankDetails] ([Id], [NomineeName], [NomineeRelation], [BankName], [AccountHolderName], [AccountNumber], [IFSCCode], [PANNumber], [TransactionPassword], [UsersDetailsId], [Deleted], [CreatedOn], [UpdatedOn]) VALUES (12, N'jlk', N'klj', N'lkj', N'kamal', N'kl', N'jkl', N'jkl', N'12345', 13, 0, CAST(0x0000A88D01777DCE AS DateTime), CAST(0x0000A88E00087677 AS DateTime))
SET IDENTITY_INSERT [dbo].[BankDetails] OFF
/****** Object:  ForeignKey [FK_UsersDetails_UsersDetails]    Script Date: 02/23/2018 01:26:50 ******/
ALTER TABLE [dbo].[UsersDetails]  WITH CHECK ADD  CONSTRAINT [FK_UsersDetails_UsersDetails] FOREIGN KEY([SponsoredId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[UsersDetails] CHECK CONSTRAINT [FK_UsersDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_PersonalDetails_UsersDetails]    Script Date: 02/23/2018 01:26:50 ******/
ALTER TABLE [dbo].[PersonalDetails]  WITH CHECK ADD  CONSTRAINT [FK_PersonalDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[PersonalDetails] CHECK CONSTRAINT [FK_PersonalDetails_UsersDetails]
GO
/****** Object:  ForeignKey [FK_BankDetails_UsersDetails]    Script Date: 02/23/2018 01:26:50 ******/
ALTER TABLE [dbo].[BankDetails]  WITH CHECK ADD  CONSTRAINT [FK_BankDetails_UsersDetails] FOREIGN KEY([UsersDetailsId])
REFERENCES [dbo].[UsersDetails] ([Id])
GO
ALTER TABLE [dbo].[BankDetails] CHECK CONSTRAINT [FK_BankDetails_UsersDetails]
GO
