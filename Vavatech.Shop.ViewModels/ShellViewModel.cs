﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Vavatech.Shop.ViewModels
{
    public static class ViewNames
    {
        public const string Customers = "Customers";
        public const string Products = "Products";
    }

    public class ShellViewModel : BaseViewModel
    {
        public ICommand ShowCustomersCommand { get; private set; }
        public ICommand ShowProductsCommand { get; private set; }
        public ICommand ShowViewCommand { get; private set; }

        private readonly INavigationService navigationService;
        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            ShowCustomersCommand = new RelayCommand(ShowCustomers);
            ShowProductsCommand = new RelayCommand(ShowProducts);
            ShowViewCommand = new RelayCommand<string>(ShowView);
        }

        public void ShowCustomers()
        {
            navigationService.Navigate("Customers");
        }

        public void ShowProducts()
        {
            navigationService.Navigate("Products");
        }

        public void ShowView(string viewName)
        {
            navigationService.Navigate(viewName);
        }
    }
}
