use master
go
create database NCRMMLS_DB
go
use NCRMMLS_DB
go

CREATE TABLE [dbo].[Address_tbl](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Crops_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Crops_tbl](
	[CropsId] [int] IDENTITY(1,1) NOT NULL,
	[CropsName] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Crops_tbl] PRIMARY KEY CLUSTERED 
(
	[CropsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CropsCatagory_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CropsCatagory_tbl](
	[CropsCatagoryId] [int] IDENTITY(1,1) NOT NULL,
	[CropsCatagoryName] [varchar](50) NOT NULL,
	[Details] [varchar](50) NOT NULL,
	[CropsId] [int] NOT NULL,
 CONSTRAINT [PK_CropsCatagory_tbl] PRIMARY KEY CLUSTERED 
(
	[CropsCatagoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[District_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District_tbl](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Division_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division_tbl](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Division_tbl] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeRoleTable]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeRoleTable](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeRole] [varchar](50) NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [date] NOT NULL,
	[StorageCompanyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsApprove] [bit] NULL,
 CONSTRAINT [PK_EmployeeRoleTable] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetailsTemp_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetailsTemp_tbl](
	[OrderDetailsTempId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CropsId] [int] NOT NULL,
	[BuyersId] [int] NOT NULL,
	[OwnersId] [int] NOT NULL,
	[Unit] [numeric](18, 2) NOT NULL,
	[TotalPrice] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetailsTemp_tbl] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsTempId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetalis_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetalis_tbl](
	[OrderDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[ProductsId] [int] NOT NULL,
	[OwnersId] [int] NOT NULL,
	[Unit] [numeric](18, 2) NOT NULL,
	[TotalPrice] [numeric](18, 2) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[OrderMasterId] [int] NOT NULL,
	[CropsId] [int] NOT NULL,
	[IsStatus] [bit] NOT NULL,
 CONSTRAINT [PK_OrderDetalis_tbl] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderMaster_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderMaster_tbl](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[ProductsList_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductsList_tbl](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[SecurityCheck_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SecurityCheck_tbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SecurityQuestion] [varchar](100) NOT NULL,
	[Answer] [varchar](100) NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_SecurityCheck_tbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockDetailsRecord_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetailsRecord_tbl](
	[StockDetailsRecordId] [int] IDENTITY(1,1) NOT NULL,
	[CropsCatagoryId] [int] NOT NULL,
	[AmountMainStocked] [numeric](18, 2) NULL,
	[Description] [nvarchar](500) NULL,
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
/****** Object:  Table [dbo].[StockMasterMainList_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMasterMainList_tbl](
	[MasterInfoId] [int] IDENTITY(1,1) NOT NULL,
	[StockMasterId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[StorageAmount] [decimal](18, 2) NOT NULL,
	[ReleaseAmount] [decimal](18, 2) NOT NULL,
	[AvailableStorageAmount] [decimal](18, 2) NOT NULL,
	[IsApprove] [bit] NOT NULL,
 CONSTRAINT [PK_StockMasterMainList_tbl] PRIMARY KEY CLUSTERED 
(
	[MasterInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockMasterRecordCrops_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockMasterRecordCrops_tbl](
	[StockMasterRecordId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](100) NOT NULL,
	[CropsAmount] [decimal](18, 2) NOT NULL,
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
/****** Object:  Table [dbo].[StockReleaseDetails_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockReleaseDetails_tbl](
	[StockReleaseId] [int] NOT NULL,
	[AmountRelease] [numeric](18, 2) NOT NULL,
	[StockMasterRecordCropsId] [int] NOT NULL,
	[CropsCatagoryId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_StockReleaseDetails_tbl] PRIMARY KEY CLUSTERED 
(
	[StockReleaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockTempRecord]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTempRecord](
	[tmpStockDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CropsCatagoryId] [int] NOT NULL,
	[StockAmount] [decimal](18, 2) NOT NULL,
	[EmployeerId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_StockTempRecord] PRIMARY KEY CLUSTERED 
(
	[tmpStockDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageCompany_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StorageCompany_tbl](
	[StorageCompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[User_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
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
	[DateOfBirth] [date] NOT NULL,
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
/****** Object:  Table [dbo].[UserType_tbl]    Script Date: 5/30/2016 8:40:41 AM ******/
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
SET IDENTITY_INSERT [dbo].[Address_tbl] ON 

INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (1, N'Plot No: 1592 ', N'South Dania Pater bug', 1, N'1208', N'Donia', N'027545361', N'01675967697', N'md.musfiqurcse@gmail.com', 1, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (2, N'Dhanmmondi R/A', N'Road 15 ,Block B', 1, N'1215', N'Dhanmmondi', N'027484231', N'01673210014', N'shafiqtib@gmail.com', 2, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (3, N'Imamganj', N'Rashul Nogor, Kather Pul', 4, N'1410', N'Ichapur', N'027621321', N'01511526231', N'rahimclt@gmail.com', 1, N'Company')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (4, N'Vill: Mia Bari', N'Manikganj sadar', 7, N'1323', N'Baliati', NULL, N'01511252523', N'delowar@gmail.com', 3, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (5, N'Vill: Rajdia', N'Road: Shamolkandi', 4, N'1415', N'East Rajdia', NULL, N'01675967697', N'omar@gmail.com', 4, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (6, N'adsfadsfadsf', N'adfasdfad', 1, N'1415', N'1415', N'021645645', N'15654645', N'omar.ratul@gmail.com', 5, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (7, N'asdfasdfa', N'sdfasdfadsf', 1, N'1415', N'Baliatai', NULL, N'+880151756554', N'abc@gmail.com', 6, N'User')
INSERT [dbo].[Address_tbl] ([AddressId], [AddressLine1], [AddressLine2], [DistrictId], [ZipCode], [PostOffice], [ContactNo], [MobileNo], [Email], [SourceId], [SourceType]) VALUES (8, N'Dhaka', N'Dhaka', 1, N'1415', N'Baliati', NULL, NULL, NULL, 7, N'User')
SET IDENTITY_INSERT [dbo].[Address_tbl] OFF
SET IDENTITY_INSERT [dbo].[Crops_tbl] ON 

INSERT [dbo].[Crops_tbl] ([CropsId], [CropsName], [Description]) VALUES (1, N'Rice', N'Rice is our national food. It is grow in the low dry field.')
SET IDENTITY_INSERT [dbo].[Crops_tbl] OFF
SET IDENTITY_INSERT [dbo].[District_tbl] ON 

INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (1, N'	Dhaka', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (2, N'Narayanganj', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (3, N'Faridpur', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (4, N'Munshiganj', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (5, N'Gopalganj', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (6, N'Kishoreganj', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (7, N'Manikganj', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (8, N'Narsingdi', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (9, N'Shariatpur', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (10, N'Tangail', 1)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (11, N'Barisal', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (12, N'Barguna', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (13, N'Bhola', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (14, N'Jhalokati', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (15, N'Patuakhali', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (16, N'Pirojpur', 2)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (17, N'Bandarban', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (18, N'Brahmanbaria', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (19, N'Chandpur', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (20, N'Chittagong', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (21, N'Comilla', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (22, N'Cox''s Bazar', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (23, N'Feni', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (24, N'Khagrachhari', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (25, N'Lakshmipur', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (26, N'Noakhali', 3)
INSERT [dbo].[District_tbl] ([DistrictId], [DistrictName], [DivisionId]) VALUES (27, N'Rangamati', 3)
SET IDENTITY_INSERT [dbo].[District_tbl] OFF
SET IDENTITY_INSERT [dbo].[Division_tbl] ON 

INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (1, N'Dhaka')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (2, N'Barisal')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (3, N'Chittagong')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (4, N'Rajshahi')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (5, N'Rangpur')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (6, N'Mymensingh')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (7, N'Sylhet')
INSERT [dbo].[Division_tbl] ([DivisionId], [DivisionName]) VALUES (8, N'Khulna')
SET IDENTITY_INSERT [dbo].[Division_tbl] OFF
SET IDENTITY_INSERT [dbo].[EmployeeRoleTable] ON 

INSERT [dbo].[EmployeeRoleTable] ([EmployeeId], [EmployeeRole], [UpdateBy], [UpdateDate], [StorageCompanyId], [UserId], [IsApprove]) VALUES (1, N'Cash Manager', 0, CAST(0x6C3B0B00 AS Date), 1, 4, 1)
INSERT [dbo].[EmployeeRoleTable] ([EmployeeId], [EmployeeRole], [UpdateBy], [UpdateDate], [StorageCompanyId], [UserId], [IsApprove]) VALUES (2, N'Chief Cash Manager', 0, CAST(0x6C3B0B00 AS Date), 1, 6, 1)
INSERT [dbo].[EmployeeRoleTable] ([EmployeeId], [EmployeeRole], [UpdateBy], [UpdateDate], [StorageCompanyId], [UserId], [IsApprove]) VALUES (6, N'Cash Manager', 0, CAST(0x123B0B00 AS Date), 1, 7, 1)
SET IDENTITY_INSERT [dbo].[EmployeeRoleTable] OFF
SET IDENTITY_INSERT [dbo].[SecurityCheck_tbl] ON 

INSERT [dbo].[SecurityCheck_tbl] ([Id], [UserId], [SecurityQuestion], [Answer], [UpdateDate]) VALUES (1, 1, N'What is your mother fabourite pet', N'Cat', CAST(0x6E390B00 AS Date))
INSERT [dbo].[SecurityCheck_tbl] ([Id], [UserId], [SecurityQuestion], [Answer], [UpdateDate]) VALUES (3, 2, N'What is your fabourite car?', N'Toyota', CAST(0x6E390B00 AS Date))
SET IDENTITY_INSERT [dbo].[SecurityCheck_tbl] OFF
SET IDENTITY_INSERT [dbo].[StorageCompany_tbl] ON 

INSERT [dbo].[StorageCompany_tbl] ([StorageCompanyId], [CompanyName], [Website], [StorageCapacity], [StorageAvailable]) VALUES (1, N'Rahim Cold Storage', N'www.rahimcoldstorage.com', CAST(100000 AS Numeric(18, 0)), CAST(100000 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[StorageCompany_tbl] OFF
SET IDENTITY_INSERT [dbo].[User_tbl] ON 

INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (1, N'shiblycse', N'123456', N'Shibly Nomany', CAST(0x30170B00 AS Date), 2, 1, N'19916234564')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (2, N'adminpanel', N'123456', N'Shafiq Rahman', CAST(0x9D180B00 AS Date), 1, 1, N'19926232324')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (3, N'delowar123', N'123456', N'Delowar Hossain', CAST(0xC9160B00 AS Date), 2, 1, N'199016545646')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (4, N'omarratul', N'141414', N'Omar faruk', CAST(0xE21A0B00 AS Date), 3, 1, N'19932564778')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (5, N'shimul14', N'123456', N'Shimul Islam', CAST(0x553B0B00 AS Date), 2, 1, N'12412341234')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (6, N'shamol3', N'123456', N'Kamalnath Dutta', CAST(0x353B0B00 AS Date), 3, 1, N'1991623494')
INSERT [dbo].[User_tbl] ([UserId], [UserName], [Pass], [FullName], [DateOfBirth], [UserTypeId], [IsActive], [NIDNumber]) VALUES (7, N'kalim', N'11111', N'Kalim Rahman', CAST(0xFE3A0B00 AS Date), 3, 1, N'1991623221')
SET IDENTITY_INSERT [dbo].[User_tbl] OFF
INSERT [dbo].[UserType_tbl] ([UserTypeId], [UserType], [Details]) VALUES (1, N'Admin', N'Priority Very High')
INSERT [dbo].[UserType_tbl] ([UserTypeId], [UserType], [Details]) VALUES (2, N'General User', N'Priority Low')
INSERT [dbo].[UserType_tbl] ([UserTypeId], [UserType], [Details]) VALUES (3, N'Employee ', N'Priority Medium')
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
ALTER TABLE [dbo].[CropsCatagory_tbl]  WITH CHECK ADD  CONSTRAINT [FK_CropsCatagory_tbl_Crops_tbl] FOREIGN KEY([CropsId])
REFERENCES [dbo].[Crops_tbl] ([CropsId])
GO
ALTER TABLE [dbo].[CropsCatagory_tbl] CHECK CONSTRAINT [FK_CropsCatagory_tbl_Crops_tbl]
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
ALTER TABLE [dbo].[StockDetailsRecord_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockDetailsRecord_tbl_Crops_tbl] FOREIGN KEY([CropsCatagoryId])
REFERENCES [dbo].[Crops_tbl] ([CropsId])
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] CHECK CONSTRAINT [FK_StockDetailsRecord_tbl_Crops_tbl]
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockDetailsRecord_tbl_StockMasterRecordCrops_tbl] FOREIGN KEY([StockMasterRecordId])
REFERENCES [dbo].[StockMasterRecordCrops_tbl] ([StockMasterRecordId])
GO
ALTER TABLE [dbo].[StockDetailsRecord_tbl] CHECK CONSTRAINT [FK_StockDetailsRecord_tbl_StockMasterRecordCrops_tbl]
GO
ALTER TABLE [dbo].[StockMasterMainList_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockMasterMainList_tbl_StockMasterRecordCrops_tbl] FOREIGN KEY([StockMasterId])
REFERENCES [dbo].[StockMasterRecordCrops_tbl] ([StockMasterRecordId])
GO
ALTER TABLE [dbo].[StockMasterMainList_tbl] CHECK CONSTRAINT [FK_StockMasterMainList_tbl_StockMasterRecordCrops_tbl]
GO
ALTER TABLE [dbo].[StockMasterMainList_tbl]  WITH CHECK ADD  CONSTRAINT [FK_StockMasterMainList_tbl_StorageCompany_tbl] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[StorageCompany_tbl] ([StorageCompanyId])
GO
ALTER TABLE [dbo].[StockMasterMainList_tbl] CHECK CONSTRAINT [FK_StockMasterMainList_tbl_StorageCompany_tbl]
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
ALTER TABLE [dbo].[StockTempRecord]  WITH CHECK ADD  CONSTRAINT [FK_StockTempRecord_CropsCatagory_tbl] FOREIGN KEY([CropsCatagoryId])
REFERENCES [dbo].[CropsCatagory_tbl] ([CropsCatagoryId])
GO
ALTER TABLE [dbo].[StockTempRecord] CHECK CONSTRAINT [FK_StockTempRecord_CropsCatagory_tbl]
GO
ALTER TABLE [dbo].[StockTempRecord]  WITH CHECK ADD  CONSTRAINT [FK_StockTempRecord_EmployeeRoleTable] FOREIGN KEY([EmployeerId])
REFERENCES [dbo].[EmployeeRoleTable] ([EmployeeId])
GO
ALTER TABLE [dbo].[StockTempRecord] CHECK CONSTRAINT [FK_StockTempRecord_EmployeeRoleTable]
GO
ALTER TABLE [dbo].[User_tbl]  WITH CHECK ADD  CONSTRAINT [FK_User_tbl_UserType_tbl] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType_tbl] ([UserTypeId])
GO
ALTER TABLE [dbo].[User_tbl] CHECK CONSTRAINT [FK_User_tbl_UserType_tbl]
GO

