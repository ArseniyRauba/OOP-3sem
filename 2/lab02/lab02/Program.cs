using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public partial class Phone
    {
        public readonly int ID;
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
    public partial class Phone {
        public Phone(int ID, string last_name, string name, string middle_name, string adress, string num_card, decimal debit, decimal credit, int local_call, int long_call)
        {
            ID = GetHashCode();
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

        public Phone CreateNew() {
            return new Phone();
        }


        //public Phone (int a = 0, string b = "Unknown",string c = "Unknown", string d = "Unknown", string e = "Unknown", string f = "0000000000000000",int g = 0, int h = 0, int i =0, int l = 0)
        //{
        //}

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

        private Phone phone123;

        public Phone phone12
        {
            get => phone123;
            set => phone123 = value;
        }

        //public static Phone() {
        //     Console.WriteLine('1');
        // }

        private int abc;
       
        public int field {
            get { return abc; }
            set { abc = value; }
        }



        public Phone (int ABC) {
            abc = ABC;
        }

        public string B(int h) {
            string str12 = "";
            for (int i = 0; i < abc; i++) {
                str12 += "a";
            }
            return str12;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Phone[] phones = new Phone[]{
                    new Phone(1, "Рауба", "Арсений", "Владимирович", "ул. Белорусская, д.21", "1234567812345678", 1000, 500, 90, 0),
                    new Phone(2, "Кулешов", "Артем", "Алексеевич", "ул. Пушкина, д.52", "2345678923456789", 2000, 1000, 30, 0),
                    new Phone(3, "Иванов", "Андрей", "Сидорович", "ул. Советская, д.125", "3456789034567890", 1500, 800, 150, 20),
                    new Phone(4, "Кузнецов", "Николай", "Александрович", "ул. Карла Маркса, д.4", "4567890145678901", 3000, 1500, 200, 90)
            };

            Phone phone1 = new Phone(1, "Рауба", "Арсений", "Владимирович", "ул. Белорусская, д.21", "1234567812345678", 1000, 500, 90, 0);
            Phone phone2 = new Phone(1, "Рауба", "Арсений", "Владимирович", "ул. Белорусская, д.21", "1234567812345678", 1000, 500, 90, 0);
            Phone phone3 = new Phone(1, "Рауба", "Арсений", "", "", "1234567812345678", 1000, 500, 90, 0);

            Console.WriteLine(phone1);
            Console.WriteLine(phone2.Balance());
            Console.WriteLine(phone1.Equals(phone2));

            int localCall = 50;
            phone1.UpdateCalls(ref localCall, out int longDistance);
            Console.WriteLine(phone1);

            int LocalCalls = 100;
            Console.WriteLine($"Абоненты, у которых время внутригородских разговоров больше, чем {LocalCalls} минут: ");

            Phone.PrintObjectCount();

            Phone.Out(phone3);

            foreach (var phone in phones) {
                if (phone.local > LocalCalls) {
                    Console.WriteLine(phone);
                }
            }

            foreach (var phone in phones)
            {
                if (phone.longc > 0)
                {
                    Console.WriteLine(phone);
                }
            }

            Phone phone4 = new Phone(1, "sgds", "","","","",233,233,22,0);
            phone4.phone12 = phone4;
            Console.WriteLine(phone4.phone12);

            var anonimus = new { phone1.nname, phone1.surrname, phone1.middle_n };





            Phone r = new Phone(12);
            r.B(r.field);
            Console.WriteLine(r.B(r.field));
        }
    }
}
