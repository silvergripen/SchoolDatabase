using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Personel
    {
        public int Jobid { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateTime Bday { get; set; }
        public int? WorkId { get; set; }
        public int? Adressid { get; set; }

        public virtual Adress? Adress { get; set; }
        public virtual Work? Work { get; set; }
        public virtual PersonelClass? PersonelClass { get; set; }
    }
}
