namespace ApiUniversity.Models;

public class StudentDTO
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public string Email {get;set;} =null!;
    public StudentDTO () {}
    public StudentDTO (Student student)
    {}
}