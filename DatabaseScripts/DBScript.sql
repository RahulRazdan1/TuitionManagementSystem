USE [Example1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HomePageUrl] [nvarchar](max) NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[CanAccessEveryting] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MustChangePassword] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [bigint] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SubjectId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherActivity]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherActivity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Users] [nvarchar](50) NULL,
	[SubjectId] [bigint] NULL,
	[Subject] [nvarchar](50) NULL,
	[Hours] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_OtherActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotRequest]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotRequest](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TuteeId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[CourseId] [bigint] NULL,
	[Topic] [nvarchar](500) NULL,
	[Date] [date] NULL,
	[SlotTime1] [nvarchar](50) NULL,
	[SlotTime2] [nvarchar](50) NULL,
	[SlotTime3] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[TutorId] [bigint] NULL,
	[AcceptedSlotTime] [nvarchar](50) NULL,
	[AcceptedOn] [datetime] NULL,
 CONSTRAINT [PK_SlotRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotResult]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotResult](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](100) NULL,
	[Tutor] [nvarchar](100) NULL,
	[Hours] [bigint] NULL,
 CONSTRAINT [PK_SlotResult] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotTimes]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotTimes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SlotTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NULL,
	[CompanyName] [nvarchar](max) NULL,
	[DotNumber] [nvarchar](max) NULL,
	[McNumber] [nvarchar](max) NULL,
	[CountryId] [bigint] NOT NULL,
	[StateId] [bigint] NOT NULL,
	[CityId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524131238_Initial', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220526174005_RemoveNameFromBrokerProfileAndAddToIdentity', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220527123303_ShipperProfile', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220527181652_AddColumnInASPNETUser', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220529102535_AddDisplayNameToRole', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220529143701_AddTableEquipmentType', N'6.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220531064717_AddProfileRefernces', N'6.0.5')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
