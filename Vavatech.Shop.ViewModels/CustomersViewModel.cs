using System;
using System.Collections.Generic;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        private readonly ICustomerService customerService;

        public CustomersViewModel()
            : this(new FakeCustomerService(new CustomerFaker()))
        {

        }

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Load();
        }

        private void Load()
        {
            Customers = customerService.Get();
        }
    }
}
