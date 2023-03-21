CREATE PROCEDURE [dbo].[spCustomer_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(150),
	@IsActive bit
AS
Begin
	Insert into dbo.CustomerData (FirstName, LastName, EmailAddress, IsActive)
	values (@FirstName, @LastName, @EmailAddress, @IsActive);
end
