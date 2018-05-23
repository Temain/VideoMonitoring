using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
	[Table("td_product_category")]
	public class ProductCategory
    {
		public ProductCategory()
		{
			CreatedAt = DateTime.Now;
		}

		public int ProductCategoryId { get; set; }

		public string ProductCategoryName { get; set; }

		public List<ProductType> ProductTypes { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
    }
}
