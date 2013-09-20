using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Task
{
	public class Good
	{
		public Guid ID { get; set; }

		public string Name { get; set; }
				
		public decimal Amount { get; set; }

		public virtual ICollection<Payment> Payments { get; set; }
 
		public virtual ICollection<Category> Categories { get; set; }
	}
}
