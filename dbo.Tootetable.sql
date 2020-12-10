CREATE TABLE [dbo].[Tootetable] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [ToodeNimetus] VARCHAR (50) NULL,
    [Kogus]        INT          NULL,
    [Hind]         REAL         NULL,
	[Pilt] VARCHAR(50) NULL,
	[Kategooria_Id] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
	FOREIGN KEY([Kategooria_Id]) REFERENCES [dbo].[Kategooria_Id] ([Id])
);

