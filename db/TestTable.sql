--drop table TestTable
use Supercharge;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TestTable]') AND type in (N'U'))
CREATE TABLE [TestTable] (
	TestTableId INT IDENTITY(1,1) NOT NULL,
	FirstData NVARCHAR(300),
	SecondData NVARCHAR(300),
	ThirdData VARCHAR(300),
	IsActive bit not null,
	CreatedBy INT,
	CreatedOnUtc DateTime,
	ModifiedBy INT,
	ModifiedOnUtc DateTime,
	
	CONSTRAINT [PK_TestTable_TestTableId] PRIMARY KEY CLUSTERED (TestTableId),
	CONSTRAINT [TestTable_CreatedBy_FK] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User]([UserId]),
	CONSTRAINT [TestTable_ModifiedBy_FK] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User]([UserId]),
);

go