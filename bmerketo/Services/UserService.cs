using bmerketo.Contexts;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserRepo _userRepo;


	public UserService(IdentityContext identityContext, UserRepo userRepo)
	{
		_identityContext = identityContext;
		_userRepo = userRepo;
	}



	public async Task<UserEntity> GetAsync(string userId)
	{
		return await _userRepo.GetAsync(x => x.Id == userId);
	}
}
