using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Vavatech.Shop.ViewModels
{

    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            execute?.Invoke((T)parameter);
        }
    }

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

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

          /* .NET Framework
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequestSuggested += value;
            }

            remove
            {
                CommandManager.RequestSuggested -= value;
            }
        }

    */


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
