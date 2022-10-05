﻿CREATE TABLE [dbo].[Player]
(
	[Id] INT PRIMARY KEY CLUSTERED IDENTITY(1, 1), 
	[EmailAddress] NVARCHAR(MAX) NOT NULL,
	[AccountName] NVARCHAR(MAX) NOT NULL,
	[Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);