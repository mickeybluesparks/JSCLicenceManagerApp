CREATE PROCEDURE [dbo].[spCustomer_Get]
	@Id int
AS
begin
	SELECT Id, FirstName, LastName, EmailAddress
	from dbo.CustomerData
	Where Id = @Id;
end
