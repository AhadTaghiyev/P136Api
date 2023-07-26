using System;
using ApiIntro.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Contexts
{
	public class ApiDbContext:DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }
		
	}
}

