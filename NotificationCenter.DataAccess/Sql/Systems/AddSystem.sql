INSERT INTO [dbo].[Systems] ([Name])
OUTPUT Inserted.Id
VALUES (@Name)