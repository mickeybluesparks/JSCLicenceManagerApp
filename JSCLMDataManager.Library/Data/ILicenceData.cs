using JSCLMDataManager.Library.Models;

namespace JSCLMDataManager.Library.Data
{
    public interface ILicenceData
    {
        Task<IEnumerable<LicenceDBModel>> GetAll();
    }
}