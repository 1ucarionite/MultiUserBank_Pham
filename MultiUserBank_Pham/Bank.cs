using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Lena Pham
// IT112
// Comments: tricky, but food to the brain. i think you should get a raise 
// behaviors not implemented and why: none, i believe

namespace MultiUserBank_Pham
{
    public class Bank
    {
        private const decimal InitialBalance = 10000;
        private string[] users;
        private string[] passwords;
        private decimal[] balances;

        public decimal BankBalance { get; }

        public Bank()
        {
            users = new string[] { "jlennon", "pmccartney", "gharrison", "rstarr" };
            passwords = new string[] { "johnny", "pauly", "georgy", "ringoy" };
            balances = new decimal[] { 1250, 2500, 3000, 1000 };
            BankBalance = InitialBalance;
        }
        
        public bool VerifyCredentials(string username, string password)
        {
            int index = Array.IndexOf(users, username);
            if (index >= 0 && passwords[index] == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetBalance(string username)
        {
            int index = Array.IndexOf(users, username);
            if (index >= 0)
            {
                return balances[index];
            }
            else
            {
                return InitialBalance;
            }
        }

        public void UpdateBalance(string username, decimal newBalance)
        {
            int index = Array.IndexOf(users, username);
            if (index >= 0)
            {
                balances[index] = newBalance;
            }
        }

        public decimal Deposit(string username, decimal amount)
        {
            decimal currentBalance = GetBalance(username);
            decimal newBalance = currentBalance + amount;
            UpdateBalance(username, newBalance);
            return newBalance;
        }

        public bool Withdraw(string username, decimal amount)
        {
            decimal currentBalance = GetBalance(username);
            if (amount <= 500 && currentBalance >= amount)
            {
                decimal newBalance = currentBalance - amount;
                UpdateBalance(username, newBalance);
                return true;
            }
            else if (amount > 500 && currentBalance >= 500)
            {
                Console.WriteLine("Withdrawals are capped at $500. Withdrew $500.");
                decimal newBalance = currentBalance - 500;
                UpdateBalance(username, newBalance);
                return true;
            }
            else if (amount > currentBalance)
            {
                Console.WriteLine("Withdrawal exceeds available balance.");
                decimal newBalance = 0;
                UpdateBalance(username, newBalance);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
