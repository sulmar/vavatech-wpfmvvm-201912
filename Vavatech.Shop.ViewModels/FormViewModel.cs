using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public class FormViewModel : BaseViewModel
    {
        public FormTemplate Form { get; set; }

        public FormViewModel()
        {
            Get();
        }

        public override Task Get()
        {
            Form = new FormTemplate();

            return base.Get();
        }

    }
}
