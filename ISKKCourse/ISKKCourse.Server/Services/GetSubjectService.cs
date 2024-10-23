using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class GetSubjectService(AppDbContext context): IGetSubjectService
    {
        public async Task<List<SubjectDto>> GetAll()
        {
            var subjects = await context.Subjects.ToListAsync();
            List<SubjectDto> results = [];

            foreach (var group in subjects)
            {
                results.Add(MapDto(group));
            }
            return results;
        }

        public async Task<SubjectDto> Get(int id)
        {
            var group = await context.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(group);
        }

        private SubjectDto MapDto(Subject group) => new SubjectDto(group.Id, group.StudyProgram, group.SubjectTitle);
    }
}