GO
INSERT [dbo].[AspNetRoles] ([Id], [HomePageUrl], [IsDeletable], [CanAccessEveryting], [IsDefault], [LastModifiedOn], [Name], [NormalizedName], [ConcurrencyStamp], [DisplayName]) VALUES (1, N'/Admin/Dashboard', 0, 1, 0, CAST(N'2022-05-31T09:39:10.5446918' AS DateTime2), N'sysadmin', N'SYSADMIN', N'be5df403-a736-45f2-923a-7aeabf3733fe', N'System Administrator')
GO
INSERT [dbo].[AspNetRoles] ([Id], [HomePageUrl], [IsDeletable], [CanAccessEveryting], [IsDefault], [LastModifiedOn], [Name], [NormalizedName], [ConcurrencyStamp], [DisplayName]) VALUES (2, N'/Tutor/Index', 0, 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'tutor', N'TUTOR', N'3c340b66-d5b4-4210-951c-8b7ac72e8a45', N'Tutor')
GO
INSERT [dbo].[AspNetRoles] ([Id], [HomePageUrl], [IsDeletable], [CanAccessEveryting], [IsDefault], [LastModifiedOn], [Name], [NormalizedName], [ConcurrencyStamp], [DisplayName]) VALUES (3, N'/Tutee/Index', 0, 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'tutee', N'TUTEE', N'93608dfd-8c68-4092-87a5-0f463850b4db', N'Tutee')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (10, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (12, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (15, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (16, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (20, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (22, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (23, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (25, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (27, 2)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (11, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (13, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (17, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (18, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (19, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (21, 3)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (24, 3)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (1, 0, N'admin@admin.com', N'ADMIN@ADMIN.COM', N'admin@admin.com', N'ADMIN@ADMIN.COM', 1, N'AQAAAAEAACcQAAAAEFz7WdT3PFkVWZVLahMwXwudOS6U4GUht4aSWDJRco/N11VTY3sOHGHbf6WLVmhbMg==', N'LSCA25Z2J7ZWVRRSIFYUSLDEDFB3VWNZ', N'0392908d-e72e-4364-9d0e-d80a3fa74c7a', NULL, 0, 0, NULL, 1, 0, N'Superadmin', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (10, 0, N'Tutor1@Tutor1.com', N'TUTOR1@TUTOR1.COM', N'Tutor1@Tutor1.com', N'TUTOR1@TUTOR1.COM', 1, N'AQAAAAEAACcQAAAAEMt56uRwFuHI0uyM7oXzK62v/d+h64wf8qCz38S0Smy8KGef25wqxnLPlmmD6fC4Qw==', N'2HKSDIV55M6UBICNSEVX2BJ5ZJ7SISZA', N'3cf76df7-13ac-438e-8f2b-61ee7e526e36', N'123456789', 0, 0, NULL, 1, 0, N'Tutor1', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (11, 0, N'Tutee1@Tutee1.com', N'Tutee1@Tutee1.com', N'Tutee1@Tutee1.com', N'TUTEE1@TUTEE1.COM', 1, N'AQAAAAEAACcQAAAAEB3XOTRTrnWxKud+8HqFi0DwR7QHy8jHAXWL9+kbi+DoC+od//FuNyv6NHPu9RFjBQ==', N'QEKQTBNAZ6E4CEUM5UKASONELU5FIKHF', N'7e0efc12-1c80-423f-8aa6-9d6f255fb170', N'12345667', 0, 0, NULL, 1, 0, N'Tutee1', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (12, 0, N'Tutor2@Tutor2.com', N'TUTOR2@TUTOR2.COM', N'Tutor2@Tutor2.com', N'TUTOR2@TUTOR2.COM', 1, N'AQAAAAEAACcQAAAAECbJjijX/j2hfZNZDhTX7D97UnMtNwjw567G7lVvd3p6ukvIkOFyGL8eHihaQFBhww==', N'C6XFDON2GPT6NNSPJN2MWUA4FOHUS6CT', N'2c5b85c3-c34e-481e-b62f-63f543107c3b', N'123456789', 0, 0, NULL, 1, 0, N'Tutor2', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (13, 0, N'Tutee2@Tutee2.com', N'TUTEE2@TUTEE2.COM', N'Tutee2@Tutee2.com', N'TUTEE2@TUTEE2.COM', 1, N'AQAAAAEAACcQAAAAEAodOSAI9g7x5erdOjhK9mYQkN5XfIF8iW1xE1Lqgco9M7rUNP01T6wXzkjdzAJRLg==', N'2V5EYCHCJOOGZQNRXRPMNNKWZ7XQ5I7I', N'4e5e38ed-2941-4b01-b0c1-f5cdd2495290', N'123123123', 0, 0, NULL, 1, 0, N'Tutee2', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (14, 0, N'Tutee3@Tutee3.com', N'TUTEE3@TUTEE3.COM', N'Tutee3@Tutee3.com', N'TUTEE3@TUTEE3.COM', 0, N'AQAAAAEAACcQAAAAEAFIM+7irMP56avQCEElyfYvXn15f3hACpJZgef83rkiKoyK+pVP5/huTXIU5SZOAQ==', N'PDWWLRA363EEBHXUGGBQBVKE2ICKRA36', N'f1a11a20-5335-455a-a2b8-66073334fbd6', N'123123123', 0, 0, NULL, 1, 0, N'Tutee3', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (15, 0, N'Tutor3@Tutor3.com', N'TUTOR3@TUTOR3.COM', N'Tutor3@Tutor3.com', N'TUTOR3@TUTOR3.COM', 1, N'AQAAAAEAACcQAAAAEM5cY8tP7w2gon68LaBTvClWTl2H1agcjMPlANVlVp0MAohgFmCUav84G4BuW7Ispg==', N'6ILAUBALXOHO533RIFFYWHVJGV5UQHDE', N'3dd7277e-922b-41f6-bded-983dbd4c36ed', N'213123123', 0, 0, NULL, 1, 0, N'Tutor3', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (16, 0, N'Tutor5@Tutor5.com', N'TUTOR5@TUTOR5.COM', N'Tutor5@Tutor5.com', N'TUTOR5@TUTOR5.COM', 1, N'AQAAAAEAACcQAAAAEFgMRf4jcRkEjozKSPEpIoDQlURZ+CAmfC5eWii5pkcwWXWaCqjtLOd/uE8Tvty7mQ==', N'PKEFHG3AS65U7GXJAYRATPZUKCCPGW32', N'863078fb-058d-4544-941c-77ce8101b3cd', N'123123123', 0, 0, NULL, 1, 0, N'Tutor5', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (17, 0, N'Tutor4@Tutor4.com', N'TUTOR4@TUTOR4.COM', N'Tutor4@Tutor4.com', N'TUTOR4@TUTOR4.COM', 1, N'AQAAAAEAACcQAAAAEHJBdReQ3jCJLY7m+FDlsalU/hp+ZYj9SgtrtONMTA869/1Bl9m6ci8qcmYjVhlSXA==', N'WLO6JVIHPB4SUC7LJI7LXYNZ2XW6KX3Q', N'0f371536-79ac-4d19-9054-4f97e5a7ad57', N'1234567889', 0, 0, NULL, 1, 0, N'Tutor4', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (18, 0, N'Tutee5@Tutee5.com', N'TUTEE5@TUTEE5.COM', N'Tutee5@Tutee5.com', N'TUTEE5@TUTEE5.COM', 1, N'AQAAAAEAACcQAAAAEMwoKMfxDiDPx71p1iKsmm+RNdqiA35P6nhhRSe7ddYQonF1DzfKTpZXQT/tidIngQ==', N'HBULOII2DH36FDIVGZEYS4YS4TBYY65X', N'0c6d5488-ea8a-41e2-ac19-4842e1a6eb5c', N'123123123', 0, 0, NULL, 1, 0, N'Tutee5', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (19, 0, N'Tutee12@Tutee12.com', N'TUTEE12@TUTEE12.COM', N'Tutee12@Tutee12.com', N'TUTEE12@TUTEE12.COM', 1, N'AQAAAAEAACcQAAAAEFomfdH1OH66Os0hqiQ/Alolf0H+CumkmEkMK+ZSyGhC8TqGKiA5kP0WDSXOjaTQCA==', N'XS4FCQUDJBNKCBTALZ3POXGEBXTXRB46', N'64c4b685-2b5f-4e8b-893c-e3de1878b5f3', N'9911333507', 0, 0, NULL, 1, 0, N'vikas Bharadwaj', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (20, 0, N'Tutor11@Tutor11.com', N'TUTOR11@TUTOR11.COM', N'Tutor11@Tutor11.com', N'TUTOR11@TUTOR11.COM', 1, N'AQAAAAEAACcQAAAAEK/U+VTtn7mlgAz2m0T/4WQ3fjZ9Q20AFF+RvyFiLGy781y4sQCfEtmt5lVpZKI2BQ==', N'HLDZ3PE2BVLP4AR4A3UJOPAAHZX4EPMC', N'a05eb417-be50-400b-98b1-475358dba6df', N'123123', 0, 0, NULL, 1, 0, N'asdasd', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (21, 0, N'Tutor31@Tutor1.com', N'TUTOR31@TUTOR1.COM', N'Tutor31@Tutor1.com', N'TUTOR31@TUTOR1.COM', 1, N'AQAAAAEAACcQAAAAEM2tTfqoy6Rlv7yu8L0WN+n3wZYXxoYMTcgXbTj4E2cqmZlpxRyv6sOTNhKKf6wcow==', N'DVPVMF2XJ73QFDF36L7YEH7CD27NQNBP', N'b119d2c9-a116-45eb-a324-c6e9b2606a73', N'12345667', 0, 0, NULL, 1, 0, N'Tutor1', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (22, 0, N'Tutor14@Tutor1.com', N'TUTOR14@TUTOR1.COM', N'Tutor14@Tutor1.com', N'TUTOR14@TUTOR1.COM', 1, N'AQAAAAEAACcQAAAAEFIn8cyh8quoiSxv+8BhM3SdsD5PPeofTbtY3nAIELQUi1OElfNDIg8Aauc+OzVnuw==', N'QVLXBST6NBH2PFVQWOXIJUH4GBOXIHDK', N'5f3e581d-c310-4a3d-9037-647caca1e8f1', N'asd', 0, 0, NULL, 1, 0, N'asd', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (23, 0, N'Tutor112@Tutor1.com', N'TUTOR112@TUTOR1.COM', N'Tutor112@Tutor1.com', N'TUTOR112@TUTOR1.COM', 1, N'AQAAAAEAACcQAAAAEB/T+JU+f22FcfHpAFsIoeOM1xiT2CURrKEITBLidUZytewd4r6Ur/W2FSWyvbsH5Q==', N'HSUUHOFS6XHIPEPC47XMI2O6ASO4VXJJ', N'241ab871-18d0-4176-8bfa-2fe61f9fd95d', N'12345667', 0, 0, NULL, 1, 0, N'Tutor21', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (24, 0, N'meet2vikas1234@gmail.com', N'MEET2VIKAS1234@GMAIL.COM', N'meet2vikas1234@gmail.com', N'MEET2VIKAS1234@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEZYxOOAjmdVPGqYNrUYSzleCANcb96i451uhWDgyzP1b4eDO3yLpRcTUsQk2etBsA==', N'BJTMQSHGDQ6II2PVMGRYPM4UDFDM5Z7K', N'1c3db5a4-9623-425a-9a4a-6558d189b743', N'11111111', 0, 0, NULL, 1, 0, N'vikas', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (25, 0, N'admin1@admin1.com', N'ADMIN1@ADMIN1.COM', N'admin1@admin1.com', N'ADMIN1@ADMIN1.COM', 1, N'AQAAAAEAACcQAAAAEM7zgGkGuzb1vzFGpSwRvIGmMMSc8HTKVTc+YQOlZmB4fj3yRhEEkhS051YZIR2fWQ==', N'AEGUWHMO5ZFSUGIVNHASPAYYGXTD3DEX', N'72c6fc6d-aecd-4920-801a-096068c2a4c7', N'9911333507', 0, 0, NULL, 1, 0, N'Cource1234', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (26, 0, N'admin1111@admin.com', N'ADMIN1111@ADMIN.COM', N'admin1111@admin.com', N'ADMIN1111@ADMIN.COM', 1, N'AQAAAAEAACcQAAAAEJBnbCxfP2hQImaTWAl6Y2zY9iHNQtaagfC0YAg3+5SwlJVU08sBdClGdW4NyfkYQg==', N'3CDTWDZLTMROXUOEF2MRAGXB7QTXEWS5', N'a49dc61f-ef15-4f4e-bf1f-270a979f63f2', N'11111111', 0, 0, NULL, 1, 0, N'Cource1234', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (27, 0, N'q2@Q2.COM', N'Q2@Q2.COM', N'q2@Q2.COM', N'Q2@Q2.COM', 1, N'AQAAAAEAACcQAAAAEBJ0Po8WmJs9Sn+U5sajWH7cyWVk6k2ThNT3Q2MNXncZ3e4sZhlFgtK09/7YAjwT+A==', N'G4BUKPBAPKAIQ3JYCGRDUG3T2NAEJIVX', N'721cfa13-c834-4037-a96e-6a3e83eb9ac9', N'213123', 0, 0, NULL, 1, 0, N'ASD', 1)
GO
INSERT [dbo].[AspNetUsers] ([Id], [MustChangePassword], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [IsActive]) VALUES (28, 0, N'admin1SA111@admin.com', N'ADMIN1SA111@ADMIN.COM', N'admin1SA111@admin.com', N'ADMIN1SA111@ADMIN.COM', 1, N'AQAAAAEAACcQAAAAENT2Jtu1jw30M+gybId69DGsS+bF8X5cP5UfiutrD0RUYLkqZhHfTb8P3Nx9aPQbRg==', N'ZTP42DCJ2LYDGWNT2PLZSIE657KHIFDY', N'ecd87461-a294-49bb-9b69-2cd3b137531c', N'AS', 0, 0, NULL, 1, 0, N'AS', 1)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (1, N'Humanities 9', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (2, N'American Studies', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (3, N'English 10', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (4, N'Asian Literature', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (5, N'Literature & the Imagination (Science Fiction)', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (6, N'Creative Writing', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (7, N'Reading, Writing & Publishing in a Digital World', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (8, N'British Literature: The World of Shakespeare', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (9, N'Contemporary American Literature', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (10, N'World Lit (Myths & Monsters) ', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (11, N'Creative Writing ', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (12, N'Satire', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (13, N'AP English Language & Composition ', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (14, N'AT Writing Workshop & Publication', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (15, N'AT Literature', 1, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (16, N'Humanities 9', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (17, N'American Studies ', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (18, N'U.S. History & Government', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (19, N'Law & Justice', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (20, N'Economics', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (21, N'Psychology', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (22, N'Modern History of Singapore', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (23, N'Modern Philosophy', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (24, N'Behavioral Economics & Game Theory', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (25, N'AP U.S. History', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (26, N'AT Historical Inquiry & Research', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (27, N'AT Geography & Field Research', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (28, N'AT Urban Studies', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (29, N'AP Economics', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (30, N'AT Economics: Globalization', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (31, N'AT Psychology', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (32, N'AP U.S. Government & Politics', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (33, N'AP Comparative Government & Politics', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (34, N'AT Entrepreneurship', 2, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (35, N'Algebra I', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (36, N'Geometry', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (37, N'Algebra II/Trigonometry', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (38, N'Conceptual Algebra II', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (39, N'Data Analytics', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (40, N'Discrete Mathematics', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (41, N'Pre-Calculus with Statistics', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (42, N'Pre-Calculus with Parametrics', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (43, N'Accelerated Math I', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (44, N'Accelerated Math II', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (45, N'AP Calculus AB', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (46, N'AP Calculus BC', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (47, N'AP Calculus BC (Post-AB)', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (48, N'AP Statistics', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (49, N'AT Post-Euclidean Geometry', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (50, N'AT Finite Math Modeling', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (51, N'AT Linear Algebra', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (52, N'AT Multivariable Calculus', 3, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (53, N'Biotechnology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (54, N'Marine Biology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (55, N'Anatomy & Physiology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (56, N'Zoology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (57, N'Environmental Science', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (58, N'Forensic Science', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (59, N'Physical Science', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (60, N'Biology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (61, N'Accelerated Biology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (62, N'Chemistry', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (63, N'Accelerated Chemistry', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (64, N'Physics', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (65, N'Accelerated Physics', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (66, N'Engineering & Space Technology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (67, N'AP Biology', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (68, N'AP Chemistry', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (69, N'AT Computational Physics', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (70, N'AP Physics 2', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (71, N'AP Physics C', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (72, N'AT Environmental Science & Field Research', 4, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (73, N'Spanish: Novice ', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (74, N'Spanish: Intermediate I', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (75, N'Spanish: Intermediate II ', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (76, N'Spanish: Intermediate III', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (77, N'Spanish: Intermediate High I', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (78, N'Spanish: Intermediate High II', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (79, N'Spanish: Intermediate High III', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (80, N'Spanish: Advanced I', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (81, N'Spanish: Advanced II', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (82, N'AP Spanish Language & Culture', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (83, N'AT Spanish Language: Latin American History and Culture Through Arts & Media', 5, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (84, N'French: Novice ', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (85, N'French: Intermediate I', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (86, N'French: Intermediate II ', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (87, N'French: Intermediate III', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (88, N'French: Intermediate High I', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (89, N'French: Intermediate High II', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (90, N'French: Intermediate High III', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (91, N'AP French Language and Culture', 6, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (92, N'Chinese: Novice', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (93, N'Chinese: Intermediate I', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (94, N'Chinese: Intermediate II ', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (95, N'Chinese: Intermediate III', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (96, N'Chinese: Intermediate High I', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (97, N'Chinese: Intermediate High II ', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (98, N'Chinese: Intermediate High III', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (99, N'Chinese: Advanced I', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (100, N'Chinese: Advanced II', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (101, N'AP Chinese Language & Culture', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (102, N'AT Chinese Language: History', 7, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (103, N'Computer Science I', 8, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (104, N'Computer Science: Mobile Application Development', 8, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (105, N'Designing Virtual Worlds', 8, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (106, N'AP Computer Science', 8, 1)
GO
INSERT [dbo].[Courses] ([Id], [Name], [SubjectId], [IsActive]) VALUES (107, N'AT Computer Science: Data Structures', 8, 1)
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[OtherActivity] ON 
GO
INSERT [dbo].[OtherActivity] ([Id], [UserId], [Users], [SubjectId], [Subject], [Hours], [IsActive]) VALUES (3, 12, N'Tutor3', 1, N'ww', CAST(3.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[OtherActivity] ([Id], [UserId], [Users], [SubjectId], [Subject], [Hours], [IsActive]) VALUES (4, 15, N'Tutor3', 1, N'ww', CAST(34.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[OtherActivity] ([Id], [UserId], [Users], [SubjectId], [Subject], [Hours], [IsActive]) VALUES (5, 10, N'Tutor1', 3, N'Mathematics', CAST(2.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[OtherActivity] ([Id], [UserId], [Users], [SubjectId], [Subject], [Hours], [IsActive]) VALUES (6, 12, N'Tutor2', 2, N'Social Studies', CAST(45.45 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[OtherActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[SlotRequest] ON 
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (2, 11, 1, 1, N'Topic 1', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 11, CAST(N'2022-08-06T23:01:32.507' AS DateTime), NULL, NULL, 10, N'12 PM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (3, 11, 2, 3, N'Topic 2', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'1 PM', 1, 11, CAST(N'2022-08-06T23:02:24.317' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (4, 11, 3, 10003, N'Topic 3', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 11, CAST(N'2022-08-06T23:01:32.507' AS DateTime), NULL, NULL, 12, N'11 AM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (5, 13, 1, 2, N'Topic 4', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 11, CAST(N'2022-08-06T23:01:32.507' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (6, 13, 2, 10002, N'Topic 5', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 11, CAST(N'2022-08-06T23:01:32.507' AS DateTime), NULL, NULL, 12, N'10 AM', CAST(N'2022-08-06T23:01:32.507' AS DateTime))
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (7, 13, 3, 10004, N'Topic 6', CAST(N'2022-08-06' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 11, CAST(N'2022-08-06T23:01:32.507' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (10, 11, 1, 1, N'vikas', CAST(N'2022-08-09' AS Date), N'3 PM', N'6 PM', N'7 PM', 1, 11, CAST(N'2022-08-09T00:56:58.050' AS DateTime), NULL, NULL, 10, N'7 PM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (11, 13, 1, 2, N'vikas', CAST(N'2022-08-26' AS Date), N'4 PM', N'7 PM', N'7 PM', 1, 11, CAST(N'2022-08-09T01:05:37.007' AS DateTime), 10, CAST(N'2022-08-19T01:39:44.867' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (12, 11, 1, 1, N'vikas', CAST(N'2022-08-25' AS Date), N'3 PM', N'6 PM', N'8 PM', 1, 11, CAST(N'2022-08-09T01:15:05.580' AS DateTime), NULL, NULL, 12, N'8 PM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (13, 11, 3, 10003, N'vikas', CAST(N'2022-08-18' AS Date), N'7 PM', N'3 PM', N'8 PM', 1, 11, CAST(N'2022-08-09T01:25:49.230' AS DateTime), 1, CAST(N'2022-08-19T01:20:29.807' AS DateTime), 10, N'8 PM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (14, 11, 3, 10003, N'vikas', CAST(N'2022-08-10' AS Date), N'3 PM', N'6 PM', N'6 PM', 1, 11, CAST(N'2022-08-09T01:49:54.273' AS DateTime), 10, CAST(N'2022-08-19T01:38:08.597' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (15, 17, 1, 2, N'Tutor4', CAST(N'2022-08-13' AS Date), N'1 PM', N'3 PM', N'7 PM', 1, 17, CAST(N'2022-08-09T15:39:30.177' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (16, 18, 3, 10004, N'course 56', CAST(N'2022-08-11' AS Date), N'12 PM', N'2 PM', N'4 PM', 1, 18, CAST(N'2022-08-09T23:58:49.910' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (17, 11, 3, 10003, N'Adverse Effects of GMOs on Health and Life.', CAST(N'2022-08-11' AS Date), N'12 PM', N'4 PM', N'8 PM', 1, 11, CAST(N'2022-08-10T00:07:23.203' AS DateTime), NULL, NULL, 10, N'8 PM', NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (18, 11, 2, 3, N'Adverse Effects', CAST(N'2022-08-18' AS Date), N'2 PM', N'6 PM', N'8 PM', 1, 11, CAST(N'2022-08-17T01:15:03.423' AS DateTime), 10, CAST(N'2022-08-19T01:24:35.667' AS DateTime), 10, N'8 PM', CAST(N'2022-08-19T01:24:36.353' AS DateTime))
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (19, 24, 2, 3, N'Tutor4', CAST(N'2022-08-18' AS Date), N'3 PM', N'6 PM', N'8 PM', 0, 11, CAST(N'2022-08-17T01:26:06.650' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (20, 24, 3, 10003, N'course 56', CAST(N'2022-08-18' AS Date), N'1 PM', N'2 PM', N'3 PM', 1, 24, CAST(N'2022-08-17T01:33:02.323' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (21, 11, 10002, 10005, N'course 56', CAST(N'2022-08-18' AS Date), N'2 PM', N'6 PM', N'7 PM', 1, 11, CAST(N'2022-08-17T22:18:49.727' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (22, 11, 10002, 10005, N'Tutor4', CAST(N'2022-08-20' AS Date), N'1 PM', N'6 PM', N'7 PM', 1, 11, CAST(N'2022-08-17T23:11:08.817' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (23, 24, 10002, 10005, N'Tutor4', CAST(N'2022-08-18' AS Date), N'12 PM', N'7 PM', N'8 PM', 1, 24, CAST(N'2022-08-17T23:12:28.013' AS DateTime), NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (24, 11, 2, 3, N'Tutor4', CAST(N'2022-08-20' AS Date), N'1 PM', N'3 PM', N'4 PM', 1, 11, CAST(N'2022-08-19T00:38:48.187' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (25, 11, 1, 1, N'vikas1234', CAST(N'2022-08-20' AS Date), N'1 PM', N'2 PM', N'3 PM', 1, 11, CAST(N'2022-08-20T09:14:21.740' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (26, 24, 1, 2, N'course 56', CAST(N'2022-08-20' AS Date), N'10 AM', N'11 AM', N'12 PM', 1, 24, CAST(N'2022-08-20T12:38:30.627' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (27, 24, 3, 37, N'course 56', CAST(N'2022-08-27' AS Date), N'2 PM', N'4 PM', N'7 PM', 1, 24, CAST(N'2022-08-21T01:02:10.287' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (28, 24, 1, 2, N'Tutor4', CAST(N'2022-08-21' AS Date), N'11 AM', N'1 PM', N'4 PM', 1, 24, CAST(N'2022-08-21T16:08:57.020' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (29, 24, 4, 58, N'Adverse Effects of GMOs on Health and Life.', CAST(N'2022-08-21' AS Date), N'2 PM', N'4 PM', N'6 PM', 1, 24, CAST(N'2022-08-21T16:17:34.893' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SlotRequest] ([Id], [TuteeId], [SubjectId], [CourseId], [Topic], [Date], [SlotTime1], [SlotTime2], [SlotTime3], [IsActive], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TutorId], [AcceptedSlotTime], [AcceptedOn]) VALUES (30, 24, 7, 94, N'Adverse Effects', CAST(N'2022-08-21' AS Date), N'12 PM', N'2 PM', N'6 PM', 1, 24, CAST(N'2022-08-21T16:21:31.260' AS DateTime), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SlotRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[SlotResult] ON 
GO
INSERT [dbo].[SlotResult] ([ID], [Subject], [Tutor], [Hours]) VALUES (1, N'VIKAS', N'VIKAS', 10)
GO
SET IDENTITY_INSERT [dbo].[SlotResult] OFF
GO
SET IDENTITY_INSERT [dbo].[SlotTimes] ON 
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (1, N'10 AM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (2, N'11 AM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (3, N'12 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (4, N'1 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (5, N'2 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (6, N'3 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (7, N'4 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (8, N'6 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (9, N'7 PM', 1)
GO
INSERT [dbo].[SlotTimes] ([Id], [Name], [IsActive]) VALUES (10, N'8 PM', 1)
GO
SET IDENTITY_INSERT [dbo].[SlotTimes] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (1, N'English', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (2, N'Social Studies', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (3, N'Mathematics', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (4, N'Science', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (5, N'Spanish', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (6, N'French', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (7, N'Chinese', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (8, N'Computer Science', 1)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [IsActive]) VALUES (9, N'test', 0)
GO
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetail] ON 
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (1, 1, NULL, NULL, NULL, 0, 0, 0, 10)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (2, 2, NULL, NULL, NULL, 0, 0, 0, 11)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (3, 1, NULL, NULL, NULL, 0, 0, 0, 12)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (4, 2, NULL, NULL, NULL, 0, 0, 0, 13)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (5, 1, NULL, NULL, NULL, 0, 0, 0, 15)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (6, 1, NULL, NULL, NULL, 0, 0, 0, 16)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (7, 2, NULL, NULL, NULL, 0, 0, 0, 17)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (8, 2, NULL, NULL, NULL, 0, 0, 0, 18)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (9, 2, NULL, NULL, NULL, 0, 0, 0, 19)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (10, 1, NULL, NULL, NULL, 0, 0, 0, 20)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (11, 2, NULL, NULL, NULL, 0, 0, 0, 21)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (12, 1, NULL, NULL, NULL, 0, 0, 0, 22)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (13, 1, NULL, NULL, NULL, 0, 0, 0, 23)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (14, 2, NULL, NULL, NULL, 0, 0, 0, 24)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (15, 1, NULL, NULL, NULL, 0, 0, 0, 25)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (16, 2, NULL, NULL, NULL, 0, 0, 0, 26)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (17, 1, NULL, NULL, NULL, 0, 0, 0, 27)
GO
INSERT [dbo].[UserDetail] ([Id], [UserTypeId], [CompanyName], [DotNumber], [McNumber], [CountryId], [StateId], [CityId], [UserId]) VALUES (18, 2, NULL, NULL, NULL, 0, 0, 0, 28)
GO
SET IDENTITY_INSERT [dbo].[UserDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTypes] ON 
GO
INSERT [dbo].[UserTypes] ([Id], [Name], [IsActive]) VALUES (1, N'Tutor', 1)
GO
INSERT [dbo].[UserTypes] ([Id], [Name], [IsActive]) VALUES (2, N'Tutee', 1)
GO
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT (N'') FOR [DisplayName]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [FullName]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[OtherActivity] ADD  CONSTRAINT [DF_OtherActivity_Active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SlotRequest] ADD  CONSTRAINT [DF_SlotRequest_Active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SlotRequest] ADD  CONSTRAINT [DF_SlotRequest_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SlotTimes] ADD  CONSTRAINT [DF_SlotTimes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserDetail] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserDetail]  WITH CHECK ADD  CONSTRAINT [FK_UserDetail_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDetail] CHECK CONSTRAINT [FK_UserDetail_AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[GetOtherActivityList]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Exec [dbo].[GetOtherActivityList] 
CREATE PROCEDURE [dbo].[GetOtherActivityList] 
AS
BEGIN
	Select OA.Id						AS Id,
	OA.UserId							AS UserId,
	OA.Users							AS Users,
	OA.SubjectId						AS SubjectId,
	OA.Subject							AS Subject,
	OA.Hours							AS Hours,
	OA.IsActive							AS IsActive
	from OtherActivity OA 
END
GO
/****** Object:  StoredProcedure [dbo].[SlotRequestResult]    Script Date: 04-09-2022 18:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Exec [dbo].[SlotRequestResult] 
CREATE PROCEDURE [dbo].[SlotRequestResult] 
AS
BEGIN
	Select CAST(1 AS BIGINT) AS ID, [Subject], Tutor, SUM([Hours]) AS [Hours]
	From 
	(
	Select  S.Name AS Subject,U.FullName AS Tutor,CAST(Count(*) AS BIGINT) AS Hours
	from SlotRequest sl
	join Subjects s on sl.SubjectId = s.Id
	join [dbo].[AspNetUsers] u on sl.TutorId = u.Id 
	where sl.IsActive = 1 and sl.TutorId != 0
	Group By S.Name,U.FullName
	UNION	 
	SELECT [Subject] AS Subject,[Users],SUM([Hours]) AS [Hours]
	FROM [dbo].[OtherActivity]
	Group BY [Users],[Subject]) T GROUP BY [Subject], Tutor
END
GO
