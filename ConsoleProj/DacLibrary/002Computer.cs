using System;
using System.Collections.Generic;

namespace DacLibraryComputerMSP
{
    class MSP
    {
        static Dictionary<string, MSP> repo = new Dictionary<string, MSP>();
        public static int count = 0;
        string _make;
        string _series;
        string _processor;
        private MSP(string make, string series, string processor)
        {
            count++;
            _make = make;
            _series = series;
            _processor = processor;
        }
        public string Make { get { return _make; } }
        public string Series { get { return _series; } }
        public string Processor { get { return _processor; } }

        public static MSP make_msp(string make, string series, string processor)
        {
            string key = make + series + processor;
            if (!repo.ContainsKey(key))
            {
                repo[key] = new MSP(make, series, processor);
            }
            return repo[key];
        }
    }
    public class Computer
    {
        public static int count = 0;

        string _ram;
        string _hd;
        string _mon;
        MSP msp;
        public Computer(string make, string series, string processor, string ram, string hd, string mon)
        {
            count++;
            msp = MSP.make_msp(make, series, processor);
            _ram = ram;
            _hd = hd;
            _mon = mon;
        }
        public static int MSPCount { get { return MSP.count; } }
        public override string ToString()
        {

            Console.WriteLine("{0,-10}:{1,-10}", "Make", msp.Make);
            Console.WriteLine("{0,-10}:{1,-10}", "Series", msp.Series);
            Console.WriteLine("{0,-10}:{1,-10}", "Processor", msp.Processor);
            Console.WriteLine("{0,-10}:{1,-10}", "Ram", _ram);
            Console.WriteLine("{0,-10}:{1,-10}", "HD", _hd);
            Console.WriteLine("{0,-10}:{1,-10}", "Mon", _mon);
            return new string('_', 50);
        }
    }
}
