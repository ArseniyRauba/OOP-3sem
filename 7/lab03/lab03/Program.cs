using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    interface generic<T>
    {
        void Add(T item);
        void Remove(T item);
        void Watch(T item);
    }


    public class CollectionType<T> : generic<T> where T : IComparable<T>
    {
        public void Add(T item)
        {
            elements.Add(item);
        }
        public void Remove(T item)
        {
            elements.Remove(item);
        }
        public void Watch(T item)
        {
            Console.WriteLine(item);
        }

        private List<T> elements;

        public CollectionType()
        {
            elements = new List<T>();
        }

        public CollectionType(List<T> init)
        {
            elements = init;
        }

        public static CollectionType<T> operator ++(CollectionType<T> set)
        {
            //Random rand = new Random();
            //set.elements.Add(rand.Next(1, 100));
            //return set;
            throw new NotSupportedException("Оператор ++ не поддерживается для обобщенного типа.");
        }
        public static CollectionType<T> operator +(CollectionType<T> set1, CollectionType<T> set2)
        {
            return new CollectionType<T>(set1.elements.Union(set2.elements).ToList());
        }

        //public static CollectionType<T> operator <=(CollectionType<T> set1, CollectionType<T> set2)
        //{
        //    return set1 <= set2;
        //}

        //public static CollectionType<T> operator >=(CollectionType<T> set1, CollectionType<T> set2)
        //{
        //    return set1 >= set2;
        //}

        public static implicit operator int(CollectionType<T> set)
        {
            return set.elements.Count;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > elements.Count)
                {
                    throw new IndexOutOfRangeException("Неверный индекс");
                };
                return elements[index];
            }
        }

        public class Production
        {
            private readonly int ID;
            private readonly string Org;

            public Production()
            {
                ID = 123;
                Org = "OPG";
            }

            public Production(int EntID, string EntOrg)
            {
                ID = EntID;
                Org = EntOrg;
            }

            public void Print()
            {
                Console.WriteLine($"Id:{ID}, Organisation: {Org}");
            }
        }

        public class Developer
        {
            private readonly string FIO;
            private readonly int ID;
            private readonly string Department;

            public Developer()
            {
                ID = 123;
                FIO = "Рауба Арсений Владимирович";
                Department = "БГТУ";
            }

            public Developer(string fIO, int iD, string department)
            {
                FIO = fIO;
                ID = iD;
                Department = department;
            }

            public void Print()
            {
                Console.WriteLine($"ID: {ID}, ФИО: {FIO}, Отдел: {Department}");
            }

        }
        //public void PushToFile()
        //{
        //    using StreamWriter sw = new("List.json");
        //    var str = JsonSerializer.Serialize(list);
        //    sw.WriteLine(str);

        //}

        //public void ReadFromFile()
        //{
        //    using StreamReader sr = new("List.json");
        //    var str = sr.ReadToEnd();
        //    list = JsonSerializer.Deserialize<T[]>(str);
        //}
    }

    public static class StatisticOperation
    {
        public static int Sum(CollectionType<int> set1)
        {
            int sum = 0;
            for (int i = 1; i < set1; i++)
            {
                sum += set1[i];
            }
            return sum;
        }

        public static int Difference(CollectionType<int> set)
        {
            int min = set[0];
            int max = set[0];

            for (int i = 0; i < set; i++)
            {
                if (set[i] > max)
                {
                    max = set[i];
                }
                if (set[i] < min)
                {
                    min = set[i];
                }
            }
            return max - min;
        }

        public static int Counter(CollectionType<int> set)
        {
            int counter = 0;
            for (int i = 0; i < set; i++)
            {
                counter++;
            }
            return counter;
        }
    }

    public static class Extensions
    {
        public static string Encrypt(this string input, int shift)
        {
            return new string(input.Select(c => (char)(c + shift)).ToArray());
        }
        public static bool Order(this CollectionType<int> set)
        {
            for (int i = 1; i < set; i++)
            {
                if (set[i - 1] > set[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    class FinalExam : IComparable<FinalExam>
    {
        public string Title { get; set; }
        public int Time { get; set; }

        public FinalExam(string title, int time)
        {
            Title = title;
            Time = time;
        }
        public int CompareTo(FinalExam a)
        {
            if (a == null) return 1;
            return Time.CompareTo(a.Time);
        }
        public void Hello()
        {
            Console.WriteLine("Hello, student!!!");
        }

        public override string ToString()
        {
            return base.ToString() + $" Includes Exam: {this.Title}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            var set1 = new CollectionType<int>(new List<int> { 1, 2, 3 });
            var set2 = new CollectionType<int>(new List<int> { 4, 5, 6 });

            //try
            //{
            //    set1++;
            //    Console.WriteLine($"set1++: {set1}");
            //}
            //catch
            //{
            //}
            //finally { 
            //    Console.WriteLine("Finally");
            //}
            var union = set1 + set2;
            Console.WriteLine($"Union set1, set2: {union}");

            //Console.WriteLine($"Equals: {set1 <= set2}");

            int size = set1;
            Console.WriteLine($"Power of set1: {size}");

            try
            {
                Console.WriteLine($"Second element set1: {set1[2]}");
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            finally
            {
                Console.WriteLine("Finally!");
            }

            Console.WriteLine($"Order: {set1.Order()}");

            string hello = "Hello";
            Console.WriteLine($"String: {hello}");
            Console.WriteLine($"Encrypted string: {hello.Encrypt(1)}");

            int sum1 = StatisticOperation.Sum(set1);
            Console.WriteLine($"Sum: {sum1}");

            int diff = StatisticOperation.Difference(set1);
            Console.WriteLine($"Diff set1: {diff}");

            int count = StatisticOperation.Counter(set1);
            Console.WriteLine($"Count set1: {count}");

            //проверка для стандартных типов данных
            var intCollection = new CollectionType<int>(new List<int> { 1, 2, 3 });
            var doubleCollection = new CollectionType<double>(new List<double> { 1.1, 1.2, 1.3 });
            var stringCollection = new CollectionType<string>(new List<string> { "123", "234", "345" });
            var charCollection = new CollectionType<char>(new List<char> { '1', '2', '3' });


            //польз класс
            var Ex = new CollectionType<FinalExam>();
            Ex.Add(new FinalExam("math", 12));
        }
    }
}
