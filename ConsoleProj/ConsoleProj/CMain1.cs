using System;
using DacLibraryComputerMSP;


namespace ConsoleProj
{
    internal class CMain2
    {
        static void Main(string[] args)
        {
            Computer c1 = new Computer("dell", "lattitude", "intel", "8gb", "1tb", "11in");
            Computer c2 = new Computer("hp", "flash", "celleron", "4gb", "2tb", "13in");
            Computer c3 = new Computer("dell", "lattitude", "intel", "4gb", ".5tb", "9in");
            Computer c4 = new Computer("hp", "flash", "celleron", "8gb", "1tb", "11in");
            Computer c5 = new Computer("dell", "lattitude", "intel", "16gb", "2tb", "14in");
            Computer c6 = new Computer("dell", "lattitude", "intel", "32gb", "1.5tb", "13in");

            foreach (Computer comp in new[] { c1, c2, c3, c4, c5, c6 })
            {
                Console.WriteLine(comp);
            }
            Console.WriteLine("Computers Total : {0}", Computer.count);
            Console.WriteLine("MSP        Total : {0}", Computer.MSPCount);
        }
    }
}

