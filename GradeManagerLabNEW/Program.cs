using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeManagerLab
{
    class Program
    {
        // Create list to hold grades and names
        static List<double> studentGrades = new List<double>() { };
        static List<Student> studentList = new List<Student>() { };       
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Grade Manager System.");
            Console.WriteLine("Enter a selection number followed by the Enter Key.");
            Console.WriteLine("1 - See All Student Grades.");
            Console.WriteLine("2 - Input Student Grades.");
            Console.WriteLine("3 - Calculate average of all student grades.");
            Console.WriteLine("4 - See top student grade.");
            Console.WriteLine("5 - See Lowest Student Grade.");
            Console.WriteLine("6 - Remove Students Grade.");
            Console.WriteLine("7 - Edit Students Grades");
            Console.WriteLine("8 - Exit Program");
            Console.WriteLine("\r\nYour Menu Selection: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine();
                    GradeBook();
                    break;

                case "2":
                    Console.Clear();
                    InputGrade();
                    break;

                case "3":
                    Console.Clear();
                    CalculateAverage();
                    break;

                case "4":
                    Console.Clear();
                    HighestGrade();
                    break;

                case "5":
                    Console.Clear();
                    LowestGrade();
                    break;

                case "6":
                    Console.Clear();
                    RemoveGrade();
                    break;

                case "7":
                    Console.Clear();
                    EditGrades();
                    break;

                case "8":
                    Console.Clear();
                    ExitProgram();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Entry, Please select a valid selection(#1-#8 to continue.");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
            return false;

        }
        static void GradeBook()
        {
            Console.WriteLine("*---- You Are Viewing Your Student Grade Book ----*");
            int i = 0;
            foreach (Student s in studentList)
            {
                Console.WriteLine($"{i}. Name: {s.Name}, Grade: {s.Grade}");
                i++;

            }
            if (i == 0)
            {
                Console.WriteLine("There are currently no grades to view. Please add students to the Grade Book.");
            }
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
            MainMenu();
        }
        static void InputGrade()
        {
            Console.Clear();
            Student s = new Student ();
            studentList.Add(s);
            Console.Write(" Enter the name of the student: ");
            s.Name = Console.ReadLine();
            Console.Write(" Enter the grade for the student: ");
            s.Grade = Convert.ToDouble(Console.ReadLine());
            Console.Clear ();   
            MainMenu();
        }
        static void CalculateAverage()
        {
            var AverageGrade = studentList.Average(s => s.Grade);   
            Console.WriteLine("The class average is: " + AverageGrade);
            Console.ReadLine();
            MainMenu();
        }
        static void HighestGrade()
        {
            var HighestGrade = studentList.Max(s => s.Grade);
            Console.Write("The highest grade is: " + HighestGrade);
            Console.ReadLine();
            MainMenu();
        }
        static void LowestGrade()
        {
            var LowestGrade = studentList.Min(s => s.Grade);
            Console.WriteLine($"The lowest grade is: " + LowestGrade);
            Console.ReadLine();
            MainMenu();
        }
        static void RemoveGrade()
        {
            Console.Clear();
            Console.WriteLine("*-*-*Remove Grade*-*-*");
            Console.WriteLine("Enter the number of the student you wish to remove... ");
            int i = 0;
            foreach (Student s in studentList)
            {
                Console.WriteLine($"{i}. Name: {s.Name}, Grade: {s.Grade}");
                i++;
            }
            int remove = Convert.ToInt32(Console.ReadLine());
            if (remove >= 0 && remove < studentList.Count)
            {
                Console.WriteLine(studentList[remove].Name + " has been deleted from the grade book.");
                studentList.RemoveAt(remove);              
            }
            Console.WriteLine("Press enter to return to the main menu...");
            Console.ReadLine();
            MainMenu();
        }
        static void EditGrades()
        {
            Console.Clear();
            Console.WriteLine("Enter the student number for the grade you wish to edit...");
            int i = 0;
            foreach (Student s in studentList)
            {
                Console.WriteLine($"{i}. Name: {s.Name}, Grade: {s.Grade}");
                i++;
            }
            int userInput = Convert.ToInt32 (Console.ReadLine());   
            if (userInput >= 0 && userInput < studentList.Count)
            {
                Console.WriteLine("Input the new grade for " + studentList[userInput].Name);
                double uGrade = Convert.ToDouble(Console.ReadLine());
                studentList[userInput].Grade = uGrade;
                Console.WriteLine("Grade succesfully updated!");
            }
            Console.WriteLine("Press enter to return to the main menu...");
            Console.ReadLine();
            MainMenu();
        }
        static void ExitProgram()
        {
            Environment.Exit(-1);
        }
        class Student
        {
            public string Name { get; set; }
            public double Grade { get; set; }
        }             

    }

}        
             
            


