using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleStudentsApp
{
    class Program
    {
        private class StudentResultComparer : IComparer<Student>
        {
            private int examId;

            #region Constructor(s)

            public StudentResultComparer(int examId)
            {
                this.examId = examId;
            }

            #endregion Constructor(s)

            #region IComparer<Student> Members

            public int Compare(Student x, Student y)
            {
                return x.GetExamResult(this.examId).CompareTo(y.GetExamResult(this.examId));
            }

            #endregion
        }

        #region Private members

        private School school;

        #endregion Private members

        #region Constructors

        public Program()
        {
            this.school = new School();
        }

        #endregion Constructors

        #region Private methods

        private void CreateStudent()
        {
            Console.WriteLine("[PROGRAM] Enter name of the student: ");
            this.school.CreateStudent(new Student(UserInput.GetString()));
        }

        private void CreateExam()
        {
            Console.WriteLine("[PROGRAM] Enter id of the exam:");
            int examId = UserInput.GetInt();
            Console.WriteLine("[PROGRAM] Enter description of the exam:");
            String examDescription = UserInput.GetString();

            this.school.CreateExam(examId, examDescription);
        }

        private int? SelectExam()
        {
            Console.WriteLine("[PROGRAM] Enter id of an existing exam:");
            int examId = UserInput.GetInt();

            // Not supported by serialization if (this.school.IsExamExists(examId))
            {
                return examId;
            }
            // Not supported by serialization Console.WriteLine("[PROGRAM] Error the exam " + examId + " does not exist: user CE command (CREATE EXAM)");
            // Not supported by serialization return null;
        }

        private void FillExam(int examId)
        {
            for (int i = 0; i != this.school.StudentsCount; i++)
            {
                Console.WriteLine("[PROGRAM] Enter mark for student " + (i + 1) + ": " + this.school.Student(i).Name);

                this.school.Student(i).RegisterExamResult(examId, UserInput.GetFloat());
            }
        }

        #endregion Private methods

        #region Student selection: sample of selection

        private bool SelectAverageHigherThan12(Student student)
        {
            return (student.AverageResult >= 12);
        }

        #endregion Student selection: sample of selection

        #region Public methods

        public void Process()
        {
            // Commands
            for (; ; )
            {
                int? examId;

                Console.WriteLine("[PROGRAM] Enter a command:");
                String command = UserInput.GetString().ToUpper();

                switch (command)
                {
                    case "LIST BY NAME":
                    case "LBN":
                        this.school.DumpStudent(null);
                        break;
                    case "LIST BY RESULT":
                    case "LBR":
                        examId = this.SelectExam();
                        if (examId.HasValue)
                        {
                            this.school.DumpStudent(new StudentResultComparer(examId.Value));
                        }
                        break;
                    case "FILL EXAM RESULT":
                    case "FER":
                        examId = this.SelectExam();
                        if (examId.HasValue)
                        {
                            this.FillExam(examId.Value);
                        }
                        break;
                    case "CREATE STUDENT":
                    case "CS":
                        this.CreateStudent();
                        break;
                    case "CREATE EXAM":
                    case "CE":
                        try
                        {
                            this.CreateExam();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[PROGRAM] Error : " + e.Message);
                        }
                        break;
                    case "SAVE":
                        this.school.Save(@"C:\__Debug\Students.xml");
                        break;
                    case "LOAD":
                        this.school.Load(@"C:\__Debug\Students.xml");
                        break;

                    case "SELECT_L10":
                    case "SL10":
                        this.school.DumpSelectedStudents(this.school.SelectAverageLowerThan10);
                        break;

                    case "SELECT_H10":
                    case "SH10":
                        this.school.DumpSelectedStudents(this.school.SelectAverageHigherThan10);
                        break;

                    case "SELECT_H12":
                    case "SH12":
                        this.school.DumpSelectedStudents(this.SelectAverageHigherThan12);
                        break;
                    
                    case "EXIT":
                        return; // Exit main

                    default:
                        Console.WriteLine("[PROGRAM] Unknown command " + command);
                        break;
                }
            }
        }

        #endregion Public methods

        #region Main entry point

        static void Main(string[] args)
        {
            Console.WriteLine("[MAIN] Start of the program");
            Program program = new Program();
            program.Process();
            Console.WriteLine("[MAIN] End of the program");
        }

        #endregion Main entry point
    }
}
