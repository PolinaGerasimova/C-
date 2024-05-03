using System;
using System.Collections.Generic;
using System.Linq;


namespace yield
{
    public static class MovingMaxTask
    {
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var maxValues = new LinkedList<double>();
            var queue = new Queue<double>();

            foreach (var dataPoint in data)
            {
                queue.Enqueue(dataPoint.OriginalY);

                if (queue.Count > windowWidth)
                {
                    if (queue.Dequeue() >= maxValues.First.Value)
                    {
                        maxValues.RemoveFirst();
                    }
                }

                while (maxValues.Count != 0 && dataPoint.OriginalY > maxValues.Last.Value)
                {
                    maxValues.RemoveLast();
                }

                maxValues.AddLast(dataPoint.OriginalY);
                yield return dataPoint.WithMaxY(maxValues.First.Value);
            }
        }
    }
}