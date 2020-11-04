﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreTask.Entity
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
