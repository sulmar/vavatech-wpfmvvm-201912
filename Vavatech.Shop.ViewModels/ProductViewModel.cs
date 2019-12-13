using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        }

        public override Task Get()
        {
            this.Product = navigationService.Parameter as Product;

            return base.Get();
        }
    }
}
