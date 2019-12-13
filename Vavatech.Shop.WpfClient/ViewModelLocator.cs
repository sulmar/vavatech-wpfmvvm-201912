using Autofac;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.FakeServices;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient
{

    // Install-Package AutoFac
    public class ViewModelLocator
    {
        private IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            
            containerBuilder
                .RegisterType<FakeProductService>()
                .As<IProductService>()
                .SingleInstance();

            containerBuilder
                .RegisterType<ProductFaker>().As<Faker<Product>>();

            containerBuilder
                .RegisterType<ProductsViewModel>();

            containerBuilder
                .RegisterType<FakeCustomerService>().As<ICustomerService>();

            containerBuilder
                .RegisterType<CustomerFaker>().As<Faker<Customer>>();

            containerBuilder
                .RegisterType<CustomersViewModel>();

            containerBuilder
                .RegisterType<ShellViewModel>();

            containerBuilder
                .RegisterType<FrameNavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            containerBuilder
                .RegisterType<ProductViewModel>();

            containerBuilder
                .RegisterType<FormViewModel>();

            container = containerBuilder.Build();
        }

        public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();

        public ProductsViewModel ProductsViewModel => container.Resolve<ProductsViewModel>();

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();

        public ProductViewModel ProductViewModel =>
            container.Resolve<ProductViewModel>();

        public FormViewModel FormViewModel => container.Resolve<FormViewModel>();
    }
}
