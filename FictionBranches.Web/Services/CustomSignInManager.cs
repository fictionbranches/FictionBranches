using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FictionBranches.Web.Services;

public class CustomSignInManager<TUser> : SignInManager<TUser>  where TUser : IdentityUser
{
    private new readonly UserManager<TUser> _userManager;

    public CustomSignInManager(
        UserManager<TUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<TUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<TUser>> logger,
        IAuthenticationSchemeProvider schemes,
        IUserConfirmation<TUser> confirmation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
        _userManager = userManager;
    }

    public async Task<SignInResult> CustomPasswordSignInAsync(string usernameOrEmail, string password, bool isPersistent, bool lockoutOnFailure)
    {
        TUser? user = null;

        // Check if input contains '@' to determine if it's email or username
        if (usernameOrEmail.Contains('@'))
        {
            // It's an email
            user = await _userManager.FindByEmailAsync(usernameOrEmail);
        }
        else
        {
            // It's a username (which is the Id in your case)
            user = await _userManager.FindByNameAsync(usernameOrEmail);
        }

        if (user == null)
        {
            return SignInResult.Failed;
        }

        return await PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
    }
}