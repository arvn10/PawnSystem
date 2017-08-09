CREATE TABLE [dbo].[Transaction] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
	[ClientID]         INT           NOT NULL,
    [ItemTypeID]       INT           NOT NULL,
    [AuctionDateID]    INT           NOT NULL,
	[IdTypeID] INT NOT NULL, 
    [PawnTicketNumber] NVARCHAR (50) NOT NULL,
    [TransactionType]  NVARCHAR (50) NOT NULL,
    [TicketType]       NVARCHAR (50) NOT NULL,
    [DateLoan]         DATE          NOT NULL,
    [DateMaturity]     DATE          NOT NULL,
    [DateExpiry]       DATE          NOT NULL,
    [Principal]        INT           NOT NULL,
    [Interest]         INT           NOT NULL,
    [ServiceCharge]    INT           NOT NULL,
    [NetProceed]       INT           NOT NULL,
    [Status]           NVARCHAR (50) NOT NULL,
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [PK_Transaction] PRIMARY KEY ([ID])
);

