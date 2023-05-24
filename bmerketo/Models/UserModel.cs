namespace bmerketo.Models;

public class UserModel
{
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? StreetName { get; set; }
	public string? PostalCode { get; set; }
	public string? City { get; set; }
}
