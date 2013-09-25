using System.ComponentModel.DataAnnotations;

namespace EF_Task
{
	public class PayPal : Payment
	{
		[MaxLength(100), EmailAddress]
		public string Account { get; set; }
	}
}
