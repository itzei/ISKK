using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetGroupService
    {
        Task<List<GroupDto>> GetAll();
        Task<GroupDto> Get(int id);
    }
}
