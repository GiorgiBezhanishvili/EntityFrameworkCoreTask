using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreTask.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
