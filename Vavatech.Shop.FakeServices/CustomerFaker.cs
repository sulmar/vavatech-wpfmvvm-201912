using Vavatech.Shop.Models;
using Bogus;

namespace Vavatech.Shop.FakeServices
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Email, (f, c) => $"{c.FirstName}.{c.LastName}@vavatech.pl");

            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
        }
    }
}
