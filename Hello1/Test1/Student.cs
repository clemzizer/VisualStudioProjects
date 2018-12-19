using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    public class Student:IComparable
    {
        const float INVALID_MARK = -1;
        internal String Name { get;  private set;}
        internal float Mark { get; set;}

        //public String Name { get; private set; }
        //public float Mark { get; private set; }
    
        internal Student(String Name)
        {
            this.Name = Name;
            this.Mark = INVALID_MARK;
        }
        public override string ToString()
        {
            if (Mark != INVALID_MARK)
            {
                return this.Name + " " + this.Mark;
            }
            else
                return "error";
        }

        public void RegisterExamResult(int Examid, float Mark){
            
        }
        // Nous permet d'être plus precis que le setter normal, faire des vérifications (sécurité...)
        //public void setMark(float Mark){
        //    this.Mark = Mark;
        //}
    }
}