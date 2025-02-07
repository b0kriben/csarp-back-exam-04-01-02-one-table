using Kreata.Backend.Context;
using Kreata.Backend.Repos.Base;
using Kreta.Shared.Dtos.Query;
using Kreta.Shared.Enums;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class StudentRepo<TDbContext> : BaseRepo<TDbContext, Student>, IStudentRepo where TDbContext : KretaContext
    {
        public StudentRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public async Task<Student> GetByNameAsync(string firstName, string lastName)
        {
            // return (await FindByConditionAsync(s => s.FirstName == firstName && s.LastName == lastName)).FirstOrDefault() ?? new Student();
            return await _dbSet!.FindByCondition<Student>(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefaultAsync() ?? new Student();
        }

        public async Task<int> GetNumberOfStudentAsync()
        {
             return await _dbSet!.CountAsync();
        }

        public async Task<int> GetNumberOfStudentByYearAsync(int year)
        {
            return await _dbSet!.CountAsync(s => s.BirthsDay.Year == year);
        }

        public async Task<int> GetNumberOfStudentByYearAsync(int year, int month)
        {
            return await _dbSet!.CountAsync(s => s.BirthsDay.Year == year && s.BirthsDay.Month==month);
        }

        public async Task<int> GetNumberOfWomanAsync()
        {
            return await _dbSet!.CountAsync(s => s.IsWoman);
        }

        public async Task<List<Student>> GetStudentByClass(int schoolYear, SchoolClassType schoolClassType)
        {
            return await _dbSet!
                .FindByCondition<Student>(s =>s.SchoolYear==schoolYear && s.SchoolClass==schoolClassType).ToListAsync();
        }

        public Task<List<Student>> FilterStudentAsync(StudentQueryDto studentQueryDto)
        {
            // Vizsgaremek változat
            IQueryable<Student> filteredByGender=_dbSet!.Where(s=>s.IsWoman == studentQueryDto.IsWoman);
        }
    }
}
