using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWPF.Models
{
    class StudentService
    {
        private static List<Student> ObjStudentsList;

        public StudentService()
        {
            ObjStudentsList = new List<Student>() { 
                new Student{Id=100,Name="Syed",Age=25}
            };
        }

        public List<Student> GetAll()
        {
            return ObjStudentsList;
        }

        public bool Add(Student objNewStudent)
        {
            if (objNewStudent.Age < 21 && objNewStudent.Age > 58)
                throw new ArgumentException("Invalid age limit for Student");
            ObjStudentsList.Add(objNewStudent);
            return true;
        }

        public bool Update(Student objUpdateStudent)
        {
            bool isUpdated = false;
            for(int index = 0;index<ObjStudentsList.Count;index++)
            {
                if (ObjStudentsList[index].Id == objUpdateStudent.Id)
                {
                    ObjStudentsList[index].Name = objUpdateStudent.Name;
                    ObjStudentsList[index].Age = objUpdateStudent.Age;
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for(int index=0;index<ObjStudentsList.Count;index++)
            {
                if (ObjStudentsList[index].Id == id)
                {
                    ObjStudentsList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }

        public Student Search(int id)
        {
            return ObjStudentsList.FirstOrDefault(e => e.Id == id);
        }


    }
}
