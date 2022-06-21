using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task13_incArray
{
    internal class incArray
    {
        static void InsertElement(ref int[] arr, int newPos, int newElement)
        {
            int[] newArr = new int[arr.Length + 1];
            for (int i = 0, j = 0; i < newArr.Length; i++, j++)
            {
                if (i == newPos)
                {
                    newArr[i] = newElement;
                    j--;
                } else
                {
                    newArr[i] = arr[j];
                }
            }
            arr = newArr;
        }
        static void PrintArray(ref int[] array)
        {
            foreach (int _a in array)
            {
                Console.Write(_a + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = { 3, 6, 8, 9, 1, 4 };
            //int[] arr = { 1 };
            Console.WriteLine($"We have an array of {arr.Length} elements:");
            PrintArray(ref arr);
            Console.Write($"Type the number for new element (0..{arr.Length}): ");
            int pos = ushort.Parse(Console.ReadLine());
            pos = (pos > arr.Length) ? (arr.Length) : pos;
            Console.Write($"Type the value of new element: ");
            int value = int.Parse(Console.ReadLine());
            InsertElement(ref arr, pos, value);
            Console.WriteLine($"New element inserted. Now array is:");
            PrintArray(ref arr);
            Console.ReadLine();
        }
    }
}
