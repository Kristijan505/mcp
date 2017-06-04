CREATE TABLE Events (
    [id] INT IDENTITY (1, 1) NOT NULL,
    [text] nvarchar (250) NULL,
    [start_date] datetime NOT NULL,
    [end_date] datetime NOT NULL,
    PRIMARY KEY (id)
)
