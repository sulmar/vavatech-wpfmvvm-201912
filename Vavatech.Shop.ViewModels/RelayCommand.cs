using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Vavatech.Shop.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();

            //if (execute!=null)
            //{
            //    execute.Invoke();
            //}
        }
    }
}
