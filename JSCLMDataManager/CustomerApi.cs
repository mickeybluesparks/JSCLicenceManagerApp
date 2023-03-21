﻿using JSCLMDataManager.Library.DataAccess;
using JSCLMDataManager.Library.Models;

namespace JSCLMDataManager
{
    public static class CustomerApi
    {
        public static void ConfigureCustomerApi(this WebApplication app)
        {
            // All of my API Endpoint mapping
            app.MapGet("/Customers", GetCustomers);
            app.MapGet("/Customers/{id}", GetCustomer);
            app.MapPost("/Customers", InsertCustomer);
            app.MapPut("/Customers", UpdateCustomer);
            //app.MapDelete("/Users", DeleteCustomer);
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
                if (results == null) { return Results.NoContent(); }
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> InsertCustomer(CustomerDBModel user, ICustomerData data)
        {
            try
            {
                await data.InsertCustomer(user);
                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> UpdateCustomer(CustomerDBModel user, ICustomerData data)
        {
            try
            {
                await data.UpdateCustomer(user);
                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        //private static async Task<IResult> DeleteCustomer(int id, ICustomerData data)
        //{
        //    try
        //    {
        //        await data.DeleteCustomer(id);
        //        return Results.Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}

    }
}