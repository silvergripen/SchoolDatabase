using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentClasses = new HashSet<StudentClass>();
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime Bday { get; set; }
        public int? Klassid { get; set; }
        public int? Adressid { get; set; }

        public virtual Adress? Adress { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
