using System;
using System.ComponentModel;

namespace Vavatech.Shop.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string Photo { get; set; }
        public string Email { get; set; }
        public bool IsRemoved { get; set; }
    }
}
