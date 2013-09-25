
using System;
using System.Linq;

namespace EF_Task
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var db = new Context())
			{
				//var good1 = new Good
				//{
				//	Name = "GOOD1",
				//	Amount = 56
				//};
				//db.Goods.Add(good1);
				//db.SaveChanges();

				//var good2 = new Good
				//{
				//	Name = "GOOD2",
				//	Amount = 29
				//};
				//db.Goods.Add(good2);
				//db.SaveChanges();


				//var payment1 = new Payment
				//{
				//	GoodId = good1.ID,
				//	Quantity = 6,
				//	Date = DateTime.Now
				//};
				//db.Payments.Add(payment1);
				//db.SaveChanges();

				//var payment2 = new Payment
				//{
				//	GoodId = good2.ID,
				//	Quantity = 3,
				//	Date = DateTime.Now
				//};
				//db.Payments.Add(payment2);
				//db.SaveChanges();

				//var payment3 = new Payment
				//{
				//	GoodId = good1.ID,
				//	Quantity = 10,
				//	Date = DateTime.Now
				//};
				//db.Payments.Add(payment3);
				//db.SaveChanges();

				
				Good good = db.Goods.Where(t => t.Name == "GOOD1").First();
				var webMoney = new WebMoney
				{
					GoodId = good.ID,
					Date = DateTime.Now,
					Quantity = 5,
					PurseNumber = "707879879896",
					ClientID = 1
				};
				db.Payments.Add(webMoney);
				db.SaveChanges();

				var paypal = new PayPal
				{
					GoodId = good.ID,
					Date = DateTime.Now,
					Quantity = 5,
					Account = "mmmm@maic.com",
					ClientID = 1
				};
				db.Payments.Add(paypal);
				db.SaveChanges();

				var bankCard = new BankCard
				{
					GoodId = good.ID,
					Date = DateTime.Now,
					Quantity = 5,
					CardNumber = "1234567890123456",
					ExpDate = new ExpiryDate{Month = 12, Year = 2012},
					ClientID = 1
				};
				db.Payments.Add(bankCard);
				db.SaveChanges();
			}
		}
	}
}
