CREATE TABLE [dbo].[ItemType] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Description]          NVARCHAR (50) NOT NULL,
    [Interest]          INT    NOT NULL,
	[Penalty]           INT NOT NULL,
    [WithServiceCharge]     TINYINT  NOT NULL,
    [MonthToPenalty] INT           NOT NULL,
    [CreatedBy]         INT NOT NULL,
    [CreatedDate]       DATETIME      NOT NULL DEFAULT GETDATE(),
    [ModifiedBy]        INT NULL,
    [ModifiedDate]      DATETIME      NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED ([ID] ASC) 
);

