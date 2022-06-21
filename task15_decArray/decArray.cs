using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task15_decArray
{
    internal class decArray
    {
        static void Delete1stElement(ref int[] arr)
        {
            int[] newArr = new int[arr.Length - 1];
            for (int i = 0, j = 1; i < newArr.Length; i++, j++)
            {
                newArr[i] = arr[j];
            }
            arr = newArr;
        }
        static void DeleteLastElement(ref int[] arr)
        {
            int[] newArr = new int[arr.Length - 1];
            for (int i = 0, j = 0; i < newArr.Length; i++, j++)
            {
                newArr[i] = arr[j];
            }
            arr = newArr;
        }  
        static void DeleteMiddleElement(ref int[] arr, int position)
        {
            int[] newArr = new int[arr.Length - 1];
            for (int i = 0, j = 0; i < newArr.Length; i++, j++)
            {
                if (position == i)
                    j++;
                newArr[i] = arr[j];
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
            if (pos == 0)
                Delete1stElement(ref arr);
            else if (pos == arr.Length)
                DeleteLastElement(ref arr);
            else
                DeleteMiddleElement(ref arr, pos);
            Console.WriteLine($"New element inserted. Now array is:");
            PrintArray(ref arr);
            Console.ReadLine();
        }
    }
}
