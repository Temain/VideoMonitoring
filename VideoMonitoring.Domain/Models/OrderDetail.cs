using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
    public class OrderDetail
    {
		public int OrderDetailId { get; set; }

		public int OrderId { get; set; }
		public Order Order { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public decimal Price { get; set; }
		public decimal? Count { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
