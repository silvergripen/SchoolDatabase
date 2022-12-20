using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Class
    {
        public Class()
        {
            PersonelClasses = new HashSet<PersonelClass>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Classid { get; set; }
        public DateTime? Classdate { get; set; }
        public int Subjectid { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<PersonelClass> PersonelClasses { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
