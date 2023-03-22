﻿using JSCLMDestopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.Library.Api;

public class CustomerEndpoint : ICustomerEndpoint
{
    private IApiHelper _apiHelper;

    public CustomerEndpoint(IApiHelper apiHelper)
    {
        _apiHelper = apiHelper;

    }

    public async Task<List<CustomerModel>> GetAll()
    {
        using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Customers"))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<CustomerModel>>();

                return result;
            }
            else
            {
                throw new Exception($"{response.ReasonPhrase}");
            }
        }
    }

}
