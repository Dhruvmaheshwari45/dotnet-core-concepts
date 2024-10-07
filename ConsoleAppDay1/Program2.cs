using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay1
{
    interface IMessage
    {
        void Send(string msg);
    }
    class Helper: IMessage //implement
    {
        IMessage nodeMsg; //containment
        public Helper(IMessage message)
        {
            nodeMsg = message;
        }
        public virtual void Send(string msg)
        {
            nodeMsg.Send(msg);
        }
    }

    class NullMsgNode: IMessage //implements
    {
        public void Send(string msg)
        {
            //do nothing
        }
    }

    class MyEncoder : Helper //extends
    {
        public MyEncoder(IMessage message) : base(message)
        {
        }
        public override void Send(string msg)
        {
            base.Send(msg);
            Console.WriteLine("Encoded : {0}", msg);
        }
    }


    class MyEncryptor : Helper 
    {
        public MyEncryptor(IMessage message) : base(message)
        {
        }
        public override void Send(string msg)
        {
            base.Send(msg);
            Console.WriteLine("Encrypted : {0}", msg);
        }
    }
    class MyCertificate : Helper
    {
        public MyCertificate(IMessage message) : base(message)
        {
        }
        public override void Send(string msg)
        {
            base.Send(msg);
            Console.WriteLine("Certificate : {0}", msg);
        }
    }

    class Sender : Helper
    {
        public Sender(IMessage message) : base(message)
        {
        }
        public override void Send(string msg)
        {
            base.Send(msg);
            Console.WriteLine("Sender : {0}", msg);
        }
    }
    enum Level { High, Medium, Low, Nude };
    static class Factory
    {
        public static IMessage GetSender(Level level)
        {
            switch (level)
            {
                case Level.High:
                    return new Sender(new MyEncryptor(new MyEncoder(new NullMsgNode())));
                case Level.Medium:
                    return new Sender(new MyEncryptor(new NullMsgNode()));
                case Level.Low:
                    return new Sender(new MyEncoder(new NullMsgNode()));
                case Level.Nude:
                    return new Sender(new NullMsgNode());
                default:
                    return new NullMsgNode();
            }
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            string message = "Diamonds has to be polished";
            IMessage sender = Factory.GetSender(Level.High);
            sender.Send(message);
        }
    }
}
