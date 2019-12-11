using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Vavatech.Shop.ViewModels;

namespace Vavatech.Shop.WpfClient
{
    public class FrameNavigationService : INavigationService
    {
        private Frame frame;

        public object Parameter { get; private set; }

        public void GoBack()
        {
            frame.GoBack();
        }

        public void GoForward()
        {
            frame.GoForward();
        }

        public void Navigate(string viewName, object parameter = null)
        {
            if (frame==null)
            {
                frame = Get("ContentFrame");
            }

            Uri uri = new Uri($"Views/{viewName}View.xaml", UriKind.Relative);

            frame.Navigate(uri, parameter);

            this.Parameter = parameter;
        }

        private Frame Get(string name)
        {
            if (Application.Current.MainWindow.FindName(name) is Frame frame)
            {
                return frame;
            }

            throw new KeyNotFoundException(name);
        }
    }
}
