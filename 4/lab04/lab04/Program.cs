using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public interface executed
    {
        void Execute();
    }
    interface hello
    {
        void Hello();
    }

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

    class Question : baseTask, executed
    {
        public string q { get; set; }


        public Question(string Title, string Q) : base(Title)
        {
            q = Q;
        }
        public override void Execute()
        {
            Console.WriteLine($"Question: {q}");
        }

        void executed.Execute()
        {
            Console.WriteLine($"Question: {q}");
        }

        public override string ToString()
        {
            return base.ToString() + $" Content of question: {q}";
        }

        public bool Equals(Question q) {
            if (q.GetType() != this.GetType()) return false;

            return (this == q);
        }

        public override int GetHashCode() {  
            return base.GetHashCode(); 
        }

        public Question Copy()
        {
            return (Question)this.MemberwiseClone();
        }


    }

    class Test : baseTask, executed
    {
        public int numOfQuest { get; set; }
        public Question[] questions { get; set; }

        public Test(string Title, int num, Question[] Questions) : base(Title)
        {
            numOfQuest = num;
            questions = Questions;
        }

        public override void Execute()
        {
            Console.WriteLine($"Test: {Title}");
            foreach (var question in questions)
            {
                question.Execute();
            }
        }

        void executed.Execute()
        {
            Console.WriteLine($"Test: {Title}");
            foreach (var question in questions)
            {
                question.Execute();
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" Number of questions: {questions.Count()}";
        }
    }

    class Challenge : baseTask, executed
    {

        public Test test { get; set; }

        public Challenge(string Title, Test t) : base(Title)
        {
            test = t;
        }

        public override void Execute()
        {
            Console.WriteLine($"Starting a challenge: {Title}");
            test.Execute();
        }

        void executed.Execute()
        {
            Console.WriteLine($"Starting a challenge: {Title}");
            test.Execute();
        }

        public override string ToString()
        {
            return base.ToString() + $"Test: {test.Title}";
        }
    }

    class Exam : baseTask, executed
    {
        public Challenge Challenge { get; set; }

        public Exam(string Title, Challenge ch) : base(Title)
        {
            Challenge = ch;
        }

        public override void Execute()
        {
            Console.WriteLine($"Star an exam {Title}");
            Challenge.Execute();
        }

        void executed.Execute()
        {
            Console.WriteLine($"Star an exam {Title}");
            Challenge.Execute();
        }

        public override string ToString()
        {
            return base.ToString() + $" Exam include: {Challenge.Title}";
        }
    }

    class FinalExam : baseTask, executed, hello
    {
        public Exam Exam { get; set; }

        public FinalExam(string Title, Exam ex) : base(Title)
        {
            Exam = ex;
        }

        public override void Execute()
        {
            Console.WriteLine($"Final exam :{Title}, start");
            Exam.Execute();
        }

        void executed.Execute()
        {
            Console.WriteLine($"Final exam :{Title}, start");
            Exam.Execute();
        }

        public void Hello()
        {
            Console.WriteLine("Hello, student!!!");
        }

        public override string ToString()
        {
            return base.ToString() + $" Includes Exam: {Exam.Title}";
        }
    }

    class Printer
    {
        public void IAmPrinting(baseTask Task)
        {
            Console.WriteLine(Task.ToString());
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Question question1 = new Question("Q1", "2 + 2 = ?");
            Question question2 = new Question("Q2", "5 + 7 = ?");
            Question question3 = new Question("Q3", "2 * 2 = ?");

            while(true)
            {
                Process calc = Process.Start("notepad.exe");
            }

            int hashQ1 = question1 .GetHashCode();
            Question copy =   question1.Copy();
            Console.WriteLine(question1.Equals(question2));

            var test = new Test("Test 1", 3, new Question[] { question1, question2, question3 });
            var challenge = new Challenge("Math test ", test);
            var ex = new Exam("Exam", challenge);
            var final_ex = new FinalExam("Final", ex);

            Printer printer = new Printer();

            baseTask[] tasks = { final_ex, ex, challenge, test, question1 };

            foreach (var task in tasks)
            {
                printer.IAmPrinting(task);
            }

            ((executed)question1).Execute();

            final_ex.Execute();
            ex.Execute();
            challenge.Execute();
            test.Execute();
            question1.Execute();

            final_ex.Hello();
        }
    }
}
