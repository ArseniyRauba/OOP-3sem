using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    static partial class TPL
    {
        public static void task5()
        {
            Console.WriteLine("Task 5");

            int size = 3333;
            int[] arr = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-100000, 100000);
            }

            Stopwatch sw = new();
            sw.Start();
            TPL.Sort(arr);
            sw.Stop();

            Console.WriteLine($"Results usual: {sw.ElapsedMilliseconds} ms");

            sw.Reset();
            int[] temp = new int[size];
            temp.CopyTo(arr, 0);

            // Parallel.For()
            {
                sw.Start();

                bool sorted = false;

                while (!sorted)
                {
                    sorted = true;
                    Parallel.For(0, size - 2, n =>
                    {
                        if (temp[n].CompareTo(temp[n + 1]) > 0)
                        {
                            int temp1 = arr[n];
                            arr[n] = arr[n + 1];
                            arr[n + 1] = temp1;
                            sorted = false;
                        }
                    });
                }
                sw.Stop();
            }
            Console.WriteLine($"Time parallel for: {sw.ElapsedMilliseconds} ms");

            sw.Reset();
            // Parallel.ForEach()
            {
                sw.Start();
                List<int> list = arr.ToList();
                int min = int.MaxValue;
                Index index = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    list = arr[i..].ToList();
                    min = int.MaxValue;

                    Parallel.ForEach(list, el =>
                    {
                        if (min > el)
                        {
                            min = el;
                            index = Array.IndexOf(arr, min);
                        }
                    });

                    arr[index] = arr[i];
                    arr[i] = min;
                }
                sw.Stop();
            }
            Console.WriteLine($"Time parallel ForEach: {sw.ElapsedMilliseconds} ms");
        }

        public static T[] Sort<T>(T[] arr) where T : IComparable
        {
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < arr.Length - 2; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        sorted = false;
                    }
                }
            }
            return arr;
        }
    }
}
