using Caliburn.Micro;
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
			}
		}

		private string _emailAddress = String.Empty;

		public string EmailAddress
		{
			get { return _emailAddress; }
			set 
			{ 
				_emailAddress = value; 
				NotifyOfPropertyChange(() => EmailAddress);
			}
		}

        public AddNewCustomerViewModel()
        {
            
        }

		public void SaveCustomer()
		{
			// save the data



			Console.WriteLine();
			// send a message to mainview to open the customer list view
		}

		public void Cancel()
		{
            // send a message to mainview to open the customer list view

        }

    }
}
