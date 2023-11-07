-- Bang AdminUser
CREATE TABLE [dbo].[AdminUser] (
    [ID]           INT     IDENTITY (1, 1) NOT NULL,
    [NameUser]     NVARCHAR (500) NULL,
    [AccountUser]  NVARCHAR (250) NULL,
    [PasswordUser] NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
--Bang Category
CREATE TABLE [dbo].[Category] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IDCate]   NVARCHAR (20)  NOT NULL,
    [NameCate] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([IDCate] ASC)
);
--Bang Customer
CREATE TABLE [dbo].[Customer] (
    [IDCus]    INT            IDENTITY (1, 1) NOT NULL,
    [NameCus]  	NVARCHAR (500) NULL,
    [AccountCus]  NVARCHAR (250) NULL,
    [PassCus]  	NVARCHAR (250) NULL,
    [Gender]	BIT	   NULL,
    [PhoneCus] 	NVARCHAR (15)  NULL,
    [EmailCus] 	NVARCHAR (250) NULL,
    [Address]	NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([IDCus] ASC)
);
--Bang Products
CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [NamePro]       NVARCHAR (MAX)  NULL,
    [DecriptionPro] NVARCHAR (MAX)  NULL,
    [Category]      NVARCHAR (20)   NULL,
    [Price]         DECIMAL (19, 4) NULL,
    [ImagePro]      NVARCHAR (MAX)  NULL,
    [Quantity]      INT        	NULL,
	[Status]		NVARCHAR(MAX)	NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Pro_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([IDCate])
);
--Bang OrderPro
CREATE TABLE [dbo].[OrderPro] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DateOrder]        DATETIME       NULL,
    [IDCus]            INT            NULL,
    [NameCus]          NVARCHAR (250) NULL,
    [PhoneCus]	     NVARCHAR (15)  NULL,
    [AddressDeliverry] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDCus]) REFERENCES [dbo].[Customer] ([IDCus])
);
--Bang OrderDetail
CREATE TABLE [dbo].[OrderDetail] (
    [ID]        INT        	IDENTITY (1, 1) NOT NULL,
    [IDProduct] INT        	NULL,
    [NamePro]   NVARCHAR (MAX)NULL,
    [IDOrder]   INT        	NULL,
    [Quantity]  INT        	NULL,
    [UnitPrice] FLOAT (53) 	NULL,
	[Size]		VARCHAR (10)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDProduct]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([IDOrder]) REFERENCES [dbo].[OrderPro] ([ID])
);

