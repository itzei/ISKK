using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentController(AppDbContext context): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await context.Students.ToListAsync();
        List<StudentDto> results = [];
        
        foreach (var student in students)
        {
            results.Add(new StudentDto(student.Id, $"{student.FirstName} {student.LastName}", student.Email));
        }
        return Ok(results);
    }
}