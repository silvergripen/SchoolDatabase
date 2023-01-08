using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int? Subjectid { get; set; }
        public int? Studentid { get; set; }
        public DateTime? Dateset { get; set; }
        public int? Grade1 { get; set; }
        public int? TeacherSetId { get; set; }

        public virtual GradeSet? Grade1Navigation { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Personel? TeacherSet { get; set; }
    }
}
