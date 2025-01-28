using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int, int, string) cortex = ( 1,2,"123") ;
            Console.WriteLine(cortex.Item2);


            //types
            //a
            int a = Console.Read();
            Console.WriteLine(a);
            float b = Console.Read();
            Console.WriteLine(b);
            double c = Console.Read();
            Console.WriteLine(c);
            char d = Console.ReadKey().KeyChar;
            //char d = Console.ReadLine()[0];
            Console.WriteLine(d);
            bool e = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine(e);
            short f = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(f);
            long g = Console.Read();
            Console.WriteLine(g);
            sbyte h = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine(h);
            byte i = Convert.ToByte(Console.ReadLine());
            Console.WriteLine(i);
            ushort j = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine(j);
            uint k = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine(k);
            ulong l = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine(l);
            decimal m = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(m);
            object n = Convert.ChangeType(Console.ReadLine(), typeof(object));
            Console.WriteLine(n);

            //b
            int o = (int)g;
            long p = (long)a;
            short r = (short)a;
            ushort s = (ushort)a;
            byte t = (byte)a;

            int u = f;
            short v = i;
            long w = a;
            long x = f;
            decimal y = j;

            //c
            // byte, sbyte, short, ushort, int, uint, long, ulong
            int z = 12;
            object obj = z;
            int z2 = (int)obj;

            //d
            var num1 = 123; //int
            var num2 = 123.123;//double
            var num3 = 123.123F;//float

            //e
            int? nul = null;
            object nul2 = null;

            //f
            var num4 = 123;
            Console.WriteLine(num4);
            //num4 = 123.123;
            Console.WriteLine(num4);

            //strings
            //a
            char symb1 = 'A';
            char symb2 = 'B';
            char symb3 = 'C';
            Console.WriteLine(symb1 > symb2);
            Console.WriteLine(symb1 > symb3);
            Console.WriteLine(symb2 > symb3);

            //b
            string str1 = "Hello, World!";
            string str2 = "Привет, Мир!";
            string str3 = "123";

            Console.WriteLine(string.Concat(str1, str2, str3));
            Console.WriteLine(string.Copy(str1));
            Console.WriteLine((str1, 10));

            string[] words = str1.Split(' ');
            Console.WriteLine(words);

            Console.WriteLine(str3.Insert(1, " "));

            Console.WriteLine(str2.Remove(8));

            int day = 19;
            Console.WriteLine($"Сегодня {day} сентября.");

            //c
            string str4 = "";
            string str5 = null;
            if (String.IsNullOrEmpty(str4)) Console.WriteLine("str is null or empty");
            if (String.IsNullOrEmpty(str5)) Console.WriteLine("str is null or empty");

            //d
            StringBuilder stringBuilder = new StringBuilder("ABC");
            stringBuilder.Insert(0, "1");
            stringBuilder.Append("2");
            stringBuilder.Replace("B", "A");

            //arrays
            //a
            int[,] array1 = { { 1, 2, 3 }, { 4, 5, 6,} };
            for (int it = 0; it < array1.Length; it++) {
                for (int jt = 0; jt < array1.Length; jt++) {
                    Console.Write("{0}\t", array1[it,jt]);
                }
                Console.WriteLine();
            }

            //b
            string[] strings = { "str1", "str2", "str3", "str4" };
            for (int ij = 0; ij < strings.Length; ij++) {
                Console.Write(strings[i]);
            }
            Console.WriteLine(strings.Length);

            Console.WriteLine("Введите номер элемента(1-4)");
            int element = Console.Read();
            if(element < 0 || element > 4) {
                Console.WriteLine("неверное число");
            }
            Console.WriteLine("Введите элемент массива");
            strings[element] = Console.ReadLine();

            //c
            int[][] array2 = new int[3][];
            array2[0] = new int[2];
            array2[1] = new int[3];
            array2[2] = new int[4];
            //int [][] array2 = {new int[2], new int[3], new int[4]}

            for (i = 0; i < array2.Length; i++) {
                for (j = 0; j < array2[i].Length; j++) {
                    Console.Write(array2[i][j] + " ");
                }
            }

            //d
            var arr = new object[10];
            var str6 = "";

            //cortex
            //a
            
            (int, string, char, string, ulong) t1 = (1, "123", 'u', "321", 17);
            //b
            Console.WriteLine(t1);
            Console.WriteLine($"{t1.Item1}, {t1.Item3}, {t1.Item4}");

            //c
            var cortex = ("Hello", 52);
            (string name, int age) = cortex;
            string name2;
            int age2;
            (name2,age2) = cortex;
            Console.WriteLine(cortex);
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(name2);
            Console.WriteLine(age2);

            //d
            (int, int) s1 = (1, 2);
            (int, int) s2 = (1, 2);
            Console.WriteLine(s1 == s2);

            //func
            int[] array3 = { 1, 2, 3, 4 };
            string str7 = "Hello";
            var result = locfunc(array3, str7);
            Console.WriteLine(result);
            (int min, int max, int sum, string letter) locfunc(int[] numbers, string str8) {
                

                int min = 0;
                int max = 0;

                for (int ij = 0; ij < array3.Length; i++) {
                    max = array3[i];
                    if (array3[i+1]>max)
                        max = array3[i+1];
                }

                for (int ij = 0; ij < array3.Length; i++)
                {
                    min = array3[i];
                    if (array3[i + 1] < min) 
                        min = array3[i + 1];
                }

                int sum = 0;
                for (int ij = 0; ij < array3.Length; ij++) {
                    sum += array3[ij];
                }
                string letter = str7.Substring(0,1);
                return (min, max, sum, letter);
            }
            
            void Func1()
            {
                int a1 = int.MaxValue;
                unchecked { a = a + 1; }
                Console.WriteLine($"Func1: a после переполнения = {a}");
            }
            void Func2() { 
                int a1 = int.MaxValue;
                try {
                    checked { a = a + 1; }
                }
                catch(OverflowException ex) {
                    Console.WriteLine("Func2: переполнения" + ex.Message);
                }
            }
            Func1();
            Func2();
        }
    }
}
