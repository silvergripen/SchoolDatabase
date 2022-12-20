using Microsoft.Data.SqlClient;
using SchoolDatabase.Data;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SchoolDatabase
{
    internal class CallingPersonel
    {
        public ArrayList CallingAllName()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GetPersonel", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            SqlDataReader School;
            connect.Open();
            School = cmdPerson.ExecuteReader();
            ArrayList allNames = new ArrayList();
              
            while (School.Read())
            {
                allNames.Add(School.GetValue(0));
                allNames.Add(School.GetValue(1));
                allNames.Add(School.GetValue(2));
            }
            School.Close();
            connect.Close();
            return allNames;

        }
        public void PrintAll()
        {
            CallingPersonel objPersonel = new CallingPersonel();
            System.Collections.ArrayList allNames = objPersonel.CallingAllName();


            for (int i = 0; i < allNames.Count; i += 3)
            {

                Console.WriteLine("{0} {1} ", allNames[i], allNames[i + 1]);
                Console.WriteLine(allNames[i + 2]);
                Console.WriteLine(new string('-', (30)));

            }
        }
      
       
    }
}
