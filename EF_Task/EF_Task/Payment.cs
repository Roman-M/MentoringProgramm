using System;

namespace EF_Task
{
	public class Payment
	{
		public Guid ID { get; set; }

		public Guid GoodId { get; set; }

		public int Quantity { get; set; }

		public DateTime Date { get; set; }

		public int ClientID { get; set; }

		public virtual Good Good { get; set; }

		public virtual Client Client { get; set; }
	}
}
