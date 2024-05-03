using System.Collections.Generic;

namespace yield
{ 
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	    {
            if (windowWidth <= 0)
                throw new System.ArgumentOutOfRangeException();

            var queue = new Queue<double>();
            double Point = 0;
            double result = 0;
            foreach (var dataPoint in data)
            {
                Point += dataPoint.OriginalY;
                result = queue.Count < windowWidth ? Point / (queue.Count + 1) : 
                    result + (dataPoint.OriginalY - queue.Dequeue()) / windowWidth;

                var newDataPoint = dataPoint.WithAvgSmoothedY(result);
                yield return newDataPoint;
                queue.Enqueue(dataPoint.OriginalY);
            }
        }
    }
}



