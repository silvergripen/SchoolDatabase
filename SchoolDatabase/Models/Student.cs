using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime? Bday { get; set; }
        public int? Klassid { get; set; }
        public int? Adressid { get; set; }

        public virtual Adress? Adress { get; set; }
        public virtual StudentClass? Klass { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
