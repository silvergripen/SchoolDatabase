using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Work
    {
        public Work()
        {
            Personels = new HashSet<Personel>();
        }

        public int Workid { get; set; }
        public string? Work1 { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
