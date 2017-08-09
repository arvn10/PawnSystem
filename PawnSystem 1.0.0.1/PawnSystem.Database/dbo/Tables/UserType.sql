CREATE TABLE [dbo].[UserType] (
    [ID] INT           IDENTITY (1, 1) NOT NULL,
    [Type]   NVARCHAR (50) NOT NULL,
    [CreatedBy] INT NOT NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

