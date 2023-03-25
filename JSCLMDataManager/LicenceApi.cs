using JSCLMDataManager.Library.Data;

namespace JSCLMDataManager;

public static class LicenceApi
{

    public static void ConfigureLicenceApi(this WebApplication app)
    {
        // All of my API Endpoint mapping
        app.MapGet("api/Licence", GetAll);

    }

    private static async Task<IResult> GetAll(ILicenceData data)
    {
        try
        {
            return Results.Ok(await data.GetAll());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

}
