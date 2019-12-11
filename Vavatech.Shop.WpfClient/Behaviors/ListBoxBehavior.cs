using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient.Behaviors
{

    // Install-Package Microsoft.Xaml.Behaviors.Wpf
    public class ListBoxBehavior : Behavior<ListBox>
    {
        public ICommand Command { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
        }

        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = this.AssociatedObject.SelectedItem;

            Command?.Execute(AssociatedObject.SelectedItem);
        }
    }
}
