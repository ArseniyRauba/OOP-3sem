using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: \n");
            Tasks.ShowProcesses();

            Console.WriteLine("Task 2: \n");
            Tasks.ShowDomains();

            Console.WriteLine("Task 3: \n");
            Tasks.SimpleNumbers();

            Console.WriteLine("Task 4: \n");
            Tasks.TwoThreds();

            Tasks.StartTimer(); // Запуск таймера

            Console.WriteLine("Нажмите любую клавишу для завершения программы.");
            Console.ReadKey(); // Ожидаем, чтобы программа не завершилась сразу
        }
    }
}