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
    public DbSet<UserEntity> UserProfiles { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }


}
