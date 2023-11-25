using Microsoft.CodeAnalysis.Scripting;
using BCrypt.Net; // Add this namespace for BCrypt
using System.Security.Cryptography;

namespace Study_Planner_WebApp.Auth
{
    public class HashingPassword
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        // Verify a password during login
        public bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
