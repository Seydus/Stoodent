CREATE TABLE [dbo].[Student] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Phone]      INT            DEFAULT ((0)) NOT NULL,
    [Address]    NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [City]       NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [DoB]        DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [Email]      NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [Gender]     NVARCHAR (MAX) NOT NULL,
    [Occupation] NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [PostCode]   INT            NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id] ASC)
);

