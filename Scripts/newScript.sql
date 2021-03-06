USE [master]
GO
/****** Object:  Database [NCRMMLS_DB]    Script Date: 4/30/2016 9:52:57 AM ******/
CREATE DATABASE [NCRMMLS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NCRMMLS_DB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NCRMMLS_DB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NCRMMLS_DB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NCRMMLS_DB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NCRMMLS_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NCRMMLS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NCRMMLS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NCRMMLS_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NCRMMLS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NCRMMLS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NCRMMLS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NCRMMLS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NCRMMLS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NCRMMLS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [NCRMMLS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NCRMMLS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NCRMMLS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NCRMMLS_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NCRMMLS_DB]
GO
/****** Object:  Table [dbo].[Address_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address_tbl](
	[AddressId] [int] NOT NULL,
	[AddressLine1] [varchar](500) NULL,
	[AddressLine2] [varchar](500) NULL,
	[DistrictId] [int] NULL,
	[ZipCode] [varchar](50) NULL,
	[PostOffice] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[Email] [varchar](70) NULL,
	[SourceId] [int] NULL,
	[SourceType] [varchar](50) NULL,
 CONSTRAINT [PK_Address_tbl] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Crops_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Crops_tbl](
	[CropsId] [int] NOT NULL,
	[CropsName] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[CropsCatagoryId] [int] NOT NULL,
 CONSTRAINT [PK_Crops_tbl] PRIMARY KEY CLUSTERED 
(
	[CropsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CropsCatagory_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CropsCatagory_tbl](
	[CropsCatagoryId] [int] NOT NULL,
	[CropsCatagoryName] [varchar](50) NOT NULL,
	[Details] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CropsCatagory_tbl] PRIMARY KEY CLUSTERED 
(
	[CropsCatagoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[District_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District_tbl](
	[DistrictId] [int] NOT NULL,
	[DistrictName] [varchar](50) NOT NULL,
	[DivisionId] [int] NOT NULL,
 CONSTRAINT [PK_District_tbl] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Division_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division_tbl](
	[DivisionId] [int] NOT NULL,
	[DivisionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Division_tbl] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeRoleTable]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeRoleTable](
	[EmployeeId] [int] NOT NULL,
	[EmployeeRole] [varchar](50) NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[StorageCompanyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeRoleTable] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetailsTemp_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetailsTemp_tbl](
	[OrderDetailsTempId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CropsId] [int] NOT NULL,
	[BuyersId] [int] NOT NULL,
	[OwnersId] [int] NOT NULL,
	[Unit] [numeric](18, 2) NOT NULL,
	[TotalPrice] [numeric](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetalis_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetalis_tbl](
	[OrderDetailsId] [int] NOT NULL,
	[ProductsId] [int] NOT NULL,
	[OwnersId] [int] NOT NULL,
	[Unit] [numeric](18, 2) NOT NULL,
	[TotalPrice] [numeric](18, 2) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[OrderMasterId] [int] NOT NULL,
	[CropsId] [int] NOT NULL,
	[IsStatus] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderMaster_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderMaster_tbl](
	[OrderId] [int] NOT NULL,
	[OrderNo] [varchar](500) NOT NULL,
	[CropsBuyerId] [int] NOT NULL,
	[TotalPrice] [numeric](18, 2) NOT NULL,
	[RecordDate] [date] NOT NULL,
 CONSTRAINT [PK_OrderMaster_tbl] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductsList_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductsList_tbl](
	[ProductId] [int] NOT NULL,
	[OwnersId] [int] NOT NULL,
	[CropsDetailsId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[LastUpdateDate] [date] NOT NULL,
	[UnitPrice] [numeric](18, 2) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_ProductsList_tbl] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SecurityCheck_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SecurityCheck_tbl](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[SecurityQuestion] [varchar](100) NOT NULL,
	[Answer] [varchar](100) NOT NULL,
	[UpdateDate] [date] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockDetailsRecord_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetailsRecord_tbl](
	[StockDetailsRecordId] [int] NOT NULL,
	[CropsId] [int] NOT NULL,
	[AmountMainStocked] [numeric](18, 2) NULL,
	[Description] [nvarchar](500) NOT NULL,
	[StockMasterRecordId] [int] NOT NULL,
	[AvailableAmount] [numeric](18, 0) NULL,
	[UpdateDate] [date] NOT NULL,
	[IsReferred] [bit] NULL,
	[AmountSecondStocked] [numeric](18, 0) NULL,
	[CropsOwnerId] [int] NOT NULL,
 CONSTRAINT [PK_StockDetailsRecord_tbl] PRIMARY KEY CLUSTERED 
(
	[StockDetailsRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockMasterRecordCrops_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockMasterRecordCrops_tbl](
	[StockMasterRecordId] [int] NOT NULL,
	[InvoiceNo] [varchar](100) NOT NULL,
	[AmountOfCropsStored] [numeric](18, 0) NOT NULL,
	[StorageCompanyId] [int] NOT NULL,
	[SourceUserId] [int] NOT NULL,
	[EntryEmployeeId] [int] NOT NULL,
	[RecordDate] [date] NOT NULL,
	[StockRecordType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StockMasterRecordCrops_tbl] PRIMARY KEY CLUSTERED 
(
	[StockMasterRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockReleaseDetails_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockReleaseDetails_tbl](
	[StockReleaseId] [int] NOT NULL,
	[StockDetailsRecordId] [int] NOT NULL,
	[AmountRelease] [numeric](18, 2) NOT NULL,
	[StockMasterRecordCropsId] [int] NOT NULL,
 CONSTRAINT [PK_StockReleaseDetails_tbl] PRIMARY KEY CLUSTERED 
(
	[StockReleaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageCompany_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StorageCompany_tbl](
	[StorageCompanyId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
	[Website] [varchar](50) NOT NULL,
	[StorageCapacity] [numeric](18, 0) NOT NULL,
	[StorageAvailable] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_StorageCompany_tbl] PRIMARY KEY CLUSTERED 
(
	[StorageCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_tbl](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Pass] [varchar](500) NOT NULL,
	[FullName] [varchar](500) NOT NULL,
	[DateOfBirth] [varchar](500) NOT NULL,
	[AddressId] [int] NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[NIDNumber] [varchar](500) NULL,
 CONSTRAINT [PK_User_tbl] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType_tbl]    Script Date: 4/30/2016 9:52:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType_tbl](
	[UserTypeId] [int] NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[Details] [varchar](500) NOT NULL,
 CONSTRAINT [PK_UserType_tbl] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] ADD  CONSTRAINT [DF_StockDetailsRecord_tbl_AmountMainStocked]  DEFAULT ((0)) FOR [AmountMainStocked]
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] ADD  CONSTRAINT [DF_StockDetailsRecord_tbl_AvailableAmount]  DEFAULT ((0)) FOR [AvailableAmount]
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] ADD  CONSTRAINT [DF_StockDetailsRecord_tbl_AmountSecondStocked]  DEFAULT ((0)) FOR [AmountSecondStocked]
GO
ALTER TABLE [dbo].[Address_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Address_tbl_District_tbl] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District_tbl] ([DistrictId])
GO
ALTER TABLE [dbo].[Address_tbl] CHECK CONSTRAINT [FK_Address_tbl_District_tbl]
GO
ALTER TABLE [dbo].[Crops_tbl]  WITH CHECK ADD  CONSTRAINT [FK_Crops_tbl_CropsCatagory_tbl] FOREIGN KEY([CropsCatagoryId])
REFERENCES [dbo].[CropsCatagory_tbl] ([CropsCatagoryId])
GO
ALTER TABLE [dbo].[Crops_tbl] CHECK CONSTRAINT [FK_Crops_tbl_CropsCatagory_tbl]
GO
ALTER TABLE [dbo].[District_tbl]  WITH CHECK ADD  CONSTRAINT [FK_District_tbl_Division_tbl] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division_tbl] ([DivisionId])
GO
ALTER TABLE [dbo].[District_tbl] CHECK CONSTRAINT [FK_District_tbl_Division_tbl]
GO
ALTER TABLE [dbo].[EmployeeRoleTable]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoleTable_StorageCompany_tbl] FOREIGN KEY([StorageCompanyId])
REFERENCES [dbo].[StorageCompany_tbl] ([StorageCompanyId])
GO
ALTER TABLE [dbo].[EmployeeRoleTable] CHECK CONSTRAINT [FK_EmployeeRoleTable_StorageCompany_tbl]
GO
ALTER TABLE [dbo].[EmployeeRoleTable]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRoleTable_User_tbl] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_tbl] ([UserId])
GO
ALTER TABLE [dbo].[EmployeeRoleTable] CHECK CONSTRAINT [FK_EmployeeRoleTable_User_tbl]
GO
ALTER TABLE [dbo].[OrderDetalis_tbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetalis_tbl_Crops_tbl] FOREIGN KEY([CropsId])
REFERENCES [dbo].[Crops_tbl] ([CropsId])
GO
ALTER TABLE [dbo].[OrderDetalis_tbl] CHECK CONSTRAINT [FK_OrderDetalis_tbl_Crops_tbl]
GO
ALTER TABLE [dbo].[OrderDetalis_tbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetalis_tbl_OrderMaster_tbl] FOREIGN KEY([OrderMasterId])
REFERENCES [dbo].[OrderMaster_tbl] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetalis_tbl] CHECK CONSTRAINT [FK_OrderDetalis_tbl_OrderMaster_tbl]
GO
ALTER TABLE [dbo].[OrderDetalis_tbl]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetalis_tbl_ProductsList_tbl] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[ProductsList_tbl] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetalis_tbl] CHECK CONSTRAINT [FK_OrderDetalis_tbl_ProductsList_tbl]
GO
ALTER TABLE [dbo].[ProductsList_tbl]  WITH CHECK ADD  CONSTRAINT [FK_ProductsList_tbl_StockDetailsRecord_tbl] FOREIGN KEY([CropsDetailsId])
REFERENCES [dbo].[StockDetailsRecord_tbl] ([StockDetailsRecordId])
GO
ALTER TABLE [dbo].[ProductsList_tbl] CHECK CONSTRAINT [FK_ProductsList_tbl_StockDetailsRecord_tbl]
GO
ALTER TABLE [dbo].[SecurityCheck_tbl]  WITH CHECK ADD  CONSTRAINT [FK_SecurityCheck_tbl_User_tbl] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_tbl] ([UserId])
GO
ALTER TABLE [dbo].[SecurityCheck_tbl] CHECK CONSTRAINT [FK_SecurityCheck_tbl_User_tbl]
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockDetailsRecord_tbl_Crops_tbl] FOREIGN KEY([CropsId])
REFERENCES [dbo].[Crops_tbl] ([CropsId])
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] CHECK CONSTRAINT [FK_StockDetailsRecord_tbl_Crops_tbl]
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockDetailsRecord_tbl_StockMasterRecordCrops_tbl] FOREIGN KEY([StockMasterRecordId])
REFERENCES [dbo].[StockMasterRecordCrops_tbl] ([StockMasterRecordId])
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] CHECK CONSTRAINT [FK_StockDetailsRecord_tbl_StockMasterRecordCrops_tbl]
GO
ALTER TABLE [dbo].[StockMasterRecordCrops_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockMasterRecordCrops_tbl_StorageCompany_tbl] FOREIGN KEY([StorageCompanyId])
REFERENCES [dbo].[StorageCompany_tbl] ([StorageCompanyId])
GO
ALTER TABLE [dbo].[StockMasterRecordCrops_tbl] CHECK CONSTRAINT [FK_StockMasterRecordCrops_tbl_StorageCompany_tbl]
GO
ALTER TABLE [dbo].[StockMasterRecordCrops_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockMasterRecordCrops_tbl_UserDetails_tbl] FOREIGN KEY([StockMasterRecordId])
REFERENCES [dbo].[EmployeeRoleTable] ([EmployeeId])
GO
ALTER TABLE [dbo].[StockMasterRecordCrops_tbl] CHECK CONSTRAINT [FK_StockMasterRecordCrops_tbl_UserDetails_tbl]
GO
ALTER TABLE [dbo].[StockReleaseDetails_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockReleaseDetails_tbl_StockDetailsRecord_tbl] FOREIGN KEY([StockReleaseId])
REFERENCES [dbo].[StockDetailsRecord_tbl] ([StockDetailsRecordId])
GO
ALTER TABLE [dbo].[StockReleaseDetails_tbl] CHECK CONSTRAINT [FK_StockReleaseDetails_tbl_StockDetailsRecord_tbl]
GO
ALTER TABLE [dbo].[StockReleaseDetails_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockReleaseDetails_tbl_StockReleaseDetails_tbl] FOREIGN KEY([StockMasterRecordCropsId])
REFERENCES [dbo].[StockMasterRecordCrops_tbl] ([StockMasterRecordId])
GO
ALTER TABLE [dbo].[StockReleaseDetails_tbl] CHECK CONSTRAINT [FK_StockReleaseDetails_tbl_StockReleaseDetails_tbl]
GO
ALTER TABLE [dbo].[StorageCompany_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StorageCompany_tbl_Address_tbl] FOREIGN KEY([StorageCompanyId])
REFERENCES [dbo].[Address_tbl] ([AddressId])
GO
ALTER TABLE [dbo].[StorageCompany_tbl] CHECK CONSTRAINT [FK_StorageCompany_tbl_Address_tbl]
GO
ALTER TABLE [dbo].[User_tbl]  WITH CHECK ADD  CONSTRAINT [FK_User_tbl_UserType_tbl] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType_tbl] ([UserTypeId])
GO
ALTER TABLE [dbo].[User_tbl] CHECK CONSTRAINT [FK_User_tbl_UserType_tbl]
GO
USE [master]
GO
ALTER DATABASE [NCRMMLS_DB] SET  READ_WRITE 
GO
