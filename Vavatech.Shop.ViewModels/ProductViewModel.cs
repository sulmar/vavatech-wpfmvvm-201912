using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        private readonly INavigationService navigationService;

        public ProductViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.Product = navigationService.Parameter as Product;
        }
    }
}
