using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface ISaveProgramService
    {
        Task Store(ProgramDto dto);
        Task Update(int id, ProgramDto dto);
        Task Delete(int id);
    }
}
