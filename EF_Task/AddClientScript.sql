CREATE TABLE [dbo].[Clients] (
    [ID] [int] NOT NULL IDENTITY,
    [Login] [nvarchar](50),
    [FIO] [nvarchar](100),
    CONSTRAINT [PK_dbo.Clients] PRIMARY KEY ([ID])
)
INSERT INTO dbo.Clients ([Login],[FIO]) VALUES ('ANONYM','Anonymous client')
ALTER TABLE [dbo].[Payments] ADD [Client] [int] NOT NULL DEFAULT 0
UPDATE dbo.Payments SET Client = (SELECT ID FROM dbo.Clients WHERE Login = 'ANONYM')
ALTER TABLE [dbo].[Payments] ADD CONSTRAINT [FK_dbo.Payments_dbo.Clients_Client] FOREIGN KEY ([Client]) REFERENCES [dbo].[Clients] ([ID]) ON DELETE CASCADE
CREATE INDEX [IX_Client] ON [dbo].[Payments]([Client])
