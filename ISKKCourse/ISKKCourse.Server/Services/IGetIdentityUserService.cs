using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetIdentityUserService
    {
        Task<List<IdentityUserDto>> GetAll();
    }
}
