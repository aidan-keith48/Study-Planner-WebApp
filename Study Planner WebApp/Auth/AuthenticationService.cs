using Study_Planner_WebApp.Data;
using Study_Planner_WebApp.Model;

namespace Study_Planner_WebApp.Auth
{
    public class AuthenticationService
    {
        HashingPassword hashPassword = new HashingPassword();
        private readonly Study_Planner_WebAppContext _context;

        public AuthenticationService(Study_Planner_WebAppContext context)
        {
            _context = context;
        }

        public RegisterUser Authentication(string username, string password)
        {
            var user = _context.RegisterUser.FirstOrDefault(user => user.username == username);
            if (user != null && hashPassword.VerifyPassword(password, user.password))
            {
                return user;
            }
            return null;
        }
    }
}
