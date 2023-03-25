CREATE PROCEDURE [dbo].[spCustomer_GetAll]
AS
begin
	set nocount on;

	SELECT Id, FirstName, LastName, EmailAddress, IsActive
	from dbo.CustomerData;
end
