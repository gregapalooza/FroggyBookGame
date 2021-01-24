using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyBookGame
{
    class Customer
    {
        private string name;
        private List<CartItem> cart;
        private double total;


        public string Name { get => name; set => name = value; }
        public double Total { get => total; set => total = value; }
        internal List<CartItem> Cart { get => cart; set => cart = value; }

        public Customer() { }
        public Customer(string name)
        {
            this.name = name;
        }
        public Customer(string name, List<CartItem> cartItems)
        {
            this.name = name;
            this.cart = cartItems;
        }

        public Customer(string name, List<CartItem> cartItems, double total)
        {
            this.name = name;
            this.cart = cartItems;
            this.total = total;
        }

        public override string ToString()
        {
            string info = "";
            info += $"{Name} ";
            foreach(CartItem item in Cart)
            {
                info += $"{item}";
            }
            
            return info;
        }
    }
}
