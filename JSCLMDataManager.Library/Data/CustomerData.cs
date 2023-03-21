using JSCLMDataManager.Library.DbAccess;
using JSCLMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDataManager.Library.Data
{
    public class CustomerData : ICustomerData
    {
        private readonly ISqlDataAccess _db;

        public CustomerData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<CustomerDBModel>> GetCustomers() =>
            _db.LoadData<CustomerDBModel, dynamic>("spCustomer_GetAll", new { });

        public async Task<CustomerDBModel?> GetCustomer(int id)
        {
            var results = await _db.LoadData<CustomerDBModel, dynamic>(
                "spCustomer_Get", new { Id = id });

            if (results == null)
                return null;

            return results.FirstOrDefault();
        }

        public Task InsertCustomer(CustomerDBModel user) =>
            _db.SaveData("spCustomer_Insert", new { user.FirstName, user.LastName, user.EmailAddress, user.IsActive });

        public Task UpdateCustomer(CustomerDBModel user) =>
            _db.SaveData("spCustomerData_Update", user);

        //public Task DeleteCustomer(int id) =>
        //    _db.SaveData("spUser_Delete", new { Id = id });

    }
}
