using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    internal class Les3
    {
        static void Main(string[] args)
        {
            string msg = "Тип {0,8} |\t.NET {1,8} |\tРазмер = {2} \t| MIN = {3,30}\t| MAX = {4}";

            Console.Title = "Типы данных в C#";

            Console.WriteLine("\n\t\t\t\t\tЧисловые (целочисленные) типы:\n)");
            Console.WriteLine(string.Format(msg, "byte", typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue));
            Console.WriteLine(string.Format(msg, "sbyte", typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
            Console.WriteLine(string.Format(msg, "short", typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue));
            Console.WriteLine(string.Format(msg, "ushort", typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue));
            Console.WriteLine(string.Format(msg, "int", typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue));
            Console.WriteLine(string.Format(msg, "uint", typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue));
            Console.WriteLine(string.Format(msg, "long", typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue));
            Console.WriteLine(string.Format(msg, "ulong", typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue));

            Console.WriteLine("\n\t\t\t\t\tЧисловые (с плавающей точкой) типы:\n)");
            Console.WriteLine(string.Format(msg, "float", typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue));
            Console.WriteLine(string.Format(msg, "double", typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue));
            Console.WriteLine(string.Format(msg, "decimal", typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue));
            Console.ReadKey();
        }
    }
}
