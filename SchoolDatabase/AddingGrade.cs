using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SchoolDatabase.Data;
using System.Collections;

namespace SchoolDatabase
{
    internal class AddingGrade
    {
        public void addingGrades()
        {
            var currentdateset = DateOnly.FromDateTime(DateTime.Now);
            
            string date_str = currentdateset.ToString("yyyy-MM-dd");
            SubjGradeGetSet set = new SubjGradeGetSet();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            
            SqlCommand gradecmd = new SqlCommand("InputGrade", connect);
            using TestContext context = new TestContext();
            gradecmd.CommandType = CommandType.StoredProcedure;
            
            var Subject = from s in context.Subjects
                            orderby s.Subjectid

                            select new
                            {
                                SubjectId = s.Subjectid,
                                SubjectName = s.SubjectName
                            };

            var Grade = from s in context.GradeSets
                            orderby s.GradeSetId

                            select new
                            {
                                GradeId = s.GradeSetId,
                                GradeName = s.Grade
                            };
            var Student = from s in context.Students
                            
                            //group s.StudentId by b.Studentid into e
                            orderby s.StudentId

                            select new
                            {
                                StudentId = s.StudentId,
                                StudentFName = s.Fname,
                                StudentLName = s.Lname

                            };
            
            connect.Open();
            foreach (var item in Subject)
            {
                Console.WriteLine(item.SubjectId + " " + item.SubjectName);
                Console.WriteLine(new string("-"), 15);
            }
            Console.WriteLine("Vilket ämne ska betyget sättas på. Skriv nummeret nedan:");
            set.subjectId = Console.ReadLine();
            gradecmd.Parameters.AddWithValue("@Subjectid", set.subjectId);
            Console.WriteLine("Vilken student ska få betyget?");
            foreach (var item in Student)
            {
                Console.WriteLine(item.StudentId + " : " + item.StudentFName + " " + item.StudentLName);
                Console.WriteLine(new string('-', (15)));
            }
            Console.WriteLine("Skriv nummeret nedan");
            set.studentId = Console.ReadLine();
            gradecmd.Parameters.AddWithValue("@Studentid", set.studentId);
            Console.WriteLine("Vilket betyg vill du sätta på studenten?");
            foreach (var item in Grade)
            {
                Console.WriteLine(item.GradeId + " " + item.GradeName);
                Console.WriteLine(new string('-', (15)));
            }
            Console.WriteLine("Skriv nummeret nedan:");
            set.grade = Console.ReadLine();
            gradecmd.Parameters.AddWithValue("@Grade", set.grade);

            //SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlConnection connect2 = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdTeach = new SqlCommand("GetTeachers", connect2);
            cmdTeach.CommandType = CommandType.StoredProcedure;
            connect2.Open();
            SqlDataReader School;
            
            School = cmdTeach.ExecuteReader();
            ArrayList allNames = new ArrayList();
            while (School.Read())
            {
               allNames.Add(School.GetValue(0));
               allNames.Add(School.GetValue(1));
               allNames.Add(School.GetValue(2));
            }
            Console.WriteLine("Vilken lärare sätter betyget");
            for (int i = 0; i < allNames.Count; i += 3)
            {

                Console.WriteLine("{0} {1} {2}", allNames[i], allNames[i + 1], allNames[i + 2]);
                Console.WriteLine(new string('-', (30)));
            }
            Console.WriteLine("Skriv siffran nedan");
            set.teacherSetId = Console.ReadLine();
            gradecmd.Parameters.AddWithValue("@TeacherSetID", set.teacherSetId);
            gradecmd.Parameters.AddWithValue("@Dateset", date_str);
            gradecmd.ExecuteNonQuery();
            connect.Close();
            connect2.Close();
        }
        
        
        
    }
}
