using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient.Behaviors
{

    // Install-Package Microsoft.Xaml.Behaviors.Wpf
    public class ListBoxBehavior : Behavior<ListBox>
    {

        // snippet: propdp
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ListBoxBehavior), new PropertyMetadata());

        // public ICommand Command { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;

            base.OnDetaching();
        }

        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = this.AssociatedObject.SelectedItem;

            Command?.Execute(AssociatedObject.SelectedItem);
        }
    }
}
