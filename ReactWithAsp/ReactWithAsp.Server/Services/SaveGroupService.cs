using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class SaveGroupService(AppDbContext context) : ISaveGroupService
    {
        public async Task Store(GroupDto dto)
        {
            var group = new Group(dto.StudyProgram, dto.GroupTitle);
            context.Groups.Add(group);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, GroupDto dto)
        {
            var group = await context.Groups.FirstOrDefaultAsync(i => i.Id == id);
            if (group != null)
            {
                group.SetValues(dto.StudyProgram, dto.GroupTitle);
                context.Groups.Update(group);
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var group = await context.Groups.FindAsync(id);
            if (group != null)
            {
                context.Groups.Remove(group);
                await context.SaveChangesAsync();
            }
        }
    }
}
