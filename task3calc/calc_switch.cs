using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3calc
{
    internal class calc_switch
    {
        static void ReadData()
        {
            Console.Write("Введи первый операнд: ");
            double firstNum = double.Parse(Console.ReadLine());
            Console.Write("Введи символ операции (+, -, *, /, % (остаток от деления)): ");
            string action = Console.ReadLine();
            Console.Write("Введи второй операнд: ");
            double secondNum = double.Parse(Console.ReadLine());
            
            double result = 0;
            bool success = false;
            switch (action)
            {
                case "+":
                    result = firstNum + secondNum;
                    success = true;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    success = true;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    success = true;
                    break;
                case "/":
                    result = firstNum / secondNum;
                    success = true;
                    break;
                case "%":
                    result = firstNum % secondNum;
                    success = true;
                    break;
                default:
                    Console.WriteLine("Введенное действие не распознано!");
                    break;
            }
            if (success)
            {
                Console.WriteLine("Результат операции " + firstNum + action + secondNum + "=" + result);
            }
            Finish();
        }
        static void Finish()
        {
            Console.WriteLine("Если нужно вычислить еще одно значение, введи 1. Для выхода нажми Enter.");
            string cheNado = Console.ReadLine();
            if (cheNado == "1")
            {
                ReadData();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Факинговый калькулятор приветствует вас!!");
            ReadData();
            Console.WriteLine("Всего доброго!!");
            Console.ReadLine();
        }
    }
}
