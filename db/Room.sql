USE Supercharge;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Room]') AND type in (N'U'))
CREATE TABLE [Room] (
    RoomId INT IDENTITY(1,1) NOT NULL,
    HotelId INT NOT NULL,
    PriceId INT NOT NULL,
    RoomNumber NVARCHAR(50),
    [Type] NVARCHAR(100),
	NumberOfPlaces INT NOT NULL,
    [Description] NVARCHAR(1000),
    IsActive BIT NOT NULL,
    CreatedBy INT,
    CreatedOnUtc DATETIME,
    ModifiedBy INT,
    ModifiedOnUtc DATETIME,
    
    CONSTRAINT [PK_Room_RoomId] PRIMARY KEY CLUSTERED (RoomId),
    CONSTRAINT [FK_Room_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [Hotel]([HotelId]),
    CONSTRAINT [FK_Room_Price] FOREIGN KEY ([PriceId]) REFERENCES [Price]([PriceId]),
    CONSTRAINT [Room_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [Room_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId])
);
GO