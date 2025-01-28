using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace lab14
{
    internal class Tasks
    {
        private static string file = "file.txt";

        //task1
        public static void ShowProcesses()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine($"Process id: {process.Id}");
                    Console.WriteLine($"Process name: {process.ProcessName}");
                    Console.WriteLine($"Process priority: {process.BasePriority}");
                    Console.WriteLine($"Process start time: {process.StartTime}");
                    Console.WriteLine($"Process condition: {process.Responding}");
                    Console.WriteLine($"Process working time: {process.TotalProcessorTime}");
                    Console.WriteLine($"Process load time: {process.UserProcessorTime}");
                }
                catch (Exception e) { }
            }

            Console.WriteLine($"Number of processes: {processes.Length}");
        }

        //task2
        public static void ShowDomains()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Domain name: {domain.FriendlyName}");
            Console.WriteLine($"Base catalog:{domain.BaseDirectory}");
            Console.WriteLine($"Config details: {domain.SetupInformation}");
            Console.WriteLine("Assemblies: ");

            Assembly[] assemblies = domain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
        }

        //task3
        public static void SimpleNumbers()
        {
            var thread1 = new Thread(PrintSimpleNumbers);
            thread1.Start();
            thread1.Name = "Simple_Numbers";
            thread1.Join();
            Console.WriteLine();
        }

        public static void Info(object thread)
        {
            var t = thread as Thread;
            Console.WriteLine($"Thread name: {t.Name}");
            Console.WriteLine($"Thread priority: {t.Priority}");
            Console.WriteLine($"Thread status: {t.ThreadState}");
            Console.WriteLine($"Thread is background: {t.IsBackground}");
            Console.WriteLine($"Thread is started: {t.IsAlive}");
            Console.WriteLine($"Thread is stoped: {t.IsThreadPoolThread}");
        }

        public static void PrintSimpleNumbers()
        {
            var thread1 = new Thread(Info);
            thread1.Start();
            thread1.Join();

            Console.WriteLine("Enter n number: ");
            int n = Console.Read();

            for (int i = 2; i < n; i++)
            {
                bool simple = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        simple = false;
                        break;
                    }
                }
                if (simple)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
        }

        //task4
        public static void TwoThreds()
        {
            var thread1 = new Thread(OddNumbers); //нечетные
            var thread2 = new Thread(EvenNumbers); //четные

            thread1.Start();
            thread2.Start();
        }

        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                for (var i = 0; i < 15; i++)
                {
                    mutex.WaitOne();

                    if (i % 2 == 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(200);

                    if (i % 2 != 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
        }

        private static void FirstlyEvenSecondlyOdd()
        {
            var objectToLock = new object();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                lock (objectToLock)
                {
                    for (var i = 0; i < 15; i++)
                    {

                        if (i % 2 == 0)
                            Console.Write(i + " ");
                    }
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);

                    if (i % 2 != 0)
                        Console.Write(i + " ");
                }
            }
        }

        public static void OddNumbers()
        {
            string nums = "";
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);//
                if (i % 2 != 0)
                {
                    nums += i + " ";
                    Console.WriteLine(i + " ");
                }
            }
            nums += '\n';
            File.AppendAllText(file, nums);
        }
        public static void EvenNumbers()
        {
            string nums = "";
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);//
                if (i % 2 == 0)
                {
                    nums += i + " ";
                    Console.WriteLine(i + " ");
                }
            }
            nums += '\n';
            File.AppendAllText(file, nums);
        }

        //task5
        public static void ReadFile()
        {
            var file2 = File.ReadAllText(file);
            Console.WriteLine(file);
        }
        private static System.Timers.Timer _timer;

        public static void StartTimer()
        {
            _timer = new System.Timers.Timer(1000); // Устанавливаем интервал в 1 секунду
            _timer.Elapsed += OnTimedEvent; // Привязываем метод для выполнения
            _timer.AutoReset = true; // Таймер будет срабатывать несколько раз
            _timer.Enabled = true; // Включаем таймер
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Таймер сработал в {e.SignalTime}");
        }
    }
}
