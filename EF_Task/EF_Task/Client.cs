using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Task
{
	public class Client
	{
		public int ID { get; set; }

		public string Login { get; set; }

		public string FIO { get; set; }

		public Payment Payment { get; set; }
	}
}
