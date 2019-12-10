using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        private readonly ICustomerService customerService;

        public CustomersViewModel()
            : this(new FakeCustomerService(new CustomerFaker()))
        {

        }

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            SendCommand = new RelayCommand(Send, CanSend);

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
        }

        public ICommand SendCommand { get; private set; }

        public void Send()
        {
            Trace.WriteLine($"Sending email to {SelectedCustomer.Email}");
        }

        public bool IsSelectedCustomer => SelectedCustomer != null;

        public bool CanSend()
        {
            return IsSelectedCustomer 
                && !string.IsNullOrEmpty(SelectedCustomer.Email);
        }

    }
}
