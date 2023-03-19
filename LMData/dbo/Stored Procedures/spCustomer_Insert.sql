CREATE PROCEDURE [dbo].[spCustomer_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(150)
AS
Begin
	Insert into dbo.CustomerData (FirstName, LastName, EmailAddress)
	values (@FirstName, @LastName, @EmailAddress);
end
