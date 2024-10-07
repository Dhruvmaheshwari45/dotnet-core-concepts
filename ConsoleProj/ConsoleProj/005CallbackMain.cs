using System;
using System.Collections.Generic;
using DacLibrary;

namespace ConsoleProj
{
    class Piyush: IClient
    {
        public void Job()
        {
            Console.WriteLine("Piyush: Task2");
        }
    }
    internal class  CallbackMain
    {
        static void Main1(string[] args)
        {
            Vendor vendor = new Vendor();
            Piyush piyush = new Piyush();
            vendor.DoBusiness(piyush);
        }
        static void ClientFun()
        {
            Console.WriteLine("Client static fun");
        }
        static void ClientFun1()
        {
            Console.WriteLine("Client static fun1"); 
        }
        static void Main(string[] args)
        {
            Vendor vendor = new Vendor();
            FPTR fptr1 = new FPTR(ClientFun);
            FPTR fptr2 = ClientFun1;

            Piyush piyush = new Piyush();
            FPTR fptr3 = piyush.Job;

            vendor.DoBusiness(fptr1);
            vendor.DoBusiness(fptr2);
            vendor.DoBusiness(fptr3);

            FPTR fp = (FPTR)FPTR.Combine(fptr1, fptr2, fptr3);

            vendor.DoBusiness(fp);

            fp = (FPTR)FPTR.Remove(fp, fptr2);
            vendor.DoBusiness(fp);
        }
    }
}
