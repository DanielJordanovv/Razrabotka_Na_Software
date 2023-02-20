using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class BankAccount
    {
        public BankAccount(int id, decimal balance = 0)
        {
            this.Id = id;
            this.Balance = balance;
        }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Negative amount");
            }
            this.Balance += amount;
        }
        public void Credit(decimal cash)
        {
            this.Balance += cash;
        }
        public void Increase(decimal percent)
        {
            this.Balance += this.Balance * percent / 100;
        }
        public decimal Bonus()
        {
            if (this.Balance>=1000 && this.Balance <=2000)
            {
                this.Balance += 100;
            }
            else if (this.Balance >= 2000 && this.Balance <= 3000)
            {
                this.Balance += 200;
            }
            else if(this.Balance>3000)
            {
                this.Balance += 300;
            }
            return this.Balance;
        }
    }
}
