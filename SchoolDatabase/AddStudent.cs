using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolDatabase.Models;

namespace SchoolDatabase
{
    internal class AddStudent
    {
        public void GetStudentAdd()
        {
            AddPlGetSet pep = new AddPlGetSet();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("InsertStudent", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            connect.Open();
            Console.WriteLine("Skriv förnamnet på studenten:");
            pep.Fname = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@Fname", pep.Fname);
            Console.WriteLine("Skriv Efternamnet på studenten");
            pep.Lname = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@LName", pep.Lname);
            Console.WriteLine("Skriv födelsedatum yyyy-mm-dd");
            pep.Bday = Console.ReadLine();
            bool birthBool = DateTime.TryParse(pep.Bday, out DateTime birthDate);
            cmdPerson.Parameters.AddWithValue("@Bday", birthDate);
            cmdPerson.ExecuteNonQuery();
            connect.Close();
            //cmdPerson.Parameters.Add("@StudentID", SqlDbType.NVarChar, 11);
            //cmdPerson.Parameters["@FName"].Value = StudentID;
            //cmdPerson.Parameters.Add("@LName", SqlDbType.NVarChar, 50);
            
        }

    }
}
