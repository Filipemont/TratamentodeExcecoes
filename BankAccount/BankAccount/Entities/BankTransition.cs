using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.Entities.Exceptions;

namespace BankAccount.Entities
{
    internal class BankTransition
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public BankTransition() { }

        public BankTransition(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if(Balance == 0)
            {
                throw new DomainException("This account ha`s no money");

            }
            if( amount > Balance)
            {
                throw new DomainException("Insuficiente balance");
            }
            if( amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            Balance -= amount;
        }
    }
}
