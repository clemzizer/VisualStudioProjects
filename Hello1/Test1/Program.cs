using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class MainClass
    {
        const int MAX_STUDENTS = 3;

        static Student[] students = new Student[MAX_STUDENTS];

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a command");
            String command = Console.ReadLine();
            switch (command)
            {
                case "LIST":
                    DisplayStudents();
                    break;
                case "EXAM":
                    EnterMarks();
                    break;
                case "RESET":
                    EnterStudents();
                    break;
                case "EXIt":
                    return; //Exit main
                default:
                    Console.WriteLine("unknown command " + command);
                    break;
                    
            }
            Console.WriteLine("1.List 2.Exam 3.End");
        }


        static private void DisplayStudents()
        {
            for (int i = 0; i < MAX_STUDENTS; i++){
                students[i].ToString();
            }
        }
        static private void EnterMarks()
        {
            for (int i = 0; i < MAX_STUDENTS; i++){
                
                Console.WriteLine("Enter a mark for student"+ (i+1) + students[i].Name);

                String input = Console.ReadLine();

                students[i].Mark=float.Parse(input);
            }

        }
        static private void EnterStudents()
        {
            for (int i = 0; i != MAX_STUDENTS; i++)
            {
                Console.WriteLine("Enter a name for the student " + (i + 1));

                String input = Console.ReadLine();

                float.Parse(input);

                students[i] = new Student(Console.ReadLine());
            }

        }
        public void FillExam(int examId){
            for (int i = 0; i < ; i++){
                
            }
        }
    }
}
