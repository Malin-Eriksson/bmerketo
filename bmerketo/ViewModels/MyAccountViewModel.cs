using bmerketo.Models.Entities;

namespace bmerketo.ViewModels;

public class MyAccountViewModel
{
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? PhoneNumber { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string? Company { get; set; }
	public string? ProfileImage { get; set; }
	public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
	public ICollection<string> Roles { get; set; } = new List<string>();



	public static implicit operator UserEntity(MyAccountViewModel viewModel)
	{
		return new UserEntity
		{
			FirstName = viewModel.FirstName,
			LastName = viewModel.LastName,
			Email = viewModel.Email,
			PhoneNumber = viewModel.PhoneNumber,
			Company = viewModel.Company
		};
	}
}
