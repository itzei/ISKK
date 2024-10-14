using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetProgramService
    {
        Task<List<ProgramDto>> GetAll();
        Task<ProgramDto> Get(int id);
    }
}
