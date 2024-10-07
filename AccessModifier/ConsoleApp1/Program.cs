using System;


namespace DacNs2_old
{
    public class Computer
    {
        public static int count = 0;
        string _make;
        string _series;
        string _processor;
        string _ram;
        string _hd;
        string _mon;

        public Computer(string make, string series, string processor, string ram, string hd, string mon)
        {
            count++;
            _make = make;
            _series = series;
            _processor = processor;
            _ram = ram;
            _hd = hd;
            _mon = mon;
        }

        public override string ToString()
        {
            Console.WriteLine("{0,-10}:{1,-10}", "Make", _make);
            Console.WriteLine("{0,-10}:{1,-10}", "Series", _series);
            Console.WriteLine("{0,-10}:{1,-10}", "Processor", _processor);
            Console.WriteLine("{0,-10}:{1,-10}", "Ram", _ram);
            Console.WriteLine("{0,-10}:{1,-10}", "HD", _hd);
            Console.WriteLine("{0,-10}:{1,-10}", "Mon", _mon);
            return new string('_', 50);
        }
    }
}
