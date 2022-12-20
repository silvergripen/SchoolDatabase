using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class GradeSet
    {
        public GradeSet()
        {
            Grades = new HashSet<Grade>();
        }

        public int GradeSetId { get; set; }
        public string? Grade { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
