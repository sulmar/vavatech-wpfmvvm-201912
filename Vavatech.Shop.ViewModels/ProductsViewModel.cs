using System.Collections.Generic;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public ICommand ShowSelectedProductCommand { get; private set; }

        private readonly IProductService productService;
        private readonly INavigationService navigationService;

        public ProductsViewModel(
            IProductService productService,
            INavigationService navigationService)
        {
            this.productService = productService;
            this.navigationService = navigationService;

            ShowSelectedProductCommand = new RelayCommand(ShowSelectedProduct);

            Load();
        }

        private void Load()
        {
            Products = productService.Get();
        }


        private void ShowSelectedProduct()
        {
            ShowProduct(SelectedProduct);
        }
        private void ShowProduct(Product product)
        {
            navigationService.Navigate("Product", product);   
        }
    }
}
