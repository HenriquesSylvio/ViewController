using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ViewController.Models;

namespace ViewController.Services
{
    public class StudentService
    {
        public List<StudentModel> Students;

        public StudentService()
        {
            string text = File.ReadAllText("students.json");
            Students = JsonConvert.DeserializeObject<List<StudentModel>>(text);
        }

        public void AddStudent(StudentModel student)
        {
            Students.Add(student);
        }

        public void DeleteStudent(string name, string surname)
        {
            Students.Remove(Students.First(u => u.Name == name && u.Surname == surname));
        }

        public void UpdateStudent(string name, string surname , string techno)
        {
            StudentModel student = Students.First(u => u.Name == name && u.Surname == surname);
            Students.Remove(student);
            student.Techno = techno;
            Students.Add(student);
        }
    }
}
