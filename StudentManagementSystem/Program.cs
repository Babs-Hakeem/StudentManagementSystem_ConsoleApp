using StudentManagementSystem.Services;
using StudentManagementSystem.Models;

StudentService studentService = new StudentService();

bool running = true;
while (running)
{
    Console.WriteLine("=======================================");
    Console.WriteLine("Welcome to the Student Management System!");
    Console.WriteLine("=======================================");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Find Student by Matriculation Number");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Exit");

    Console.Write("Please select an option (1-6): ");
    int option;
    while(!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
    {
        Console.Write("Invalid input. Please select an option (1-6): ");
    }

    switch (option)
    {
        case 1:
            AddStudent();
            break;
        case 2:
            ViewAllStudents();
            break;
        case 3:
            SearchStudent();
            break;
        case 4:
            UpdateStudent();
            break;
        case 5:
            DeleteStudent();
            break;
        case 6:
            running = false;
            break;
            
    }
    
}

void AddStudent()
{
    Console.Write("Enter your matriculation number: ");
    string matricNumber = Console.ReadLine()?.Trim() ?? string.Empty;
    Console.Write("Enter your name: ");
    string name = Console.ReadLine()?.Trim() ?? string.Empty;
    Console.Write("Enter your department: ");
    string department = Console.ReadLine()?.Trim() ?? string.Empty;
    Console.Write("Enter your level('100', '200', '300' or '400'): ");
    int level = int.Parse(Console.ReadLine()?.Trim() ?? "0");
    Console.Write("Enter your email: ");
    string email = Console.ReadLine()?.Trim() ?? string.Empty;

    if(string.IsNullOrWhiteSpace(matricNumber) || 
        string.IsNullOrWhiteSpace(name) || 
        string.IsNullOrWhiteSpace(department) || 
        level <= 0 || string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("All fields are required. Please try again.");
        return;
    }

    Student student = new Student
    {
        MatriculationNumber = matricNumber,
        Name = name,
        Department = department,
        Level = level,
        Email = email
    };
    bool added = studentService.AddStudent(student);
}

void ViewAllStudents()
{
    List<Student> students = studentService.GetAllStudents();

    if(students.Count == 0)
    {
        Console.WriteLine("Students not found");
        return;
    }
    Console.WriteLine("=========Registered Students=========");
    foreach(var student in students)
    {
        DisplayStudentDetails(student);
    }
}
void SearchStudent()
{
    Console.Write("Enter the matriculation number of the student to search: ");
    string matricNumber = Console.ReadLine()?.Trim() ?? string.Empty;

    if(string.IsNullOrWhiteSpace(matricNumber))
    {
        Console.WriteLine("Matriculation number is required. Please try again.");
        return;
    }
Student? student = studentService.FindStudentsByMatricNumber(matricNumber);
    if(student == null)
    {
        Console.WriteLine("Student not found");
        return;
    }
    DisplayStudentDetails(student);
}
void UpdateStudent()
{
    Console.Write("Enter the matriculation number of the student to update: ");
    string matricNumber = Console.ReadLine()?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(matricNumber))
    {
        Console.WriteLine("Matriculation number is required. Please try again.");
        return;
    }
    Student? student = studentService.FindStudentsByMatricNumber(matricNumber);
    if (student == null)
    {
        Console.WriteLine("Student not found");
        return;
    }
    Console.Write("Enter new department: ");
    string department = Console.ReadLine()?.Trim() ?? string.Empty;
    Console.Write("Enter new level('100', '200', '300' or '400'): ");
    int level = int.Parse(Console.ReadLine()?.Trim() ?? "0");
    Console.Write("Enter new email: ");
    string email = Console.ReadLine()?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(department) || level <= 0 || string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("All fields are required. Please try again.");
        return;
    }
    bool updated = studentService.UpdateStudent(matricNumber, department, level, email);
}
bool DeleteStudent()
{
    Console.Write("Enter the matriculation number of the student to delete: ");
    string matricNumber = Console.ReadLine()?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(matricNumber))
    {
        Console.WriteLine("Matriculation number is required. Please try again.");
        return false;
    }
    bool deleted = studentService.DeleteStudent(matricNumber);
    if (!deleted)
    {
        Console.WriteLine("Student not found");
        return false;
    }
    return true;
}

void DisplayStudentDetails(Student student)
{
    Console.WriteLine($"Matriculation Number: {student.MatriculationNumber}");
    Console.WriteLine($"Name: {student.Name}");
    Console.WriteLine($"Department: {student.Department}");
    Console.WriteLine($"Level: {student.Level}");
    Console.WriteLine($"Email: {student.Email}");
}