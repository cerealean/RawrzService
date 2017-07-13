CREATE TABLE [dbo].[UserInformation] (
    [id]                        INT           IDENTITY (1, 1) NOT NULL,
    [user_id]                   INT           NOT NULL,
    [first_name]                VARCHAR (255) NOT NULL,
    [last_name]                 VARCHAR (255) NOT NULL,
    [email]                     VARCHAR (255) NOT NULL,
    [phone]                     VARCHAR (255) NOT NULL,
    [can_text]                  BIT           NOT NULL,
    [can_email]                 BIT           NOT NULL,
    [two_factor_authentication] BIT           NOT NULL,
    CONSTRAINT [PK_UserInformation] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_UserInformation_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
);

