namespace Kreta.Shared.Models
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            IsWoomen = false;
        }


        public Employee(string firstName, string lastName, DateTime birthsDay, bool isWoomen)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            IsWoomen = isWoomen;
        }

        public Employee(Guid id, string firstName, string lastName, DateTime birthsDay, bool isWoomen, string job)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            IsWoomen = isWoomen;
            Job = job;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public bool IsWoomen { get; set; }
        public string Job { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
