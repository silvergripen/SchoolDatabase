using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class StudentSubject
    {
        public int StudentSubjectId { get; set; }
        public int? Studentid { get; set; }
        public int? Subjectid { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
