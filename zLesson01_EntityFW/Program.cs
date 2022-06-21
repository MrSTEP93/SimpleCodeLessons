// See https://aka.ms/new-console-template for more information
using System;

namespace Zlesson01_EntityFW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DBSQLModule.OpenSqlConnection();

            Console.ReadLine();
        }
    }
}