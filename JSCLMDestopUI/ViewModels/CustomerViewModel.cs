﻿using AutoMapper;
using Caliburn.Micro;
using JSCLMDestopUI.Library.Api;
using JSCLMDestopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.ViewModels;

public class CustomerViewModel : Screen
{
    private BindingList<CustomerDisplayModel>? _customers;

    private readonly ICustomerEndpoint _customerEndpoint;
    private readonly IMapper _mapper;

    public BindingList<CustomerDisplayModel>? Customers
    {
        get { return _customers; }
        set
        {
            _customers = value;
            NotifyOfPropertyChange(() => Customers);
        }
    }

    public CustomerViewModel(ICustomerEndpoint customerEndpoint, IMapper mapper)
    {
        _customerEndpoint = customerEndpoint;
        _mapper = mapper;
        _customers = null;
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
}
