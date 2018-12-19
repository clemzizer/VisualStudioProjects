using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleStudentsApp
{
    [Serializable]
    public class Student : IComparable<Student>
    {
        #region Internal types

        /* For serialization private */
        public struct ExamResult
        {
            public int examId;
            public float examResult;

            public ExamResult(int examId, float examResult)
            {
                this.examId = examId;
                this.examResult = examResult;
            }
        }

        #endregion Internal types

        #region Private members

        /* For serialization private */
        public List<ExamResult> results;

        #endregion Private members

        #region Properties

        public String Name { get; /* For serialization private */ set; }

        [XmlIgnore]
        public float AverageResult
        {
            get
            {
                if (this.results.Count > 0)
                {
                    float value = 0;
                    foreach (ExamResult result in this.results)
                    {
                        value += result.examResult;
                    }
                    return value / this.results.Count;
                }
                return -1;
            }
        }

        #endregion Properties

        #region Constructor(s)

        internal Student(String name)
        {
            this.Name = name;
            this.results = new List<ExamResult>();
        }

        // Only for serialization
        public Student() { }

        #endregion Constructor(s)

        #region Public methods

        public override string ToString()
        {
            String Text = this.Name + " (" + this.AverageResult + ")";
            foreach (ExamResult result in this.results)
            {
                Text += "\n\t<" + result.examId + " --> " + result.examResult + ">";
            }
            return Text;
        }

        public float GetExamResult(int examId)
        {
            foreach (ExamResult result in this.results)
            {
                if (result.examId == examId) return result.examResult;
            }

            return float.NaN;
        }

        public void RegisterExamResult(int examId, float examResult)
        {
            this.results.Add(new ExamResult(examId, examResult));
        }

        #endregion Public methods

        #region IComparable<Student> Members

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }

        #endregion
    }
}
