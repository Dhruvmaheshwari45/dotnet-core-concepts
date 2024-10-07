using System;
using System.Collections.Generic;
using System.Diagnostics;
using DacLibrary;


namespace ConsoleProj
{
    public class CMainTransaction
    {
        public static void Main(string[] args)
        {
            Account account = new Account(10000);
            TransHelper transHelper = new TransHelper(account);

            transHelper.Deposit(2000);
            transHelper.Deposit(1000);
            transHelper.Deposit(3000);
            transHelper.Withdraw(1000);
            transHelper.Withdraw(2000);

            //transHelper.undo();
            //transHelper.undo();
            transHelper.undo();

            Console.WriteLine($"Account Balance : {transHelper.Balance}");
            Console.WriteLine($"Account Balance : {account.GetBalance()}");

        }
    }
}
