using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyBookGame
{
    class Book
    {
        private string code;
        private string name;
        private double price;
        private string descript;
        private string author;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Descript { get => descript; set => descript = value; }
        public double Price { get => price; set => price = value; }
        public string Author { get => author; set => author = value; }

        public Book() { }

        public Book(string code, string name,  string descript, double price, string author)
        {
            Code = code;
            Name = name;
            Descript = descript;
            Price = price;
            Author = author;
        }

        public override string ToString()
        {
            string info = "";
            info += $" {code} ";
            info += $" {name} ";

            return info;
        }
    }
}
