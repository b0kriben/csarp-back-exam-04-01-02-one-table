namespace Kreta.Shared.Models
{
    public class Employer
    {
        public Employer()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            IsWoomen = false;
        }


        public Employer(string firstName, string lastName, DateTime birthsDay, bool isWoomen)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            IsWoomen = isWoomen;
        }

        public Employer(Guid id, string firstName, string lastName, DateTime birthsDay, bool isWoomen)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            IsWoomen = isWoomen;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public bool IsWoomen { get; set; }
        public string CorporateName { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
