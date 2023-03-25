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
    private readonly CustomerViewModel _customerVM;
    private readonly AddNewCustomerViewModel _addNewCustomerVM;

    public MainViewModel(IEventAggregator events, CustomerViewModel customerVM, AddNewCustomerViewModel addNewCustomerVM )
    {
        _events = events;
        _customerVM = customerVM;
        _addNewCustomerVM = addNewCustomerVM;
        _events.SubscribeOnUIThread(this);
        ActivateItemAsync(_customerVM);
    }

    public Task HandleAsync(AddNewCustomerEvent message, CancellationToken cancellationToken)
    {
        ActivateItemAsync(_addNewCustomerVM);

        return Task.CompletedTask;
    }

    public Task HandleAsync(DisplayCustomerListEvent message, CancellationToken cancellationToken)
    {
        ActivateItemAsync(_customerVM);

        return Task.CompletedTask;
    }

    public Task HandleAsync(CheckUserLicenceEvent message, CancellationToken cancellationToken)
    {

        Console.WriteLine();

        return Task.CompletedTask;

    }
}
