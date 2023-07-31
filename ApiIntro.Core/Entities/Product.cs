using System;
using ApiIntro.Core.Entities.BaseEntities;

namespace ApiIntro.Core.Entities
{
	public class Product:BaseEntity
	{
	     public string Name { get; set; }	
	     public string Price { get; set; }
		 public  string Image { get; set; }
		 public  string ImageUrl { get; set; }
        public int CategoryId { get; set; }
		 public Category Category { get; set; }
    }
}

