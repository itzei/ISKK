using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Services;

namespace ReactWithAsp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class StudentController(IGetStudentService getStudentService, ISaveStudentService saveStudentService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await getStudentService.GetAll();
        return Ok(results);
    }
    [HttpPut("{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Put(int id, StudentDto dto)
    {
        await saveStudentService.Update(id, dto);
        return Ok();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentDto dto)
    {
        await saveStudentService.Store(dto);
        return Ok();
    }

}