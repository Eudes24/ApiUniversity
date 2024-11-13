using ApiUniversity.Data;
using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly UniversityContext _context;

    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/enrollment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> GetEnrollment()
    {
        // Get enrollments and related lists
        var enrollments = _context.Enrollments.Include(x => x.Student).Include(x => x.Course).Select(x => new EnrollmentDTO(x));
        return await enrollments.ToListAsync();
    }

    // POST: api/enrollment
    [HttpPost]
    public async Task<ActionResult<Enrollment>> PostEnrollment(EnrollmentDTO EnrollmentDTO)
    {
        var enrollment = new Enrollment(EnrollmentDTO);

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        enrollment = await _context.Enrollments.Include(x => x.Student).Include(x => x.Course).FirstAsync(t => t.StudentId == EnrollmentDTO.StudentId && t.CourseId == EnrollmentDTO.CourseId);

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, new DetailedEnrollmentDTO(enrollment));
    }
}
