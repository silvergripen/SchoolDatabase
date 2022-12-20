using System;
using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

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
            Console.WriteLine("Var snäll och skriv in förnamnet på studenten");
            FirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Var snäll och skriv efternamnet på studenten");
            LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Skriv födelsedatum på studenten yyyy-mm-dd");
            Birthday = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Vilken adress har studenten?");
            Adress2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("I vilken ort bor studenten?");
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

        
    }
}
