using System;
using System.Collections.Generic;

namespace LimitedSizeStack;

public class LimitedSizeStack<T>
{
    private readonly int limit;
	private LinkedList<T> items = new LinkedList<T>();

	public LimitedSizeStack(int undoLimit)
	{
		this.limit = undoLimit;
	}

    public void Push(T item)
	{
		if (limit == 0) return;

		items.AddLast(item);
		Count++;

		if (items.Count > limit)
		{
			items.RemoveFirst();
			Count--;
		}
	}

	public T Pop()
	{
		if (limit == 0) throw new InvalidOperationException();
		var result = items.Last.Value;
		items.RemoveLast();
		Count--;
		return result;
	}

	public int Count
	{
		get;
		private set;
	}
}

