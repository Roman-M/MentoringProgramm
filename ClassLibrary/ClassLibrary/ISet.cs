using System;

namespace ClassLibrary
{
	public interface ISet<T>
	{
		// Methods
		void Add(T item);
		void Add(T item, Func<T,T,bool> match);
		void Delete(T item);
		void Clear();
		bool Exists(T item);
		bool Exists(Predicate<T> match);
		// Properties
		T[] Items { get; }
		bool IsEmpty { get; }
		int Count { get; }
	}
}