using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;

namespace Kreta.Shared.Assemblers
{
    public class StudentAssembler : Assambler<Student, StudentDto>
    {
        public override StudentDto ToDto(Student domainEntity)
        {
            return domainEntity.ToStudentDto();
        }

        public override Student ToModel(StudentDto dto)
        {
            return dto.ToStudent();
        }
    }
}
