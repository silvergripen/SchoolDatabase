using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class PersonelClass
    {
        public int Id { get; set; }
        public int? Personelid { get; set; }
        public int? Classid { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Personel IdNavigation { get; set; } = null!;
    }
}
