CREATE PROCEDURE [dbo].[spLicence_GetAll]
AS
begin
	set nocount on;

	select [Id], [StartDate], [EndDate], [LicenceType], [LastChangedDate]
	from dbo.LicenceData;

end
