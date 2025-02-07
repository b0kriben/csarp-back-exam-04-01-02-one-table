namespace Kreta.Shared.Models
{
    public class Job
    {
        public Job(Guid id, string jobName, DateTime publishmentDate, bool isActive, Employer employer)
        {
            Id = id;
            JobName = jobName;
            PublishmentDate = publishmentDate;
            IsActive = isActive;
            Employer = employer;
        }

        public Job()
        {
            Id = Guid.NewGuid();
            JobName = string.Empty;
            PublishmentDate = DateTime.Now;
            IsActive = false;
            Employer = new();
        }

        public Guid Id { get; set; }
        public string JobName { get; set; }
        public DateTime PublishmentDate { get; set; }
        public bool IsActive { get; set; }
        public Employer Employer;
    }
}
