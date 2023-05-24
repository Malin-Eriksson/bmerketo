using bmerketo.Contexts;
using bmerketo.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
 

    public UserService(IdentityContext identityContext)
    {
        _identityContext = identityContext;

    }

    public async Task<UserEntity> GetUserProfileAsync(string email)
    {
        var userEntity = await _identityContext.UserProfiles/*.Include(x => x.User)*/.FirstOrDefaultAsync(x => x.Email == email);
        return userEntity!;
    }
}
