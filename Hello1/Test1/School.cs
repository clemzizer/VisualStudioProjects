using System;
namespace Test1
{
    public class School
    {
        #region Constructors 
        public School()
        {
        }
    }
    public bool IsExamExist(int examId){
        return (this.exams[examId]!=null);
    }
    public Student Studnt(int index){
        return this.students[index];
    }
    public void CreateStudent(Student student){
        //TODO AppDomainManager parameter errir
        this.students
    }
}
