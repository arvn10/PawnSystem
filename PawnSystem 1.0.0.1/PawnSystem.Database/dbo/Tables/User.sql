CREATE TABLE [dbo].[User] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [UserTypeID] INT           NOT NULL,
    [UserName]  NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Status]     NVARCHAR (20) NOT NULL,
    [CreatedBy] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),  
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC) 
);

