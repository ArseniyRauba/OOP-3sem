using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab12
{
    static class VAVFileInfo
    {
        public static void GetFileInfo(string path)
        {
            FileInfo fileInf = new FileInfo(path);//тут про файл с которым работаем
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Полный путь: {0}", fileInf.DirectoryName);
                Console.WriteLine("Расширение: {0}", fileInf.Extension);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
                Console.WriteLine($"Время последнего доступа к файлу: {0}", fileInf.LastAccessTime);
                Console.WriteLine($"Время последнего изменения файла: {0}", fileInf.LastWriteTime);
            }
            VAVLog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
