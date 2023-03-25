CREATE PROCEDURE [dbo].[spLicenceTypes_GetAll]
AS
begin
	set nocount on;

	select [Id], [Name]
	from dbo.LicenceTypes;
end