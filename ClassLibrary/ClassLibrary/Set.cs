using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
	public class Set<T> : ISet<T>
	{
		private readonly List<T> underlyingList;

		public int Count
		{
			get { return underlyingList.Count; }
		}

		public T this[int index]
		{
			get 
			{
				if (index >= 0 && index < Count)
					return underlyingList[index];
				else
					throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsEmpty
		{
			get { return this.Count == 0 ? true : false; }
		}

		public Set()
		{
			underlyingList = new List<T>();
		}

		public void Add(T item)
		{
			Add(item, (a,b) => a.Equals(b));
		}

		public void Add(T item, Func<T,T,bool> match)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this[i], item))
					throw new ArgumentException("The same element is already exists in this collection.");
			}
			underlyingList.Add(item);
		}

		public void Delete(T item)
		{
			if (Exists(item))
				underlyingList.Remove(item); 
		}

		public void Clear()
		{
			underlyingList.Clear();
		}

		public bool Exists(T item)
		{
			return Exists((e) => e.Equals(item));
		}

		public bool Exists(Predicate<T> match)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this[i]))
					return true;
			}
			return false;
		}
	}
}