using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ApiIntro.Service.Dtos.Products
{
	public record ProductPostDto
	{
        public string Name { get; set; }
        public string Price { get; set; }
        public IFormFile File { get; set; }
        public int CategoryId { get; set; }
    }
}

