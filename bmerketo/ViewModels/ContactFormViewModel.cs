using bmerketo.Models.Entities;

namespace bmerketo.ViewModels
{
	public class ContactFormViewModel
	{
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; } = null!;
		public string? Company { get; set; } = null!;
		public string Message { get; set; } = null!;


		public static implicit operator ContactFormEntity(ContactFormViewModel viewModel)
		{
			return new ContactFormEntity
			{
				Name = viewModel.Name,
				Email = viewModel.Email,
				PhoneNumber = viewModel.PhoneNumber,
				Company = viewModel.Company,
				Message = viewModel.Message
			};
		}
	}
}
