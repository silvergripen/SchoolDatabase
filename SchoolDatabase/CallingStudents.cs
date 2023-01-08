using Microsoft.Data.SqlClient;
using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            foreach (var item in innerJoin)
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

        public void AllInfoStudents()
        {
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students
                            join a in context.Adresses
                            on s.Adressid equals a.Adressid
                            join b in context.Grades
                            on s.StudentId equals b.Studentid
                            join c in context.Subjects
                            on b.Subjectid equals c.Subjectid
                            join d in context.GradeSets
                            on b.Grade1 equals d.GradeSetId
                            //group s.StudentId by b.Studentid into e
                            orderby s.Fname
                            
                            select new
                            {
                                StudentFName = s.Fname,
                                StudentLName = s.Lname,
                                AdressName = a.Adress1,
                                AdressCounty = a.County,
                                GradeDate = b.Dateset,
                                Gradeperf = b.Grade1,
                                subjectGrade = c.SubjectName

                            };
            
            foreach (var item in innerJoin)
            {
                //var firName = string.Concat(item.StudentFName);
                Console.WriteLine(item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(item.subjectGrade + " " + item.Gradeperf + " " + item.GradeDate);
                //Console.WriteLine(item.AdressName);
                //Console.WriteLine(item.AdressCounty);
                //for (int i = 0; i < item.subjectGrade.Length; i++)
                //{
                //   
                //}
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
            Console.WriteLine("5) Kolla upp specific student");
            Console.WriteLine("6) Kolla upp all info om alla studenters betyg");

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
                    Console.Clear();
                    GetSpecificStudent();
                    return true;
                case "6":
                    AllInfoStudents();
                    return true;
                default:
                    return true;
            }

        
           

        }
        public ArrayList GetSpecificStudent()
        {

            using TestContext context = new TestContext();
            var innerJoin = from s in context.Students

                            orderby s.StudentId
                            select new
                            {
                                StudentID = s.StudentId,
                                StudentFName = s.Fname,
                                StudentLName = s.Lname

                            };
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.StudentID + ": " + item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(new string('-', (30)));
            }

                AddPlGetSet pep = new AddPlGetSet();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GetSpecificStudent", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            Console.WriteLine("Skriv ID på Studenten du vill se information om:");
            pep.workid = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@Id", pep.workid);
            School = cmdPerson.ExecuteReader();
            ArrayList allNames = new ArrayList();
            while (School.Read())
            {
                allNames.Add(School.GetValue(0));
                allNames.Add(School.GetValue(1));
                allNames.Add(School.GetValue(2));
                allNames.Add(School.GetValue(3));
                allNames.Add(School.GetValue(4));
                allNames.Add(School.GetValue(5));
                allNames.Add(School.GetValue(6));
                allNames.Add(School.GetValue(7));
                allNames.Add(School.GetValue(8));
            }
            
            for (int i = 0; i < allNames.Count; i += 9)
            {

                Console.WriteLine("{0} {1} {2} ", allNames[i], allNames[i + 1], allNames[i + 2]);
                Console.WriteLine("{0}:", allNames[i + 4] + " ");
                Console.WriteLine(allNames[i + 3] + " " + allNames[i + 5]);
                Console.WriteLine(allNames[i + 8] + " " + allNames[i + 7] + " " + allNames[i + 6]);
                Console.WriteLine(new string('-', (40)));

            }
            School.Close();
            connect.Close();
            return allNames;
        }
    }
}
