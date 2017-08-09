CREATE TABLE [dbo].[AuctionDate] (
    [ID] INT  IDENTITY (1, 1) NOT NULL,
    [Date]   DATE NOT NULL,
    [ItemFrom]     DATE NOT NULL,
    [ItemTo]       DATE NOT NULL,
    [CreatedBy] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),  
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Auction] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
