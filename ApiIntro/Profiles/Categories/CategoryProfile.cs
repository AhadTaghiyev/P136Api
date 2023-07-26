using System;
using ApiIntro.Dtos.Categories;
using ApiIntro.Entities;
using AutoMapper;

namespace ApiIntro.Profiles.Categories
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

