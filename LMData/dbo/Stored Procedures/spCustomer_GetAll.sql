CREATE PROCEDURE [dbo].[spCustomer_GetAll]
AS
begin
	SELECT Id, FirstName, LastName, EmailAddress
	from dbo.CustomerData;
end
