using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class SaveSubjectService(AppDbContext context) : ISaveSubjectService
    {
        public async Task Store(SubjectDto dto)
        {
            var subject = new Subject(dto.StudyProgram, dto.SubjectTitle);
            context.Subjects.Add(subject);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, SubjectDto dto)
        {
            var subject = await context.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            if (subject != null)
            {
                subject.SetValues(dto.StudyProgram, dto.SubjectTitle);
                context.Subjects.Update(subject);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var subject = await context.Subjects.FindAsync(id);
            if (subject != null)
            {
                context.Subjects.Remove(subject);
                await context.SaveChangesAsync();
            }
        }
    }
}
