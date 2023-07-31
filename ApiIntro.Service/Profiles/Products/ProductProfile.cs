using System;
using ApiIntro.Core.Entities;
using ApiIntro.Service.Dtos.Products;
using AutoMapper;

namespace ApiIntro.Service.Profiles.Products
{
	public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductGetDto>();
			CreateMap<ProductPostDto, Product>();

        }
	}
}

