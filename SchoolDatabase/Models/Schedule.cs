using System;
using System.Collections.Generic;

namespace SchoolDatabase.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public string? DayofWeek { get; set; }
        public TimeSpan? TimeofDay { get; set; }
        public int? Classid { get; set; }

        public virtual Class? Class { get; set; }
    }
}
