using System;
using ApiIntro.Service.Dtos.Categories;
using ApiIntro.Core.Entities;
using AutoMapper;

namespace ApiIntro.Service.Profiles.Categories
{
	public class CategoryProfile:Profile
	{
		public CategoryProfile()
		{
			CreateMap<CategoryPostDto, Category>();
			CreateMap<CategoryUpdateDto, Category>();
			CreateMap<Category, CategoryGetDto>();
        }
	}
}

