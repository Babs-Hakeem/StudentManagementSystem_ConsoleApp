using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public string MatriculationNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Level { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
