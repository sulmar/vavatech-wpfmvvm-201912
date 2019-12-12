namespace Vavatech.Shop.Models
{
    public class Product : BaseEntity
    {
        private bool isRemoved;

        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsSelected { get; set; }
        public bool IsRemoved
        {
            get => isRemoved; set
            {
                isRemoved = value;
                OnPropertyChanged();
            }
        }
        public byte[] Photo { get; set; }

        public UnitPriceLevel UnitPriceLevel
        {
            get
            {
                if (UnitPrice < 100)
                    return UnitPriceLevel.Low;
                else if (UnitPrice >= 100 && UnitPrice < 500)
                    return UnitPriceLevel.Normal;
                else
                    return UnitPriceLevel.High;
            }

        }
            
    }

    public enum UnitPriceLevel
    {
        Low,
        Normal,
        High
    }
}
