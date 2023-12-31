USE [master]
GO
/****** Object:  Database [UniverstyTMS]    Script Date: 11.10.2023 21:53:26 ******/
CREATE DATABASE [UniverstyTMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniverstyTMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UniverstyTMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniverstyTMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UniverstyTMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [UniverstyTMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniverstyTMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniverstyTMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniverstyTMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniverstyTMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniverstyTMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniverstyTMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniverstyTMS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UniverstyTMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniverstyTMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniverstyTMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniverstyTMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniverstyTMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniverstyTMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniverstyTMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniverstyTMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniverstyTMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniverstyTMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniverstyTMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniverstyTMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniverstyTMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniverstyTMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniverstyTMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UniverstyTMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniverstyTMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniverstyTMS] SET  MULTI_USER 
GO
ALTER DATABASE [UniverstyTMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniverstyTMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniverstyTMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniverstyTMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniverstyTMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniverstyTMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniverstyTMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [UniverstyTMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UniverstyTMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11.10.2023 21:53:26 ******/
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
/****** Object:  Table [dbo].[Announces]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HeaderInfo] [nvarchar](30) NOT NULL,
	[MainInfo] [nvarchar](max) NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Announces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[IsAdmin] [bit] NULL,
	[TypeId] [int] NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
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
/****** Object:  Table [dbo].[Attances]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[DVM] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Attances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactForms]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactForms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Header] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Contact] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ContactForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultys]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Facultys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SDF1] [int] NOT NULL,
	[SDF2] [int] NOT NULL,
	[SDF3] [int] NOT NULL,
	[TSI] [int] NOT NULL,
	[SSI] [int] NOT NULL,
	[ORT] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupLessons]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupLessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_GroupLessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupCode] [nvarchar](20) NOT NULL,
	[SpecialtyId] [int] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacultyId] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](30) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FacultyId] [int] NOT NULL,
 CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[SurName] [nvarchar](max) NOT NULL,
	[Birthday] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Language] [nvarchar](max) NOT NULL,
	[IncludeYear] [int] NOT NULL,
	[PerYear] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[IncludePoint] [int] NOT NULL,
	[StateOrdered] [bit] NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacultyId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[IncludedYear] [int] NOT NULL,
	[Language] [nvarchar](max) NOT NULL,
	[Specialty] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[SurName] [nvarchar](max) NOT NULL,
	[Birthday] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Mail] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 11.10.2023 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230916214614_AnnounceTableCreated', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230916215229_AnnounceTableConfiguration', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230917193441_SettingsTableAddId', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230917195227_SettingsHandleTable', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230917205321_GroupTableCreated', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230917224305_OtherTableAdded', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230919114737_GradesTableAddedWithConfig', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230919120018_GroupLessonAndLessonTableadded', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230922113814_RemoveTeacherIdFromGroupsTable', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230922114206_TeacherIdAddedIntoGroupLessons', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230925125452_AttanceTableCreated', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230928125641_HoursColAddedAToLesson', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230928132754_ContactFormTableAdded', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230928134537_ColNameChangedOnContact', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231004110117_AppUserTableCreated', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231004122752_RemovedTypeIdRequireInAppUserTable', N'6.0.22')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231004123138_TypeIdRequireInAppUserTable', N'6.0.22')
GO
SET IDENTITY_INSERT [dbo].[Announces] ON 

INSERT [dbo].[Announces] ([Id], [HeaderInfo], [MainInfo], [Date]) VALUES (1, N'1-ci Kurslarin Nezerine', N'Universtetimize Xosh Gelmisiz.Zehmet olmasa Kafedraniza Yaxinlasin ve Telebe Biletlerinizi Elde Edin.Diqqetiniz Ucun Tesekkurler', N'17.09.2023')
INSERT [dbo].[Announces] ([Id], [HeaderInfo], [MainInfo], [Date]) VALUES (5, N'Sened Qebulu', N'Sened Qebulu Baslamisdir.En Qisa Zamanda Universtete Gelmeyiniz Xais Olunur', N'18.09.2023')
SET IDENTITY_INSERT [dbo].[Announces] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'586f016e-36f8-4c3a-af6f-614bd7718045', N'Admin', N'ADMIN', N'68ac4569-af7d-414b-b0f3-9ad844013b3d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7914ce5f-fb75-411f-a8c0-632ed7bd9f49', N'Member', N'MEMBER', N'49f1d04f-908a-45af-a087-5b53b9364029')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ba2807c5-5626-4446-8f58-6c92d823c7f4', N'Staff', N'STAFF', N'690bf4ed-13c9-467c-856a-1a8e3dd1339d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'46ea7ae0-5f58-4a64-b83c-516cbeb90b17', N'ba2807c5-5626-4446-8f58-6c92d823c7f4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [IsAdmin], [TypeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'46ea7ae0-5f58-4a64-b83c-516cbeb90b17', N'AppUser', 1, NULL, N'Staff', N'STAFF', N'staff@admin.com', N'STAFF@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEEMC27TBA9b152kwK+1b0nZZx4TxS6TffHrmwEXAqZsfxy8Ev/N/bcPhFkbl8IKPsg==', N'PTN2KGQWSJHAET4KDYWI62NM34H4HLRJ', N'62116c60-4c62-4e66-a256-63d167d1ef7c', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Attances] ON 

INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (1, 1, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (2, 1, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (3, 1, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (4, 1, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (5, 1, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (6, 1, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (7, 2, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (8, 2, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (9, 2, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (10, 2, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (11, 2, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (12, 2, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (13, 2, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (14, 2, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (15, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (16, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (17, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (18, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (19, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (20, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (21, 5, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (22, 7, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (23, 7, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (24, 7, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (25, 7, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (26, 7, 1, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (27, 7, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (28, 7, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (29, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (30, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (31, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (32, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (33, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (34, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (35, 8, 1, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (36, 7, 2, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (37, 7, 2, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (38, 7, 2, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (39, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (40, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (41, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (42, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (43, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (44, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (45, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (46, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (47, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (48, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (49, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (50, 7, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (51, 8, 2, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (52, 8, 2, N'+')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (53, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (54, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (55, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (56, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (57, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (58, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (59, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (60, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (61, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (62, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (63, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (64, 8, 2, N'-')
INSERT [dbo].[Attances] ([Id], [StudentId], [LessonId], [DVM]) VALUES (65, 8, 2, N'-')
SET IDENTITY_INSERT [dbo].[Attances] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactForms] ON 

INSERT [dbo].[ContactForms] ([Id], [Header], [Text], [Contact]) VALUES (1, N'test', N'texttest', N'testmail')
INSERT [dbo].[ContactForms] ([Id], [Header], [Text], [Contact]) VALUES (2, N'test2', N'test2', N'55454545')
SET IDENTITY_INSERT [dbo].[ContactForms] OFF
GO
SET IDENTITY_INSERT [dbo].[Facultys] ON 

INSERT [dbo].[Facultys] ([Id], [Name], [Code]) VALUES (1, N'İqtisadiyyat', N'ACC')
INSERT [dbo].[Facultys] ([Id], [Name], [Code]) VALUES (2, N'Memarliq', N'ARC')
INSERT [dbo].[Facultys] ([Id], [Name], [Code]) VALUES (3, N'İnşaat', N'CNT')
INSERT [dbo].[Facultys] ([Id], [Name], [Code]) VALUES (4, N'Mühəndislik', N'ENG')
INSERT [dbo].[Facultys] ([Id], [Name], [Code]) VALUES (5, N'Sənaye', N'SM')
SET IDENTITY_INSERT [dbo].[Facultys] OFF
GO
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [StudentId], [SDF1], [SDF2], [SDF3], [TSI], [SSI], [ORT], [LessonId]) VALUES (4, 7, 8, 78, 36, 95, 72, 67, 1)
INSERT [dbo].[Grades] ([Id], [StudentId], [SDF1], [SDF2], [SDF3], [TSI], [SSI], [ORT], [LessonId]) VALUES (5, 8, 0, 0, 0, 0, 10, 15, 1)
INSERT [dbo].[Grades] ([Id], [StudentId], [SDF1], [SDF2], [SDF3], [TSI], [SSI], [ORT], [LessonId]) VALUES (6, 7, 1, 0, 0, 0, 0, 10, 2)
INSERT [dbo].[Grades] ([Id], [StudentId], [SDF1], [SDF2], [SDF3], [TSI], [SSI], [ORT], [LessonId]) VALUES (7, 8, 0, 0, 0, 0, 0, 10, 2)
SET IDENTITY_INSERT [dbo].[Grades] OFF
GO
SET IDENTITY_INSERT [dbo].[GroupLessons] ON 

INSERT [dbo].[GroupLessons] ([Id], [GroupId], [LessonId], [TeacherId]) VALUES (4, 23, 1, 1)
INSERT [dbo].[GroupLessons] ([Id], [GroupId], [LessonId], [TeacherId]) VALUES (8, 23, 2, 1)
SET IDENTITY_INSERT [dbo].[GroupLessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [GroupCode], [SpecialtyId]) VALUES (23, N'4060A', 1)
INSERT [dbo].[Groups] ([Id], [GroupCode], [SpecialtyId]) VALUES (24, N'4080A', 1)
INSERT [dbo].[Groups] ([Id], [GroupCode], [SpecialtyId]) VALUES (25, N'4090A', 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([Id], [FacultyId], [Name], [Hours]) VALUES (1, 5, N'Sənayenin Əsasları', 8)
INSERT [dbo].[Lessons] ([Id], [FacultyId], [Name], [Hours]) VALUES (2, 3, N'Ekologiya', 16)
INSERT [dbo].[Lessons] ([Id], [FacultyId], [Name], [Hours]) VALUES (11, 1, N'test2', 12)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Key], [Value]) VALUES (4, N'Nömrə', N'+994 50 885 90 83')
INSERT [dbo].[Settings] ([Id], [Key], [Value]) VALUES (5, N'Faks', N'+994 50 885 90 83')
INSERT [dbo].[Settings] ([Id], [Key], [Value]) VALUES (6, N'Mail', N'rhdkazimov@gmail.com')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialties] ON 

INSERT [dbo].[Specialties] ([Id], [Name], [FacultyId]) VALUES (1, N'Sənaye Mühəndisliyi ', 5)
SET IDENTITY_INSERT [dbo].[Specialties] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [GroupId], [TypeId], [Password], [FirstName], [SurName], [Birthday], [Mail], [Language], [IncludeYear], [PerYear], [Status], [IncludePoint], [StateOrdered], [Img]) VALUES (7, 23, 1, N'1234', N'Teestt', N'test', N'2023.02.12', N'test@mail.ru', N'Az', 2002, 2020, 1, 200, 1, N'96d1c6c2-cada-41b0-930b-3479dce79f4109bf7a72e69611c35f77c4ae4a97cc083ace1a4c_full.jpg')
INSERT [dbo].[Students] ([Id], [GroupId], [TypeId], [Password], [FirstName], [SurName], [Birthday], [Mail], [Language], [IncludeYear], [PerYear], [Status], [IncludePoint], [StateOrdered], [Img]) VALUES (8, 23, 1, N'123456', N'Muxtar', N'Valizade', N'2003.07.17', N'mvalizadeh@mail.com', N'İngilis', 2023, 1999, 1, 559, 0, N'4557ea42-f225-494c-bc64-e1601a2b4b450025095360_10.jpg')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [FacultyId], [TypeId], [IncludedYear], [Language], [Specialty], [FirstName], [SurName], [Birthday], [Password], [Mail], [Img]) VALUES (1, 4, 2, 2022, N'Azerbaijan', N'Ekolog', N'Etibar', N'Qehremanov', N'17.04.1996', N'etibar123', N'eqehremanov@gmail.com', N'c7051ae222d609bf7a72e69611c35f77c4ae4a97cc083ace1a4c_full.jpg')
INSERT [dbo].[Teachers] ([Id], [FacultyId], [TypeId], [IncludedYear], [Language], [Specialty], [FirstName], [SurName], [Birthday], [Password], [Mail], [Img]) VALUES (2, 2, 2, 2021, N'Azerbaijan', N'İT', N'Kənan', N'Ələkbərov', N'02.01.2003', N'kenan123', N'kelekberov@gmail.com', N'ab3d0e84-a076-475f-abd2-c7051ae222d609bf7a72e69611c35f77c4ae4a97cc083ace1a4c_full.jpg')
INSERT [dbo].[Teachers] ([Id], [FacultyId], [TypeId], [IncludedYear], [Language], [Specialty], [FirstName], [SurName], [Birthday], [Password], [Mail], [Img]) VALUES (5, 2, 2, 2023, N'Azerbaijan', N'IT', N'Rahid', N'Kazimov', N'11.03.2003', N'rahid123', N'rhdkazimov@gmail.com', N'ab3d0e84-a076-475f-abd2-c7051ae222d609bf7a72e69611c35f77c4ae4a97cc083ace1a4c_full.jpg')
INSERT [dbo].[Teachers] ([Id], [FacultyId], [TypeId], [IncludedYear], [Language], [Specialty], [FirstName], [SurName], [Birthday], [Password], [Mail], [Img]) VALUES (8, 1, 2, 2023, N'Azerbaycan', N'İT', N'Məhəmməd', N'Mikayılov', N'2000.02.16', N'muhammed123', N'mmikayilov@mail.com', N'7e0e8f0a-b994-4e56-860e-e89b54bb9fd30d34ef629732f7e365dd6f5385b41ed0.jpg')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([Id], [Name]) VALUES (1, N'student')
INSERT [dbo].[Types] ([Id], [Name]) VALUES (2, N'teacher')
SET IDENTITY_INSERT [dbo].[Types] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11.10.2023 21:53:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_TypeId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_TypeId] ON [dbo].[AspNetUsers]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11.10.2023 21:53:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Grades_LessonId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Grades_LessonId] ON [dbo].[Grades]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Grades_StudentId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Grades_StudentId] ON [dbo].[Grades]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupLessons_GroupId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_GroupLessons_GroupId] ON [dbo].[GroupLessons]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupLessons_LessonId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_GroupLessons_LessonId] ON [dbo].[GroupLessons]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupLessons_TeacherId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_GroupLessons_TeacherId] ON [dbo].[GroupLessons]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Groups_SpecialtyId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Groups_SpecialtyId] ON [dbo].[Groups]
(
	[SpecialtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Specialties_FacultyId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Specialties_FacultyId] ON [dbo].[Specialties]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_GroupId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Students_GroupId] ON [dbo].[Students]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_TypeId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Students_TypeId] ON [dbo].[Students]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_FacultyId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_FacultyId] ON [dbo].[Teachers]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_TypeId]    Script Date: 11.10.2023 21:53:27 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_TypeId] ON [dbo].[Teachers]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attances] ADD  DEFAULT (N'-') FOR [DVM]
GO
ALTER TABLE [dbo].[Grades] ADD  DEFAULT ((0)) FOR [LessonId]
GO
ALTER TABLE [dbo].[GroupLessons] ADD  DEFAULT ((0)) FOR [TeacherId]
GO
ALTER TABLE [dbo].[Groups] ADD  DEFAULT ((0)) FOR [SpecialtyId]
GO
ALTER TABLE [dbo].[Lessons] ADD  DEFAULT ((0)) FOR [Hours]
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
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Types_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Types] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Types_TypeId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Lessons_LessonId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Students_StudentId]
GO
ALTER TABLE [dbo].[GroupLessons]  WITH CHECK ADD  CONSTRAINT [FK_GroupLessons_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupLessons] CHECK CONSTRAINT [FK_GroupLessons_Groups_GroupId]
GO
ALTER TABLE [dbo].[GroupLessons]  WITH CHECK ADD  CONSTRAINT [FK_GroupLessons_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupLessons] CHECK CONSTRAINT [FK_GroupLessons_Lessons_LessonId]
GO
ALTER TABLE [dbo].[GroupLessons]  WITH CHECK ADD  CONSTRAINT [FK_GroupLessons_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[GroupLessons] CHECK CONSTRAINT [FK_GroupLessons_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Specialties_SpecialtyId] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Specialties_SpecialtyId]
GO
ALTER TABLE [dbo].[Specialties]  WITH CHECK ADD  CONSTRAINT [FK_Specialties_Facultys_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Facultys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Specialties] CHECK CONSTRAINT [FK_Specialties_Facultys_FacultyId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups_GroupId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Types_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Types] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Types_TypeId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Facultys_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Facultys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Facultys_FacultyId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Types_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Types] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Types_TypeId]
GO
USE [master]
GO
ALTER DATABASE [UniverstyTMS] SET  READ_WRITE 
GO
