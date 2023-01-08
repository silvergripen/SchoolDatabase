using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Class
    {
        public Class()
        {
            PersonelClasses = new HashSet<PersonelClass>();
            Schedules = new HashSet<Schedule>();
        }

        public int Classid { get; set; }
        public int Subjectid { get; set; }
        public int? StudClassid { get; set; }

        public virtual StudentClass? StudClass { get; set; }
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<PersonelClass> PersonelClasses { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
