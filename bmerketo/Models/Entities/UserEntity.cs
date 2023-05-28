using Microsoft.AspNetCore.Identity;


namespace bmerketo.Models.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set;} = null!;
    public string? Company { get; set; }
    public string? ProfilePicture { get; set; }
	public ICollection<UserAddressEntity> Addresses { get; set; } = new List<UserAddressEntity>();
}
