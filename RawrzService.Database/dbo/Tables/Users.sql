CREATE TABLE [dbo].[Users] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [username]  VARCHAR (100) NOT NULL,
    [is_active] BIT           NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC)
);

