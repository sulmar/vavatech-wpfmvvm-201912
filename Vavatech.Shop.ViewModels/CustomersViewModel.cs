using System.Collections.Generic;
using System.Diagnostics;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set
            {
                if (SelectedCustomer != null)
                {
                    SelectedCustomer.PropertyChanged -= SelectedCustomer_PropertyChanged;
                }

                _SelectedCustomer = value;
                SendCommand.OnCanExecuteChanged();

                SelectedCustomer.PropertyChanged += SelectedCustomer_PropertyChanged;

            }
        }

        private void SelectedCustomer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SendCommand.OnCanExecuteChanged();
        }

        private readonly ICustomerService customerService;

      

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

        public RelayCommand SendCommand { get; private set; }

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
