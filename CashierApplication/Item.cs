using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemNamespace
{
    public class Item
    {
        public string ItemName { get; }
        public double ItemPrice { get; }
        public int ItemQuantity { get; }
        public double TotalPrice { get;  set; }

        public Item(string name, double price, int quantity)
        {
            ItemName = name;
            ItemPrice = price;
            ItemQuantity = quantity;
            TotalPrice = CalculateTotalPrice();
        }

        public double CalculateTotalPrice()
        {
            return ItemPrice * ItemQuantity;
        }

        public void SetPayment(double amount)
        {
        }
    }

    public class DiscountedItem : Item
    {
        public double ItemDiscount { get; }
        public double DiscountedPrice { get;  set; }
        public double PaymentAmount { get;  set; }
        public double Change { get;  set; }

        public DiscountedItem(string name, double price, int quantity, double discount)
            : base(name, price, quantity)
        {
            ItemDiscount = discount;
            DiscountedPrice = CalculateDiscountedPrice();
        }

        public double CalculateDiscountedPrice()
        {
            return ItemPrice * (1 - (ItemDiscount * 0.01));
        }

        public void SetPayment(double amount)
        {
            PaymentAmount = amount;
            CalculateChange();
        }

        private void CalculateChange()
        {
            Change = PaymentAmount - TotalPrice;
        }

        public  double CalculateTotalPrice()
        {
            return DiscountedPrice * ItemQuantity;
        }

        public double GetChange()
        {
            return Change;
        }
    }
}
