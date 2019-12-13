using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.ViewModels
{
    public abstract class BaseViewModel : Base
    {
        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading; 
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }


        public async void Load()
        {
            IsLoading = true;
            
            await Get();

            IsLoading = false;
        }

        public virtual Task Get()
        {
            return Task.CompletedTask;
        }
         
    }
}
