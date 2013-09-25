using System.Collections.Generic;

namespace EF_Task
{
	public class Client
	{
		public int ID { get; set; }

		public string Login { get; set; }

		public string FIO { get; set; }

		public virtual ICollection<Payment> Payments { get; set; }
	}
}
