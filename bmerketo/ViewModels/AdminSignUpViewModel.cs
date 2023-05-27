using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels;

public class AdminSignUpViewModel
{
	
	public string? FirstName { get; set; } = null!;

	
	public string? LastName { get; set; } = null!;

	[Required(ErrorMessage = "Email address is required")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "Password is required")]
	[DataType(DataType.Password)]
	public string Password { get; set; } = null!;

	[Required(ErrorMessage = "Confirm password")]
	[DataType(DataType.Password)]
	[Compare(nameof(Password))]
	public string ConfirmPassword { get; set; } = null!;

	public string? PhoneNumber { get; set; } = null!;

	public string? Company { get; set; } = null!;

	[Display(Name = "Uplad Profile Picture")]
	[DataType(DataType.Upload)]
	public IFormFile? ProfilePicture { get; set; }

	public string? StreetName { get; set; } = null!;

	public string? PostalCode { get; set; } = null!;

	public string? City { get; set; } = null!;




	public static implicit operator UserEntity(AdminSignUpViewModel model)
	{
		return new UserEntity
		{
			UserName = model.Email,
			Email = model.Email,
			PhoneNumber = model.PhoneNumber,
			FirstName = model.FirstName,
			LastName = model.LastName,
			Company = model.Company


		};
	}

	public static implicit operator AddressEntity(AdminSignUpViewModel model)
	{
		return new AddressEntity
		{
			StreetName = model.StreetName,
			PostalCode = model.PostalCode,
			City = model.City

		};
	}

}
