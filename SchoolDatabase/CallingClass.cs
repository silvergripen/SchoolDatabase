using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class CallingClass
    {
        public void CallingStudentsSubject()
        {
            using TestContext context = new TestContext();
            var students = from x in context.StudentSubjects
                           join s in context.Students on x.Studentid equals s.StudentId
                           join c in context.Subjects on x.Subjectid equals c.Subjectid
                           where c.SubjectName == "Math"
                           select new
                           {
                               subjectName = c.SubjectName,
                               studentFName = s.Fname,
                               studentLName = s.Lname
                           };
                           
                
            foreach (var item in students)
            {
                Console.WriteLine(item.subjectName);
                Console.WriteLine(item.studentFName + " " + item.studentLName);
                Console.WriteLine(new string('-', (30)));
            }

        }
    }
}

