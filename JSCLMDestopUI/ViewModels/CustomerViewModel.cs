using AutoMapper;
using Caliburn.Micro;
using JSCLMDestopUI.EventModels;
using JSCLMDestopUI.Library.Api;
using JSCLMDestopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.ViewModels;

public class CustomerViewModel : Screen
{
    private BindingList<CustomerDisplayModel>? _customers;

    private readonly ICustomerEndpoint _customerEndpoint;
    private readonly IMapper _mapper;
    private readonly IEventAggregator _events;

    public BindingList<CustomerDisplayModel>? Customers
    {
        get { return _customers; }
        set
        {
            _customers = value;
            NotifyOfPropertyChange(() => Customers);
        }
    }

    private CustomerDisplayModel? _selectedCustomer;

    public CustomerDisplayModel? SelectedCustomer
    {
        get { return _selectedCustomer; }
        set 
        { 
            _selectedCustomer = value; 
            NotifyOfPropertyChange(() => SelectedCustomer);
            NotifyOfPropertyChange(() => CanCheckLicence);
            NotifyOfPropertyChange(() => CanEditCustomer);

        }
    }

    public bool CanCheckLicence
    {
        get
        {
            if (SelectedCustomer == null)
            {
                return false;
            }

            return true;
        }
    }

    public bool CanEditCustomer
    {
        get
        {
            if (SelectedCustomer == null)
            {
                return false;
            }

            return true;
        }
    }

    public CustomerViewModel(ICustomerEndpoint customerEndpoint, IMapper mapper, IEventAggregator events)
    {
        _customerEndpoint = customerEndpoint;
        _mapper = mapper;
        _events = events;
        _customers = null;
        _selectedCustomer = null;
    }

    protected override async void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);

        await LoadCustomers();
    }

    private async Task LoadCustomers()
    {
        var customerList = await _customerEndpoint.GetAll();
        var customers = _mapper.Map<List<CustomerDisplayModel>>(customerList);
        Customers = new BindingList<CustomerDisplayModel>(customers);

    }

    public async void AddNewCustomer()
    {
        // send a message to the main view to load a new screen

        await _events.PublishOnUIThreadAsync(new AddNewCustomerEvent());
    }

    public async void CheckLicence()
    {
        // send a message to the main view to load the licence screen for the selected user

        await _events.PublishOnUIThreadAsync(new CheckUserLicenceEvent(SelectedCustomer));

    }

    public async void EditCustomer()
    {


    }
}
