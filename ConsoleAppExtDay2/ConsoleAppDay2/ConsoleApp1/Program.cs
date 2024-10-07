using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;

    namespace Lib1
    {
        class Computer
        {
            private string _make;
            private string _series;
            private string _processor;
            private string _ram;
            private string _hdd;
            private string _mon;

            public Computer(string make, string series, string processor, string ram, string hdd, string mon)
            {
                _make = make;
                _series = series;
                _processor = processor;
                _ram = ram;
                _hdd = hdd;
                _mon = mon;
            }

            public override string ToString()
            {
                string output = "";
                output += $"{"Make",-10} : {_make}\n";
                output += $"{"Series",-10} : {_series}\n";
                output += $"{"Processor",-10} : {_processor}\n";
                output += $"{"Ram",-10} : {_ram}\n";
                output += $"{"HDD",-10} : {_hdd}\n";
                output += $"{"Monitor",-10} : {_mon}\n";
                output += new string('_', 50);
                return output;
            }
        }
    }
}
