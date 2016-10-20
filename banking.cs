using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSet2
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = " ";
            Customer C = new Customer();
            do
            {
                Console.WriteLine("Welcome to Bank de Chaz!");
                Console.WriteLine("To look up an account please enter [1]");
                Console.WriteLine("To create a new account please enter [2]");
                Console.WriteLine("To quit the application please enter [q]");
                x = Console.ReadLine();
                if (x == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome back! Please enter your phone number below:");
                    string returnnum = Console.ReadLine();
                    int returnnumber = 0;
                    int.TryParse(returnnum, out returnnumber);
                    if(returnnumber == C.CustomerID)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Hi " + C.FirstName);
                        Console.WriteLine();
                        if(C.Check[0].Balance > 0)
                        {
                            Console.WriteLine("You have " + C.Check[0].Balance.ToString() + " in your Checking Account.");
                        }
                        if(C.Savin[0].Balance > 0)
                        {
                            Console.WriteLine("You have " + C.Savin[0].Balance.ToString() + " in your Savings Account");
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                        Console.WriteLine("Doesn't Work");

                }
                else if (x == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome! Let's get started with opening up an account!");
                    Console.WriteLine("Please enter your first name below:");
                    
                    C.FirstName = Console.ReadLine();
                    Console.WriteLine("And your last name:");
                    C.LastName = Console.ReadLine();
                    Console.WriteLine("And finally, your phone number:");
                    string phone = Console.ReadLine();
                    int phonenum = 0;
                    int.TryParse(phone, out phonenum);
                    C.CustomerID = phonenum;
                    Console.WriteLine();
                    Console.WriteLine("Hi " + C.FirstName + " " + C.LastName + "! We should be able to reach you at " + phone);
                    Console.WriteLine();

                    Console.WriteLine("Let's get started with creating your account!");
                    Console.WriteLine("Please enter [1] to create a Checking Account");
                    Console.WriteLine("Please enter [2] to create a Savings Account");
                    int count = 0;
                    string z = Console.ReadLine();
                    int.TryParse(z, out count);
                    if (count == 1)
                    {
                        Console.WriteLine("Let's get started with your Checking Account!");
                        Console.WriteLine("How much money would you like to initially deposit?");
                        double deposit = 0;
                        string dep = Console.ReadLine();
                        double.TryParse(dep, out deposit);
                        if (deposit > 0)
                        {
                            Console.WriteLine("Success! You now have a balnce of $" + dep + " in your Checking Account at Bank de Chaz.");
                            C.Check[0].Balance = deposit;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, but you did not add enough money to create a new checking account");
                        }
                    }
                    else if (count == 2)
                        {
                            Console.WriteLine("Let's get started with your Savings Account!");
                            Console.WriteLine("How much money would you like to initially deposit?");
                            double deposit = 0;
                            string dep = Console.ReadLine();
                            double.TryParse(dep, out deposit);
                            if (deposit > 0)
                            {
                                Console.WriteLine("Success! You now have a balnce of $" + dep + " in your Savings Account at Bank de Chaz.");
                                C.Savin[0].Balance = deposit;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, but you did not add enough money to create a new savings account");
                            }
                        }
                    else
                    {
                        Console.ReadLine();
                    }

                    Console.Read();
                    
                }

            } while (x != "q" && x != "Q");
        }
    }

    abstract class Account
    {
        public double Balance { get; set; }
        public abstract double IR();
    }

    class Checking : Account
    {
        public override double IR()
        {
            return 0.001;
        }
    }

    class Savings : Account
    {
        public override double IR()
        {
            return 0.015;
        }
    }

    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerID { get; set; }
        public Checking[] Check;
        public Savings[] Savin;
        public override string ToString()
        {
            string result = "";

            result += "Welcome " + FirstName + " " + LastName;
            return result;
        }
    }
}
