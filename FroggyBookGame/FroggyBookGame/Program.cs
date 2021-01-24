using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroggyBookGame
{
    class Program
    {
        static void Main(string[] args)
        {
            char response;
            Customer customer = new Customer();
            List<Book> books = new List<Book>();
            List<Game> games = new List<Game>();
            List<CartItem> cart = new List<CartItem>();

            Console.WriteLine("Welcome!");
            Console.WriteLine("what is your name?");
            string name = Console.ReadLine();
            customer.Name = name;
            customer.Cart = new List<CartItem>();
            Console.WriteLine($"Welcome {customer.Name}\n");

            Console.WriteLine("Books avaiable");
            ProcessBookFile(books);
            foreach(Book i in books)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("***********************");
            Console.WriteLine("Games avaiable");
            ProcessGameFile(games);
            foreach (Game j in games)
            {
                Console.WriteLine(j);
            }

            do
            {
                Console.WriteLine("Which would you like?");
                string product = Console.ReadLine().ToUpper();

                if (books.Find(x => x.Code == product) != null)
                {
                    CartItem cartItems = new CartItem();
                    int i = books.FindIndex(x => x.Code == product);
                    Console.WriteLine($"You chose {books[i]}. How many would you like?");
                    int j = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Oty: {j}\nItem: {books[i].Name}\nPrice: {books[i].Price:c}\nSubTotal: {books[i].Price * j:c}\n");
                    cartItems.Code = books[i].Code;
                    cartItems.Name = books[i].Name;
                    cartItems.Price = books[i].Price;
                    cartItems.Qty = j;
                    cart.Add(cartItems);
                }
                else if (games.Find(x => x.Code == product) != null)
                {
                    CartItem cartItems = new CartItem();
                    int i = games.FindIndex(x => x.Code == product);
                    Console.WriteLine($"You chose {games[i]}. How many would you like?");
                    int j = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Oty: {j}\nItem: {games[i].Name}\nPrice: {games[i].Price:c}\nSubTotal: {games[i].Price * j:c}\n");
                    cartItems.Code = games[i].Code;
                    cartItems.Name = games[i].Name;
                    cartItems.Price = games[i].Price;
                    cartItems.Qty = j;
                    cart.Add(cartItems);
                }
                else
                {
                    Console.WriteLine("Please choose again");
                }

                Console.WriteLine("Would you like another item or to continue? Y or N");
                response = Convert.ToChar(Console.ReadLine());
            } while (response == 'Y' || response == 'y');

            foreach(CartItem item in cart)
            {
                customer.Cart.Add(item);
            }

            CalcRecipt(customer);

            Console.ReadLine();
            
        }

        public static void CalcRecipt(Customer cust)
        {
            double subtotal = 0;
            double add = 0;
            double total = 0;
            double TAX = .076;
            foreach (CartItem i in cust.Cart)
            {
                subtotal += i.Price * i.Qty;
            }

            add = subtotal * TAX;

            total = subtotal + add;

            PrintRecipt(cust, subtotal, add, total);

        }

        public static void PrintRecipt(Customer c, double sub, double tax, double total)
        {
            string a = "************************************************";
            Console.WriteLine(a);
            Console.WriteLine($"Thank you {c.Name} for shoppiung with us!");
            Console.WriteLine(a);

            Console.Write("Qty\tItem\t\t\tPrice\tTotal\n");
            foreach(CartItem i in c.Cart)
            {
                Console.WriteLine($"{i.Qty}\t{i.Name}\t{i.Price}\t{total:c}");
            }

            Console.Write($"Sub total: {sub:c}\nTax: {tax:c}\nTotal: {total:c}\n");
            Console.WriteLine(a);
        }

        public static List<Book> ProcessBookFile(List<Book> bookList)
        {
            string inRecord;
            using (StreamReader inFile = new StreamReader("Books.txt"))
            {
                while ((inRecord = inFile.ReadLine()) != null)
                {
                    Book thisBook = new Book();

                    string[] fields = inRecord.Split(',');
                    thisBook = new Book(fields[0],
                                        fields[1],
                                        fields[2],
                                        Convert.ToDouble(fields[3]),
                                        fields[4]);

                    bookList.Add(thisBook);
                }
            }

            return bookList;
        }

        public static List<Game> ProcessGameFile(List<Game> gameList)
        {
            string inRecord;
            using (StreamReader inFile = new StreamReader("Games.txt"))
            {
                while ((inRecord = inFile.ReadLine()) != null)
                {
                    Game thisGame = new Game();

                    string[] fields = inRecord.Split(',');
                    thisGame = new Game(fields[0],
                                        fields[1],
                                        fields[2],
                                        Convert.ToDouble(fields[3]),
                                        fields[4]);
                    gameList.Add(thisGame);
                }
            }
            return gameList;
        }
    }
}
