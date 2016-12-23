using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var ts = TimeSpan.Parse("20:41:06.895");
            Console.WriteLine(ts);
        }
    }
}
