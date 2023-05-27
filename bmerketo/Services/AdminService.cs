using bmerketo.Models.Entities;
using bmerketo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static bmerketo.Services.AdminService;

namespace bmerketo.Services;

public class AdminService
{
	private readonly UserManager<UserEntity> _userManager;
	private readonly UserRepo _userRepo;

	public AdminService(UserManager<UserEntity> userManager, UserRepo userRepo)
	{
		_userManager = userManager;
		_userRepo = userRepo;
	}

	public async Task<IEnumerable<User>> GetUsersAsync()
	{
		var users = new List<User>();
		foreach (var user in await _userManager.Users.ToListAsync())
		{
			var _user = new User
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
			};

			foreach (var role in await _userManager.GetRolesAsync(user))
			{
				_user.RoleNames.Add(role);
			}

			users.Add(_user);

		}
		return users;
	}







	public class User
	{
		public string? Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public List<string> RoleNames { get; set; } = new List<string>();

	}
}
