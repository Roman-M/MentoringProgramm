using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Task
{
	public class BankCard : Payment
	{
		[MaxLength(16), RegularExpression("^[0-9]{16}$")]
		public string CardNumber { get; set; }

		public ExpiryDate ExpDate { get; set; }

		[NotMapped]
		public int CVC { get; set; }
	}
}
