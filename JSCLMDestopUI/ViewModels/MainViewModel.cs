using Caliburn.Micro;
using JSCLMDestopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JSCLMDestopUI.ViewModels;

public class MainViewModel : Conductor<object>, IHandle<AddNewCustomerEvent>, IHandle<DisplayCustomerListEvent>, IHandle<CheckUserLicenceEvent>
{
    private readonly IEventAggregator _events;

    public MainViewModel(IEventAggregator events )
    {
        _events = events;
        _events.SubscribeOnUIThread(this);
        ActivateItemAsync(IoC.Get<CustomerViewModel>());
    }

    public async Task DisplayAllLicences()
    {
        await ActivateItemAsync(IoC.Get<LicenceViewModel>());
    }

    public async Task HandleAsync(AddNewCustomerEvent message, CancellationToken cancellationToken)
    {
        await ActivateItemAsync(IoC.Get<AddNewCustomerViewModel>());

        return;
    }

    public async Task HandleAsync(DisplayCustomerListEvent message, CancellationToken cancellationToken)
    {
        await ActivateItemAsync(IoC.Get<CustomerViewModel>());

        return;
    }

    public async Task HandleAsync(CheckUserLicenceEvent message, CancellationToken cancellationToken)
    {

        await ActivateItemAsync(IoC.Get<LicenceViewModel>());

        return;

    }
}
