using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMonitoring.Domain.Models
{
    public class Order
    {
		public Order()
		{
			CreatedAt = DateTime.Now;
		}

		public int OrderId { get; set; }
		public decimal TotalSum { get; set; }

		public string ApplicationUserId { get; set; }
		public ApplicationUser User { get; set; }

		public bool IsChecked { get; set; }
		public bool IsSended { get; set; }
		public bool IsDelivered { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
	}
}
