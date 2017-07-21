CREATE TABLE [dbo].[email_addresses]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [email_address] VARCHAR(255) NOT NULL, 
    [is_primary] BIT NOT NULL DEFAULT 0, 
    [is_verified] BIT NOT NULL DEFAULT 0, 
    [user_id] INT NOT NULL, 
    CONSTRAINT [FK_email_addresses_users] FOREIGN KEY ([user_id]) REFERENCES [users]([id])
)
