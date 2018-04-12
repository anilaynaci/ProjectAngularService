using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishService
{
    class Program
    {
        static void Main(string[] args)
        {
            var epAddress = "http://localhost:3063/corsService";
            Uri baseAddress = new Uri(epAddress);
            var host = new CorsEnabledServiceHost(typeof(ValuesService), baseAddress);
            host.Open();

            Console.WriteLine("host ready on " + epAddress + " ...");

            Console.ReadLine();
        }
    }
}