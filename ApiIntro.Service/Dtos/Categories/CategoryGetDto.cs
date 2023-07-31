using System;
namespace ApiIntro.Service.Dtos.Categories
{ 
    public record CategoryGetDto
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
    }
}

