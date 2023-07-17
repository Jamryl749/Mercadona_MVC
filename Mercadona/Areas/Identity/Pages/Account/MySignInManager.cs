using Microsoft.AspNetCore.Identity;

namespace Mercadona.Areas.Identity.Pages.Account
{
    public class MySignInManager : SignInManager<IdentityUser>
    {
        public MySignInManager(UserManager<IdentityUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<IdentityUser> claimsFactory, Microsoft.Extensions.Options.IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<Microsoft.AspNetCore.Identity.IdentityUser>> logger, Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider schemes, IUserConfirmation<IdentityUser> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        public override async Task<SignInResult> PasswordSignInAsync(string username, string password,
            bool isPersistent, bool lockoutOnFailure)
        {
            var user = await UserManager.FindByEmailAsync(username);
            if (user == null)
            {
                return SignInResult.Failed;
            }

            return await PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }
    }
}
