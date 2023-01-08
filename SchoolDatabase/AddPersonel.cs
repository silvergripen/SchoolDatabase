using System;
using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SchoolDatabase
{
    internal class AddPersonel
    {
        public string FirstName;
        public string LastName;
        public string Birthday;
        public string Adress2;
        public string County1;
        
        //public AddPersonel(string FirstName, string LastName, string Birthday, string Adress2, string County1)
        //{
        //    this.FirstName = FirstName;
        //    this.LastName = LastName;
        //    this.Birthday = Birthday;
        //    this.Adress2 = Adress2;
        //    this.County1= County1;
        //}
        public void adding()
        {
            Console.WriteLine("Var snäll och skriv in förnamnet på Personalen");
            FirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Var snäll och skriv efternamnet på Personal");
            LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Skriv födelsedatum på Personal yyyy-mm-dd");
            Birthday = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Vilken adress har Personal?");
            Adress2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("I vilken ort bor Personal?");
            County1 = Console.ReadLine();
            Console.Clear();
            bool birthBool = DateTime.TryParse(Birthday, out DateTime birthDate);
            TestContext context = new TestContext();
            if(birthBool == true)
            {
                Adress ad1 = new Adress()
                {
                    Adress1 = Adress2,
                    County = County1

                };
                context.Adresses.Add(ad1);
                context.SaveChanges();
                Personel pers1 = new Personel()
                {
                    Fname = FirstName,
                    Lname = LastName,
                    Bday = birthDate,
                    Adressid = ad1.Adressid
                };
                context.Personels.Add(pers1);
                context.SaveChanges();
            }
            else if(birthBool == false) { Console.WriteLine("Fel datum Starta om programmet och försök igen."); }
            
            
        }
        public void AddingPersonel()
        {
            AddPlGetSet pep = new AddPlGetSet();
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-GD035FL; Initial Catalog=School;Integrated Security=true");
            SqlCommand cmdPerson = new SqlCommand("insertPersonel", connect);
            cmdPerson.CommandType = CommandType.StoredProcedure;
            connect.Open();
            Console.WriteLine("Skriv förnamnet på Personalen:");
            pep.Fname = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@Fname", pep.Fname);
            Console.WriteLine("Skriv Efternamnet på Personalen");
            pep.Lname = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@LName", pep.Lname);
            Console.WriteLine("Skriv födelsedatum yyyy-mm-dd");
            pep.Bday = Console.ReadLine();
            bool birthBool = DateTime.TryParse(pep.Bday, out DateTime birthDate);
            //Temp behöver fixa så det går runt inte super viktigt
            if (birthBool == true)
            {
                cmdPerson.Parameters.AddWithValue("@Bday", pep.Bday);
            }
            else
            {
                Console.WriteLine("Försök igen yyyy-mm-dd");
                pep.Bday = Console.ReadLine();
            }
            Console.WriteLine("Skriv Jobbstart yyyy-mm-dd");
            pep.workstart = Console.ReadLine();
            bool workBool = DateTime.TryParse(pep.workstart, out DateTime workDate);
            //Temp behöver fixa så det går runt inte super viktigt
            if (workBool == true)
            {
                cmdPerson.Parameters.AddWithValue("@workstart", pep.workstart);
            }
            else
            {
                Console.WriteLine("Försök igen yyyy-mm-dd");
                pep.workstart = Console.ReadLine();
            }
            Console.WriteLine("Vilket jobb får Personen?");
            using TestContext context = new TestContext();
            var innerJoin = from s in context.Works
                            orderby s.Workid

                            select new
                            {
                                workId = s.Workid,
                                workName = s.Work1
                            };
            foreach (var item in innerJoin)
            {
               
                Console.WriteLine(item.workId + " " + item.workName);
                Console.WriteLine(new string('-', (10)));
            }
            Console.WriteLine("Skriv nummeret nedan");
            pep.workid = Console.ReadLine();
            cmdPerson.Parameters.AddWithValue("@workid", pep.workid);
            cmdPerson.ExecuteNonQuery();
            connect.Close();
        }

        
    }
}
