using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Services
{
    // AuthService.cs
    public class AuthService
    {
        private readonly List<User> _users; // In-memory user store for demonstration

        public AuthService()
        {
            // Initialize some demo users
            _users = new List<User>
        {
            new User { Id = 1, Username = "ddheadoffice", Password = "password", UserType = "DDHeadOffice" },
            new User { Id = 2, Username = "ddoutlet", Password = "password", UserType = "DDOutlet" },
            new User { Id = 3, Username = "thirdparty", Password = "password", UserType = "ThirdPartyOutlet" }
        };
        }

        public User Authenticate(string username, string password)
        {
            // Find user by username and password
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // Return null if user not found or password is incorrect
            if (user == null)
                return null;

            // Authentication successful, return user
            return user;
        }
    }

}
