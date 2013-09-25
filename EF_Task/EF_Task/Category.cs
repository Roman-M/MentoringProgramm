using System.Collections.Generic;

namespace EF_Task
{
	public class Category
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public int Parent_Id { get; set; }

		public virtual Category ParentCategory { get; set; }

		public virtual ICollection<Good> Goods { get; set; }
	}
}
