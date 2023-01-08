using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class Subjects
    {
        public void ActiveSubjects()
        {
            using TestContext context = new TestContext();
            //var students = from x in context.StudentSubjects
            //               join s in context.Students on x.Studentid equals s.StudentId
            //               join c in context.Subjects on x.Subjectid equals c.Subjectid
            //               where c.SubjectName == "Math"
            //               select new
            //               {
            //                   subjectName = c.SubjectName,
            //                   studentFName = s.Fname,
            //                   studentLName = s.Lname
            //               };
            var subjects = from a in context.Subjects
                           where a.PersonelId != null
                           select new
                           {
                               subjectName = a.SubjectName,
                           };
            Console.WriteLine("Current active subjects");
            foreach (var item in subjects)
            {
                
                Console.WriteLine(item.subjectName);
                Console.WriteLine(new string('-', (30)));
            }
        }
    }
}
