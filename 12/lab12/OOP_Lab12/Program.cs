using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Тест метода GetDiskInfo()");
                VAVDiskInfo.GetDiskInfo();
                Console.WriteLine("\n\nТест метода GetFileInfo()");
                VAVFileInfo.GetFileInfo("D:\\3 семм\\ООП\\12_Потоки_файловая система.pdf");
                Console.WriteLine("\n\nТест метода GetDirInfo()");
                VAVDirInfo.GetDirInfo("D:\\3 семм\\ООП");
                Console.WriteLine("\n\nТест метода GetFilesAndFoulders()");
                VAVFileManager.GetFilesAndFoulders("..\\net6.0");
                Console.WriteLine("\n\nТест метода CreateCopyOfFile()");
                VAVFileManager.CreateCopyOfFile("..\\net6.0\\VAVInspect\\VAVdirinfo.txt");
                Console.WriteLine("\n\nТест метода Remove()");
                //VAVFileManager.Remove("..\\net6.0\\VAVInspect\\VAVdirinfo.txt\\copy_TDSdirinfo.txt");
                Console.WriteLine("\n\nСоздание директория VAVFiles");
                VAVFileManager.CreateDirectory("..\\net6.0", "VAVFiles");
                Console.WriteLine("\n\nКопирование файлов с расширением .dll и .exe в директорию VAVFiles");
                VAVFileManager.ReplaceTo("..\\net6.0", "VAVFiles", ".dll", ".exe");
                Console.WriteLine("\n\nУпаковка в zip-архив VAVFiles");
                VAVFileManager.CreateZip("VAVFiles");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}