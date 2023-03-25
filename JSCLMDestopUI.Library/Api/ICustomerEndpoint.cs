using JSCLMDestopUI.Library.Models;

namespace JSCLMDestopUI.Library.Api
{
    public interface ICustomerEndpoint
    {
        Task<List<CustomerModel>> GetAll();
        Task AddNewCustomer(CustomerModel customer);
    }
}