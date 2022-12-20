using System.Collections;

namespace SchoolDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MainMenu Menus = new MainMenu();
            //Menus.Menu();
            AddStudent stud = new AddStudent();
            stud.GetStudentAdd();
        }
    }
}