using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using static System.Collections.Specialized.BitVector32;

namespace lab13
{
    class Serializer
    {
        public static void Serialize(string filename, Question q)
        {
            string[] format = filename.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            bf.Serialize(fs, q);
                            Console.WriteLine($"Object serialized to {filename}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Question));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            json.WriteObject(fs, q);
                            Console.WriteLine($"Object serialized to {filename}");
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(Question));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            xml.Serialize(fs, q);
                            Console.WriteLine($"Object serialized to {filename}");
                        }
                        break;
                    }
                case "soap": 
                    {
                        SoapFormatter sf = new SoapFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            sf.Serialize(fs, q);
                            Console.WriteLine($"Object serialized to {filename}");
                        }
                        break; 
                    }
                default:
                    {
                        Console.WriteLine("Wrong format of file");
                        break;
                    }
            }
        }

        public static void Deserialize(string filename)
        {
            string[] format = filename.Split('.');
            switch (format[1])
            {
                case "bin":
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            Question desQ = (Question)bf.Deserialize(fs);
                            Console.WriteLine($"Deserialized from file {desQ.ToString}");
                        }
                        break;
                    }
                case "json":
                    {
                        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Question));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            Question desQ = (Question)json.ReadObject(fs);
                            Console.WriteLine($"Deserialized from file {desQ.ToString}");
                        }
                        break;
                    }
                case "xml":
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(Question));
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            Question desQ = (Question)xml.Deserialize(fs);
                            Console.WriteLine($"Deserialized from file {desQ.ToString}");
                        }
                        break;
                    }
                case "soap":
                    {
                        SoapFormatter sf = new SoapFormatter();
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            Question desQ = (Question)sf.Deserialize(fs);
                            Console.WriteLine($"Deserialized from file {desQ.ToString}");
                        }
                        break;
                    }
            }
        }
    }
}
