using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab13
{
    [Serializable]
    abstract class baseTask
    {
        public string Title { get; set; }

        public baseTask(string title)
        {
            Title = title;
        }

        public abstract void Execute();

        public override string ToString()
        {
            return $"Type: {GetType().Name}; Title: {Title};";
        }
    }

    [Serializable]
    [XmlRoot]
    class Question : baseTask
    {
        [NonSerialized]
        public string q;


        public Question(string Title, string Q) : base(Title)
        {
            q = Q;
        }
        public override void Execute()
        {
            Console.WriteLine($"Question: {q}");
        }

        public override string ToString()
        {
            return base.ToString() + $" Content of question: {q}";
        }

        public bool Equals(Question q)
        {
            if (q.GetType() != this.GetType()) return false;

            return (this == q);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Question Copy()
        {
            return (Question)this.MemberwiseClone();
        }
    }
}
