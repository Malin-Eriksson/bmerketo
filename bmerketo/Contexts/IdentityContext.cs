using bmerketo.Models.Entities;
using bmerketo.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Contexts;

public class IdentityContext : IdentityDbContext
{


    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }
    public DbSet<UserProfileEntity> UserProfiles { get; set; }


}
