USE Supercharge;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Visitor]') AND type in (N'U'))
CREATE TABLE [dbo].[Visitor] (
    VisitorId INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(300) NOT NULL,
    LastName NVARCHAR(300) NOT NULL,
    Email VARCHAR(300) NOT NULL,
    Phone NVARCHAR(15),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedBy INT,
    CreatedOnUtc DATETIME NULL DEFAULT(GETUTCDATE()),
    ModifiedBy INT,
    ModifiedOnUtc DATETIME,
    
    CONSTRAINT [PK_Visitor_VisitorId] PRIMARY KEY CLUSTERED (VisitorId),
    CONSTRAINT [FK_Visitor_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [FK_Visitor_ModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId]),
    CONSTRAINT [UQ_Visitor_Email] UNIQUE (Email)
);
GO