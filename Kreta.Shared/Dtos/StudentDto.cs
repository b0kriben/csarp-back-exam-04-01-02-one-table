using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthsDay { get; set; }
        public int SchoolYear { get; set; }
        public SchoolClassType SchoolClass { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public bool IsWoman { get; set; }
    }
}
