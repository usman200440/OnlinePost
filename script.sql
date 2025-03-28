USE [master]
GO
/****** Object:  Database [post_management_system]    Script Date: 1/12/2024 3:12:34 PM ******/
CREATE DATABASE [post_management_system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'post_management_system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\post_management_system.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'post_management_system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\post_management_system_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [post_management_system] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [post_management_system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [post_management_system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [post_management_system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [post_management_system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [post_management_system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [post_management_system] SET ARITHABORT OFF 
GO
ALTER DATABASE [post_management_system] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [post_management_system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [post_management_system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [post_management_system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [post_management_system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [post_management_system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [post_management_system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [post_management_system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [post_management_system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [post_management_system] SET  ENABLE_BROKER 
GO
ALTER DATABASE [post_management_system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [post_management_system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [post_management_system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [post_management_system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [post_management_system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [post_management_system] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [post_management_system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [post_management_system] SET RECOVERY FULL 
GO
ALTER DATABASE [post_management_system] SET  MULTI_USER 
GO
ALTER DATABASE [post_management_system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [post_management_system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [post_management_system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [post_management_system] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [post_management_system] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'post_management_system', N'ON'
GO
ALTER DATABASE [post_management_system] SET QUERY_STORE = OFF
GO
USE [post_management_system]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [post_management_system]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/12/2024 3:12:35 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[branches]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branches](
	[b_id] [int] IDENTITY(1,1) NOT NULL,
	[b_name] [nvarchar](max) NOT NULL,
	[c_id] [int] NOT NULL,
 CONSTRAINT [PK_branches] PRIMARY KEY CLUSTERED 
(
	[b_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Charges]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charges](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[min_weight] [int] NOT NULL,
	[max_weight] [int] NOT NULL,
	[c_rate] [int] NOT NULL,
 CONSTRAINT [PK_Charges] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cities]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer_Packages]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Packages](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[user_name] [nvarchar](max) NOT NULL,
	[package_name] [nvarchar](max) NOT NULL,
	[package_discount] [int] NOT NULL,
	[package_price] [int] NOT NULL,
	[expired] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customer_Packages] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deliverables]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliverables](
	[DeliverableId] [int] IDENTITY(1,1) NOT NULL,
	[Tracking_Number] [nvarchar](max) NOT NULL,
	[User_id] [int] NOT NULL,
	[DateOfPosting] [datetime2](7) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[TypeOfDelivery] [int] NOT NULL,
	[pay_id] [int] NOT NULL,
	[DestinationAddress] [nvarchar](max) NOT NULL,
	[SenderAddress] [nvarchar](max) NOT NULL,
	[Contact_Number] [nvarchar](max) NOT NULL,
	[DateReceived] [datetime2](7) NOT NULL,
	[DateDelivered] [datetime2](7) NOT NULL,
	[package_type] [nvarchar](max) NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[branch_id] [int] NOT NULL,
	[c_id] [int] NOT NULL,
	[Total_Price] [int] NOT NULL,
 CONSTRAINT [PK_Deliverables] PRIMARY KEY CLUSTERED 
(
	[DeliverableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery_Histories]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Histories](
	[DeliverableId] [int] IDENTITY(1,1) NOT NULL,
	[Tracking_Number] [nvarchar](max) NOT NULL,
	[DateOfPosting] [datetime2](7) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[DestinationAddress] [nvarchar](max) NOT NULL,
	[SenderAddress] [nvarchar](max) NOT NULL,
	[Contact_Number] [nvarchar](max) NOT NULL,
	[DateReceived] [datetime2](7) NOT NULL,
	[DateDelivered] [datetime2](7) NOT NULL,
	[package_type] [nvarchar](max) NOT NULL,
	[normal_charges] [int] NOT NULL,
	[service_charges] [int] NOT NULL,
	[Total_Price] [int] NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[branch_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Delivery_Histories] PRIMARY KEY CLUSTERED 
(
	[DeliverableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[emplogs]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emplogs](
	[EId] [int] IDENTITY(1,1) NOT NULL,
	[EUserName] [nvarchar](max) NOT NULL,
	[EEmail] [nvarchar](max) NOT NULL,
	[EPassword] [nvarchar](max) NOT NULL,
	[Branch] [int] NOT NULL,
	[ERoleId] [int] NULL,
 CONSTRAINT [PK_emplogs] PRIMARY KEY CLUSTERED 
(
	[EId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee_informations]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_informations](
	[e_id] [int] IDENTITY(1,1) NOT NULL,
	[e_user_name] [varchar](255) NOT NULL,
	[e_email] [varchar](255) NOT NULL,
	[e_password] [varchar](255) NOT NULL,
	[Branch] [int] NOT NULL,
	[e_role_id] [int] NULL,
 CONSTRAINT [PK__employee__3E2ED64A7C1E550E] PRIMARY KEY CLUSTERED 
(
	[e_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Forms]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[f_name] [nvarchar](max) NOT NULL,
	[status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Packages]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_name] [nvarchar](max) NOT NULL,
	[p_dis] [int] NOT NULL,
	[p_price] [int] NOT NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[payments]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[personal_informations]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personal_informations](
	[p_id] [int] IDENTITY(1,1) NOT NULL,
	[p_user_name] [varchar](255) NOT NULL,
	[p_email] [varchar](255) NOT NULL,
	[p_password] [varchar](255) NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[p_role_id] [int] NULL,
 CONSTRAINT [PK__personal__82E06B91B4ACF851] PRIMARY KEY CLUSTERED 
(
	[p_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roles]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[r_id] [int] IDENTITY(1,1) NOT NULL,
	[r_name] [varchar](255) NOT NULL,
 CONSTRAINT [PK__roles__C476232731402581] PRIMARY KEY CLUSTERED 
(
	[r_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[servicetypes]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicetypes](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[service_name] [nvarchar](max) NOT NULL,
	[service_charges] [int] NOT NULL,
 CONSTRAINT [PK_servicetypes] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 1/12/2024 3:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_branches_c_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_branches_c_id] ON [dbo].[branches]
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customer_Packages_user_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_Packages_user_id] ON [dbo].[Customer_Packages]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deliverables_branch_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deliverables_branch_id] ON [dbo].[Deliverables]
(
	[branch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deliverables_c_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deliverables_c_id] ON [dbo].[Deliverables]
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deliverables_pay_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deliverables_pay_id] ON [dbo].[Deliverables]
(
	[pay_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deliverables_TypeOfDelivery]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deliverables_TypeOfDelivery] ON [dbo].[Deliverables]
(
	[TypeOfDelivery] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Deliverables_User_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Deliverables_User_id] ON [dbo].[Deliverables]
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_emplogs_Branch]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_emplogs_Branch] ON [dbo].[emplogs]
(
	[Branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_emplogs_ERoleId]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_emplogs_ERoleId] ON [dbo].[emplogs]
(
	[ERoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_employee_informations_Branch]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_employee_informations_Branch] ON [dbo].[employee_informations]
(
	[Branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_employee_informations_e_role_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_employee_informations_e_role_id] ON [dbo].[employee_informations]
(
	[e_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__employee__12E5DDF5AACC7E40]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__employee__12E5DDF5AACC7E40] ON [dbo].[employee_informations]
(
	[e_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__employee__EA4040794CADA275]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__employee__EA4040794CADA275] ON [dbo].[employee_informations]
(
	[e_user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_personal_informations_p_role_id]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_personal_informations_p_role_id] ON [dbo].[personal_informations]
(
	[p_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__personal__05B441C35D5C8B1F]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__personal__05B441C35D5C8B1F] ON [dbo].[personal_informations]
(
	[p_user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__personal__37393E4664DDC0F2]    Script Date: 1/12/2024 3:12:35 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__personal__37393E4664DDC0F2] ON [dbo].[personal_informations]
(
	[p_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Delivery_Histories] ADD  DEFAULT (N'') FOR [branch_name]
GO
ALTER TABLE [dbo].[employee_informations] ADD  DEFAULT ((3)) FOR [e_role_id]
GO
ALTER TABLE [dbo].[personal_informations] ADD  DEFAULT ((2)) FOR [p_role_id]
GO
ALTER TABLE [dbo].[branches]  WITH CHECK ADD  CONSTRAINT [FK_branches_cities_c_id] FOREIGN KEY([c_id])
REFERENCES [dbo].[cities] ([c_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[branches] CHECK CONSTRAINT [FK_branches_cities_c_id]
GO
ALTER TABLE [dbo].[Customer_Packages]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Packages_personal_informations_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[personal_informations] ([p_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customer_Packages] CHECK CONSTRAINT [FK_Customer_Packages_personal_informations_user_id]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverables_branches_branch_id] FOREIGN KEY([branch_id])
REFERENCES [dbo].[branches] ([b_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverables_branches_branch_id]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverables_Charges_c_id] FOREIGN KEY([c_id])
REFERENCES [dbo].[Charges] ([c_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverables_Charges_c_id]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverables_payments_pay_id] FOREIGN KEY([pay_id])
REFERENCES [dbo].[payments] ([p_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverables_payments_pay_id]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverables_personal_informations_User_id] FOREIGN KEY([User_id])
REFERENCES [dbo].[personal_informations] ([p_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverables_personal_informations_User_id]
GO
ALTER TABLE [dbo].[Deliverables]  WITH CHECK ADD  CONSTRAINT [FK_Deliverables_servicetypes_TypeOfDelivery] FOREIGN KEY([TypeOfDelivery])
REFERENCES [dbo].[servicetypes] ([s_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deliverables] CHECK CONSTRAINT [FK_Deliverables_servicetypes_TypeOfDelivery]
GO
ALTER TABLE [dbo].[emplogs]  WITH CHECK ADD  CONSTRAINT [FK_emplogs_branches_Branch] FOREIGN KEY([Branch])
REFERENCES [dbo].[branches] ([b_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[emplogs] CHECK CONSTRAINT [FK_emplogs_branches_Branch]
GO
ALTER TABLE [dbo].[emplogs]  WITH CHECK ADD  CONSTRAINT [FK_emplogs_roles_ERoleId] FOREIGN KEY([ERoleId])
REFERENCES [dbo].[roles] ([r_id])
GO
ALTER TABLE [dbo].[emplogs] CHECK CONSTRAINT [FK_emplogs_roles_ERoleId]
GO
ALTER TABLE [dbo].[employee_informations]  WITH CHECK ADD  CONSTRAINT [FK__employee___e_rol__3B75D760] FOREIGN KEY([e_role_id])
REFERENCES [dbo].[roles] ([r_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[employee_informations] CHECK CONSTRAINT [FK__employee___e_rol__3B75D760]
GO
ALTER TABLE [dbo].[employee_informations]  WITH CHECK ADD  CONSTRAINT [FK_employee_informations_branches_Branch] FOREIGN KEY([Branch])
REFERENCES [dbo].[branches] ([b_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[employee_informations] CHECK CONSTRAINT [FK_employee_informations_branches_Branch]
GO
ALTER TABLE [dbo].[personal_informations]  WITH CHECK ADD  CONSTRAINT [FK__personal___p_rol__412EB0B6] FOREIGN KEY([p_role_id])
REFERENCES [dbo].[roles] ([r_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[personal_informations] CHECK CONSTRAINT [FK__personal___p_rol__412EB0B6]
GO
USE [master]
GO
ALTER DATABASE [post_management_system] SET  READ_WRITE 
GO
