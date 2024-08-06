using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL_DBSlide.Entities
{
    public class StudentGroup
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public StudentGroup() {
            Students = new List<Student>();
        }
        public StudentGroup(string name) : this()
        {
            Name = name;
        }
        public StudentGroup(string name, params Student[] students) : this(name)
        {
            foreach (Student student in students)
            {
                Students.Add(student);
            }
        }

        public bool AddStudent(Student student)
        {
            if(Students.Select(s => $"{s.First_name} {s.Last_name}").Contains($"{student.First_name} {student.Last_name}")) return false;
            Students.Add(student);
            return true;
        }

        public bool RemoveStudent(Student student)
        {
            if (!Students.Contains(student)) return false;
            Students.Remove(student);
            return true;
        }
    }
}
