using System.Collections.Generic;
using System.Windows.Input;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private IEnumerable<Product> _Products;
        public IEnumerable<Product> Products
        {
            get => _Products;
            set
            {
                _Products = value;

                OnPropertyChanged();
            }
        }

        public Product SelectedProduct { get; set; }
        public ProductSearchCriteria Criteria { get; set; }
        public ICommand ShowSelectedProductCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }

        private readonly IProductService productService;
        private readonly INavigationService navigationService;

        public ProductsViewModel(
            IProductService productService,
            INavigationService navigationService)
        {
            this.productService = productService;
            this.navigationService = navigationService;

            ShowSelectedProductCommand = new RelayCommand(ShowSelectedProduct);

            SearchCommand = new RelayCommand(Search, CanSearch);

            Criteria = new ProductSearchCriteria();

            Criteria.PropertyChanged += Criteria_PropertyChanged;

            Load();
        }

        private void Criteria_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           SearchCommand.OnCanExecuteChanged();

            if (SearchCommand.CanExecute(null))
            {
                SearchCommand.Execute(null);
            }
        }

        private void Load()
        {
        }


        private void ShowSelectedProduct()
        {
            ShowProduct(SelectedProduct);
        }
        private void ShowProduct(Product product)
        {
            navigationService.Navigate("Product", product);   
        }

        private void Search()
        {
            Products = productService.Get(Criteria);
        }

        private bool CanSearch() => Criteria.IsValid;
    }
}
