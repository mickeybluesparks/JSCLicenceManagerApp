CREATE TABLE [dbo].[CustomerData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(150) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [LicenceId] INT NULL, 
    CONSTRAINT [FK_CustomerData_ToLicenceData] FOREIGN KEY ([LicenceId]) REFERENCES [dbo].[LicenceData](Id)
)
