using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Models.DTOs;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Services
{
    public class GetIdentityUserService(AppDbContext context): IGetIdentityUserService
    {
        public async Task<List<IdentityUserDto>> GetAll()
        {
            var identityUser = await context.Users.ToListAsync();
            List<IdentityUserDto> results = new List<IdentityUserDto>();

            foreach (var identityUsers in identityUser)
            {
                results.Add(MapDto(identityUsers));
            }
            return results;
        }
        public async Task<IdentityUserDto> Get(string id)
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.Id == id);
            return MapDto(user);
        }
        private IdentityUserDto MapDto(Microsoft.AspNetCore.Identity.IdentityUser identityUsers) => new IdentityUserDto(identityUsers.UserName, identityUsers.Email);
    }
}
