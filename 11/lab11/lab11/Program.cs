using System;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace lab11
{
    public static class Reflector
    {
        public static void Info(string className, string param)
        {
            Type type = Type.GetType(className);
            string outStr = "";

            outStr += "Class name: ";
            outStr += className + '\n';

            //a 
            outStr += "Assembly: ";
            string asmbName = type.Assembly.GetName().Name;
            outStr += asmbName + '\n';

            //b
            outStr += "Public constructors: ";
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            foreach (var itm in constructors)
            {
                outStr += itm + "; ";
            }
            outStr += '\n';

            //c
            outStr += "Public methods: ";

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (var itm in methods)
            {
                outStr = itm + "; ";
            }
            outStr += "\n";

            //d
            outStr += "Fields: ";

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var itm in fields)
            {
                outStr += itm + "; ";
            }
            outStr += "\n";

            //e
            outStr += "Interfaces: ";

            var interfaces = type.GetInterfaces();

            foreach (var itm in interfaces)
            {
                outStr += itm + "; ";
            }
            outStr += "\n";

            //f
            outStr += "Methods with param: ";

            Type paramType = Type.GetType(param);

            foreach (var itm in methods)
            {
                var parameters = itm.GetParameters();
                foreach (var p in parameters)
                {
                    if (p.ParameterType == paramType)
                    {
                        outStr += p + "; ";
                    }
                }
            }
            outStr += "\n";

            File.AppendAllText("D:\\output.txt", outStr + "\n\n\n\n\n");
        }
        public static void Invoke()
        {
            var line = File.ReadAllLines("D:\\input.txt");
            foreach (var itm in line)
            {
                var parts = itm.Split(',');
                string className = parts[0].Trim();
                string methodName = parts[1].Trim();
                int parameter1 = Convert.ToInt32(parts[2].Trim());
                int parameter2 = Convert.ToInt32(parts[3].Trim());

                Type type = Type.GetType(className);
                object classObj = Activator.CreateInstance(type);

                MethodInfo method = type.GetMethod(methodName);
                ParameterInfo[] parameters = method.GetParameters();

                Random random = new Random();
                object[] values = new object[parameters.Length];

                values[0] = parameter1;
                values[1] = parameter2;

                object result = method.Invoke(classObj, values);

                string content = $"Class: {className}, Method: {methodName}, Params: {string.Join(", ", values)}, Result: {result}";
                File.AppendAllText("D:\\labOut.txt", content + "\n");
            }
        }
        public static T Create<T>()
        {
            Type type = typeof(T);
            ConstructorInfo constructor = type.GetConstructors().First();
            object instance = constructor.Invoke(Array.Empty<object>());
            return (T)instance;
        }
    }

    public class Test
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public Test()
        {
            a = 1; b = 2; c = 3;
        }

        public Test(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public class StringFinder
    {
        public string Word { get; set; }

        public StringFinder(string word)
        {
            Word = word;
        }

        public string StringFind(string word)
        {
            return Word + word[1];
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test(1, 2, 3);
            StringFinder stringFinder = new StringFinder("word");
            List<int> list = new List<int> { 1, 2, 3 };

            Reflector.Info(test.ToString(), "System.Int32");
            Reflector.Info(stringFinder.ToString(), "System.String");
            Reflector.Info(list.ToString(), "System.Int32");

            Reflector.Invoke();

            var inst = Reflector.Create<Test>();
            Console.WriteLine(inst.Sum(2, 2));
        }
    }
}
