using System.ComponentModel.DataAnnotations;

namespace EF_Task
{
	public class ExpiryDate
	{
		[Range(1,12)]
		public int Month { get; set; }

		[Range(1990,2100)]
		public int Year { get; set; }
	}
}
