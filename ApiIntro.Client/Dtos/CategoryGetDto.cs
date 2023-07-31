using System;
namespace ApiIntro.Client.Dtos
{
	public class CategoryGetDto
	{
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class GetItems<T>
    {
        public List<T> Items { get; set; }
    }
}

