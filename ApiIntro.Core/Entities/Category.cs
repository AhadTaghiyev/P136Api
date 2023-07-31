using System;
using System.ComponentModel.DataAnnotations;
using ApiIntro.Core.Entities.BaseEntities;

namespace ApiIntro.Core.Entities
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public List<Product> Products {get;set;}
	}
}

