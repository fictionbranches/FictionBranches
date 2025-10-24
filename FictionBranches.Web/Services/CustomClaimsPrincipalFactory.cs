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
        {
            throw new ArgumentNullException("user");
        }
        var principal = await base.CreateAsync(user);
        if (principal.Identity is ClaimsIdentity)
        {
            var identity = (ClaimsIdentity)principal.Identity;
            identity.AddClaim(new Claim(Names.ClaimUsername, user.Id));
            identity.AddClaim(new Claim(Names.ClaimUserLevel, user.Level.ToString()));
            identity.AddClaim(new Claim(Names.ClaimAuthorName, user.Author));
        }
        return principal;
    }

}

public static class ClaimsExtensions
{
    public static bool IsLoggedIn(this ClaimsPrincipal principal)
    {
        var username = Username(principal);
        if (username == null)
            return false;
        return !string.IsNullOrWhiteSpace(username);
    }

    public static string? Username(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);
        return principal.FindFirst(Names.ClaimUsername)?.Value;
    }

    public static short Level(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);
        var claim = principal.FindFirst(Names.ClaimUserLevel);
        return claim == null ? (short)0 : short.Parse(claim.Value);
    }
    
    public static string AuthorName(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);
        var claim = principal.FindFirst(Names.ClaimAuthorName);
        return claim.Value;
    }
}