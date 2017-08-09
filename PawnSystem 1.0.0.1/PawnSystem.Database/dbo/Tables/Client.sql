CREATE TABLE [dbo].[Client] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [Address]       NVARCHAR (255) NOT NULL,
    [ContactNumber] NVARCHAR (50)  NOT NULL,
    [ImagePath]     TEXT           NULL,
    [CreatedBy] INT NOT NULL, 
	[CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ID] ASC)
);

