using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public partial class TPL
    {
        public static void task1(int N)
        {
            Console.WriteLine("Task 1");

            Stopwatch sw = new();

            Task task1 = new(() => FindSimple1(N, sw));

            Console.WriteLine($"Status before start {task1.Status}");
            sw.Start();
            task1.Start();
            Console.WriteLine($"Status after start {task1.Status}");
        }

        public static void task2(int N)
        {
            Console.WriteLine("Task 2");

            CancellationTokenSource ct = new(); //объект, позволяет отменить выполнение задачи

            var token = ct.Token;
            Task task2 = new(() => FindSimple2(N, ref token), token);
            Console.WriteLine($"Status before start {task2.Status}");
            task2.Start();
            Console.WriteLine($"Status after start {task2.Status}");
            Thread.Sleep(3000);
            Console.WriteLine($"Статус после отмены: {task2.Status}");
        }

        public static List<int> FindSimple1(int N, Stopwatch stw = null)
        {
            List<int> simpleNum = new List<int>();

            for (int i = 2; i < N; i++)
            {
                bool simple = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        simple = false;
                    }
                }
                if (simple)
                {
                    simpleNum.Add(i);
                }
            }

            if (stw != null)
            {
                stw.Stop();
                Console.WriteLine($"Время выполнения: {stw.Elapsed}");
            }

            Console.WriteLine("Выполнено!");

            return simpleNum;
        }

        public static List<int> FindSimple2(int N, ref CancellationToken token)
        {
            List<int> simpleNum = new List<int>();

            for (int i = 2; i < N; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task is canceled");
                    return null;
                }

                bool simple = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        simple = false;
                    }
                }
                if (simple)
                {
                    simpleNum.Add(i);
                }
            }

            Console.WriteLine("Выполнено!");

            return simpleNum;
        }
    }
}
