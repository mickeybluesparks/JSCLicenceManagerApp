CREATE PROCEDURE [dbo].[spCustomer_GetAll]
AS
begin
	SELECT Id, FirstName, LastName, EmailAddress, IsActive
	from dbo.CustomerData;
end
