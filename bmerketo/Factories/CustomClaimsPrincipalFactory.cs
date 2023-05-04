using bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace bmerketo.Factories;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
{
    private readonly UserService _userService;

    public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
    {
        _userService = userService;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);

        var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

		var roles = await UserManager.GetRolesAsync(user);

		claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));



		claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

        return claimsIdentity;


	}
}
