using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class NewSet {
        private List<int> elements;

        public NewSet() {
            elements = new List<int>();
        }

        public NewSet(List<int> init) {
            elements = init;
        }

        public static NewSet operator ++(NewSet set) {
            Random rand = new Random();
            set.elements.Add(rand.Next(1, 100));
            return set;
        }
        public static NewSet operator +(NewSet set1, NewSet set2) {
            return new NewSet(set1.elements.Union(set2.elements).ToList());
        }

        public static NewSet operator <=(NewSet set1, NewSet set2) {
            if (set1.Equals(set2))
            {
                return set1;
            }
            else
            {
                return set2;
            }
        }

        public static NewSet operator >=(NewSet set1, NewSet set2) {
            return set1 >= set2;
        }

        public static implicit operator int(NewSet set) {
            return set.elements.Count;
        }

        public int this[int index] {
            get {
                if (index < 0 || index > elements.Count) {
                    throw new IndexOutOfRangeException("Неверный индекс");
                };
                return elements[index];
            }
        }

        public class Production {
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

        public class Developer {
            private readonly string FIO;
            private readonly int ID;
            private readonly string Department;

            public Developer() {
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

            public void Print() {
                Console.WriteLine($"ID: {ID}, ФИО: {FIO}, Отдел: {Department}");
            }

            
        }

        public void Add(int a) { 
            elements.Add(a);
        }

        public static NewSet operator-(NewSet a, NewSet b) {
            NewSet c = new NewSet();
            foreach (var i in a.elements) {
                foreach (var j in b.elements)
                {
                    if (i == j) {
                        c.Add(j);
                    }
                }
            }

            return c;
        }

    }

    public static class StatisticOperation { 
        public static int Sum(NewSet set1) {
            int sum = 0;
            for (int i = 1; i < set1; i++) {
                sum += set1[i];
            }
            return sum;
        }

        public static int Difference(NewSet set) {
            int min = set[0];
            int max = set[0];

            for (int i = 0; i < set; i++) {
                if (set[i] > max) { 
                    max = set[i];
                }
                if (set[i] < min) { 
                    min = set[i];
                }
            }
            return max - min;
        }

        public static int Counter(NewSet set) {
            int counter = 0;
            for (int i = 0; i < set; i++) {
                counter++;
            }
            return counter;
        }
    }

    public static class Extensions {
        public static string Encrypt(this string input, int shift) {
            return new string(input.Select(c => (char)(c + shift)).ToArray());
        }
        public static bool Order(this NewSet set) {
            for (int i = 1; i < set; i++) {
                if (set[i - 1] > set[i]) {
                    return false;
                }
            }
            return true;
        }
    }

    internal class Program {
        static void Main(string[] args) {

            NewSet set1 = new NewSet(new List<int> {1, 2, 3});
            NewSet set2 = new NewSet(new List<int> {4, 5, 6});

            set1++;
            Console.WriteLine($"set1++: {set1}");

            NewSet union = set1 + set2;
            Console.WriteLine($"Union set1, set2: {union}");

            Console.WriteLine($"Equals: {set1 <= set2}");

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

            Console.WriteLine(set1 - set2);
        }
    }
}
