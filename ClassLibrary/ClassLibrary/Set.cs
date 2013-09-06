using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
	public class Set<T> : ISet<T>
	{
		private readonly List<T> sets;

		public int Count
		{
			get { return sets.Count; }
		}

		public T[] Items
		{
			get { return sets.ToArray<T>(); }
		}

		public bool IsEmpty
		{
			get { return sets != null && this.Count != 0 ? false : true; }
		}

		public Set()
		{
			sets = new List<T>();
		}

		public void Add(T item)
		{
			if (Exists(item) == false)
				sets.Add(item);
		}

		public void Add(T item, Func<T,T,bool> match)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this.Items[i], item) == true)
					return;
			}
			sets.Add(item);
		}

		public void Delete(T item)
		{
			if (Exists(item) == true)
				sets.Remove(item);
		}

		public void Clear()
		{
			sets.Clear();
		}

		public bool Exists(T item)
		{
			for(int i = 0; i < this.Count; i++)
			{
				if (this.Items[i].Equals(item))
					return true;
			}
			return false;
		}

		public bool Exists(Predicate<T> obj)
		{
			return sets.Exists(obj);
		}
	}
}