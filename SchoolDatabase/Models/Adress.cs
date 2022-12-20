using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Adress
    {
        public Adress()
        {
            Personels = new HashSet<Personel>();
            Students = new HashSet<Student>();
        }

        public int Adressid { get; set; }
        public string Adress1 { get; set; } = null!;
        public string County { get; set; } = null!;

        public virtual ICollection<Personel> Personels { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
