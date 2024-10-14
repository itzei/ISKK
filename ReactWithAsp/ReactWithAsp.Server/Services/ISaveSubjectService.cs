using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface ISaveSubjectService
    {
        Task Store(SubjectDto dto);
        Task Update(int id, SubjectDto dto);
        Task Delete(int id);
    }
}
