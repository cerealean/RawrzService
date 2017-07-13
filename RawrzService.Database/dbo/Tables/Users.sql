CREATE TABLE [dbo].[Users] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [username]  VARCHAR (100) NOT NULL,
    [is_active] BIT           NOT NULL,
	[first_name]                VARCHAR (255) NOT NULL,
    [last_name]                 VARCHAR (255) NOT NULL,
    [email]                     VARCHAR (255) NOT NULL,
    [phone]                     VARCHAR (255) NOT NULL,
    [can_text]                  BIT           NOT NULL,
    [can_email]                 BIT           NOT NULL,
    [two_factor_authentication] BIT           NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC)
);

