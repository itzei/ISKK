using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetLecturerService
    {
        Task<List<LecturerDto>> GetAll();
        Task<LecturerDto> Get(int id);
    }
}
