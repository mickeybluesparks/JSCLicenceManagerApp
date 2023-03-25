using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDataManager.Library.Models;

public class LicenceDBModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime LastChangedDate { get; set; }
}
