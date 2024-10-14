using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetSubjectService
    {
        Task<List<SubjectDto>> GetAll();
        Task<SubjectDto> Get(int id);
    }
}
