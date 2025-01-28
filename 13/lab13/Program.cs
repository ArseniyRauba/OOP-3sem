using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;

namespace lab13
{
    class Program
    {
        static void Main()
        {
            Question question1 = new Question("Q1", "2 + 2 = ?");
            Question question2 = new Question("Q2", "5 + 7 = ?");
            Question question3 = new Question("Q3", "2 * 2 = ?");

            Console.WriteLine("Serialization: ");
            Console.WriteLine("Binary: ");
            Serializer.Serialize("question1.bin", question1);

            Console.WriteLine("Json: ");
            Serializer.Serialize("question2.json", question2);

            Console.WriteLine("XML: ");
            Serializer.Serialize("question3.xml", question3);

            Console.WriteLine("Deserialization: ");
            Console.WriteLine("Binary: ");
            Serializer.Deserialize("question1.bin");

            Console.WriteLine("Json: ");
            Serializer.Deserialize("question2.json");

            Console.WriteLine("XML: ");
            Serializer.Deserialize("question3.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            List<Question> checks = new List<Question>();
            checks.Add(question1);
            checks.Add(question2);
            checks.Add(question3);

            using (FileStream fs = new FileStream("Collection.xml", FileMode.Create))
            {
                serializer.Serialize(fs, checks);
            }

            Console.WriteLine("XML сериализация коллекции");
            using (FileStream fr = new FileStream("Collection.xml", FileMode.Open))
            {
                List<Question> newLst = (List<Question>)serializer.Deserialize(fr);
                foreach (var item in newLst)
                {
                    Console.WriteLine($"Десериализован: " + item.ToString());
                }
            }

            XmlDocument document = new XmlDocument(); // Создаем XML-документ
            document.Load("Collection.xml"); // Загружаем XML-документ из файла
            XmlNode xmlRoot = document.DocumentElement; // Получаем корневой элемент
            XmlNodeList allPlants = xmlRoot.SelectNodes("*"); // Получаем список всех узлов в документе
            foreach (XmlNode node in allPlants)
            {
                Console.WriteLine(node.InnerText);
            }

            XElement language;
            XElement name;
            XAttribute year;

            XDocument Lang = new XDocument();
            XElement root = new XElement("ЯП");

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "C#";
            year = new XAttribute("year", "1998");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "C++";
            year = new XAttribute("year", "1983");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            language = new XElement("language");
            name = new XElement("name");
            name.Value = "Java";
            year = new XAttribute("year", "1995");
            language.Add(name);
            language.Add(year);
            root.Add(language);

            Lang.Add(root);
            Lang.Save("Lang.xml");

            // Запрос от пользователя
            Console.WriteLine("Введите год для поиска: ");
            string yearXML = Console.ReadLine();
            var allAlbums = root.Elements("language");//linq
            /*var allAlbums = root.Elements("language")
                                    .Where(x=>x.Attribute("year").Value == yearXML);
             */

            foreach (var item in allAlbums)
            {
                if (item.Attribute("year").Value == yearXML)
                {
                    Console.WriteLine(item.Value);
                }
            }

            // Использование XPath для поиска языков по году из Lang.xml
            Console.WriteLine("\nИспользуем XPath для поиска по году:");
            var doc = XDocument.Load("Lang.xml");  // Загружаем документ с языками
            var languages = doc.XPathSelectElements($"//languag[@year='{yearXML}']");

            foreach (var languag in languages)
            {
                Console.WriteLine($"Язык: {languag.Element("name").Value}, Год: {languag.Attribute("year").Value}");
            }
        }
    }
}
