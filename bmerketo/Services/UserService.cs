using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserRepo _userRepo;
	private readonly UserManager<UserEntity> _userManager;
	private readonly IWebHostEnvironment _webHostEnvironment;


	public UserService(IdentityContext identityContext, UserRepo userRepo, UserManager<UserEntity> userManager, IWebHostEnvironment webHostEnvironment)
	{
		_identityContext = identityContext;
		_userRepo = userRepo;
		_userManager = userManager;
		_webHostEnvironment = webHostEnvironment;
	}



	public async Task<UserEntity> GetAsync(string userId)
	{
		return await _userRepo.GetAsync(x => x.Id == userId);
	}

	public async Task<bool> UpdateUserRoleAsync(string userId, string newRole)
	{
		var user = await _userManager.FindByIdAsync(userId);

		if (user != null)
		{
			var currentRoles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, currentRoles);
			await _userManager.AddToRoleAsync(user, newRole);
			await _userManager.UpdateAsync(user);
			return true;
		}
		return false;
	}

	public async Task<bool> UploadImageAsync(UserEntity user, IFormFile profilePicture)
	{
		try
		{
			string imagePath = $"{_webHostEnvironment.WebRootPath}/images/profile/{user.ProfilePicture}";
			await profilePicture.CopyToAsync(new FileStream(imagePath, FileMode.Create));
			return true;
		}
		catch { return false; }
	}

}
