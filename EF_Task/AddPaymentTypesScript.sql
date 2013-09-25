ALTER TABLE [dbo].[Payments] ADD [CardNumber] [nvarchar](16)
ALTER TABLE [dbo].[Payments] ADD [ExpDate_Month] [int]
ALTER TABLE [dbo].[Payments] ADD [ExpDate_Year] [int]
ALTER TABLE [dbo].[Payments] ADD [Account] [nvarchar](100)
ALTER TABLE [dbo].[Payments] ADD [PurseNumber] [nvarchar](12)
ALTER TABLE [dbo].[Payments] ADD [Type] [nvarchar](128)