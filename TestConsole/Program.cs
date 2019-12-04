using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class A
    {
        public virtual void Act()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        public override void Act()
        {
            Console.WriteLine("B");
        }
    }

    class C : A
    {
        public override void Act()
        {
            Console.WriteLine("C");
        }
    }

    class D : A
    {
        public new void Act()
        {
            Console.WriteLine("D");
        }
        public void wewe()
        {
        }
    }

    class Program
    {
        static void Main()
        {
            var objects = new List<A>
        {
            new B(),
            new C(),
            new D()
        };

            foreach (var item in objects)
            {
                item.Act();
            }
            Console.ReadLine();
        }
       
    }
    //    public class A
    //    {
    //        static int b;
    //        int c;
    //        A()
    //        { c = b++; }
    //        public static int getB() { return b; }
    //    }
    //    class Program
    //    {

    //        private static AutoResetEvent _event = new AutoResetEvent(false);

    //        static void Main(string[] args)
    //        {
    //            A.getB();
    //            StringBuilder sb = new StringBuilder();

    //                var greatest = new System.Collections.Generic.Dictionary<string,string>()
    //{
    //   { "Basketball", "Michael Jordan" },
    //   { "Football", "Peyton Manning" },
    //   { "Baseball", "Babe Ruth" }
    //};
    //            TestvirtualOverride();
    //            //TestTime();
    //            Console.ReadLine();
    //        }
    //        static void TestvirtualOverride()
    //        {
    //            A a = new B();
    //            a.printdetail();
    //        }
    //        static void TestTime()
    //        {
    //            DateTime localDateTime, univDateTime;

    //            Console.WriteLine("Enter a date and time.");
    //            string strDateTime = Console.ReadLine();

    //            try
    //            {
    //                localDateTime = DateTime.Parse(strDateTime);
    //                univDateTime = localDateTime.ToUniversalTime();

    //                Console.WriteLine("{0} This local time is {1} universal time(UTC).",
    //                                       localDateTime,
    //                                        univDateTime);
    //            }
    //            catch (FormatException)
    //            {
    //                Console.WriteLine("Invalid format.");
    //                return;
    //            }

    //            Console.WriteLine("Enter a date and time in universal time.");
    //            strDateTime = Console.ReadLine();

    //            try
    //            {
    //                univDateTime = DateTime.Parse(strDateTime);
    //                localDateTime = univDateTime.ToLocalTime();

    //                Console.WriteLine("{0} universal time is {1} local time.",
    //                                         univDateTime,
    //                                         localDateTime);
    //            }
    //            catch (FormatException)
    //            {
    //                Console.WriteLine("Invalid format.");
    //                return;
    //            }

    //        }
    //    }
}
