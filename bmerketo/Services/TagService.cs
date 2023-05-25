using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Services;

public class TagService
{
	private readonly TagRepo _tagRepo;

	public TagService(TagRepo tagRepo)
	{
		_tagRepo = tagRepo;
	}

	public async Task<List<SelectListItem>> GetTagsAsync()
	{
		var tags = new List<SelectListItem>();

		foreach (var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName
			});
		}

		return tags;
	}

	public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
	{
		var tags = new List<SelectListItem>();

		foreach (var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName,
				Selected = selectedTags.Contains(tag.Id.ToString())
			});
		}

		return tags;
	}


}
