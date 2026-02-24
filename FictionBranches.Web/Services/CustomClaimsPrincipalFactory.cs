using System.Security.Claims;
using FictionBranches.Web.Constants;
using FictionBranches.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FictionBranches.Web.Services;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<Fbuser>
{
    public CustomClaimsPrincipalFactory(UserManager<Fbuser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
    }
    public override async Task<ClaimsPrincipal> CreateAsync(Fbuser user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        var principal = await base.CreateAsync(user);
        if (principal.Identity is ClaimsIdentity identity)
        {
            identity.AddClaim(new Claim(Names.ClaimUsername, user.Id));
            identity.AddClaim(new Claim(Names.ClaimUserLevel, user.Level.ToString()));
            identity.AddClaim(new Claim(Names.ClaimAuthorName, user.Author!));
        }
        return principal;
    }

}

public static class ClaimsExtensions
{
    public static bool IsLoggedIn(this ClaimsPrincipal? principal)
    {
        if (principal == null)
            return false;
        try
        {
            return !string.IsNullOrWhiteSpace(Username(principal));
        }
        catch
        {
            return false;
        }
    }

    public static string Username(this ClaimsPrincipal principal) => SafeClaim(principal, Names.ClaimUsername);

    private static short Level(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);
        var claim = principal.FindFirst(Names.ClaimUserLevel);
        return claim == null ? (short)0 : short.Parse(claim.Value);
    }

    private static string SafeClaim(ClaimsPrincipal principal, string  claimName)
    {
        var claimValue = principal?.FindFirst(claimName)?.Value;
        ArgumentNullException.ThrowIfNull(claimValue);
        return claimValue;
    }

    public static bool IsAdmin(this ClaimsPrincipal principal) => principal.Level() >= 100;
    public static bool IsMod(this ClaimsPrincipal principal) => principal.Level() >= 10;
    
    public static string AuthorName(this ClaimsPrincipal principal) => SafeClaim(principal, Names.ClaimAuthorName);
}