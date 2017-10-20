using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class A
    {
        public dynamic xyz;

        public virtual void printdetail()
        {
            Console.WriteLine("Class A");
        }
    }
    public class B : A
    {
        public override void printdetail()
        {
            xyz = "dfsd";
            Console.WriteLine("Class B " + xyz);
        }
    }

}
