USE [master]
GO
/****** Object:  Database [InventoryManagementDB]    Script Date: 9/30/2023 1:46:18 PM ******/
CREATE DATABASE [InventoryManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManagementDB', FILENAME = N'E:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\InventoryManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryManagementDB_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\InventoryManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InventoryManagementDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InventoryManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [InventoryManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InventoryManagementDB', N'ON'
GO
ALTER DATABASE [InventoryManagementDB] SET QUERY_STORE = OFF
GO
USE [InventoryManagementDB]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.CategoryDetails] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvoice]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[InvoiceDate] [datetime] NULL,
	[GrandTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblInvoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLoginDetail]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoginDetail](
	[LoginDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[LoginTime] [nvarchar](50) NULL,
	[LogoutTime] [nvarchar](50) NULL,
	[LoginDate] [datetime] NULL,
 CONSTRAINT [PK_tblLoginDetail] PRIMARY KEY CLUSTERED 
(
	[LoginDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserTypeId] [int] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 9/30/2023 1:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTypeDetails] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([CategoryId], [CategoryName]) VALUES (1, N'Pens')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCustomer] ON 

INSERT [dbo].[tblCustomer] ([CustomerId], [CustomerName], [Email], [Phone]) VALUES (1, N'Nepal', N'neapl@123gmail.com', N'9849514056')
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([Id], [Username], [Password], [UserTypeId]) VALUES (2, N'support', N'support', 1)
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUserType] ON 

INSERT [dbo].[tblUserType] ([UserTypeId], [UserType]) VALUES (1, N'Admin')
INSERT [dbo].[tblUserType] ([UserTypeId], [UserType]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[tblUserType] OFF
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblUserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[tblUserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblUserType]
GO
USE [master]
GO
ALTER DATABASE [InventoryManagementDB] SET  READ_WRITE 
GO
