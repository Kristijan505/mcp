CREATE TABLE [dbo].[Events] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [text]       NVARCHAR (250) NULL,
    [start_date] DATETIME       NOT NULL,
    [end_date]   DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);