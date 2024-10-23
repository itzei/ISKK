using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface ISaveGroupService
    {
        Task Store(GroupDto dto);
        Task Update(int id, GroupDto dto);
        Task Delete(int id);
    }
}
