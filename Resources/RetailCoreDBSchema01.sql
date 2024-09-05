USE [RetailCore]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Address](
	[AddressId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[StreetAddress] [nvarchar](255) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Country] [nvarchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AuditLog](
	[AuditLogId] [uniqueidentifier] NOT NULL,
	[TableName] [nvarchar](100) NOT NULL,
	[Action] [nvarchar](20) NOT NULL,
	[RecordId] [uniqueidentifier] NOT NULL,
	[OldValues] [nvarchar](max) NULL,
	[NewValues] [nvarchar](max) NULL,
	[ActionDate] [datetime] NULL,
	[ActionedBy] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cart]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cart](
	[CartId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CartItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CartItem](
	[CartItemId] [uniqueidentifier] NOT NULL,
	[CartId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Quantity] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Coupon]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Coupon](
	[CouponId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DiscountPercentage] [decimal](5, 2) NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CouponId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OnlinePayment]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OnlinePayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OnlinePayment](
	[OnlinePaymentId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NULL,
	[PaymentMethod] [nvarchar](100) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionStatus] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OnlinePaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Order]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[OrderId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[OrderDate] [datetime] NULL,
	[ShippingAddressId] [uniqueidentifier] NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[ShippingCost] [decimal](18, 2) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItem](
	[OrderItemId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaymentMethod]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PaymentMethod](
	[PaymentMethodId] [uniqueidentifier] NOT NULL,
	[MethodName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permission](
	[PermissionId] [uniqueidentifier] NOT NULL,
	[PermissionName] [nvarchar](100) NOT NULL,
	[PermissionTypeId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermissionType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PermissionType](
	[PermissionTypeId] [uniqueidentifier] NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductAttribute]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductAttribute](
	[ProductAttributeId] [uniqueidentifier] NOT NULL,
	[AttributeName] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductAttributeMapping]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductAttributeMapping](
	[ProductAttributeMappingId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[ProductAttributeId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductAttributeMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryId] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductImage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductImage](
	[ProductImageId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[ImageUrl] [nvarchar](500) NOT NULL,
	[IsPrimary] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductReview]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductReview]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductReview](
	[ProductReviewId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Rating] [int] NOT NULL,
	[ReviewText] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductTag]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductTag](
	[ProductTagId] [uniqueidentifier] NOT NULL,
	[TagName] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProductTagMapping]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductTagMapping](
	[ProductTagMappingId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[ProductTagId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductTagMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Role]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[RoleLevelId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RoleLevel]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleLevel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleLevel](
	[RoleLevelId] [uniqueidentifier] NOT NULL,
	[RoleLevelName] [nvarchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RolePermission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RolePermission](
	[RolePermissionId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NULL,
	[PermissionId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RolePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Shipping]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shipping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Shipping](
	[ShippingId] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NULL,
	[Carrier] [nvarchar](100) NULL,
	[TrackingNumber] [nvarchar](100) NULL,
	[ShipmentDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ShippingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PasswordHash] [varbinary](512) NOT NULL,
	[PasswordSalt] [varbinary](512) NOT NULL,
	[IsDeleted] [bit] NULL,
	[RoleId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__User__1788CC4CC3F47D81] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__User__A9D105342178F36C] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wishlist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Wishlist](
	[WishlistId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[WishlistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WishlistProduct]    Script Date: 09/06/2024 3:17:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WishlistProduct]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WishlistProduct](
	[WishlistProductId] [uniqueidentifier] NOT NULL,
	[WishlistId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[WishlistProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Address__Address__02FC7413]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Address] ADD  DEFAULT (newid()) FOR [AddressId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Address__IsDelet__04E4BC85]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Address] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Address__Created__05D8E0BE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Address] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__AuditLog__AuditL__5E8A0973]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AuditLog] ADD  DEFAULT (newid()) FOR [AuditLogId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__AuditLog__Action__5F7E2DAC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[AuditLog] ADD  DEFAULT (getdate()) FOR [ActionDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cart__CartId__2BFE89A6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart] ADD  DEFAULT (newid()) FOR [CartId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Cart__CreatedDat__2DE6D218]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CartItem__CartIt__32AB8735]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CartItem] ADD  DEFAULT (newid()) FOR [CartItemId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__CartItem__Create__3587F3E0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CartItem] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Coupon__CouponId__503BEA1C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT (newid()) FOR [CouponId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Coupon__IsActive__51300E55]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Coupon__CreatedD__5224328E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__OnlinePay__Onlin__41EDCAC5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OnlinePayment] ADD  DEFAULT (newid()) FOR [OnlinePaymentId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__OnlinePay__Payme__43D61337]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OnlinePayment] ADD  DEFAULT (getdate()) FOR [PaymentDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__OnlinePay__Creat__44CA3770]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OnlinePayment] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__OrderId__0A9D95DB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT (newid()) FOR [OrderId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__OrderDate__0C85DE4D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__TaxAmount__0E6E26BF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [TaxAmount]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__ShippingC__0F624AF8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [ShippingCost]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__IsDeleted__10566F31]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Order__CreatedDa__114A936A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__OrderItem__Order__160F4887]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OrderItem] ADD  DEFAULT (newid()) FOR [OrderItemId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__OrderItem__Creat__18EBB532]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OrderItem] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__PaymentMe__Payme__498EEC8D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PaymentMethod] ADD  DEFAULT (newid()) FOR [PaymentMethodId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__PaymentMe__IsAct__4A8310C6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PaymentMethod] ADD  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__PaymentMe__Creat__4B7734FF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PaymentMethod] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__Permi__73BA3083]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Permission] ADD  DEFAULT (newid()) FOR [PermissionId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__IsDel__75A278F5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Permission] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__Creat__76969D2E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Permission] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__Permi__6D0D32F4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PermissionType] ADD  DEFAULT (newid()) FOR [PermissionTypeId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__IsDel__6E01572D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PermissionType] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Permissio__Creat__6EF57B66]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PermissionType] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Product__Product__403A8C7D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  DEFAULT (newid()) FOR [ProductId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Product__IsDelet__4222D4EF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Product__Created__4316F928]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductAt__Produ__32E0915F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAttribute] ADD  DEFAULT (newid()) FOR [ProductAttributeId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductAt__IsDel__33D4B598]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAttribute] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductAt__Creat__34C8D9D1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAttribute] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductAt__Produ__47DBAE45]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAttributeMapping] ADD  DEFAULT (newid()) FOR [ProductAttributeMappingId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductAt__Creat__4AB81AF0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAttributeMapping] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductCa__Produ__2C3393D0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductCategory] ADD  DEFAULT (newid()) FOR [ProductCategoryId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductCa__IsDel__2D27B809]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductCategory] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductCa__Creat__2E1BDC42]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductCategory] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductIm__Produ__56E8E7AB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductImage] ADD  DEFAULT (newid()) FOR [ProductImageId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductIm__IsPri__58D1301D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductImage] ADD  DEFAULT ((0)) FOR [IsPrimary]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductIm__Creat__59C55456]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductImage] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductRe__Produ__571DF1D5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductReview] ADD  DEFAULT (newid()) FOR [ProductReviewId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductRe__Creat__59FA5E80]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductReview] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductTa__Produ__398D8EEE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductTag] ADD  DEFAULT (newid()) FOR [ProductTagId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductTa__IsDel__3A81B327]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductTag] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductTa__Creat__3B75D760]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductTag] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductTa__Produ__4F7CD00D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductTagMapping] ADD  DEFAULT (newid()) FOR [ProductTagMappingId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__ProductTa__Creat__52593CB8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductTagMapping] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Role__RoleId__656C112C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] ADD  DEFAULT (newid()) FOR [RoleId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Role__IsDeleted__6754599E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Role__CreatedDat__68487DD7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Role] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__RoleLevel__RoleL__5EBF139D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RoleLevel] ADD  DEFAULT (newid()) FOR [RoleLevelId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__RoleLevel__IsDel__5FB337D6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RoleLevel] ADD  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__RoleLevel__Creat__60A75C0F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RoleLevel] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__RolePermi__RoleP__7B5B524B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RolePermission] ADD  DEFAULT (newid()) FOR [RolePermissionId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__RolePermi__Creat__7E37BEF6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[RolePermission] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Shipping__Shippi__3A4CA8FD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Shipping] ADD  DEFAULT (newid()) FOR [ShippingId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Shipping__Shipme__3C34F16F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Shipping] ADD  DEFAULT (getdate()) FOR [ShipmentDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Shipping__Create__3D2915A8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Shipping] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__User__UserId__25869641]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__UserId__25869641]  DEFAULT (newid()) FOR [UserId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__User__IsDeleted__267ABA7A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__IsDeleted__267ABA7A]  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__User__CreatedDat__276EDEB3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__CreatedDat__276EDEB3]  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Wishlist__Wishli__1DB06A4F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Wishlist] ADD  DEFAULT (newid()) FOR [WishlistId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Wishlist__Create__1F98B2C1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Wishlist] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__WishlistP__Wishl__245D67DE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WishlistProduct] ADD  DEFAULT (newid()) FOR [WishlistProductId]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__WishlistP__Creat__2739D489]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[WishlistProduct] ADD  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__Created__06CD04F7]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__Created__06CD04F7] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__Created__06CD04F7]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__Created__06CD04F7]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__Modifie__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__Modifie__07C12930] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__Modifie__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__Modifie__07C12930]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__UserId__03F0984C]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__UserId__03F0984C] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Address__UserId__03F0984C]') AND parent_object_id = OBJECT_ID(N'[dbo].[Address]'))
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__UserId__03F0984C]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__AuditLog__Action__607251E5]') AND parent_object_id = OBJECT_ID(N'[dbo].[AuditLog]'))
ALTER TABLE [dbo].[AuditLog]  WITH CHECK ADD  CONSTRAINT [FK__AuditLog__Action__607251E5] FOREIGN KEY([ActionedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__AuditLog__Action__607251E5]') AND parent_object_id = OBJECT_ID(N'[dbo].[AuditLog]'))
ALTER TABLE [dbo].[AuditLog] CHECK CONSTRAINT [FK__AuditLog__Action__607251E5]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__CreatedBy__2EDAF651]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__CreatedBy__2EDAF651] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__CreatedBy__2EDAF651]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__CreatedBy__2EDAF651]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__ModifiedBy__2FCF1A8A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__ModifiedBy__2FCF1A8A] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__ModifiedBy__2FCF1A8A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__ModifiedBy__2FCF1A8A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__UserId__2CF2ADDF]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__Cart__UserId__2CF2ADDF] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Cart__UserId__2CF2ADDF]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cart]'))
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__Cart__UserId__2CF2ADDF]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__CartId__339FAB6E]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([CartId])
REFERENCES [dbo].[Cart] ([CartId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__Create__367C1819]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK__CartItem__Create__367C1819] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__Create__367C1819]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK__CartItem__Create__367C1819]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__Modifi__37703C52]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK__CartItem__Modifi__37703C52] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__Modifi__37703C52]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK__CartItem__Modifi__37703C52]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__CartItem__Produc__3493CFA7]') AND parent_object_id = OBJECT_ID(N'[dbo].[CartItem]'))
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Coupon__CreatedB__531856C7]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coupon]'))
ALTER TABLE [dbo].[Coupon]  WITH CHECK ADD  CONSTRAINT [FK__Coupon__CreatedB__531856C7] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Coupon__CreatedB__531856C7]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coupon]'))
ALTER TABLE [dbo].[Coupon] CHECK CONSTRAINT [FK__Coupon__CreatedB__531856C7]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Coupon__Modified__540C7B00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coupon]'))
ALTER TABLE [dbo].[Coupon]  WITH CHECK ADD  CONSTRAINT [FK__Coupon__Modified__540C7B00] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Coupon__Modified__540C7B00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Coupon]'))
ALTER TABLE [dbo].[Coupon] CHECK CONSTRAINT [FK__Coupon__Modified__540C7B00]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OnlinePay__Creat__45BE5BA9]') AND parent_object_id = OBJECT_ID(N'[dbo].[OnlinePayment]'))
ALTER TABLE [dbo].[OnlinePayment]  WITH CHECK ADD  CONSTRAINT [FK__OnlinePay__Creat__45BE5BA9] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OnlinePay__Creat__45BE5BA9]') AND parent_object_id = OBJECT_ID(N'[dbo].[OnlinePayment]'))
ALTER TABLE [dbo].[OnlinePayment] CHECK CONSTRAINT [FK__OnlinePay__Creat__45BE5BA9]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OnlinePay__Modif__46B27FE2]') AND parent_object_id = OBJECT_ID(N'[dbo].[OnlinePayment]'))
ALTER TABLE [dbo].[OnlinePayment]  WITH CHECK ADD  CONSTRAINT [FK__OnlinePay__Modif__46B27FE2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OnlinePay__Modif__46B27FE2]') AND parent_object_id = OBJECT_ID(N'[dbo].[OnlinePayment]'))
ALTER TABLE [dbo].[OnlinePayment] CHECK CONSTRAINT [FK__OnlinePay__Modif__46B27FE2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OnlinePay__Order__42E1EEFE]') AND parent_object_id = OBJECT_ID(N'[dbo].[OnlinePayment]'))
ALTER TABLE [dbo].[OnlinePayment]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__CreatedBy__123EB7A3]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__CreatedBy__123EB7A3] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__CreatedBy__123EB7A3]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__CreatedBy__123EB7A3]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__ModifiedB__1332DBDC]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__ModifiedB__1332DBDC] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__ModifiedB__1332DBDC]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__ModifiedB__1332DBDC]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__ShippingA__0D7A0286]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ShippingAddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__UserId__0B91BA14]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__UserId__0B91BA14] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Order__UserId__0B91BA14]') AND parent_object_id = OBJECT_ID(N'[dbo].[Order]'))
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__UserId__0B91BA14]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Creat__19DFD96B]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Creat__19DFD96B] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Creat__19DFD96B]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK__OrderItem__Creat__19DFD96B]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Modif__1AD3FDA4]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK__OrderItem__Modif__1AD3FDA4] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Modif__1AD3FDA4]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK__OrderItem__Modif__1AD3FDA4]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Order__17036CC0]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__OrderItem__Produ__17F790F9]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItem]'))
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__PaymentMe__Creat__4C6B5938]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentMethod]'))
ALTER TABLE [dbo].[PaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK__PaymentMe__Creat__4C6B5938] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__PaymentMe__Creat__4C6B5938]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentMethod]'))
ALTER TABLE [dbo].[PaymentMethod] CHECK CONSTRAINT [FK__PaymentMe__Creat__4C6B5938]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__PaymentMe__Modif__4D5F7D71]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentMethod]'))
ALTER TABLE [dbo].[PaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK__PaymentMe__Modif__4D5F7D71] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__PaymentMe__Modif__4D5F7D71]') AND parent_object_id = OBJECT_ID(N'[dbo].[PaymentMethod]'))
ALTER TABLE [dbo].[PaymentMethod] CHECK CONSTRAINT [FK__PaymentMe__Modif__4D5F7D71]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Creat__778AC167]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permission]'))
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK__Permissio__Creat__778AC167] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Creat__778AC167]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permission]'))
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK__Permissio__Creat__778AC167]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Modif__787EE5A0]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permission]'))
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK__Permissio__Modif__787EE5A0] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Modif__787EE5A0]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permission]'))
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK__Permissio__Modif__787EE5A0]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Permi__74AE54BC]') AND parent_object_id = OBJECT_ID(N'[dbo].[Permission]'))
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD FOREIGN KEY([PermissionTypeId])
REFERENCES [dbo].[PermissionType] ([PermissionTypeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Creat__6FE99F9F]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissionType]'))
ALTER TABLE [dbo].[PermissionType]  WITH CHECK ADD  CONSTRAINT [FK__Permissio__Creat__6FE99F9F] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Creat__6FE99F9F]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissionType]'))
ALTER TABLE [dbo].[PermissionType] CHECK CONSTRAINT [FK__Permissio__Creat__6FE99F9F]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Modif__70DDC3D8]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissionType]'))
ALTER TABLE [dbo].[PermissionType]  WITH CHECK ADD  CONSTRAINT [FK__Permissio__Modif__70DDC3D8] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Permissio__Modif__70DDC3D8]') AND parent_object_id = OBJECT_ID(N'[dbo].[PermissionType]'))
ALTER TABLE [dbo].[PermissionType] CHECK CONSTRAINT [FK__Permissio__Modif__70DDC3D8]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Product__Categor__412EB0B6]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([ProductCategoryId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Product__Created__440B1D61]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Created__440B1D61] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Product__Created__440B1D61]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Created__440B1D61]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Product__Modifie__44FF419A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Modifie__44FF419A] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Product__Modifie__44FF419A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Modifie__44FF419A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Creat__35BCFE0A]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttribute]'))
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK__ProductAt__Creat__35BCFE0A] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Creat__35BCFE0A]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttribute]'))
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK__ProductAt__Creat__35BCFE0A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Modif__36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttribute]'))
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK__ProductAt__Modif__36B12243] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Modif__36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttribute]'))
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK__ProductAt__Modif__36B12243]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Creat__4BAC3F29]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping]  WITH CHECK ADD  CONSTRAINT [FK__ProductAt__Creat__4BAC3F29] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Creat__4BAC3F29]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping] CHECK CONSTRAINT [FK__ProductAt__Creat__4BAC3F29]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Modif__4CA06362]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping]  WITH CHECK ADD  CONSTRAINT [FK__ProductAt__Modif__4CA06362] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Modif__4CA06362]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping] CHECK CONSTRAINT [FK__ProductAt__Modif__4CA06362]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Produ__48CFD27E]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductAt__Produ__49C3F6B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductAttributeMapping]'))
ALTER TABLE [dbo].[ProductAttributeMapping]  WITH CHECK ADD FOREIGN KEY([ProductAttributeId])
REFERENCES [dbo].[ProductAttribute] ([ProductAttributeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductCa__Creat__2F10007B]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductCategory]'))
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__Creat__2F10007B] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductCa__Creat__2F10007B]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductCategory]'))
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__Creat__2F10007B]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductCa__Modif__300424B4]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductCategory]'))
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__Modif__300424B4] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductCa__Modif__300424B4]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductCategory]'))
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__Modif__300424B4]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductIm__Creat__5AB9788F]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductImage]'))
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK__ProductIm__Creat__5AB9788F] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductIm__Creat__5AB9788F]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductImage]'))
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK__ProductIm__Creat__5AB9788F]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductIm__Modif__5BAD9CC8]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductImage]'))
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK__ProductIm__Modif__5BAD9CC8] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductIm__Modif__5BAD9CC8]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductImage]'))
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK__ProductIm__Modif__5BAD9CC8]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductIm__Produ__57DD0BE4]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductImage]'))
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductRe__Creat__5AEE82B9]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK__ProductRe__Creat__5AEE82B9] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductRe__Creat__5AEE82B9]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK__ProductRe__Creat__5AEE82B9]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductRe__Modif__5BE2A6F2]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK__ProductRe__Modif__5BE2A6F2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductRe__Modif__5BE2A6F2]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK__ProductRe__Modif__5BE2A6F2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductRe__Produ__5812160E]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Creat__3C69FB99]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTag]'))
ALTER TABLE [dbo].[ProductTag]  WITH CHECK ADD  CONSTRAINT [FK__ProductTa__Creat__3C69FB99] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Creat__3C69FB99]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTag]'))
ALTER TABLE [dbo].[ProductTag] CHECK CONSTRAINT [FK__ProductTa__Creat__3C69FB99]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Modif__3D5E1FD2]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTag]'))
ALTER TABLE [dbo].[ProductTag]  WITH CHECK ADD  CONSTRAINT [FK__ProductTa__Modif__3D5E1FD2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Modif__3D5E1FD2]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTag]'))
ALTER TABLE [dbo].[ProductTag] CHECK CONSTRAINT [FK__ProductTa__Modif__3D5E1FD2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Creat__534D60F1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping]  WITH CHECK ADD  CONSTRAINT [FK__ProductTa__Creat__534D60F1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Creat__534D60F1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping] CHECK CONSTRAINT [FK__ProductTa__Creat__534D60F1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Modif__5441852A]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping]  WITH CHECK ADD  CONSTRAINT [FK__ProductTa__Modif__5441852A] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Modif__5441852A]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping] CHECK CONSTRAINT [FK__ProductTa__Modif__5441852A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Produ__5070F446]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductTa__Produ__5165187F]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductTagMapping]'))
ALTER TABLE [dbo].[ProductTagMapping]  WITH CHECK ADD FOREIGN KEY([ProductTagId])
REFERENCES [dbo].[ProductTag] ([ProductTagId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Role__CreatedBy__693CA210]') AND parent_object_id = OBJECT_ID(N'[dbo].[Role]'))
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK__Role__CreatedBy__693CA210] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Role__CreatedBy__693CA210]') AND parent_object_id = OBJECT_ID(N'[dbo].[Role]'))
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK__Role__CreatedBy__693CA210]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Role__ModifiedBy__6A30C649]') AND parent_object_id = OBJECT_ID(N'[dbo].[Role]'))
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK__Role__ModifiedBy__6A30C649] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Role__ModifiedBy__6A30C649]') AND parent_object_id = OBJECT_ID(N'[dbo].[Role]'))
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK__Role__ModifiedBy__6A30C649]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Role__RoleLevelI__66603565]') AND parent_object_id = OBJECT_ID(N'[dbo].[Role]'))
ALTER TABLE [dbo].[Role]  WITH CHECK ADD FOREIGN KEY([RoleLevelId])
REFERENCES [dbo].[RoleLevel] ([RoleLevelId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RoleLevel__Creat__619B8048]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleLevel]'))
ALTER TABLE [dbo].[RoleLevel]  WITH CHECK ADD  CONSTRAINT [FK__RoleLevel__Creat__619B8048] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RoleLevel__Creat__619B8048]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleLevel]'))
ALTER TABLE [dbo].[RoleLevel] CHECK CONSTRAINT [FK__RoleLevel__Creat__619B8048]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RoleLevel__Modif__628FA481]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleLevel]'))
ALTER TABLE [dbo].[RoleLevel]  WITH CHECK ADD  CONSTRAINT [FK__RoleLevel__Modif__628FA481] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RoleLevel__Modif__628FA481]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleLevel]'))
ALTER TABLE [dbo].[RoleLevel] CHECK CONSTRAINT [FK__RoleLevel__Modif__628FA481]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__Creat__7F2BE32F]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK__RolePermi__Creat__7F2BE32F] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__Creat__7F2BE32F]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK__RolePermi__Creat__7F2BE32F]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__Modif__00200768]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK__RolePermi__Modif__00200768] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__Modif__00200768]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK__RolePermi__Modif__00200768]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__Permi__7D439ABD]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__RolePermi__RoleI__7C4F7684]') AND parent_object_id = OBJECT_ID(N'[dbo].[RolePermission]'))
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Shipping__Create__3E1D39E1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Shipping]'))
ALTER TABLE [dbo].[Shipping]  WITH CHECK ADD  CONSTRAINT [FK__Shipping__Create__3E1D39E1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Shipping__Create__3E1D39E1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Shipping]'))
ALTER TABLE [dbo].[Shipping] CHECK CONSTRAINT [FK__Shipping__Create__3E1D39E1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Shipping__Modifi__3F115E1A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Shipping]'))
ALTER TABLE [dbo].[Shipping]  WITH CHECK ADD  CONSTRAINT [FK__Shipping__Modifi__3F115E1A] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Shipping__Modifi__3F115E1A]') AND parent_object_id = OBJECT_ID(N'[dbo].[Shipping]'))
ALTER TABLE [dbo].[Shipping] CHECK CONSTRAINT [FK__Shipping__Modifi__3F115E1A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Shipping__OrderI__3B40CD36]') AND parent_object_id = OBJECT_ID(N'[dbo].[Shipping]'))
ALTER TABLE [dbo].[Shipping]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__CreatedBy__286302EC]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__CreatedBy__286302EC] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__CreatedBy__286302EC]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__CreatedBy__286302EC]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__ModifiedBy__29572725]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__ModifiedBy__29572725] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__ModifiedBy__29572725]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__ModifiedBy__29572725]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__RoleId__2610A626]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__RoleId__2610A626] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__User__RoleId__2610A626]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__RoleId__2610A626]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__Create__208CD6FA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK__Wishlist__Create__208CD6FA] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__Create__208CD6FA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK__Wishlist__Create__208CD6FA]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__Modifi__2180FB33]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK__Wishlist__Modifi__2180FB33] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__Modifi__2180FB33]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK__Wishlist__Modifi__2180FB33]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__UserId__1EA48E88]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK__Wishlist__UserId__1EA48E88] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Wishlist__UserId__1EA48E88]') AND parent_object_id = OBJECT_ID(N'[dbo].[Wishlist]'))
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK__Wishlist__UserId__1EA48E88]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Creat__282DF8C2]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct]  WITH CHECK ADD  CONSTRAINT [FK__WishlistP__Creat__282DF8C2] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Creat__282DF8C2]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct] CHECK CONSTRAINT [FK__WishlistP__Creat__282DF8C2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Modif__29221CFB]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct]  WITH CHECK ADD  CONSTRAINT [FK__WishlistP__Modif__29221CFB] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Modif__29221CFB]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct] CHECK CONSTRAINT [FK__WishlistP__Modif__29221CFB]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Produ__2645B050]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__WishlistP__Wishl__25518C17]') AND parent_object_id = OBJECT_ID(N'[dbo].[WishlistProduct]'))
ALTER TABLE [dbo].[WishlistProduct]  WITH CHECK ADD FOREIGN KEY([WishlistId])
REFERENCES [dbo].[Wishlist] ([WishlistId])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK__ProductRe__Ratin__59063A47]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductReview]'))
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
