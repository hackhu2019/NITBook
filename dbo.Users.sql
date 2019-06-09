CREATE TABLE [dbo].[Users] (
    [Id]         INT         IDENTITY  NOT NULL,
    [userName]   NVARCHAR (12) NOT NULL,
    [password]   NVARCHAR (12) NOT NULL,
    [LoginTime]  DATETIME      NULL,
    [createTIme] DATETIME      NOT NULL,
    [isAdmin]    BIT           NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

