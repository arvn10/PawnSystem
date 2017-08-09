CREATE TABLE [dbo].[IdType]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL
)
