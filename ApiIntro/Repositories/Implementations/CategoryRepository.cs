using System;
using ApiIntro.Contexts;
using ApiIntro.Entities;
using ApiIntro.Repositories.Interfaces;

namespace ApiIntro.Repositories.Implementations
{
	public class CategoryRepository:Repository<Category>,ICategoryRepository 
	{
        private readonly ApiDbContext _context;

        public CategoryRepository(ApiDbContext context):base(context)
        {
          
        }
    }
}

