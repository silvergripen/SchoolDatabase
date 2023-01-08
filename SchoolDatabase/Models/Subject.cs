using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public int Subjectid { get; set; }
        public string SubjectName { get; set; } = null!;
        public int? Classid { get; set; }
        public int? PersonelId { get; set; }

        public virtual Personel? Personel { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
