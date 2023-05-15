using System;
using System.Xml.Schema;

namespace MultiUserBank_Pham
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.WriteLine("Welcome to the Multi User Bank! Bank Balance: " + bank.BankBalance.ToString("C"));
            Console.WriteLine("What would you like to do?");

            while (true)
            {
                Console.WriteLine("1. Log In 2. Exit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("Enter your username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    if (bank.VerifyCredentials(username, password))
                    {
                        decimal currentBalance = bank.GetBalance(username);

                        Console.WriteLine("Welcome, " + username + "!");
                        Console.WriteLine("Your current balance is: " + currentBalance.ToString("C"));

                        while (true)
                        {
                            Console.WriteLine("1. Check Balance 2. Deposit 3. Withdraw 4. Log Out");

                            input = Console.ReadLine();

                            if (input == "1")
                            {
                                currentBalance = bank.GetBalance(username);
                                Console.WriteLine("Your current balance is: " + currentBalance.ToString("C"));
                            }
                            if (input == "2")
                            {
                                Console.WriteLine("Please enter the amount to deposit:");
                                decimal depositAmount = decimal.Parse(Console.ReadLine());

                                decimal newBalance = bank.Deposit(username, depositAmount);
                                Console.WriteLine("New Balance: " + newBalance.ToString("C"));
                            }
                            else if (input == "3")
                            {
                                Console.WriteLine("Please enter the amount to withdraw:");
                                decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                                bool success = bank.Withdraw(username, withdrawAmount);

                                if (success)
                                {
                                    decimal updatedBalance = bank.GetBalance(username);
                                    Console.WriteLine("New Balance: " + updatedBalance.ToString("C"));
                                }
                            }
                            else if (input == "4")
                            {
                                Console.WriteLine("Thank you for using our bank. Goodbye!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials. Please try again.");
                    }
                }
                if (input == "2")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

            }

        }

    }





}
