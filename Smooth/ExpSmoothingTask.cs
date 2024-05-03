using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            double pastPoint = 0;
            bool checkElement = true;

            foreach (var dataPoint in data)
            {
                if (checkElement)
                {
                    pastPoint = dataPoint.OriginalY;
                    checkElement = false;
                }
                else
                {
                    pastPoint = alpha * dataPoint.OriginalY + (1 - alpha) * pastPoint;
                }

                yield return dataPoint.WithExpSmoothedY(pastPoint);
            }
        }
    }
}