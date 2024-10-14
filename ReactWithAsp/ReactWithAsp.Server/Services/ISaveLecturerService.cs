using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface ISaveLecturerService
    {
        Task Store(LecturerDto dto);
        Task Update(int id, LecturerDto dto);
        Task Delete(int id);
    }
}
