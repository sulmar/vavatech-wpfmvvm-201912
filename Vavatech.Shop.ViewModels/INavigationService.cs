﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.ViewModels
{
    public interface INavigationService
    {
        void Navigate(string viewName, object parameter = null);
        void GoBack();
        void GoForward();
        object Parameter { get; }
    }
}
