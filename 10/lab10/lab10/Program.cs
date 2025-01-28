using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    internal class Program
    {
        public partial class Phone
        {
            private int ID;
            private string last_name;
            private string name;
            private string middle_name;
            private string adress;
            private string num_card;
            private decimal debit;
            private decimal kredit;
            private int local_call;
            private int long_call;

            private static int objCounter;

            public const int iPhone = 200;

            public int id
            {
                get
                {
                    return ID;
                }
                set
                {
                    ID = value;
                }
            }

            public string surrname
            {
                get
                {
                    return last_name;
                }
                set
                {
                    last_name = value;
                }
            }

            public string nname
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public string middle_n
            {
                get
                {
                    return middle_name;
                }
                set
                {
                    middle_name = value;
                }
            }

            public string location
            {
                get
                {
                    return adress;
                }
                set
                {
                    adress = value;
                }
            }

            public string card
            {
                get
                {
                    return num_card;
                }
                set
                {
                    num_card = value;
                }
            }

            public decimal deBit
            {
                get
                {
                    return debit;
                }
                set
                {
                    debit = value;
                }
            }

            public decimal kreDit
            {
                get
                {
                    return kredit;
                }
                set
                {
                    kredit = value;
                }
            }

            public int local
            {
                get
                {
                    return local_call;
                }
                set
                {
                    local_call = value;
                }
            }

            public int longc
            {
                get
                {
                    return long_call;
                }
                set
                {
                    long_call = value;
                }
            }

        }
        public partial class Phone
        {
            public Phone(int ID, string last_name, string name, string middle_name, string adress, string num_card, decimal debit, decimal credit, int local_call, int long_call)
            {
                id = ID; 
                surrname = last_name;
                nname = name;
                middle_n = middle_name;
                location = adress;
                card = num_card;
                deBit = debit;
                kreDit = credit;
                local = local_call;
                longc = long_call;
            }

            static Phone()
            {
                objCounter = 0;
                Console.WriteLine(objCounter);
            }

            private Phone()
            {
                ID = GetHashCode();
                objCounter++;
            }

            public Phone CreateNew()
            {
                return new Phone();
            }

            public decimal Balance()
            {
                return debit - kredit;
            }

            public void UpdateCalls(ref int local, out int longDistance)
            {
                local += 10;
                longDistance = long_call;
            }

            public override bool Equals(object obj)
            {
                if (obj is Phone other)
                {
                    return this.ID == other.ID;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return (last_name + name + middle_n).GetHashCode();
            }

            public override string ToString()
            {
                return $"ID: {ID}, ФИО: {last_name} {name} {middle_name}, Адрес: {adress}, Номер кредитной карты: {num_card}, Дебет: {debit}, Кредит: {kredit}, Время внутригородских разговоров: {local_call} мин., Время междугородних разговоров: {long_call} мин.";
            }

            public static void PrintObjectCount()
            {
                Console.WriteLine($"Количество созданных объектов: {objCounter}");
            }

            public static void Out(Phone phone3)
            {
                Console.WriteLine(phone3.ToString());
            }

        }

        static void Main(string[] args)
        {
            //1
            string[] month = { "january", "february", "march", "april", "june", "jule", "august", "september", "october", "november", "december" };
            int n = 4;

            var nLenMonth = from m in month
                            where m.Length == n
                            select m;

            foreach (var m in nLenMonth)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n");

            var summerWinter = from m in month
                               where m == "june" || m == "jule" || m == "august" || m == "december" || m == "january" || m == "february"
                               select m;

            foreach (var m in summerWinter)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n");

            var soretedMonths = month.OrderBy(m => m);
            foreach (var m in soretedMonths)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n");

            var countU = month.Where(m => month.Length >= 4 && m.Contains("u"));
            foreach (var m in countU)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("\n");

            //2(8var)
            List<Phone> phones = new List<Phone>();
            Phone phone1 = new Phone(1, "Рауба", "Арсений", "Владимирович", "ул. Белорусская, д.21", "1234567812345678", 1000, 500, 90, 0);
            Phone phone2 = new Phone(2, "Кулешов", "Артем", "Алексеевич", "ул. Пушкина, д.52", "2345678923456789", 2000, 1000, 30, 0);
            Phone phone3 = new Phone(3, "Иванов", "Андрей", "Сидорович", "ул. Советская, д.125", "3456789034567890", 1000, 800, 150, 20);
            Phone phone4 = new Phone(4, "Кузнецов", "Николай", "Александрович", "ул. Карла Маркса, д.4", "4567890145678901", 3000, 1500, 200, 90);
            Phone phone5 = new Phone(5, "Смирнов", "Дмитрий", "Иванович", "ул. Ленина, д.10", "5678901256789012", 2500, 1200, 50, 10);
            Phone phone6 = new Phone(6, "Петров", "Илья", "Сергеевич", "ул. Мира, д.7", "6789012367890123", 1000, 700, 70, 15);
            Phone phone7 = new Phone(7, "Сидоров", "Олег", "Дмитриевич", "ул. Гагарина, д.30", "7890123478901234", 3500, 2000, 250, 100);
            Phone phone8 = new Phone(8, "Михайлов", "Евгений", "Андреевич", "ул. Калинина, д.19", "8901234589012345", 4000, 2500, 300, 120);
            Phone phone9 = new Phone(9, "Федоров", "Владимир", "Игоревич", "ул. Жукова, д.11", "9012345690123456", 2200, 1100, 80, 30);
            Phone phone10 = new Phone(10, "Алексеев", "Максим", "Николаевич", "ул. Победы, д.9", "0123456701234567", 2900, 1400, 100, 50);

            phones.Add(phone1);
            phones.Add(phone2);
            phones.Add(phone3);
            phones.Add(phone4);
            phones.Add(phone5);
            phones.Add(phone6);
            phones.Add(phone7);
            phones.Add(phone8);
            phones.Add(phone9);
            phones.Add(phone10);

            //время внутр больше 100
            int limitedTime_local = 100;
            var firstList = from phone in phones
                            where phone.local > limitedTime_local
                            select phone;

            Console.WriteLine("время внутр больше 100: ");

            foreach (var phone in firstList)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine("\n");

            //пользовались междугород связью
            var secondList = from phone in phones
                             where phone.longc > 0
                             select phone;

            Console.WriteLine("пользовались междугород связью: ");

            foreach (var phone in firstList)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine("\n");

            //с заданым значением дебета
            int debt = 1000;
            var thirdList = from phone in phones
                            where phone.deBit == debt
                            select phone;

            Console.WriteLine("с заданым значением дебета: ");

            foreach (var phone in thirdList)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine("\n");

            //макс абонент(local call)
            var fourthList = from phone in phones
                             select phone;
            var max = fourthList.OrderByDescending(phone => phone.local).FirstOrDefault();
            Console.WriteLine("макс абонент(local call): ");
            Console.WriteLine(max);
            Console.WriteLine("\n");

            //упорядоченные по фамилии
            var fifthList = phones.OrderBy(phone => phone.surrname);
            foreach (var phone in fifthList)
            {
                Console.WriteLine(phone);
            }
            Console.WriteLine("\n");

            //task4
            var task4 = phones.Where(p => p.local < 100).OrderBy(p => p.nname).GroupBy(p => p.id).Skip(2).Count();
            Console.WriteLine("task4");
            Console.WriteLine(task4);
            Console.WriteLine("\n");

            //join
            var tariffs = new List<(int ID, string Tariff)>
            {
                (1, "Тариф A"),
                (2, "Тариф B"),
                (3, "Тариф C"),
                (4, "Тариф D"),
                (5, "Тариф E"),
                (6, "Тариф F"),
                (7, "Тариф G"),
                (8, "Тариф H"),
                (9, "Тариф I"),
                (10, "Тариф J")
            };

            var joinedList = from phone in phones
                             join tariff in tariffs
                             on phone.id equals tariff.ID
                             select new
                             {
                                 phone.id,
                                 Name = $"{phone.nname} {phone.middle_n} {phone.surrname}",
                                 TariffName = tariff.Tariff
                             };

            Console.WriteLine("Абоненты с тарифами:");
            foreach (var item in joinedList)
          {
                Console.WriteLine($"ID: {item.id}, Имя: {item.Name}, Тариф: {item.TariffName}");
            }
        }
    }
}
