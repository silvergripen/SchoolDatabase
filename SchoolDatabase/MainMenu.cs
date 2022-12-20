using SchoolDatabase.Data;
using SchoolDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    internal class MainMenu
    {

        public bool Menu()
        {

            CallAvgGrades avgGrades= new CallAvgGrades();
            CallingClass ClassCall= new CallingClass();
            CallingPersonel PersonelCall= new CallingPersonel();
            CallingStudents StudentCall = new CallingStudents();
            AddPersonel NewPersonel = new AddPersonel();
            AddStudent NewStudent = new AddStudent();   
            
            Console.Clear();
            Console.WriteLine("Välj vilket nummer du vill ha:");
            Console.WriteLine("1) Kolla upp personalen");
            Console.WriteLine("2) Kolla upp studenter");
            Console.WriteLine("3) Kolla betyg");
            Console.WriteLine("4) kolla alla kurser");
            Console.WriteLine("5) Lägg till nya elever");
            Console.WriteLine("6) Lägg till ny personal");


            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    PersonelCall.PrintAll();
                    return true;
                case "2":
                    Console.Clear();
                    StudentCall.CallStudentMenu();
                    return true;
                case "3":
                    Console.Clear();
                    PersonelCall.PrintAll();
                    return true;
                case "4":
                    avgGrades.printGradeMenu();
                     return true;
                case "5":
                    NewStudent.GetStudentAdd();
                    return true;
                case "6":
                    Console.Clear();
                    NewPersonel.adding();
                    return true;
                default:
                    return true;
            }
        }
    }
}

