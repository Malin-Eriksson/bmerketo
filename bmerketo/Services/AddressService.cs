using bmerketo.Models.Entities;
using bmerketo.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace bmerketo.Services;

public class AddressService
{
	private readonly AddressRepo _addressRepo;
	private readonly UserAddressRepo _userAddressRepo;

	public AddressService(AddressRepo addressRepo, UserAddressRepo userAddressRepo)
	{
		_addressRepo = addressRepo;
		_userAddressRepo = userAddressRepo;
	}

	public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
	{
		var entity = await _addressRepo.GetAsync(x =>
			x.StreetName == addressEntity.StreetName &&
			x.PostalCode == addressEntity.PostalCode &&
			x.City == addressEntity.City
		);

		entity ??= await _addressRepo.AddAsync(addressEntity);
		return entity!;
	}




	public async Task<bool> AddUserAddressAsync(UserEntity userEntity, AddressEntity addressEntity)
	{
		try
		{
			var entity = await _userAddressRepo.AddAsync(new UserAddressEntity
			{
				UserId = userEntity.Id,
				AddressId = addressEntity.Id,
			});

			if (entity != null)
				return true;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return false;





	}
}
