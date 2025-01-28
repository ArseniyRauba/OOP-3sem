using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using lab04;
using static System.Net.Mime.MediaTypeNames;

namespace lab04
{
    interface executed
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

        //public abstract void Execute();

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
        public void Execute()
        {
            Console.WriteLine($"Question: {q}");
        }

        public override string ToString()
        {
            return base.ToString() + $" Content of question: {q}";
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

        public void Execute()
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

        public void Execute()
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

        public void Execute()
        {
            Console.WriteLine($"Start an exam {Title}");
            Challenge.Execute();
        }

        public override string ToString()
        {
            return base.ToString() + $" Exam include: {Challenge.Title}";
        }
    }

    partial class FinalExam : baseTask, executed, hello
    {
        public Exam Exam { get; set; }

        public FinalExam(string Title, Exam ex) : base(Title)
        {
            Exam = ex;
        }

        public void Execute()
        {
            Console.WriteLine($"Final exam :{Title}, start");
            Exam.Execute();
        }


    }

    partial class FinalExam
    {
        public override string ToString()
        {
            return base.ToString() + $" Includes Exam: {Exam.Title}";
        }
        public void Hello()
        {
            Console.WriteLine("Hello, student!!!");
        }
    }

    class Printer
    {
        public void IAmPrinting(baseTask Task)
        {
            Console.WriteLine(Task.ToString());
        }
    }

    struct Student //структура
    {
        public string name;
        public int age;
        public int group;

        public Student(string Name, int Age, int Group)
        {
            name = Name;
            age = Age;
            group = Group;
        }

        public void Print()
        {
            Console.WriteLine($"Student[Name: {this.name}; Age: {this.age}; Group: {this.group}]");
        }
    }

    enum Days //перечисление
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public abstract class Task
    {
        public string subject { get; set; }
        public Task(string subj)
        {
            subject = subj;
        }

        public abstract void Print();
    }

    public class zachet : Task
    {
        public bool pass { get; set; }

        public zachet(string subj, bool IsPass) : base(subj)
        {
            pass = IsPass;
        }

        public override void Print()
        {
            Console.WriteLine($"Зачет по предмету: {subject}; Сдан: {pass}");
        }
    }

    public class ex : Task
    {
        public int grade { get; set; }

        public ex(string subj, int Grade) : base(subj)
        {
            grade = Grade;
        }

        public override void Print()
        {
            Console.WriteLine($"Экзамен по предмету: {subject}; Отметка: {grade}");
        }
    }

    public class Session
    { //контейнер
        private List<Task> chall = new List<Task>();
        public void Add(Task task)
        {
            chall.Add(task);
        }

        public ex Find(string Subject)
        {
            foreach (var test in chall)
            {
                if (test is ex exam && exam.subject == Subject)
                {
                    return exam;
                }
            }

            return null;
        }


        public int count()
        {
            return chall.Count;
        }
    }

    public class SessionController
    {
        private Session session;
        public SessionController(Session session)
        {
            this.session = session;
        }
        public void AddTask(Task task)
        {
            session.Add(task);
        }
        public ex FindExam(string subject)
        {
            return session.Find(subject);
        }
        public int Total()
        {
            return session.count();
        }
    }

    public class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }

    public class InvalidDataException : MyException
    {
        public InvalidDataException(string message) : base(message) { }
    }

    public class InvalidIndexException : MyException
    {
        public InvalidIndexException(string message) : base(message) { }
    }

    public class DataValidationException : MyException
    {
        public DataValidationException(string message) : base(message) { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Question question1 = new Question("Q1", "2 + 2 = ?");
            Question question2 = new Question("Q2", "5 + 7 = ?");
            Question question3 = new Question("Q3", "2 * 2 = ?");

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

            final_ex.Execute();
            ex.Execute();
            challenge.Execute();
            test.Execute();
            question1.Execute();

            final_ex.Hello();

            Student student = new Student("Arseniy", 18, 8);
            //student.name = "Arseniy";
            //student.age = 18;
            //student.group = 8;

            student.Print();

            Days today = Days.Saturday;
            Console.WriteLine($"Day: {today}");


            Session session = new Session();

            session.Add(new zachet("Математика", true));
            session.Add(new zachet("Физика", false));
            session.Add(new ex("Программирование", 5));
            session.Add(new ex("Математика", 4));

            Console.WriteLine("Экзамены по предмету 'Математика':");
            var mathEx = session.Find("Математика");
            Console.WriteLine(mathEx);

            SessionController controller = new SessionController(session);

            controller.AddTask(new ex("Математика", 2));
            var exam = controller.FindExam("Математика");
            Console.WriteLine(exam);
            Console.WriteLine($"Общее количество: {controller.Total()}");


            question1 = null;
            Debug.Assert(question1 == null, "вопрос не инициализирован!");

            Question[] qq = { question1, question2, question3 };
            try
            {
                try
                {
                    int x = 0;
                    int result = 10 / x;
                }
                catch (DivideByZeroException ex0)
                {
                    Console.WriteLine($"Ошибка деления на ноль: {ex0.Message}");
                    Console.WriteLine($"Стек вызовов: {ex0.StackTrace}");
                    Console.WriteLine($"Причина: {ex0.InnerException}");
                }

                try
                {
                    object someObject = "Hello, world!";
                    int invalidCast = (int)someObject;
                }
                catch (InvalidCastException ex01)
                {
                    Console.WriteLine($"Ошибка преобразования типа: {ex01.Message}");
                    Console.WriteLine($"Стек вызовов: {ex01.StackTrace}");
                    Console.WriteLine($"Причина: {ex01.InnerException}");
                }

                try
                {
                    if (question1 == null)
                    {
                        throw new InvalidDataException("Ошибка данных!");
                    }
                }
                catch (InvalidDataException ex1)
                {
                    Console.WriteLine($"Вызвано исключение InvalidDataException: {ex1.Message}");
                    Console.WriteLine($"Стек вызовов: {ex1.StackTrace}");
                    Console.WriteLine($"Причина: {ex1.InnerException}");
                }

                try
                {
                    int i = 3;

                    if (i >= qq.Length)
                    {
                        throw new InvalidIndexException("Неправильный индекс!");
                    }
                    else
                    {
                        Console.WriteLine(qq[i]);
                    }
                }
                catch (InvalidIndexException ex2)
                {
                    Console.WriteLine($"Вызвано исключение InvalidIndexException: {ex2.Message}");
                    Console.WriteLine($"Стек вызовов: {ex2.StackTrace}");
                    Console.WriteLine($"Причина: {ex2.InnerException}");
                }

                try
                {
                    question2.Title = "Q3";
                    if (question2.Title != "Q2")
                    {
                        throw new DataValidationException("Неправильная валидация!");
                    }
                }
                catch (DataValidationException ex3)
                {
                    Console.WriteLine($"Вызвано исключение DataValidationException: {ex3.Message}");
                    throw;
                }

            }

            catch (Exception EX)
            {
                Console.WriteLine($"Исключение обработано: {EX.Message}");
            }
            finally { Console.WriteLine("Finally!"); }
        }
    }
}
