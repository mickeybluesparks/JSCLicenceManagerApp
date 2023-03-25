CREATE TABLE [dbo].[LicenceData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [LicenceType] INT NOT NULL, 
    [token] NCHAR(10) NULL, 
    [LastChangedDate] DATETIME2 NULL, 
    CONSTRAINT [FK_LicenceData_ToLicenceType] FOREIGN KEY ([LicenceType]) REFERENCES [dbo].[LicenceTypes](Id) 
)
