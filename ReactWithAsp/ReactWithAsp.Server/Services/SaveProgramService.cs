using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class SaveProgramService(AppDbContext context) : ISaveProgramService
    {
        public async Task Store(ProgramDto dto)
        {
            var program = new Programs(dto.StudyTitle, dto.Credits, dto.Description);
            context.Programs.Add(program);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, ProgramDto dto)
        {
            var program = await context.Programs.FirstOrDefaultAsync(i => i.Id == id);
            if (program != null)
            {
                program.SetValues(dto.StudyTitle, dto.Credits, dto.Description);
                context.Programs.Update(program);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var program = await context.Programs.FindAsync(id);
            if (program != null)
            {
                context.Programs.Remove(program);
                await context.SaveChangesAsync();
            }
        }
    }
}
