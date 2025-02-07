namespace Kreta.Shared.Models
{
    public class UserAccount
    {
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public byte[]? ProfilePicture { get; set; } = null;
    }
}
