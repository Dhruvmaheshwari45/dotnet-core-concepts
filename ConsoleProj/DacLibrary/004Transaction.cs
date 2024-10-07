using System;
using System.Collections.Generic;


namespace DacLibrary
{
    public class Account
    {
        int _account;
        public Account(int account)
        {
            _account = account;
        }
        public void Debit(int amt)
        {
            _account -= amt;
        }
        //public void Withdraw(int amt)
        //{
        //    _account -= amt;
        //}
        public void Credit(int amt) => _account += amt;
        public int GetBalance()
        {
            return _account;
        }
    }
    abstract class Command
    {
        protected int amt;
        protected Command(int amt)
        {
            this.amt = amt;
        }
        public abstract void execute(Account account);
        public abstract void unexecute(Account account);
    }

    class WithDrawCommand : Command
    {
        public WithDrawCommand(int amt) : base(amt)
        {

        }
        public override void execute(Account account)
        {
            account.Debit(amt);
        }
        public override void unexecute(Account account)
        {
            account.Credit(amt);
        }
    }
    class DepositCommand : Command
    {
        public DepositCommand(int amt) : base(amt)
        {
        }
        public override void execute(Account account)
        {
            account.Credit(amt);
        }
        public override void unexecute(Account account)
        {
            account.Debit(amt);
        }
    }
    public class TransHelper
    {
        Stack<Command> repo = new Stack<Command>();
        Account _account;
        public TransHelper(Account account)
        {
            _account = account;
        }
        public void Deposit(int amt)
        {
            DepositCommand cmd = new DepositCommand(amt);
            cmd.execute(_account);
            repo.Push(cmd);
        }
        public void Withdraw(int amt)
        {
            WithDrawCommand cmd = new WithDrawCommand(amt);
            cmd.execute(_account);
            repo.Push(cmd);
        }
        public void undo()
        {
            Command cmd = repo.Pop();
            cmd.unexecute(_account);
        }
        public int Balance { get { return _account.GetBalance(); } }

    }
}
