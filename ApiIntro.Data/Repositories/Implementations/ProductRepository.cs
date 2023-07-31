using System;
using ApiIntro.Core.Entities;
using ApiIntro.Core.Repositories;
using ApiIntro.Data.Contexts;

namespace ApiIntro.Data.Repositories.Implementations
{
	public class ProductRepository:Repository<Product>,IProductRepository
	{
		public ProductRepository(ApiDbContext context):base(context)
		{
		}
	}
}

