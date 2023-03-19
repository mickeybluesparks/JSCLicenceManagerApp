CREATE PROCEDURE [dbo].[spCustomerData_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(150)
AS
Begin
	update dbo.CustomerData 
	set FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
	where Id = @Id;
end
