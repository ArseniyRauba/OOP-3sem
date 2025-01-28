using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab9
{
    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Developer { get; set; }

        public Software(string name, string version, string developer)
        {
            Name = name;
            Version = version;
            Developer = developer;
        }

        public override string ToString()
        {
            return $"Software:{this.Name}, Version{this.Version}, Developer{this.Developer}";
        }
    }

    public class ISoftware<T> : IList<T>
    {
        private SortedList<int, T> SoftwareList;

        public ISoftware()
        {
            SoftwareList = new SortedList<int, T>();
        }

        public T this[int index]
        {
            get => SoftwareList.Values[index];
            set => throw new NotSupportedException("Direct set operation is not supported.");
        }

        public int Count => SoftwareList.Count;
        public bool IsReadOnly => false;

        public void Add(T value)
        {
            int key = SoftwareList.Count;
            SoftwareList.Add(key, value);
        }

        public void Clear()
        {
            SoftwareList.Clear();
        }

        public bool Contains(T item)
        {
            return SoftwareList.Values.Contains(item);
        }

        public void CopyTo(T[] arr, int index)
        {
            SoftwareList.Values.CopyTo(arr, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return SoftwareList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < SoftwareList.Values.Count; i++)
            {
                if (SoftwareList.Values[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("operation is not supported.");
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < SoftwareList.Count)
            {
                SoftwareList.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }

        public bool Remove(T item)
        {
            int keyToRemove = -1;
            foreach (var pair in SoftwareList)
            {
                if (pair.Value.Equals(item))
                {
                    keyToRemove = pair.Key;
                    break;
                }
            }

            if (keyToRemove != -1)
            {
                SoftwareList.Remove(keyToRemove);
                return true;
            }
            return false;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Software soft1 = new Software("Win", "1.0", " Eminem");
            Software soft2 = new Software("Mac", "1.1", " Sanya");
            Software soft3 = new Software("Lini", "5.2", " Sanya");

            ISoftware<Software> SoftCollection = new ISoftware<Software>();

            SoftCollection.Add(soft1);
            SoftCollection.Add(soft2);
            SoftCollection.Add(soft3);

            foreach (var soft in SoftCollection)
            {
                Console.WriteLine(soft);
            }

            var searchItem = new Software("Visual Studio", "2022", "Microsoft");
            Console.WriteLine($"\nContains 'Visual Studio': {SoftCollection.Contains(searchItem)}");

            SoftCollection.Remove(soft1);
            foreach (var soft in SoftCollection)
            {
                Console.WriteLine(soft);
            }

            int n = 2;
            for (int i = 0; i < n; i++)
            {
                SoftCollection.RemoveAt(0);
            }

            SoftCollection.Add(new Software("js", "2.1", "who"));
            SoftCollection.Add(new Software("node.js", "1.3", "who"));

            var dictionaryCollection = new Dictionary<int, Software>();
            int key = 0;
            foreach (var software in SoftCollection)
            {
                dictionaryCollection[key++] = software;
            }

            foreach (var val in dictionaryCollection)
            {
                Console.WriteLine($"Key: {val.Key}, Value: {val.Value}");
            }

            string search = "who";

            foreach (var val in dictionaryCollection)
            {
                if (val.Value.Name == search)
                {
                    Console.WriteLine($"Found: {val.Value}");
                }
            }

            ObservableCollection<Software> observ = new ObservableCollection<Software>();
            observ.CollectionChanged += CollectionChanged;
            observ.Insert(0, soft1);
            observ.Insert(1, soft2);
            observ.Insert(2, soft3);
            observ.RemoveAt(0);
        }
        private static void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Software newSoft)
                    {
                        Console.WriteLine($"Добавлен новый объект: {newSoft.ToString()}");
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Software old)
                    {
                        Console.WriteLine($"Удалён объект: {old.ToString()}");
                    }
                    break;
            }
        }
    }
}