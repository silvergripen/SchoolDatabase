using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class CallAvgGrades
    {
        public ArrayList CallingMonthGrade()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GradeDateMonth", connect);
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
                

            }
            School.Close();
            connect.Close();
            return AllGrades;

        }
        public void printGrade()
        {
            CallAvgGrades Grades = new CallAvgGrades();
            System.Collections.ArrayList allNames = Grades.CallingMonthGrade();


            for (int i = 0; i < allNames.Count; i += 5)
            {

                Console.WriteLine("{0} {1} ", allNames[i], allNames[i + 1]);
                Console.WriteLine("{0} {1} {2} ", allNames[i + 3], allNames[i + 4], allNames[i + 2]);
                Console.WriteLine(new string('-', (30)));

            }
        }

        public ArrayList CallingGradeAvgLowHi()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GradeAvgLowHi", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            School = cmdPerson.ExecuteReader();
            ArrayList CallAvgGrades = new ArrayList();

            while (School.Read())
            {
                CallAvgGrades.Add(School.GetValue(0));
                CallAvgGrades.Add(School.GetValue(1));
                CallAvgGrades.Add(School.GetValue(2));
                CallAvgGrades.Add(School.GetValue(3));
                CallAvgGrades.Add(School.GetValue(4));


            }
            School.Close();
            connect.Close();
            return CallAvgGrades;

        }
        public void printGradeAvg()
        {

                CallAvgGrades Grades = new CallAvgGrades();
                System.Collections.ArrayList allNames = Grades.CallingGradeAvgLowHi();


                for (int i = 0; i < allNames.Count; i += 5)
                {

                    Console.WriteLine("{0} {1} ", allNames[i], allNames[i + 1]);
                    Console.WriteLine("{0} {1} {2} ", allNames[i + 3], allNames[i + 4], allNames[i + 2]);
                    Console.WriteLine(new string('-', (30)));

                }
            
        }
        public bool printGradeMenu()
        {
            Console.WriteLine("Välj vilket nummer du vill ha:");
            Console.WriteLine("1) Alla betyg senaste månaden");
            Console.WriteLine("2) Betyg snittet samt högsta och lägsta betyget");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    printGrade();
                    return true;
                case "2":
                    Console.Clear();
                    printGradeAvg();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
