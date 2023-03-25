using JSCLMDestopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.EventModels
{
    public class CheckUserLicenceEvent
    {
        private readonly CustomerDisplayModel? _selectedCustomer;

        public CheckUserLicenceEvent(CustomerDisplayModel? selectedCustomer)
        {
            _selectedCustomer = selectedCustomer;
        }

    }
}
