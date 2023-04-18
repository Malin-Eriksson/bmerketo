﻿using bmerketo.Contexts;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo.Services;

public class AuthService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IdentityContext _identityContext;
	private readonly SeedService _seedService;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, SeedService seedService)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _seedService = seedService;
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


			IdentityUser identityUser = model;
			await _userManager.CreateAsync(identityUser, model.Password);

			await _userManager.AddToRoleAsync(identityUser, roleName);

			UserProfileEntity userProfileEntity = model;
			userProfileEntity.UserId = identityUser.Id;

			_identityContext.UserProfiles.Add(userProfileEntity);
			await _identityContext.SaveChangesAsync();

			return true;
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
