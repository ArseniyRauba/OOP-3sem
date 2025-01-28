using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TPL.task1(2200);
                TPL.task2(6000);
                TPL.task4_1();
                TPL.task4_2();
                TPL.task5();
                TPL.task6();
                TPL.task7();
                TPL.task8();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1000);
        }
    }
}