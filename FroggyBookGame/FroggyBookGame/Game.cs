using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyBookGame
{
    class Game
    {
        private string code;
        private string name;
        private string descript;
        private double price;
        private string rating;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Descript { get => descript; set => descript = value; }
        public double Price { get => price; set => price = value; }
        public string Rating { get => rating; set => rating = value; }

        public Game() { }
        public Game(string code, string name, string descript, double price, string rating)
        {
            Code = code;
            Name = name;
            Descript = descript;
            Price = price;
            Rating = rating;
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
