using Vavatech.Shop.Models;
using Bogus;

namespace Vavatech.Shop.FakeServices
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => f.Finance.Amount(10, 1000));
            Ignore(p => p.IsSelected);
            Ignore(p => p.Photo);
        }
    }
}
