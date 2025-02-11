using Kreata.Backend.Controllers.Base;
using Kreata.Backend.Repos;
using Kreta.Shared.Assemblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Dtos.Query;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    public partial class StudentController : BaseController<Student, StudentDto>
    {
        private IStudentRepo _studentRepo;
        public StudentController(StudentAssembler? assambler, IStudentRepo? repo) : base(assambler, repo)
        {
            _studentRepo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("getstudentbyfullname")]
        public async Task<IActionResult> GetStudentByFullName([FromQuery] FullNameQueryDto fullNameDto)
        {
            return Ok(await _studentRepo.GetByNameAsync(fullNameDto.FirstName, fullNameDto.LastName));
        }

        [HttpGet("NumberOfStudent")]
        public async Task<IActionResult> GetNumberOfStudentAsync()
        {
            return Ok(await _studentRepo.GetNumberOfStudentAsync());
        }

        // A paraméterben kapott évszám évben született diákok száma (diákok)
        // A paraméterben kapott hónapszám hónapban született diákok száma (diákok)
        [HttpGet("NumberOfStudentByYear/{year}")]
        public async Task<IActionResult> GetNumberOfStudentByYearAsync(int year)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYearAsync(year));
        }

        [HttpGet("NumberOfStudentByYearAndMonth/{year}/{month}")]
        public async Task<IActionResult> GetNumberOfStudentByYearAsync(int year,int month)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYearAsync(year,month));
        }

        [HttpGet("NumberOfStudentByYearAndMonthQuery")]
        public async Task<IActionResult> GetNumberOfStudentByYearQueryAsync([FromQuery] int year, [FromQuery] int month)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYearAsync(year, month));
        }

        // Ezt nem szabad
        [HttpGet("NumberOfStudentByYearAndMonthQuery2")]
        public async Task<IActionResult> GetNumberOfStudentByYearQueryAsync2([FromBody] int year)
        {
            int month = 10;
            return Ok(await _studentRepo.GetNumberOfStudentByYearAsync(year, month));
        }

        // Szűrés: név, évszám, hónap, nem
        [HttpGet("FilterStudent")]
        public async Task<IActionResult> FilterStudentAsync([FromQuery] StudentQueryDto studentQueryDto)
        {
            if (!studentQueryDto.IsValid())
                return BadRequest("A szűrési paraméterek nem megfelelőek");
            return Ok(await _studentRepo.FilterStudentAsync(studentQueryDto));
        }
    }
}
