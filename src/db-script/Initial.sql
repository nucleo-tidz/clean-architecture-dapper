IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Product'
          AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE [dbo].[Product]
    (
        [Id] INT IDENTITY(1,1)  NOT NULL,
        [Name] NVARCHAR(max) NOT NULL,
        [Description]  NVARCHAR(max) NOT NULL,
        [Amount] Decimal(18,10),
		[Currency]  NVARCHAR(max) NOT NULL,
        CONSTRAINT PK_Product
            PRIMARY KEY (Id)
    );
END

GO

IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Order'
          AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE [dbo].[Order]
    (
        [Id] INT IDENTITY(1,1)  NOT NULL,
        [Name] NVARCHAR(max) NOT NULL,
        [Description]  NVARCHAR(max) NOT NULL,
        [OrderedBy] NVARCHAR(max) NOT NULL,
        CONSTRAINT PK_Order
            PRIMARY KEY (Id)
    );
END

GO

IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Inventory'
          AND TABLE_SCHEMA = 'dbo'
)
BEGIN
    CREATE TABLE [dbo].[Inventory]
    (
        [Id] INT IDENTITY(1,1)  NOT NULL,
        [ProductId] NVARCHAR(max) NOT NULL,
        [Quantity]  int NOT NULL,
      
        CONSTRAINT PK_Inventory
            PRIMARY KEY (Id)
    );
END

Insert Into Product values ('TV','TV',1000,'USD');
insert into Inventory values  (1,10)