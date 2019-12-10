using System.Collections.Generic;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        private readonly IProductService productService;

        public ProductsViewModel()
            : this(new FakeProductService(new ProductFaker()))
        {

        }

        public ProductsViewModel(IProductService productService)
        {
            this.productService = productService;

            Load();
        }

        private void Load()
        {
            Products = productService.Get();
        }
    }
}
