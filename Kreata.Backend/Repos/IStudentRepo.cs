using Kreata.Backend.Repos.Base;
using Kreta.Shared.Dtos.Query;
using Kreta.Shared.Enums;
using Kreta.Shared.Models;

namespace Kreata.Backend.Repos
{
    public interface IStudentRepo : IBaseRepo<Student>
    {
        Task<Student> GetByNameAsync(string firstName, string lastName);
        Task<List<Student>> GetStudentByClass(int schoolYear, SchoolClassType schoolClassType);
        Task<int> GetNumberOfStudentAsync();
        Task<int> GetNumberOfWomanAsync();
        Task<int> GetNumberOfStudentByYearAsync(int year);
        Task<int> GetNumberOfStudentByYearAsync(int year, int month);
        Task<List<Student>> FilterStudentAsync(StudentQueryDto studentQueryDto);
    }

}
