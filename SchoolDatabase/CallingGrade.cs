using Microsoft.Data.SqlClient;
using SchoolDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class CallingGrade
    {
        public ArrayList allgrades()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GetAllGradeWTeach", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            School = cmdPerson.ExecuteReader();
            ArrayList AllGrades = new ArrayList();

            while (School.Read())
            {
                AllGrades.Add(School.GetValue(0));
                AllGrades.Add(School.GetValue(1));
                AllGrades.Add(School.GetValue(2));
                AllGrades.Add(School.GetValue(3));
                AllGrades.Add(School.GetValue(4));
                AllGrades.Add(School.GetValue(5));
                AllGrades.Add(School.GetValue(6));


            }
            School.Close();
            connect.Close();
            return AllGrades;


        }
        public void printGrade()
        {
            //CallAvgGrades Grades = new CallAvgGrades();
            //System.Collections.ArrayList allNames = Grades.CallingMonthGrade();
            CallingGrade Grade = new CallingGrade();
            System.Collections.ArrayList allNames = Grade.allgrades();
           


            for (int i = 0; i < allNames.Count; i += 7)
            {

                Console.WriteLine("{0} {1} ", allNames[i], allNames[i + 1]);
                Console.WriteLine("{0}//Ämne:  {1} ", allNames[i + 2], allNames[i + 4] + " " + allNames[i + 3]);
                Console.WriteLine("Teacher set Grade: " + allNames[i + 5] + " " + allNames[i + 6]);
                Console.WriteLine(new string('-', (40)));

            }
        }
    }
}
