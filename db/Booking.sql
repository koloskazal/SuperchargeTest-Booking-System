USE Supercharge;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Booking]') AND type in (N'U'))
CREATE TABLE [dbo].[Booking] (
    BookingId INT IDENTITY(1,1) NOT NULL,
    VisitorId INT NOT NULL,
    RoomId INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    CreatedBy INT,
    CreatedOnUtc DATETIME NOT NULL DEFAULT(GETUTCDATE()),
    ModifiedBy INT,
    ModifiedOnUtc DATETIME,
    
    CONSTRAINT [PK_Booking_BookingId] PRIMARY KEY CLUSTERED (BookingId),
    CONSTRAINT [FK_Booking_Visitor] FOREIGN KEY ([VisitorId]) REFERENCES [dbo].[Visitor]([VisitorId]),
    CONSTRAINT [FK_Booking_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room]([RoomId]),
    CONSTRAINT [Booking_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [Booking_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId])
);
GO