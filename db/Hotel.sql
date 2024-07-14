USE Supercharge;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel]') AND type in (N'U'))
CREATE TABLE [Hotel] (
    HotelId INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(300) NOT NULL,
    [Address] NVARCHAR(500),
    IsActive BIT NOT NULL,
    CreatedBy INT,
    CreatedOnUtc DATETIME,
    ModifiedBy INT,
    ModifiedOnUtc DATETIME,
    
    CONSTRAINT [PK_Hotel_HotelId] PRIMARY KEY CLUSTERED (HotelId),
    CONSTRAINT [Hotel_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [Hotel_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId])
);
GO