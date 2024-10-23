using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class GetGroupService(AppDbContext context): IGetGroupService
    {
        public async Task<List<GroupDto>> GetAll()
        {
            var groups = await context.Groups.ToListAsync();
            List<GroupDto> results = [];

            foreach (var group in groups)
            {
                results.Add(MapDto(group));
            }
            return results;
        }

        public async Task<GroupDto> Get(int id)
        {
            var group = await context.Groups.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(group);
        }

        private GroupDto MapDto(Group group) => new GroupDto(group.Id, group.StudyProgram, group.GroupTitle);
    }
}
