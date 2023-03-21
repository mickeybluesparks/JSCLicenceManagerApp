using JSCLMDataManager.Library.Models;

namespace JSCLMDataManager.Library.DataAccess
{
    public interface ICustomerData
    {
        Task<IEnumerable<CustomerDBModel>> GetUsers();
    }
}