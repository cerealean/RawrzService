CREATE TABLE [dbo].[user_authentication] (
    [id]      INT             IDENTITY (1, 1) NOT NULL,
    [hash]    VARBINARY (MAX) NOT NULL,
    [salt]    VARBINARY (MAX) NOT NULL,
    [user_id] INT             NOT NULL,
    CONSTRAINT [PK_user_authentication] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_user_authentication_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([id])
);

