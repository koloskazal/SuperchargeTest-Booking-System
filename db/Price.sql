USE Supercharge;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Price]') AND type in (N'U'))
CREATE TABLE [Price] (
    PriceId INT IDENTITY(1,1) NOT NULL,
    HotelId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    PriceType NVARCHAR(100),
    StartDate DATETIME,
    EndDate DATETIME,
    IsActive BIT NOT NULL,
    CreatedBy INT,
    CreatedOnUtc DATETIME,
    ModifiedBy INT,
    ModifiedOnUtc DATETIME,
    
    CONSTRAINT [PK_Price_PriceId] PRIMARY KEY CLUSTERED (PriceId),
    CONSTRAINT [FK_Price_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [Hotel]([HotelId]),
    CONSTRAINT [Price_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [Price_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId])
);
GO