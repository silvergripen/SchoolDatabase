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
  
        public ArrayList GetPersonelList()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("GetpersonelYearsWorked", connect);
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
                allNames.Add(School.GetValue(3));
            }
            School.Close();
            connect.Close();
            return allNames;
        }
        public void CallingProffession()
        {
             
            using TestContext context = new TestContext();
            var Subject = from s in context.Subjects
                          join x in context.Personels
                          on s.PersonelId equals x.Jobid
                          select new
                          {
                              SubjectName = s.SubjectName,
                              Fname = x.Fname,
                              Lname = x.Lname
                          };

            foreach (var item in Subject)
            {
                Console.WriteLine(item.SubjectName);
                Console.WriteLine(item.Fname + " " + item.Lname);
                Console.WriteLine(new string('-', (30)));
                //bool isReal = innerJoin.Count(x => x == item) > 1;

                


            }
        
        }
        public void PrintAll()
        {
            CallingPersonel objPersonel = new CallingPersonel();
            System.Collections.ArrayList allNames = objPersonel.GetPersonelList();


            for (int i = 0; i < allNames.Count; i += 4)
            {

                Console.WriteLine("{0} {1} ", allNames[i], allNames[i + 1]);
                Console.WriteLine("Worked as: " + allNames[i + 2] + " For : " + allNames[i + 3] + " Years");
                Console.WriteLine(new string('-', (30)));

            }
        }
        
      
       
    }
}

//OBSELETE

//public ArrayList CallingAllName()
//{
//    SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
//    SqlCommand cmdPerson = new SqlCommand("GetPersonel", connect);
//    cmdPerson.CommandType = CommandType.StoredProcedure;
//    SqlDataReader School;
//    connect.Open();
//    School = cmdPerson.ExecuteReader();
//    ArrayList allNames = new ArrayList();

//    while (School.Read())
//    {
//        allNames.Add(School.GetValue(0));
//        allNames.Add(School.GetValue(1));
//        allNames.Add(School.GetValue(2));
//    }
//    School.Close();
//    connect.Close();
//    return allNames;

//}
