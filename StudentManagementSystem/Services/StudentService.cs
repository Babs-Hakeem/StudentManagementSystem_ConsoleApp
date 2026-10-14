using System;
using System.Collections.Generic;
using System.Text;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly List<Student> _students = new();

        public bool AddStudent(Student student)
        {
            bool alreadyExists = _students.Any(s => s.MatriculationNumber.Equals(
                student.MatriculationNumber, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                return false;
            }

            _students.Add(student);

            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student? FindStudentsByMatricNumber(string matricNumber)
        {
            return _students.FirstOrDefault(s => s.MatriculationNumber.Equals(
                matricNumber, StringComparison.OrdinalIgnoreCase));
        }

        public bool UpdateStudent(string matricNumber, string department, int level, string email)
        {
            Student? student = FindStudentsByMatricNumber(matricNumber);
            if(student == null)
            {
                return false;
            }
            student.Department = department;
            student.Level = level;
            student.Email = email;
            return true;
        }

        public bool DeleteStudent(string matricNumber)
        {
            Student? student = FindStudentsByMatricNumber(matricNumber);
            if(student == null)
            {
                return false;
            }
            _students.Remove(student);
            return true;
        }

    }
}
