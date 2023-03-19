using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.ViewModels;

public class MainViewModel : Conductor<object>
{
    private readonly CustomerViewModel _customerVM;

    public MainViewModel(CustomerViewModel customerVM )
    {
        _customerVM = customerVM;

        ActivateItemAsync(_customerVM);
    }

}
