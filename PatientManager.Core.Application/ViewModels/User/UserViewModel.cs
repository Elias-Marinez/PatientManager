
namespace PatientManager.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string UserType { get; set; }
    }
}
