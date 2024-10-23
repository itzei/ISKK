using ReactWithAsp.Server.Models.DTOs;

namespace ReactWithAsp.Server.Services
{
    public interface IGetStudentService
    {
        Task<List<StudentDto>> GetAll();
        Task<StudentDto> Get(int id);
    }
}
