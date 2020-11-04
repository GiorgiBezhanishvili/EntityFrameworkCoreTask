using EntityFrameworkCoreTask.Context;
using EntityFrameworkCoreTask.Entity;
using EntityFrameworkCoreTask.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studentNames = new List<string>() { "Giorgi", "Toby", "Michael", "Pam", "Dwight", "Jim" };

            List<string> subjectNames = new List<string>() { "Math", "Programming", "History", "Biology", "Chemistry" };

            using (var context = new UniversityDbContext())
            {
                for (int i = 0; i < 50; i++)
                {
                    context.Add(new Student
                    {
                        StudentName = studentNames.Random()
                    });
                }

                for (int i = 0; i < 5; i++)
                {
                    context.Add(new Subject
                    {
                        SubjectName = subjectNames[i]
                    });
                }

                context.SaveChanges();
            }

            using (var context = new UniversityDbContext())
            {
                var students = context.Students.AsEnumerable();

                var subjects = context.Subjects.AsEnumerable();

                foreach (var student in students)
                {
                    var randomSubject = subjects.Random();
                    var distinctRandomSubject = subjects.Random();
                    while (randomSubject == distinctRandomSubject)
                        distinctRandomSubject = subjects.Random();

                    context.Add(new StudentSubject
                    {
                        StudentId = student.Id,
                        SubjectId = randomSubject.Id
                    });

                    context.Add(new StudentSubject
                    {
                        StudentId = student.Id,
                        SubjectId = distinctRandomSubject.Id
                    });
                }
                context.SaveChanges();
            }
            Console.WriteLine("The End!");
        }
    }
}
