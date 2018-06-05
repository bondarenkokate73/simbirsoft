CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [Player1] NCHAR(10) NULL DEFAULT PlayerOne, 
    [Player2] NCHAR(10) NULL DEFAULT PlayerTwo, 
    [KolvoHod] INT NOT NULL, 
    [Win] INT NOT NULL
)
