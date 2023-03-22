using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.Library.Api;

public class ApiHelper : IApiHelper
{
    private HttpClient _apiClient;


    public HttpClient ApiClient { get => _apiClient; }

    public ApiHelper()
    {
        string api = ConfigurationManager.AppSettings["api"];

        _apiClient = new HttpClient();
        _apiClient.BaseAddress = new Uri(api);
        _apiClient.DefaultRequestHeaders.Accept.Clear();
        _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    }
}
