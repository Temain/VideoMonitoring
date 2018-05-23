using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
	[Table("tl_order")]
	public class Order
    {
		public Order()
		{
			CreatedAt = DateTime.Now;
		}

		public int OrderId { get; set; }
		public decimal TotalSum { get; set; }

		public long UserId { get; set; }
		public User User { get; set; }

		public bool IsChecked { get; set; }
		public bool IsSended { get; set; }
		public bool IsDelivered { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
	}
}
