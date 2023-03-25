using Caliburn.Micro;
using JSCLMDestopUI.EventModels;
using JSCLMDestopUI.Library.Api;
using JSCLMDestopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCLMDestopUI.ViewModels
{
    public class AddNewCustomerViewModel : Screen
    {
        private string _firstName = string.Empty;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;

                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSaveCustomer);
            }
        }

        private string _lastName = String.Empty;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSaveCustomer);
            }
        }

        private string _emailAddress = String.Empty;
        private readonly ICustomerEndpoint _customerEndpoint;
        private readonly IEventAggregator _events;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanSaveCustomer);
            }
        }

        public AddNewCustomerViewModel(ICustomerEndpoint customerEndpoint, IEventAggregator events)
        {
            _customerEndpoint = customerEndpoint;
            _events = events;
        }

        public bool CanSaveCustomer
        {
            get
            {
                if (String.IsNullOrEmpty(_firstName) || String.IsNullOrWhiteSpace(_firstName) ||
                        String.IsNullOrEmpty(_lastName) || String.IsNullOrWhiteSpace(_lastName) ||
                        String.IsNullOrEmpty(_emailAddress) || String.IsNullOrEmpty(_emailAddress))
                {
                    return false;
                }

                return true;
            }
        }

        public async void SaveCustomer()
        {
            // save the data

            CustomerModel data = new CustomerModel
            {
                FirstName = _firstName,
                LastName = _lastName,
                EmailAddress = _emailAddress,
                IsActive = true,
            };

            await _customerEndpoint.AddNewCustomer(data);

            // send a message to mainview to open the customer list view
            await _events.PublishOnUIThreadAsync(new DisplayCustomerListEvent());

        }

        public void Cancel()
        {
            // send a message to mainview to open the customer list view

        }

    }
}
