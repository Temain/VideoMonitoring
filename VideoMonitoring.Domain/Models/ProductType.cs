using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
	public class ProductType
	{
		public ProductType()
		{
			CreatedAt = DateTime.Now;
		}

		public int ProductTypeId { get; set; }
		public string ProductTypeName { get; set; }

		public int ProductCategoryId { get; set; }
		public ProductCategory ProductCategory { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

		public List<Product> Products { get; set; }
    }
}
