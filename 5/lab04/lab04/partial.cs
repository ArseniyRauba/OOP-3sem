using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab04
{
    public partial class zachet
    {
        public override void Print()
        {
            Console.WriteLine($"Зачет по предмету: {subject}; Сдан: {pass}");
        }
    }

}
