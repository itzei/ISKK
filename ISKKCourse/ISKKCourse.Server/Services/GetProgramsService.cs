using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class GetProgramService(AppDbContext context): IGetProgramService
    {
        public async Task<List<ProgramDto>> GetAll()
        {
            var programs = await context.Program
                .Include(i => i.Subjects).ToListAsync();
            List<ProgramDto> results = [];

            foreach (var program in programs)
            {
                results.Add(MapDto(program));
            }
            return results;
        }

        public async Task<ProgramDto> Get(int id)
        {
            var program = await context.Program
                .Include(i => i.Subjects).FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(program);
        }

        private ProgramDto MapDto(Programs program) => new ProgramDto(program.Id, program.StudyTitle, program.Credits, program.Description, program.Subjects.Select(i => new SubjectDto
        (
            i.Id,
            i.StudyProgram,
            i.SubjectTitle
        )).ToList());
    }
}
