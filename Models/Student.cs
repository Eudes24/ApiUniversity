namespace ApiUniversity.Models;

public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public string Email {get;set;} =null!;
    public List<Enrollment> Enrollments { get; set; } = new();
    
    public Student() { }
    // Default constructor
    public Student(StudentDTO studentDTO) { }
}