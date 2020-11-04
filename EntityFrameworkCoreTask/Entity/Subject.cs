using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreTask.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
