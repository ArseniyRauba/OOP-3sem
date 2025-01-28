using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab12
{
    static class VAVDiskInfo
    {
        public static void GetDiskInfo()// метод для доступа к дискк
        {
            DriveInfo[] infs = DriveInfo.GetDrives();
            foreach (DriveInfo inff in infs)
            {
                Console.WriteLine($"Имя диска : {inff.Name}");
                Console.WriteLine($"Свободное место на диске : {inff.AvailableFreeSpace}");
                Console.WriteLine($"Файловая система : {inff.DriveFormat}");
                if (inff.IsReady)
                {
                    Console.WriteLine($"Объем диска: {inff.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {inff.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {inff.VolumeLabel}");
                }
            }
            VAVLog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }
}
