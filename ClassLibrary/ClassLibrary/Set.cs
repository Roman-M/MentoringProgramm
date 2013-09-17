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

		public T this[int index]
		{
			get 
			{
				if (index >= 0 && index < Count)
					return sets[index];
				else
					throw new ArgumentOutOfRangeException();
			}
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
			Add(item, (a,b) => a.Equals(b));
		}

		public void Add(T item, Func<T,T,bool> match)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this[i], item) == true)
					throw new ArgumentException("The same element is already exists in this collection.");
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
			return Exists((e) => e.Equals(item));
		}

		public bool Exists(Predicate<T> obj)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (obj(this[i]) == true)
					return true;
			}
			return false;
		}
	}
}