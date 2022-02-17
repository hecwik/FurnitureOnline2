CREATE TABLE [Shipping] (
  [Id] int identity,
  [Name] varchar(100),
  [Price] float,
  [Specification] float
  PRIMARY KEY ([id])
);

CREATE TABLE [Category] (
  [Id] int identity,
  [Name] varchar(100)
  PRIMARY KEY ([id])
);

CREATE TABLE [Payment] (
  [id] int identity,
  [Method] varchar(100),
  [Specification] varchar(250),
  PRIMARY KEY ([id])
);

CREATE TABLE [ShoppingCart] (
  [Id] int identity,
  [AmountOfItems] int,
  [ProductsId] int,
  PRIMARY KEY ([Id])
);

CREATE TABLE [Customer] (
  [Id] int identity,
  [FirstName] varchar(50),
  [LastName] varchar(50),
  [Adress] varchar(50),
  [ZipCode] varchar(5),
  [City] varchar(50),
  [Email] nvarchar(50) UNIQUE,
  [PhoneNumber] nvarchar(20),
  [IdNumber] varchar(12),
  [UserName] nvarchar(50) UNIQUE,
  [Password] nvarchar(50),
  [Membership] bit,
  PRIMARY KEY ([Id])
);

CREATE TABLE [Products] (
  [Id] int identity,
  [Name] varchar(100),
  [CurrentPrice] float,
  [CategoryId] int,
  [SupplierId] int,
  [ChosenItem] bit,
  [stockUnit] int,
  [Description] text,
  [Color] varchar(30),
  [Material] varchar(30),
  [ArticleNr] int UNIQUE,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_Products.CategoryId]
    FOREIGN KEY ([CategoryId])
      REFERENCES [Category]([Id])
);

CREATE TABLE [OrderHistory] (
  [Id] int identity,
  [CustomerId] int,
  [TotalAmount] float,
  [PaymentId] int,
  [ShippingId] int,
  [OrderDate] datetime2,
  [ShippingAdress] varchar(50),
  [ShippingZipCode] varchar(5),
  [ShippingCity] varchar(50),
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_OrderHistory.ShippingId]
    FOREIGN KEY ([ShippingId])
      REFERENCES [Shipping]([Id]),
  CONSTRAINT [FK_OrderHistory.CustomerId]
    FOREIGN KEY ([CustomerId])
      REFERENCES [Customer]([Id]),
  CONSTRAINT [FK_OrderHistory.PaymentId]
    FOREIGN KEY ([PaymentId])
      REFERENCES [Payment]([id])
);

CREATE TABLE [OrderDetail] (
  [Id] int identity,
  [OrderId] int,
  [ProductId] int,
  [Quantity] int,
  [Price] float,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_OrderDetail.OrderId]
    FOREIGN KEY ([OrderId])
      REFERENCES [OrderHistory]([Id]),
  CONSTRAINT [FK_OrderDetail.ProductId]
    FOREIGN KEY ([ProductId])
      REFERENCES [Products]([Id])
);

CREATE TABLE [Supplier] (
  [Id] int identity,
  [Name] varchar(100),
  [City] varchar(100),
  [Adress] varchar(50),
  [ZipCode] varchar(50),
  [InStock] bit,
  PRIMARY KEY ([Id]),
);