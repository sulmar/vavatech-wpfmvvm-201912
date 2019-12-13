using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        //public bool IsLoading
        //{
        //    get => isLoading; set
        //    {
        //        isLoading = value;
        //        OnPropertyChanged();
        //    }
        //}

        public IEnumerable<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        private Customer _SelectedCustomer;
        private IEnumerable<Customer> customers;
       // private bool isLoading;

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

           // Load();
        }



        //public async void Load()
        //{
        //    IsLoading = true;
        //    Customers = await customerService.GetAsync();
        //    IsLoading = false;
        //}

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

        public override async Task Get()
        {
            Customers = await customerService.GetAsync();
        }
    }
}
