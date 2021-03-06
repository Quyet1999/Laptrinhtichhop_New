USE [master]
GO
/****** Object:  Database [TraSua]    Script Date: 6/11/2021 5:26:58 PM ******/
CREATE DATABASE [TraSua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TraSua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TraSua.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TraSua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TraSua_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TraSua] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TraSua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TraSua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TraSua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TraSua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TraSua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TraSua] SET ARITHABORT OFF 
GO
ALTER DATABASE [TraSua] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TraSua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TraSua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TraSua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TraSua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TraSua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TraSua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TraSua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TraSua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TraSua] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TraSua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TraSua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TraSua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TraSua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TraSua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TraSua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TraSua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TraSua] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TraSua] SET  MULTI_USER 
GO
ALTER DATABASE [TraSua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TraSua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TraSua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TraSua] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TraSua] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TraSua] SET QUERY_STORE = OFF
GO
USE [TraSua]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] NOT NULL,
	[GroupID] [int] NULL,
	[Username] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[StatusAccount] [bit] NULL,
	[StatusLog] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] NOT NULL,
	[EmployeeCreate] [int] NULL,
	[TimeCreate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[TotalMoney] [int] NULL,
	[StatusBill] [bit] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[ID_Detail] [int] NOT NULL,
	[BillID] [int] NULL,
	[ItemID] [int] NULL,
	[NumberItem] [int] NULL,
	[Price] [int] NULL,
	[TotalMoneyDetail] [int] NULL,
	[TypeItem] [bit] NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[ID_Detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](200) NULL,
	[TimeSignUp] [datetime] NULL,
	[EmployeeAccept] [int] NULL,
	[AccountID] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drink]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drink](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Type] [int] NULL,
	[Status] [bit] NULL,
	[Price] [int] NULL,
	[AccountChange] [int] NULL,
	[AccountCreate] [int] NULL,
	[TimeCreate] [datetime] NULL,
	[TimeChange] [datetime] NULL,
 CONSTRAINT [PK_Drink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] NOT NULL,
	[AccountID] [int] NULL,
	[FullName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderOnline]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderOnline](
	[ID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[TimeOrder] [datetime] NULL,
	[EmployeeAccept] [int] NULL,
	[TimeAccept] [datetime] NULL,
	[Address] [nvarchar](200) NULL,
	[PhoneNumber] [varchar](12) NULL,
	[TotalMoney] [int] NULL,
	[StatusAccept] [bit] NULL,
 CONSTRAINT [PK_OrderOnline] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderOnlineDetail]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderOnlineDetail](
	[ID_Detail] [int] NOT NULL,
	[OrderOnlineID] [int] NULL,
	[ItemOrderID] [int] NULL,
	[NumberOrder] [int] NULL,
	[Price] [int] NULL,
	[TotalMoneyDetail] [int] NULL,
	[TypeItem] [bit] NULL,
 CONSTRAINT [PK_OrderOnlineDetail] PRIMARY KEY CLUSTERED 
(
	[ID_Detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[SessionID] [varchar](10) NOT NULL,
	[AccountID] [int] NULL,
	[Timecreate] [datetime] NULL,
	[TimeEnd] [datetime] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topping]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topping](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [int] NULL,
	[Status] [bit] NULL,
	[AccountCreate] [int] NULL,
	[AccountChange] [int] NULL,
	[TimeCreate] [datetime] NULL,
	[TimeChange] [datetime] NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Topping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeDrink]    Script Date: 6/11/2021 5:26:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeDrink](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[AccountCreate] [int] NULL,
	[TimeCreate] [datetime] NULL,
	[AccountChange] [int] NULL,
	[TimeChange] [datetime] NULL,
 CONSTRAINT [PK_TypeDrink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([ID], [GroupID], [Username], [Password], [StatusAccount], [StatusLog]) VALUES (1, 2, N'admin', N'admin', 1, 0)
GO
INSERT [dbo].[Bill] ([ID], [EmployeeCreate], [TimeCreate], [CustomerID], [TotalMoney], [StatusBill]) VALUES (0, 1, CAST(N'2021-06-09T09:30:07.040' AS DateTime), -1, 75000, 1)
INSERT [dbo].[Bill] ([ID], [EmployeeCreate], [TimeCreate], [CustomerID], [TotalMoney], [StatusBill]) VALUES (1, 1, CAST(N'2021-06-07T00:00:00.000' AS DateTime), 1, 50000, 1)
INSERT [dbo].[Bill] ([ID], [EmployeeCreate], [TimeCreate], [CustomerID], [TotalMoney], [StatusBill]) VALUES (2, 1, CAST(N'2021-06-09T09:36:35.423' AS DateTime), -1, 100000, 1)
INSERT [dbo].[Bill] ([ID], [EmployeeCreate], [TimeCreate], [CustomerID], [TotalMoney], [StatusBill]) VALUES (3, 1, CAST(N'2021-06-09T09:38:01.653' AS DateTime), -1, 165000, 1)
GO
INSERT [dbo].[BillDetail] ([ID_Detail], [BillID], [ItemID], [NumberItem], [Price], [TotalMoneyDetail], [TypeItem]) VALUES (0, 0, 1, 3, 25000, 75000, 1)
INSERT [dbo].[BillDetail] ([ID_Detail], [BillID], [ItemID], [NumberItem], [Price], [TotalMoneyDetail], [TypeItem]) VALUES (1, 1, 1, 2, 25000, 50000, 1)
INSERT [dbo].[BillDetail] ([ID_Detail], [BillID], [ItemID], [NumberItem], [Price], [TotalMoneyDetail], [TypeItem]) VALUES (2, 2, 1, 4, 25000, 100000, 1)
INSERT [dbo].[BillDetail] ([ID_Detail], [BillID], [ItemID], [NumberItem], [Price], [TotalMoneyDetail], [TypeItem]) VALUES (3, 3, 1, 5, 25000, 125000, 1)
INSERT [dbo].[BillDetail] ([ID_Detail], [BillID], [ItemID], [NumberItem], [Price], [TotalMoneyDetail], [TypeItem]) VALUES (4, 3, 1, 4, 10000, 40000, 0)
GO
INSERT [dbo].[Drink] ([ID], [Name], [Description], [Type], [Status], [Price], [AccountChange], [AccountCreate], [TimeCreate], [TimeChange]) VALUES (1, N'Trà sữa 3 anh em', N'đây là trà sữa rất ngon', 1, 1, 25000, 1, 1, CAST(N'2021-06-07T00:00:00.000' AS DateTime), CAST(N'2021-06-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Employee] ([ID], [AccountID], [FullName], [Sex], [Birthday], [Address]) VALUES (1, 1, N'Nguyễn Trọng Quyết', 1, CAST(N'1999-12-30' AS Date), N'Hà nội')
GO
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'AVJVNDDJLM', 1, CAST(N'2021-06-09T17:08:31.513' AS DateTime), CAST(N'2021-06-09T17:08:38.440' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'DKLFEQDGOK', 1, CAST(N'2021-06-09T16:09:31.900' AS DateTime), CAST(N'2021-06-09T16:09:42.030' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'DRJLSAONSN', 1, CAST(N'2021-06-09T09:02:30.563' AS DateTime), CAST(N'2021-06-09T09:03:19.023' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'EBLNFBMMQQ', 1, CAST(N'2021-06-09T09:37:48.803' AS DateTime), CAST(N'2021-06-09T09:38:46.527' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'ECKNQMAVVV', 1, CAST(N'2021-06-08T20:45:37.207' AS DateTime), CAST(N'2021-06-08T20:46:39.003' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'EDSUEORLSQ', 1, CAST(N'2021-06-08T21:21:13.880' AS DateTime), CAST(N'2021-06-08T21:21:13.880' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'ENBRSNVKGN', 1, CAST(N'2021-06-08T21:23:34.570' AS DateTime), CAST(N'2021-06-08T21:29:20.857' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'FAUBADQCPP', 1, CAST(N'2021-06-09T16:11:06.473' AS DateTime), CAST(N'2021-06-09T16:11:37.107' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'FHIUJDSMLM', 1, CAST(N'2021-06-09T15:11:11.443' AS DateTime), CAST(N'2021-06-09T15:11:14.823' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'GKDILTJMAV', 1, CAST(N'2021-06-09T15:11:36.080' AS DateTime), CAST(N'2021-06-09T15:12:15.983' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'GSQHPCNBJS', 1, CAST(N'2021-06-09T09:26:18.063' AS DateTime), CAST(N'2021-06-09T09:26:18.063' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'HBIJSMSHJB', 1, CAST(N'2021-06-09T09:36:21.110' AS DateTime), CAST(N'2021-06-09T09:36:21.110' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'HTTGQOIUHM', 1, CAST(N'2021-06-08T21:20:09.117' AS DateTime), CAST(N'2021-06-08T21:20:09.117' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'JABAPBJSJV', 1, CAST(N'2021-06-11T17:22:40.830' AS DateTime), CAST(N'2021-06-11T17:22:40.830' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'JQBRMDIQCK', 1, CAST(N'2021-06-09T09:25:06.923' AS DateTime), CAST(N'2021-06-09T09:25:06.923' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'KGILREDURC', 1, CAST(N'2021-06-09T15:10:44.053' AS DateTime), CAST(N'2021-06-09T15:11:01.897' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'LLRNQGKMDU', 1, CAST(N'2021-06-09T09:17:29.093' AS DateTime), CAST(N'2021-06-09T09:17:29.093' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'MIKOCILVSQ', 1, CAST(N'2021-06-09T09:16:15.407' AS DateTime), CAST(N'2021-06-09T09:16:15.407' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'NSROSIRQJA', 1, CAST(N'2021-06-09T09:19:00.317' AS DateTime), CAST(N'2021-06-09T09:19:00.317' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'NVAHLEPKEP', 1, CAST(N'2021-06-08T21:18:51.373' AS DateTime), CAST(N'2021-06-08T21:19:05.883' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'PFMHCOCVQU', 1, CAST(N'2021-06-09T09:29:38.077' AS DateTime), CAST(N'2021-06-09T09:29:38.077' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'QBFGUDCPRN', 1, CAST(N'2021-06-11T17:23:43.093' AS DateTime), CAST(N'2021-06-11T17:24:07.010' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'QQMGPLEAEP', 1, CAST(N'2021-06-08T21:20:24.307' AS DateTime), CAST(N'2021-06-08T21:20:24.307' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'SLUEDJBCHF', 1, CAST(N'2021-06-08T21:22:43.897' AS DateTime), CAST(N'2021-06-08T21:23:14.913' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'TFMRFNUPNC', 1, CAST(N'2021-06-09T15:12:41.770' AS DateTime), CAST(N'2021-06-09T15:12:41.770' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'TQTQHSFICA', 1, CAST(N'2021-06-09T17:10:22.497' AS DateTime), CAST(N'2021-06-09T17:10:37.347' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'TSGDGCVLQP', 1, CAST(N'2021-06-09T09:07:00.933' AS DateTime), CAST(N'2021-06-09T09:07:00.933' AS DateTime), 1)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'UCNUGADRNJ', 1, CAST(N'2021-06-09T15:09:17.000' AS DateTime), CAST(N'2021-06-09T15:10:27.907' AS DateTime), 0)
INSERT [dbo].[Session] ([SessionID], [AccountID], [Timecreate], [TimeEnd], [Status]) VALUES (N'VEMORMDKTD', 1, CAST(N'2021-06-09T17:08:49.630' AS DateTime), CAST(N'2021-06-09T17:09:03.227' AS DateTime), 0)
GO
INSERT [dbo].[Topping] ([ID], [Name], [Description], [Price], [Status], [AccountCreate], [AccountChange], [TimeCreate], [TimeChange], [Image]) VALUES (1, N'Pudding', N'đây là topping đấy', 10000, 1, 1, 1, CAST(N'2021-06-08T00:00:00.000' AS DateTime), CAST(N'2021-06-08T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[TypeDrink] ([ID], [Name], [Description], [AccountCreate], [TimeCreate], [AccountChange], [TimeChange]) VALUES (1, N'Trà sữa', N'Đây là món trà sữa', 1, CAST(N'2021-06-07T00:00:00.000' AS DateTime), 1, CAST(N'2021-06-07T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([EmployeeCreate])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[Drink]  WITH CHECK ADD  CONSTRAINT [FK_Drink_TypeDrink] FOREIGN KEY([Type])
REFERENCES [dbo].[TypeDrink] ([ID])
GO
ALTER TABLE [dbo].[Drink] CHECK CONSTRAINT [FK_Drink_TypeDrink]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Account]
GO
ALTER TABLE [dbo].[OrderOnline]  WITH CHECK ADD  CONSTRAINT [FK_OrderOnline_Employee] FOREIGN KEY([EmployeeAccept])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[OrderOnline] CHECK CONSTRAINT [FK_OrderOnline_Employee]
GO
ALTER TABLE [dbo].[OrderOnlineDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderOnlineDetail_OrderOnline] FOREIGN KEY([OrderOnlineID])
REFERENCES [dbo].[OrderOnline] ([ID])
GO
ALTER TABLE [dbo].[OrderOnlineDetail] CHECK CONSTRAINT [FK_OrderOnlineDetail_OrderOnline]
GO
USE [master]
GO
ALTER DATABASE [TraSua] SET  READ_WRITE 
GO
