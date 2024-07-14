USE [Supercharge]
GO

INSERT INTO [dbo].[User]([FirstName],[LastName],[Email],[IsActive],[CreatedBy],[CreatedOnUtc],[ModifiedBy],[ModifiedOnUtc])
		   VALUES ('Kolos','Kazal','koloskazal@gmail.com',1,1,GETUTCDATE(),1,GETUTCDATE());
INSERT INTO [dbo].[User]([FirstName],[LastName],[Email],[IsActive],[CreatedBy],[CreatedOnUtc],[ModifiedBy],[ModifiedOnUtc])
		   VALUES ('Jakab','Gipsz','jakabGipsz@gmail.com',1,1,GETUTCDATE(),1,GETUTCDATE());
GO


