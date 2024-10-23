using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface ISaveStudentService
    {
        Task Store(StudentDto dto);
        Task Update(int id, StudentDto dto);
    }
}
