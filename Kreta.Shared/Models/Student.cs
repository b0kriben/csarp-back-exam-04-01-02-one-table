using Kreta.Shared.Enums;

namespace Kreta.Shared.Models
{
    public class Student : IDbEntity<Student>
    {      
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthsDay { get; set; }
        public int SchoolYear { get; set; }
        public SchoolClassType SchoolClass { get; set; }
        public string EducationLevel { get; set; } = string.Empty;
        public bool IsWoman { get; set; } = false;
        public bool HasId => Id != Guid.Empty;
        public bool IsMan =>!IsWoman;

        public override string ToString()
        {
            return $"{Id} {LastName} {FirstName} ({SchoolYear}.{SchoolClass}) - ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)}) ({EducationLevel})";
        }
    }
}
