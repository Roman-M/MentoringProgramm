using System.ComponentModel.DataAnnotations;

namespace EF_Task
{
	public class WebMoney : Payment
	{
		[MaxLength(12), RegularExpression("^[0-9]{12}$")]
		public string PurseNumber { get; set; }
	}
}
