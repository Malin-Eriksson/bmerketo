using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Services;

public class TagService
{
	private readonly TagRepo _tagRepo;

	public TagService(TagRepo tagRepo)
	{
		_tagRepo = tagRepo;
	}

	public async Task<TagEntity> GetOrCreateAsync(TagModel model)
	{
		var tagEntity = await _tagRepo.GetAsync(x => x.Id == model.Value);
		tagEntity ??= await _tagRepo.AddAsync(new TagEntity { TagName = model.Name });
		return tagEntity;
	}

	public async Task<IEnumerable<TagModel>> GetTagsAsync()
	{
		var items = await _tagRepo.GetAllAsync();
		var tags= new List<TagModel>();

		foreach(var item in items)
			tags.Add(new TagModel { Name = item.TagName, Value = item.Id });

		return tags;
	}
}
