INSERT INTO [dbo].[Notifications] ([SystemId], [Message])
OUTPUT Inserted.Id
VALUES (@SystemId, @Message)