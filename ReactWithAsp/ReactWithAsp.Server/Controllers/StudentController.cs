using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Services;

namespace ReactWithAsp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentController(IGetStudentService getStudentService, ISaveStudentService saveStudentService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await getStudentService.GetAll();
        return Ok(results);
    }
    [HttpPut("{id:int}")]

    public async Task<IActionResult> Put(int id, StudentDto dto)
    {
        await saveStudentService.Update(id, dto);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentDto dto)
    {
        await saveStudentService.Store(dto);
        return Ok();
    }

}