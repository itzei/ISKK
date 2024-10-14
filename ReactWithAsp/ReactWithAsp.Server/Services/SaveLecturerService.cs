using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class SaveLecturerService(AppDbContext context) : ISaveLecturerService
    {
        public async Task Store(LecturerDto dto)
        {
            var lecturer = new Lecturer(dto.FirstName, dto.LastName, dto.Email, dto.PhoneNumber);
            context.Lecturers.Add(lecturer);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, LecturerDto dto)
        {
            var lecturer = await context.Lecturers.FirstOrDefaultAsync(i => i.Id == id);
            if (lecturer != null)
            {
                lecturer.SetValues(dto.FirstName, dto.LastName, dto.Email, dto.PhoneNumber);
                context.Lecturers.Update(lecturer);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var lecturer = await context.Lecturers.FindAsync(id);
            if (lecturer != null)
            {
                context.Lecturers.Remove(lecturer);
                await context.SaveChangesAsync();
            }
        }
    }
}
