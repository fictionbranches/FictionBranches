using Microsoft.AspNetCore.Identity;
using BC = BCrypt.Net.BCrypt;

namespace FictionBranches.Web.Services;

public class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
{
    public string HashPassword(TUser user, string password)
    {
        return BC.HashPassword(password);
    }

    public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    {
        if (BC.Verify(providedPassword, hashedPassword))
        {
            // Check if the hash needs rehashing (optional - for security upgrades)
            if (BC.HashPassword(providedPassword, hashedPassword) != hashedPassword)
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }
            return PasswordVerificationResult.Success;
        }
        return PasswordVerificationResult.Failed;
    }
}