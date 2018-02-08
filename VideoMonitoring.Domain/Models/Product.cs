using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
	[Table("tl_product")]
	public class Product
    {
		public Product()
		{
			CreatedAt = DateTime.Now;
		}

		public int ProductId { get; set; }
		public int ProductName { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal? InStock { get; set; }

		public int ProductTypeId { get; set; }
		public ProductType ProductType { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
