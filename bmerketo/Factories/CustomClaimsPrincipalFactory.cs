using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace bmerketo.Factories;

public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity>
{
    private readonly UserService _userService;
    private readonly UserAddressRepo _userAddressRepo;
	private readonly AddressRepo _addressRepo;

	public CustomClaimsPrincipalFactory(UserManager<UserEntity> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService, UserAddressRepo userAddressRepo, AddressRepo addressRepo) : base(userManager, optionsAccessor)
	{
		_userService = userService;
		_userAddressRepo = userAddressRepo;
		_addressRepo = addressRepo;
	}

	protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
    {
        var claimsIdentity = await base.GenerateClaimsAsync(user);

        var userProfileEntity = await _userService.GetAsync(user.Id);

		var userAddress = await _userAddressRepo.GetAsync(x => x.UserId == user.Id);

		var address = await _addressRepo.GetAsync(x => x.Id == userAddress.AddressId);

		

		var roles = await UserManager.GetRolesAsync(user);


		claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));



		claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));
        claimsIdentity.AddClaim(new Claim("Company", user.Company ?? ""));
        claimsIdentity.AddClaim(new Claim("PhoneNumber", user.PhoneNumber ?? ""));
        claimsIdentity.AddClaim(new Claim("ProfilePicture", user.ProfilePicture ?? ""));

		claimsIdentity.AddClaim(new Claim("Street", address.StreetName ?? ""));
		claimsIdentity.AddClaim(new Claim("PostalCity",$"{address.PostalCode}  {address.City}" ?? ""));




		return claimsIdentity;


	}


}
