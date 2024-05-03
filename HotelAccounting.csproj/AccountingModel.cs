using System;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Total1
        {
            get { return total; }
            set { total = price * nightsCount * (1 - discount / 100); }  
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentException();
                price = value;
                
                Notify(nameof(Total));
                Notify(nameof(Price));
            }
        }
        public int NightsCount
        {
            get { return nightsCount; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
               
                Notify(nameof(Total));
                Notify(nameof(NightsCount));
            }
        }
        public double Discount
        {
            get { return discount; }
            set
            {
                if (value > 100) throw new ArgumentException();
                discount = value;
                
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }
        public double Total
        {
            get { return total= price * nightsCount * (1 - discount / 100); ; }
            set
            {
                if (value < 0) throw new ArgumentException();
                total = value;
                discount = 100 * (1 - total / (price * nightsCount));

                Notify(nameof(Total));
                Notify(nameof(Discount));
            }
        }
    }
}
