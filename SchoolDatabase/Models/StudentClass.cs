﻿using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class StudentClass
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Student? Student { get; set; }
    }
}
