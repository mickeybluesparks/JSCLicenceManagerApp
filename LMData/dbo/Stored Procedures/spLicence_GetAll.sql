CREATE PROCEDURE [dbo].[spLicence_GetAll]
AS
begin
	set nocount on;

	select l.[Id], l.[StartDate], l.[EndDate], t.[Name], l.[LastChangedDate]
	from dbo.LicenceData l
	Inner Join dbo.LicenceTypes t on l.LicenceType = t.Id;

end
