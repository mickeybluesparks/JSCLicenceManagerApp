using JSCLMDataManager.Library.Internal.DataAccess;
using JSCLMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDataManager.Library.DataAccess
{
    public class CustomerData : ICustomerData
    {
        private readonly ISqlDataAccess _db;

        public CustomerData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<CustomerDBModel>> GetUsers() =>
            _db.LoadData<CustomerDBModel, dynamic>("spCustomer_GetAll", new { });

    }
}
