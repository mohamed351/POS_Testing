USE [POSApplicatication]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/1/2023 3:32:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[GPC] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 11/1/2023 3:32:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](150) NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/1/2023 3:32:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](500) NULL,
	[CategoryID] [int] NULL,
	[TypeID] [int] NOT NULL,
	[ProductImage] [nvarchar](150) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 11/1/2023 3:32:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[Id] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[PackageID] [int] NOT NULL,
	[ProductName] [nvarchar](500) NULL,
	[Quantity] [decimal](9, 5) NULL,
	[CodeType] [nvarchar](10) NULL,
	[ParentID] [int] NULL,
	[QuantityBase] [decimal](9, 5) NULL,
	[Code] [nvarchar](150) NULL,
	[ReferenceNumber] [nvarchar](50) NULL,
	[SalesPrice] [decimal](9, 5) NULL,
	[Cost] [decimal](9, 5) NULL,
	[IsMain] [bit] NULL,
 CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductUnitType]    Script Date: 11/1/2023 3:32:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductUnitType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductUnitType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [GPC]) VALUES (1, N'Drinks', N'10000025')
INSERT [dbo].[Category] ([ID], [Name], [GPC]) VALUES (2, N'Snakes', N'1000035')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Packages] ON 

INSERT [dbo].[Packages] ([ID], [PackageName], [TypeID]) VALUES (1, N'Unit', 1)
INSERT [dbo].[Packages] ([ID], [PackageName], [TypeID]) VALUES (2, N'Kg', 2)
INSERT [dbo].[Packages] ([ID], [PackageName], [TypeID]) VALUES (3, N'Gram', 2)
INSERT [dbo].[Packages] ([ID], [PackageName], [TypeID]) VALUES (4, N'Bastal', 1)
INSERT [dbo].[Packages] ([ID], [PackageName], [TypeID]) VALUES (5, N'Box', 1)
SET IDENTITY_INSERT [dbo].[Packages] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [ProductName], [CategoryID], [TypeID], [ProductImage]) VALUES (1, N'Pepise', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductDetails] ([Id], [ProductID], [PackageID], [ProductName], [Quantity], [CodeType], [ParentID], [QuantityBase], [Code], [ReferenceNumber], [SalesPrice], [Cost], [IsMain]) VALUES (1, 1, 1, N'Pepise -Unit', CAST(1.00000 AS Decimal(9, 5)), N'EGS', NULL, CAST(1.00000 AS Decimal(9, 5)), N'100002410', NULL, CAST(5.00000 AS Decimal(9, 5)), CAST(4.00000 AS Decimal(9, 5)), 1)
INSERT [dbo].[ProductDetails] ([Id], [ProductID], [PackageID], [ProductName], [Quantity], [CodeType], [ParentID], [QuantityBase], [Code], [ReferenceNumber], [SalesPrice], [Cost], [IsMain]) VALUES (2, 1, 4, N'Pepise -Bastal', CAST(40.00000 AS Decimal(9, 5)), N'EGS', 1, CAST(40.00000 AS Decimal(9, 5)), N'100002410', NULL, CAST(5.00000 AS Decimal(9, 5)), CAST(4.00000 AS Decimal(9, 5)), 1)
GO
SET IDENTITY_INSERT [dbo].[ProductUnitType] ON 

INSERT [dbo].[ProductUnitType] ([TypeID], [TypeName]) VALUES (1, N'Unit')
INSERT [dbo].[ProductUnitType] ([TypeID], [TypeName]) VALUES (2, N'Weight')
INSERT [dbo].[ProductUnitType] ([TypeID], [TypeName]) VALUES (3, N'Length')
SET IDENTITY_INSERT [dbo].[ProductUnitType] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductUnitType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[ProductUnitType] ([TypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductUnitType]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_Packages] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Packages] ([ID])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_Packages]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_Product]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_ProductDetails] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ProductDetails] ([Id])
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_ProductDetails]
GO
