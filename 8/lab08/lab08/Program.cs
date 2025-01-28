using System;
using System.Diagnostics;
using System.Collections;
using System.Xml;

namespace lab08
{
    public delegate void UpgradeEvent();
    public delegate void TurnOnEvent(int voultage);
    public class Boss
    {

        public event UpgradeEvent? Upgrade;
        public event TurnOnEvent? TurnOn;

        public void PerformUpgrade()
        {
            Console.WriteLine("Boss: Включение...");
            Upgrade?.Invoke();
        }

        public void PerformTurnOn(int voltage)
        {
            Console.WriteLine($"Boss: Включение на {voltage}V.");
            TurnOn?.Invoke(voltage);
        }

    }

    public abstract class Device
    {
        public string Name { get; set; }
        public bool Work { get; set; } = true;
        public int level { get; set; } = 0;

        public Device(string name)
        {
            Name = name;
        }

        public abstract void upgrade();
        public abstract void turnOn(int volt);
    }

    public class Laptop : Device
    {
        public Laptop(string name) : base(name) { }
        public override void upgrade() => Console.WriteLine(Work ? $"Улучшение {Name} до уровня {++level}" : $"Оборудование {Name} сломано!");
        public override void turnOn(int volt)
        {
            if (Work)
            {
                if (volt < 220)
                {
                    Console.WriteLine("Слишком маленькое напряжение!");
                }
                else if (volt > 250)
                {
                    Console.WriteLine($"Большое напряжение, устройство {Name} сломано");
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {volt}");
                }
            }
            else
            {
                Console.WriteLine($"Устройство{Name} сломано");
            }
        }
    }

    public class Cooker : Device
    {
        public Cooker(string name) : base(name) { }
        public override void upgrade() => Console.WriteLine(Work ? $"Улучшение {Name} до уровня {++level}" : $"Оборудование {Name} сломано!");
        public override void turnOn(int volt)
        {
            if (Work)
            {
                if (volt < 380)
                {
                    Console.WriteLine("Слишком маленькое напряжение!");
                }
                else if (volt > 410)
                {
                    Console.WriteLine($"Большое напряжение, устройство {Name} сломано");
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {volt}");
                }
            }
            else
            {
                Console.WriteLine($"Устройство{Name} сломано");
            }
        }
    }

    public class Fridge : Device
    {
        public Fridge(string name) : base(name) { }
        public override void upgrade() => Console.WriteLine(Work ? $"Улучшение {Name} до уровня {++level}" : $"Оборудование {Name} сломано!");
        public override void turnOn(int volt)
        {
            if (Work)
            {
                if (volt < 220)
                {
                    Console.WriteLine("Слишком маленькое напряжение!");
                }
                else if (volt > 300)
                {
                    Console.WriteLine($"Большое напряжение, устройство {Name} сломано");
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {volt}");
                }
            }
            else
            {
                Console.WriteLine($"Устройство{Name} сломано");
            }
        }
    }

    class StringWorks
    {
        private Action<string> CorrectStr1;
        private Action<string, char> Correctstr2;

        public StringWorks()
        {

            CorrectStr1 += DeleteSpace;
            CorrectStr1 += UpperCase;
            CorrectStr1 += DelPunct;
            Correctstr2 = AddSymb;
        }

        public void DeleteSpace(string str)
        {
            str = str.Replace(" ", "");
            Console.WriteLine($"Строка без пробелов: {str}");
        }

        public void UpperCase(string str)
        {
            str = str.ToUpper();
            Console.WriteLine($"Строка в верхнем регистре{str}");
        }

        public void DelPunct(string str)
        {
            str = str.Replace("!", "")
                     .Replace(".", "")
                     .Replace(",", "")
                     .Replace(":", "")
                     .Replace(";", "")
                     .Replace("?", "");
            Console.WriteLine($"Строка без знаков препинания: {str}");
        }

        public void AddSymb(string str, char symb) {
            str += symb;
            Console.WriteLine($"Измененная строка: {str}");
        }

        public void UseAll(string input, char addSymb)
        {
            Console.WriteLine("Исходная строка: " + input);

            Correctstr2?.Invoke(input, addSymb);

            CorrectStr1?.Invoke(input);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boss boss = new Boss();
            Laptop laptop = new Laptop("Laptop1");
            Cooker cooker = new Cooker("Cooker1");
            Fridge fridge = new Fridge("Fridge1");

            boss.Upgrade += laptop.upgrade;
            boss.Upgrade += cooker.upgrade;
            boss.Upgrade += fridge.upgrade;

            boss.TurnOn += laptop.turnOn;
            boss.TurnOn += cooker.turnOn;
            boss.TurnOn += fridge.turnOn;

            boss.PerformUpgrade();
            boss.PerformTurnOn(420);
            boss.PerformTurnOn(240);


            StringWorks stringWorks = new StringWorks();

            string input = "Hello, World!";
            char ch = '1';

            stringWorks.UseAll(input, ch);
        }
    }
}
