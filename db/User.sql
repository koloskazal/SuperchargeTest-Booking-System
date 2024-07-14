--drop table User
use Supercharge;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[User]') AND type in (N'U'))
CREATE TABLE [User] (
	UserId INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(300),
	LastName NVARCHAR(300),
	Email VARCHAR(300),
	IsActive bit not null,
	CreatedBy INT,
	CreatedOnUtc DateTime,
	ModifiedBy INT,
	ModifiedOnUtc DateTime,
	
	CONSTRAINT [PK_User_UserId] PRIMARY KEY CLUSTERED (UserId),
	CONSTRAINT [User_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
	CONSTRAINT [User_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId]),
);

go