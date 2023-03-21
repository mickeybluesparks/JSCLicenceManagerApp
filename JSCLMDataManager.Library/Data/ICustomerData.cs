using JSCLMDataManager.Library.Models;

namespace JSCLMDataManager.Library.Data
{
    public interface ICustomerData
    {
        Task<IEnumerable<CustomerDBModel>> GetCustomers();
        Task<CustomerDBModel?> GetCustomer(int id);

        Task InsertCustomer(CustomerDBModel user);

        public Task UpdateCustomer(CustomerDBModel user);

    }
}