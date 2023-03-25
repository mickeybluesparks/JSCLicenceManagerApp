using JSCLMDataManager.Library.DbAccess;
using JSCLMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDataManager.Library.Data;

public class LicenceData : ILicenceData
{

    private readonly ISqlDataAccess _db;

    public LicenceData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<LicenceDBModel>> GetAll() =>
        _db.LoadData<LicenceDBModel, dynamic>("spLicence_GetAll", new { });

}
