using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class CallingStudents
    {
       
        public void CallingStudentsFname()
        {
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students
                            join a in context.Adresses
                            on s.Adressid equals a.Adressid
                            orderby s.Fname
                            select new
                            {
                                StudentFName = s.Fname,
                                StudentLName = s.Lname,
                                AdressName = a.Adress1,
                                AdressCounty = a.County

                            };
            
            foreach(var item in innerJoin)
            {
                Console.WriteLine(item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(item.AdressName);
                Console.WriteLine(item.AdressCounty);
                Console.WriteLine(new string('-', (30)));
            }
        }
        public void CallingStudentsFnameDesc()
        {
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students
                            join a in context.Adresses
                            on s.Adressid equals a.Adressid
                            orderby s.Fname descending
                            select new
                            {
                                StudentFName = s.Fname,
                                StudentLName = s.Lname,
                                AdressName = a.Adress1,
                                AdressCounty = a.County
                            };
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(item.AdressName);
                Console.WriteLine(item.AdressCounty);
                Console.WriteLine(new string('-', (30)));
            }
        }
        public void CallingStudentsLname()
        {
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students
                            join a in context.Adresses
                            on s.Adressid equals a.Adressid
                            orderby s.Lname
                            select new
                            {
                                StudentFName = s.Fname,
                                StudentLName = s.Lname,
                                AdressName = a.Adress1,
                                AdressCounty = a.County
                            };
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(item.AdressName);
                Console.WriteLine(item.AdressCounty);
                Console.WriteLine(new string('-', (30)));
            }
        }
        public void CallingStudentsLnameDesc()
        {
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students
                            join a in context.Adresses
                            on s.Adressid equals a.Adressid
                            orderby s.Lname descending
                            select new
                            {
                                StudentFName = s.Fname,
                                StudentLName = s.Lname,
                                AdressName = a.Adress1,
                                AdressCounty = a.County
                            };
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(item.AdressName);
                Console.WriteLine(item.AdressCounty);
                Console.WriteLine(new string('-', (30)));
            }
        }
        public bool CallStudentMenu()
        {
            Console.WriteLine("Välj vilket nummer du vill ha:");
            Console.WriteLine("1) Sorterat efter förstanamn Ascendig");
            Console.WriteLine("2) Sorterat efter förstanamn Descending");
            Console.WriteLine("3) sorterat efter Efternamn Ascending");
            Console.WriteLine("4) sorterat efter Efternamn Descending");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    CallingStudentsFname();
                    return true;
                case "2":
                    Console.Clear();
                    CallingStudentsFnameDesc();
                    return true;
                case "3":
                    Console.Clear();
                    CallingStudentsLname();
                    return true;
                case "4":
                    Console.Clear();
                    CallingStudentsLnameDesc();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }

        }
    }
}
