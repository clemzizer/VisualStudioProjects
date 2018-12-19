using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleStudentsApp
{
    [Serializable]
    public class School
    {
        #region Private members

        /* For serialization private */
        public List<Student> students;
        /* Cannot be serialize like this ... ignore it for now */
        private Dictionary<int, String> exams;
        
        #endregion Private members

        #region Properties

        public int StudentsCount
        {
            get { return this.students.Count; }
        }

        #endregion Properties

        #region Constructors

        public School()
        {
            this.students = new List<Student>();
            this.exams = new Dictionary<int, string>();
        }

        #endregion Constructors

        #region Public methods

        public bool IsExamExists(int examId)
        {
            return this.exams.Keys.Contains(examId);
        }

        public Student Student(int index)
        {
            return this.students[index];
        }

        public void CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new NullReferenceException("Student object cannot be null at creation");
            }
            this.students.Add(student);
        }

        public void CreateExam(int examId, String description)
        {
            if (this.IsExamExists(examId))
            {
                throw new Exception("Exam id " + examId + " already defined");
            }
            this.exams.Add(examId, description);
        }

        public void DumpStudent(IComparer<Student> comparer)
        {
            if (comparer != null)
            {
                this.students.Sort(comparer);
            }
            else
            {
                this.students.Sort();
            }

            for (int i = 0; i != this.students.Count; i++)
            {
                Console.WriteLine(this.students[i].ToString());
            }
        }

        #endregion Public methods

        #region Public methods: serialization

        public void Save(String Filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(School));
            using (StreamWriter wr = new StreamWriter(Filename))
            {
                xs.Serialize(wr, this); // Serialize the students content
            }
        }

        public void Load(String Filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(School));
            using (StreamReader wr = new StreamReader(Filename))
            {
                School loadedShool = xs.Deserialize(wr) as School; // Deserialize the students content
                // Set the internal content
                this.students = loadedShool.students;
            }
        }

        #endregion Public methods: serialization

        #region Student selection

        #region Student selection: delegate type definition

        public delegate bool StudentSelectDelegate(Student student);

        #endregion Student selection: delegate type definition

        #region Student selection: selection routine

        public void DumpSelectedStudents(StudentSelectDelegate StudentSelect)
        {
            foreach (Student student in this.students)
            {
                if (StudentSelect(student))
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }

        #endregion Student selection: selection routine

        #region Student selection: sample of selection

        public bool SelectAverageLowerThan10(Student student)
        {
            return (student.AverageResult <= 10);
        }

        public bool SelectAverageHigherThan10(Student student)
        {
            return (student.AverageResult >= 10);
        }

        #endregion Student selection: sample of selection

        #endregion Student selection
    }
}
