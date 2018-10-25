CREATE TABLE [dbo].[Students] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Subjects] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [StudentID] INT            NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Student] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Students] ([Id])
);

