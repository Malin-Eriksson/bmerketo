using bmerketo.Contexts;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Services;

public class AuthService
{
	private readonly SignInManager<UserEntity> _signInManager;
	private readonly SeedService _seedService;
	private readonly AddressService _addressService;
	private readonly UserManager<UserEntity> _userManager;

	public AuthService(SignInManager<UserEntity> signInManager, SeedService seedService, AddressService addressService, UserManager<UserEntity> userManager)
	{
		_signInManager = signInManager;
		_seedService = seedService;
		_addressService = addressService;
		_userManager = userManager;
	}

	public async Task<bool> SignUpAsync(UserSignUpViewModel model)
	{
		try
		{
			//Sets default role to user
			await _seedService.SeedRoles();
			var roleName = "user";

			//If there's no users, the user created will be admin
			if (!await _userManager.Users.AnyAsync())
				roleName = "admin";


			UserEntity userEntity = model;
			var result = await _userManager.CreateAsync(userEntity, model.Password);

			await _userManager.AddToRoleAsync(userEntity, roleName);

			if (result.Succeeded)
			{
				var addressEntity = await _addressService.GetOrCreateAsync(model);
				if (addressEntity != null)
				{
					await _addressService.AddUserAddressAsync(userEntity, addressEntity);
					return true;
				}

			}

			return false;

/*			UserEntity userEntity = model;
			userEntity.UserId = identityUser.Id;

			_identityContext.UserProfiles.Add(userEntity);
			await _identityContext.SaveChangesAsync();

			return true;*/
		} 
		catch { return false; }
	}

	public async Task<bool> SignUpAsync(AdminSignUpViewModel model)
	{
		try
		{
			//Sets default role to user
			await _seedService.SeedRoles();
			var roleName = "user";

			//If there's no users, the user created will be admin
			if (!await _userManager.Users.AnyAsync())
				roleName = "admin";


			UserEntity userEntity = model;
			var result = await _userManager.CreateAsync(userEntity, model.Password);

			await _userManager.AddToRoleAsync(userEntity, roleName);

			if (result.Succeeded)
			{
				var addressEntity = await _addressService.GetOrCreateAsync(model);
				if (addressEntity != null)
				{
					await _addressService.AddUserAddressAsync(userEntity, addressEntity);
					return true;
				}

			}

			return false;

			/*			UserEntity userEntity = model;
						userEntity.UserId = identityUser.Id;

						_identityContext.UserProfiles.Add(userEntity);
						await _identityContext.SaveChangesAsync();

						return true;*/
		}
		catch { return false; }
	}

	public async Task<bool> SignInAsync(UserSignInViewModel model)
	{
		try
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
			return result.Succeeded;
		}
		catch { return false; }
	}


	public async Task<bool> SignOutAsync(ClaimsPrincipal user)
	{
		await _signInManager.SignOutAsync();
		return _signInManager.IsSignedIn(user);
	}
}
