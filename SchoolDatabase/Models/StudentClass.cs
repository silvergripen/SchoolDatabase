using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class StudentClass
    {
        public StudentClass()
        {
            Classes = new HashSet<Class>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int? ClassId { get; set; }
        public string? StudentClassName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
