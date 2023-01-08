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
    internal class CallingAvgSalary
    {
        public ArrayList SalaryCall()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("AvgSalary", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            School = cmdPerson.ExecuteReader();
            ArrayList AllSalary = new ArrayList();
            while (School.Read())
            {
                AllSalary.Add(School.GetValue(0));
                AllSalary.Add(School.GetValue(1));

            }
            for (int i = 0; i < AllSalary.Count; i += 2)
            {

                Console.WriteLine("{0} Avg Salary: {1} kr ", AllSalary[i], AllSalary[i + 1]);
                Console.WriteLine(new string('-', (30)));

            }
            School.Close();
            connect.Close();
            return AllSalary;
        }
        public ArrayList SalarySumCall()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("SumarSalary", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            School = cmdPerson.ExecuteReader();
            ArrayList AllSalary = new ArrayList();
            while (School.Read())
            {
                AllSalary.Add(School.GetValue(0));
                AllSalary.Add(School.GetValue(1));

            }
            for (int i = 0; i < AllSalary.Count; i += 2)
            {

                Console.WriteLine("{0} Sum of all Salary: {1} kr ", AllSalary[i], AllSalary[i + 1]);
                Console.WriteLine(new string('-', (40)));

            }
            School.Close();
            connect.Close();
            return AllSalary;
        }
        public bool printSalaryMenu()
        {
            Console.WriteLine("Välj vilket nummer du vill ha:");
            Console.WriteLine("1) Avg Lön");
            Console.WriteLine("2) Sum Lön");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    SalaryCall();
                    return true;
                case "2":
                    Console.Clear();
                    SalarySumCall();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}

