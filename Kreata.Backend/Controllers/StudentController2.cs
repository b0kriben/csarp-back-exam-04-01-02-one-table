using Kreata.Backend.Controllers.Base;
using Kreata.Backend.Repos;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class StudentController : BaseController<Student, StudentDto>
    {             
        [HttpGet("byid/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(Guid id)
        {
            var student = (await _studentRepo.FindByConditionAsync(s => s.Id == id)).FirstOrDefault();
            if (student != null)
                return Ok(student.ToStudentDto());
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            var students = (await _studentRepo.GetAllAsync()).ToList();
            return Ok(students.Select(student => student.ToStudentDto()));
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateStudentAsync(StudentDto student)
        {
            Response response = response = await _studentRepo.UpdateAsync(student.ToStudent());
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("A diák adatainak módosítása nem sikerült!");
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudendAsync(Guid id)
        {
            Response response = await _studentRepo.DeleteAsync(id);
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("A diák adatainak törlése nem sikerült!");
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateStudentAsync(StudentDto student)
        {
            Response response = await _studentRepo.CreateAsync(student.ToStudent());
            if (response.HasError)
            {
                Console.WriteLine(response.Error);
                response.ClearAndAddError("Új diák adatának felvétele nem sikerült!");
                return BadRequest(response);
            }
            else
                return Ok(response);
        }
    }
}
