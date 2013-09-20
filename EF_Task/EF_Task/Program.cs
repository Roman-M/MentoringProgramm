
using System;
namespace EF_Task
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var db = new Context())
			{
				var good = new Good
				{
					//ID = Guid.NewGuid(),
					Name = "Gsdfs"
				};
				db.Goods.Add(good);
				db.SaveChanges();
			}
		}
	}
}
