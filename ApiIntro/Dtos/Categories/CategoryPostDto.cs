using System;
using System.ComponentModel.DataAnnotations;

namespace ApiIntro.Dtos.Categories
{
	public record CategoryPostDto
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
    }
}

