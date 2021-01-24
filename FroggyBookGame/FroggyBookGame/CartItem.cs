using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyBookGame
{
    class CartItem
    {
        private string code;
        private string name;
        private double price;
        private int qty;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }

        public CartItem() { }
        public CartItem(string code, string name, double price, int qty)
        {
            Code = code;
            Name = name;
            Price = price;
            Qty = qty;
        }

        public override string ToString()
        {
            string info = "";
            info += $"{Code} ";
            info += $"{Name} ";
            info += $"{Price} ";
            info += $"{Qty} ";

            return info;
        }
    }
}
