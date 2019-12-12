using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public class ProductSearchCriteria : Base
    {
        private string name;
        private decimal? fromUnitPrice;
        private decimal? toUnitPrice;

        protected void OnPropertyChanged()
        {
            base.OnPropertyChanged();
            base.OnPropertyChanged(nameof(IsValid));
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public decimal? FromUnitPrice
        {
            get => fromUnitPrice; 
            set
            {
                fromUnitPrice = value;
                OnPropertyChanged();
            }
        }
        public decimal? ToUnitPrice
        {
            get => toUnitPrice; 
            set
            {
                toUnitPrice = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid => IsValidUnitPrice && IsValidName;

        private bool IsValidName => Name?.Length > 3;

        private bool IsValidUnitPrice =>
           !FromUnitPrice.HasValue || !ToUnitPrice.HasValue ||
            FromUnitPrice.HasValue && ToUnitPrice.HasValue
                    && FromUnitPrice.Value <= ToUnitPrice.Value;

    }
}
