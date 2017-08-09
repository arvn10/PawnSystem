CREATE TABLE [dbo].[TransactionItem] (
    [ID] INT NOT NULL IDENTITY, 
    [TransactionID]     INT           NOT NULL,
    [Description]       NVARCHAR (255) NOT NULL,
    [CreatedBy] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),  
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_TransactionItem] PRIMARY KEY ([ID])
);

