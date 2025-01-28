using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    static partial class TPL
    {
        //task 3
        public static int Sum(int[] nums) => nums.Sum();
        public static double Square(double a, double b) => a * b;
        public static double Volume(double a, double b, double c) => a * b * c;

        public static void task4_1()
        {
            Console.WriteLine("Task 4(1)");

            var task1 = Task.Run(() => Sum([1, 2, 3, 4, 5, 6, 7]));
            var task2 = task1.ContinueWith(x => Square(x.Result, 5));
            var task3 = task2.ContinueWith(y => Volume(y.Result, 5, 2));

            Console.WriteLine($"Result 4(1): {task3.Result}");
        }

        public static void task4_2()
        {
            // GetAwaiter() - это метод для получения объекта, который позволяет ожидать завершения задачи. Возвращает объект типа TaskAwaiter.
            // GetResult() - это метод для получения результата задачи в случае, если она завершилась успешно. Возвращает результат типа T.
            Console.WriteLine("Task 4(2)");

            Task<int> task1 = new(() => Sum([1, 12, 123]));
            task1.Start();
            task1.GetAwaiter().GetResult();

            Task<double> task2 = new(() => Square(task1.Result, 5));
            task2.Start();
            task2.GetAwaiter().GetResult();

            Task <double> task3 = new(() => Volume(task2.Result, 5, 2));
            task3.Start();
            task3.GetAwaiter().GetResult();

            Console.WriteLine($"Result 4(2): {task3.Result}");
        }
    }
}
