using lab7;
using lab9;
using System;
using System.Diagnostics;

namespace laboratory_work7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new String('_', 100));
            Console.WriteLine("first task");

            Person p1 = new Person();
            Person p2 = new Person();
            Console.WriteLine(Object.ReferenceEquals(p1, p2));
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());

            Console.WriteLine(new String('_', 100));
            Console.WriteLine("second task");

            Student student = new Student();
            Exam exam1 = new Exam();
            Exam exam2 = new Exam("Math", 2, DateTime.Today);
            Test test1 = new Test();
            Test test2 = new Test("Philosophy", true);
            student.AddExams(exam1, exam2);
            student.AddTests(test1, test2);
            Console.WriteLine(student);

            Console.WriteLine(new String('_', 100));
            Console.WriteLine("third task");


            Console.WriteLine(student.Person);

            Console.WriteLine(new String('_', 100));
            Console.WriteLine("fourth task");

            Student studentCopy = student.DeepCopy() as Student;
            Console.WriteLine(student);
            Console.WriteLine(studentCopy);
            student.Group = 201;
            Console.WriteLine(student);
            Console.WriteLine(studentCopy);

            Console.WriteLine(new String('_', 100));
            Console.WriteLine("fifth task");

            try
            {
                student.Group = 10;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(new String('_', 100));
            Console.WriteLine("sixth task");

            foreach (var item in student.ExamsAndTests())
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(new String('_', 100));
            Console.WriteLine("seventh task");

            foreach (var item in student.ExamsBiggerThan(3))
            {
                Console.WriteLine(item);
            }

        }
    }
}