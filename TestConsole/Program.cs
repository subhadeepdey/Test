using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTime();
            Console.ReadLine();
        }
        static void TestTime()
        {
            DateTime localDateTime, univDateTime;

            Console.WriteLine("Enter a date and time.");
            string strDateTime = Console.ReadLine();

            try
            {
                localDateTime = DateTime.Parse(strDateTime);
                univDateTime = localDateTime.ToUniversalTime();
                Console.WriteLine("{0} This local time is {1} universal time(UTC).",
                                       localDateTime,
                                        univDateTime);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
                return;
            }

            Console.WriteLine("Enter a date and time in universal time.");
            strDateTime = Console.ReadLine();

            try
            {
                univDateTime = DateTime.Parse(strDateTime);
                localDateTime = univDateTime.ToLocalTime();

                Console.WriteLine("{0} universal time is {1} local time.",
                                         univDateTime,
                                         localDateTime);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
                return;
            }

        }
    }
}
