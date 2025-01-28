using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OOP_Lab12
{
    static class VAVDirInfo
    {
        public static void GetDirInfo(string path)//про папку ООП
        {
            DirectoryInfo dirInf = new(path);
            if (dirInf.Exists)
            {
                Console.WriteLine("Имя каталога: {0}", dirInf.Name);//тут у нас имя
                Console.WriteLine("Полный путь: {0}", dirInf.FullName);// тут полный путь
                Console.WriteLine("Время создания: {0}", dirInf.CreationTime);//тут как будто дальше все понятно
                Console.WriteLine("Корневой каталог: {0}", dirInf.Root);
                Console.WriteLine("Родительский каталог: {0}", dirInf.Parent);
                Console.WriteLine("Количество файлов: {0}", dirInf.GetFiles().Length);
                Console.WriteLine("Количество подкаталогов: {0}", dirInf.GetDirectories().Length);
            }
            VAVLog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
