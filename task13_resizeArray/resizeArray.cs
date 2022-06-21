using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task13_resizeArray
{
    internal class resizeArray
    {
        static void Resize(ref int[] sourceArr, short newSize)
        {
            int[] newArr = new int [sourceArr.Length + newSize];
            int _steps = sourceArr.Length < newArr.Length ? sourceArr.Length : newArr.Length;
            for (int i = 0; i < _steps; i++)
            {
                newArr[i] = sourceArr[i];
            }
            /*
             * if (newSize == 1)
                newArr[sourceArr.Length] = 0;
            */
            sourceArr = newArr;
        }
        static void printArray(ref int[] array)
        {
            foreach (int _a in array)
            {
                Console.Write(_a + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //int[] arr = { 3, 6, 8, 9, 1, 4 };
            int[] arr = { 1 };
            Console.WriteLine($"We have an array of {arr.Length} elements:");
            printArray(ref arr);
            Console.Write("Type the symbol for action (d - decrease, i - increase): ");
            string act = Console.ReadLine();
            if (act == "d")
                Resize(ref arr, -1);
            else if (act == "i")
                Resize(ref arr, 1);
            Console.WriteLine($"Resizing of array completed. His lenght = {arr.Length}, his elements:");
            printArray(ref arr);
            Console.ReadLine();
        }
    }
}
