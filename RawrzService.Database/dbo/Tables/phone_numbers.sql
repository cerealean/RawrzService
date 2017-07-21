CREATE TABLE [dbo].[phone_numbers]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [phone_number] VARCHAR(12) NOT NULL, 
    [phone_type_id] INT NOT NULL, 
    [can_text] BIT NOT NULL DEFAULT 0, 
    [is_verified] BIT NOT NULL DEFAULT 0, 
    [is_primary] BIT NOT NULL DEFAULT 0, 
    [user_id] INT NOT NULL, 
    CONSTRAINT [FK_phone_numbers_users] FOREIGN KEY ([user_id]) REFERENCES [users]([id]), 
    CONSTRAINT [FK_phone_numbers_phone_types] FOREIGN KEY ([phone_type_id]) REFERENCES [phone_types]([id])
)
