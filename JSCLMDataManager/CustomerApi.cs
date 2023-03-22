using JSCLMDataManager.Library.Data;
using JSCLMDataManager.Library.Models;

namespace JSCLMDataManager
{
    public static class CustomerApi
    {
        public static void ConfigureCustomerApi(this WebApplication app)
        {
            // All of my API Endpoint mapping
            app.MapGet("api/Customers", GetCustomers);
            app.MapGet("api/Customers/{id}", GetCustomer);
            app.MapPost("api/Customers", InsertCustomer);
            app.MapPut("api/Customers", UpdateCustomer);
            app.MapDelete("api/Customers", DeleteCustomer);
        }

        private static async Task<IResult> GetCustomers(ICustomerData data)
        {
            try
            {
                return Results.Ok(await data.GetCustomers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> GetCustomer(int id, ICustomerData data)
        {
            try
            {
                var results = await data.GetCustomer(id);
                if (results == null) 
                { 
                    return Results.NoContent(); 
                }

                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> InsertCustomer(CustomerDBModel Customer, ICustomerData data)
        {
            try
            {
                await data.InsertCustomer(Customer);
                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> UpdateCustomer(CustomerDBModel Customer, ICustomerData data)
        {
            try
            {
                await data.UpdateCustomer(Customer);
                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> DeleteCustomer(int id, ICustomerData data)
        {
            //try
            //{
            //    await data.DeleteCustomer(id);
            //    return Results.Ok(data);
            //}
            //catch (Exception ex)
            //{
            //    return Results.Problem(ex.Message);
            //}

            return Results.NotFound(data);
        }

    }
}
