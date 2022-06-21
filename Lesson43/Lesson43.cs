using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson43
{
    internal class Lesson43
    {
        static void Faa (ref int b)
        {
            b = -5;
        }
        static void Main(string[] args)
        {
            int a = 2;
            Faa (ref a);
            Console.WriteLine("a=" + a);
            Console.ReadLine();
        }
    }
}
